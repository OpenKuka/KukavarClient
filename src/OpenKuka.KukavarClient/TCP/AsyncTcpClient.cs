using NLog;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace OpenKuka.KukavarClient.TCP
{
    public enum ClientStatus
    {
        Connecting,
        Reconnecting,
        Connected,
        Disconnected,
        Closing,
        Closed,
    }
    public enum ConnectionErrorCode
    {
        Successful,
        Timeout,
        HostUnreachable,
        Rejected,
        SocketError,
        IOError,
        UnkownError,
    }
    public class ConnectionErrorEventArgs : EventArgs
    {
        public ConnectionErrorCode ErrorCode { get; private set; }
        public ConnectionErrorEventArgs(ConnectionErrorCode errorcode)
        {
            ErrorCode = errorcode;
        }
    }
    public class ClosingEventArgs : EventArgs
    {
        public bool BrokenConnection { get; private set; }
        public ClosingEventArgs(bool brokenConnection)
        {
            BrokenConnection = brokenConnection;
        }
    }
    public class BytesReceivedEventArgs : EventArgs
    {
        public int Count { get; private set; }
        public BytesReceivedEventArgs(int count)
        {
            Count = count;
        }
    }
    public class BytesSentEventArgs : EventArgs
    {
        public int Count { get; private set; }
        public BytesSentEventArgs(int count)
        {
            Count = count;
        }
    }
    public abstract class AsyncTcpClient
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private ByteQueue ByteSendQueue;

        #region Properties
        public bool AutoReconnect { get; set; }             = true;
        public TimeSpan ConnectionTimeout { get; set; }     = TimeSpan.FromSeconds(2);          // timeout pour le client.connect()
        public TimeSpan ReconnectionTimeout { get; set; }   = TimeSpan.FromSeconds(15);         // durée maximum pour la tentative de reconnexion
        public TimeSpan ReconnectionDelay { get; set; }     = TimeSpan.FromSeconds(2);          // delay between 2 reconnection attempts
        public int ConnectionCount { get; private set; }    = 0;                                // number of times the client was (re)connected 
        public int ReconnectionAttemptsCount { get; private set; }  = 0;
        public TimeSpan MaxIdleTime { get; set; }           = TimeSpan.FromSeconds(1);          // maximum idle time of the connection. If no bytes are received within this periode of time the keep-alive is started

        public TimeSpan ReadTimeout { get; set; }           = TimeSpan.FromMilliseconds(200);   // timeout pour le stream.wread()
        public TimeSpan WriteTimeout { get; set; }          = TimeSpan.FromMilliseconds(200);   // timeout pour le stream.write()
        public TimeSpan PingTimeout { get; set; }           = TimeSpan.FromMilliseconds(100);   // timeout pour la requete ping-pong
        public byte[]   PingMsg { get; set; }
        public byte[]   PongMsg { get; set; }

        public IPAddress ServerIP { get; set; }     = IPAddress.Parse("192.168.10.4");
        public int ServerPort { get; set; }         = 7000;
        public ClientStatus Status { get; private set; }    = ClientStatus.Disconnected;

        public int Id { get; private set; }
        public Logger Logger { get; private set; }
        

        public ByteQueue ByteBuffer { get; private set; }

        #endregion

        #region Events

        public event AsyncEventHandler<EventArgs> Connecting;
        private Task OnConnecting()
        {
            if (Connecting != null)
                return Connecting.InvokeAllAsync(this, EventArgs.Empty);
            else
                return Task.CompletedTask;
        }

        public event AsyncEventHandler<EventArgs> Connected;
        private Task OnConnected()
        {
            if (Connected != null)
                return Connected.InvokeAllAsync(this, EventArgs.Empty);
            else
                return Task.CompletedTask;
        }

        public event AsyncEventHandler<ConnectionErrorEventArgs> ConnectionError;
        private Task OnConnectionError(ConnectionErrorCode errorcode)
        {
            if (ConnectionError != null)
                return ConnectionError.InvokeAllAsync(this, new ConnectionErrorEventArgs(errorcode));
            else
                return Task.CompletedTask;
        }

        public event AsyncEventHandler<ClosingEventArgs> Closing;  
        private Task OnClosing(bool brokenConnection)
        {
            if (Closing != null)
                return Closing.InvokeAllAsync(this, new ClosingEventArgs(brokenConnection));
            else
                return Task.CompletedTask;
        }

        public event AsyncEventHandler<EventArgs> Closed;
        private Task OnClosed()
        {
            if (Closed != null)
                return Closed.InvokeAllAsync(this, EventArgs.Empty);
            else
                return Task.CompletedTask;
        }

        public event AsyncEventHandler<BytesReceivedEventArgs> BytesReceived;
        private Task OnBytesReceived(int count)
        {
            if (count > 0)
            {
                if (BytesReceived != null)
                    return BytesReceived.InvokeAllAsync(this, new BytesReceivedEventArgs(count));
            }
            
            return Task.CompletedTask; // return a fake completed task to continue on awaiting
        }

        public event AsyncEventHandler<BytesSentEventArgs> BytesSent;
        private Task OnBytesSent(int count)
        {
            if (count > 0)
            {
                if (BytesSent != null)
                    return BytesSent.InvokeAllAsync(this, new BytesSentEventArgs(count));
            }

            return Task.CompletedTask; // return a fake completed task to continue on awaiting
        }

        public Func<AsyncTcpClient, int, Task> BytesEnqueuedCallback;

        #endregion Events

        public AsyncTcpClient(int guid, int initialBufferCapacity, int minBufferCapacity, int maxBufferCapacity, Logger logger = null)
        {
            Logger = logger ?? NLog.LogManager.CreateNullLogger();

            Id = guid;
            ByteBuffer = new ByteQueue("RQueue ", initialBufferCapacity, minBufferCapacity, maxBufferCapacity, Logger);
            ByteSendQueue = new ByteQueue("WQueue ", 1024, 1024, 8192, Logger);
        }
     
        public void Run()
        {
            var t1 = Task.Run(() => ReceivingAsync());
            var t2 = Task.Run(() => SendingAsync());
        }
        private async Task ReceivingAsync()
        {
            byte[] rbuffer = new byte[1024];
            int readCount = 0;
            var timer = Stopwatch.StartNew();
            var delay = TimeSpan.FromMilliseconds(0.5);

            while (!_cts.Token.IsCancellationRequested)
            {
                await Task.Delay(delay);
                // poll a bunch of bytes
                readCount = await ReadAsync(rbuffer, 0, rbuffer.Length);
                if (readCount > 0)
                {
                    timer.Stop();
                    await OnBytesReceived(readCount);
                    ByteBuffer.Enqueue(rbuffer, 0, readCount);
                    await BytesEnqueuedCallback(this, readCount);
                }
                else
                {
                    // no more data available
                    // either the stream is down or no data are available.

                    if (!timer.IsRunning)
                    {
                        timer.Restart();
                    }
                    else if (timer.Elapsed > MaxIdleTime)
                    {
                        // we now suspect a potential deconnection.
                        // we try a ping-pong with the host to see if it is still connected
                        Logger.Log(LogLevel.Trace, "No bytes were received within the last {0}ms. Operating the keep-alive...", (int)timer.Elapsed.TotalMilliseconds);
                        var alive = await Ping(0);
                        timer.Stop();
                        if (!alive)
                        {
                            Status = ClientStatus.Disconnected;
                            await ReconnectAsync();
                        }
                    }
                }
            }
        }
        private async Task SendingAsync()
        {
            byte[] wbuffer = new byte[256];
            var delay = TimeSpan.FromMilliseconds(0.5);
            while (!_cts.Token.IsCancellationRequested)
            {
                await Task.Delay(delay);
                // push a bunch of bytes
                if (ByteSendQueue.Count > 0)
                {
                    var count = ByteSendQueue.Dequeue(ByteSendQueue.Count, ref wbuffer);
                    await WriteAsync(wbuffer, 0, count);
                }
            }
        }
        public async void Close()
        {
            await Close(false);
        }

        #region Connect/Disconnect
        public async Task<bool> ConnectAsync()
        {
            Dispose();

            tcpClient = new TcpClient()
            {
                ReceiveTimeout = (int)ReadTimeout.TotalMilliseconds,
                SendTimeout = (int)WriteTimeout.TotalMilliseconds,
            };


            if (ConnectionCount == 0)
            {
                // first connection
                Status = ClientStatus.Connecting;
                Logger.Log(LogLevel.Info, "Connecting for the first time to host {0}:{1} ...", ServerIP, ServerPort);
            }
            else
            {
                // reconnecting
                Status = ClientStatus.Reconnecting;
                Logger.Log(LogLevel.Debug, "Reconnecting attempt {0} ...", ReconnectionAttemptsCount);
            }

            await OnConnecting();
            using (var cts = new CancellationTokenSource(ReconnectionTimeout))
            {
                var token = cts.Token;
                var task = tcpClient.ConnectAsync(ServerIP, ServerPort);
                var timeoutTask = await Task.WhenAny(task, Task.Delay(-1, token));


                Exception exception = null;
                var errorcode = ConnectionErrorCode.UnkownError;
                var succeed = false;

                try
                {
                    await timeoutTask; // wait on the returned task to observe any exceptions.
                    succeed = true;
                }
                catch (TaskCanceledException ex)
                {
                    exception = ex;
                    errorcode = ConnectionErrorCode.Timeout;
                }
                catch (SocketException ex) when (ex.SocketErrorCode == SocketError.TimedOut)
                {
                    exception = ex;
                    errorcode = ConnectionErrorCode.Timeout;
                }
                catch (SocketException ex)
                {
                    exception = ex;
                    errorcode = ConnectionErrorCode.SocketError;
                }
                catch (IOException ex)
                {
                    exception = ex;
                    errorcode = ConnectionErrorCode.IOError;
                }
                catch (Exception ex)
                {
                    errorcode = ConnectionErrorCode.UnkownError;
                    Logger.Log(LogLevel.Error, ex, "Connection failed ({0})", errorcode);
                    throw;
                }
                finally
                {
                    if (succeed)
                    {
                        Status = ClientStatus.Connected;
                        _cts = new CancellationTokenSource();
                        stream = tcpClient.GetStream();
                        ConnectionCount += 1;

                        var local = (IPEndPoint)tcpClient.Client.LocalEndPoint;
                        var remote = (IPEndPoint)tcpClient.Client.RemoteEndPoint;

                        if (ConnectionCount == 1)
                            Logger.Log(LogLevel.Info, "Connected for the first time to {0}:{1} from {2}:{3}", remote.Address, remote.Port, local.Address, local.Port);

                        await OnConnected();
                    }
                    else
                    {
                        Status = ClientStatus.Disconnected;
                        if (exception != null)
                        {
                            if (ConnectionCount == 0)
                                Logger.Log(LogLevel.Error, exception, "Connection failed ({0})", errorcode);
                            else
                                Logger.Log(LogLevel.Debug, exception, "Reconnection failed ({0})", errorcode);
                        }
                        await OnConnectionError(errorcode);
                    }
                }

                return succeed;
            }
        }
        private async Task<bool> ReconnectAsync()
        {
            if (AutoReconnect == false)
            {
                // close and dispose the socket
                await Close(brokenConnection: true);
                return false;
            }
            else
            {
                Status = ClientStatus.Reconnecting;
                Logger.Log(LogLevel.Warn, "Reconnecting for the {2} time to host {0}:{1} ...", ServerIP, ServerPort, ConnectionCount);
                Logger.Log(LogLevel.Warn, "The client will attempt to reconnect to host every {0}s for {1}", ReconnectionDelay.TotalSeconds, ReconnectionTimeout.ToString(@"hh\:mm\:ss"));

                var timer = new Stopwatch();
                ReconnectionAttemptsCount = 0;

                try
                {
                    timer.Start();
                    using (var cts = new CancellationTokenSource(ReconnectionTimeout))
                    {
                        var token = cts.Token;
                        var success = await Task.Run(async () =>
                        {
                            var chrono = new Stopwatch();
                            while (!token.IsCancellationRequested)
                            {
                                chrono.Restart();
                                ReconnectionAttemptsCount += 1;
                                if (await ConnectAsync())
                                    return true;
                                int t = Math.Max(0, (int)(ReconnectionDelay.TotalMilliseconds - chrono.ElapsedMilliseconds));
                                await Task.Delay(t);
                            }
                            return false;
                        }, token);
                        timer.Stop();

                        if (success)
                        {
                            var local = (IPEndPoint)tcpClient.Client.LocalEndPoint;
                            var remote = (IPEndPoint)tcpClient.Client.RemoteEndPoint;
                            Logger.Log(LogLevel.Info, "Reconnected to {0}:{1} from {2}:{3} after {4} attempts during {5}", remote.Address, remote.Port, local.Address, local.Port, ReconnectionAttemptsCount, timer.Elapsed.ToString(@"hh\:mm\:ss"));
                            Logger.Log(LogLevel.Info, "It's been {0} times the client has been successfuly reconnected to the host", ConnectionCount - 1);
                            return true;
                        }
                        else
                        {
                            await Close(brokenConnection: true);
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log(LogLevel.Error, ex, "Reconnection failed for un unkown problem.");
                    throw;
                }
            }    
        }


        private async Task<bool> Ping(int id)
        {
            using (var cts = new CancellationTokenSource(PingTimeout))
            {
                return await Ping(id, cts.Token);
            }
        }
        private async Task<bool> Ping(int id, CancellationToken token)
        {
            var readLength = 0;
            var chrono = new Stopwatch();
            chrono.Start();

            var buffer = new byte[PongMsg.Length]; // size of a ping answer

            var task = Task.Run(async () =>
            {
                Logger.Log(LogLevel.Trace, "? keep-alive : pinging host...");
                await stream.WriteAsync(PingMsg, 0, PingMsg.Length, token);
                readLength = await WaitAsync(buffer, 0, buffer.Length, token);
                return readLength;
            }, token);

            try
            {
                var timeoutTask = await Task.WhenAny(task, Task.Delay(-1, token));
                await timeoutTask; // wait on the returned task to observe any exceptions.
                readLength = task.Result;
            }
            catch (TaskCanceledException ex)
            {
                readLength = 0;
            }

            chrono.Stop();
            if (buffer.SequenceEqual(PongMsg))
            {
                Logger.Log(LogLevel.Trace, "+ keep-alive : ping received after {}ms", chrono.ElapsedMilliseconds);
                return true;
            }
            else
            {
                Logger.Log(LogLevel.Trace, "- Keep-alive : ping lost after {}ms", chrono.ElapsedMilliseconds);
                return false;
            }
        }
        private async Task Close(bool brokenConnection)
        {
            Status = ClientStatus.Closing;
            Logger.Log(LogLevel.Info, "Closing...");
            await OnClosing(brokenConnection);

            _cts?.Cancel();
            Dispose();
            ConnectionCount = 0;
            ReconnectionAttemptsCount = 0;

            Status = ClientStatus.Closed;
            Logger.Log(LogLevel.Fatal, "Closed");
            OnClosed().Wait();
        }
        private void Dispose()
        {
            tcpClient?.Dispose();
            stream = null;
        }
        #endregion

        #region Read
        protected async Task<int> ReadAsync(byte[] buffer, int offset, int count)
        {
            using (var cts = new CancellationTokenSource(ReadTimeout))
            {
                return await ReadAsync(buffer, offset, count, cts.Token);
            }
        }
        private async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken token)
        {
            if (stream.DataAvailable)
            {
                try
                {
                    var task = stream.ReadAsync(buffer, offset, count, token);
                    var timeoutTask = await Task.WhenAny(task, Task.Delay(-1, token));
                    await timeoutTask; // wait on the returned task to observe any exceptions.
                    //await OnBytesReceived(task.Result);
                    Logger.Log(LogLevel.Trace, "[RStream] <<{0,3} bytes received : {1}", task.Result, ByteArrayToString(buffer, offset, task.Result));
                    //await BytesReceivedCallback(this, task.Result);
                    return task.Result;
                }
                catch (Exception ex)
                {
                    return 0; ;
                }
            }
            else
            {
                return 0;
            }    
        }
        protected async Task<int> WaitAsync(byte[] buffer, int offset, int count)
        {
            using (var cts = new CancellationTokenSource(ReadTimeout))
            {
                return await WaitAsync(buffer, offset, count, cts.Token);
            }            
        }
        private async Task<int> WaitAsync(byte[] buffer, int offset, int count, CancellationToken token)
        {
            try
            {
                var task = Task.Run(async () =>
                {
                    // try to fill the buffer until count is reached or task is cancelled
                    int readLength = 0;
                    while (!token.IsCancellationRequested && count > 0)
                    {
                        try
                        {
                            if (stream.DataAvailable)
                            {
                                readLength += await stream.ReadAsync(buffer, offset, count, token);
                                offset += readLength;
                                count -= readLength;
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Log(LogLevel.Trace, ex, "Read : error while reading the stream");
                            break;
                        }
                    }
                    return readLength;
                }, token);

                var timeoutTask = await Task.WhenAny(task, Task.Delay(-1, token));
                await timeoutTask; // wait on the returned task to observe any exceptions.
                return task.Result;
            }
            catch (TaskCanceledException ex)
            {
                Logger.Log(LogLevel.Trace, ex, "Read : timeout with no bytes received");
                return 0;
            }
        }
        #endregion

        #region Send
        protected async Task WriteAsync(byte[] bytes, int offset, int count)
        {
            
            using (var cts = new CancellationTokenSource(WriteTimeout))
            {
                await WriteAsync(bytes, offset, count, cts.Token);
            }
        }
        private async Task WriteAsync(byte[] bytes, int offset, int count, CancellationToken token)
        {
            if (bytes.Length == 0)
                return;

            try
            {
                var task = stream.WriteAsync(bytes, offset, count, token);
                var timeoutTask = await Task.WhenAny(task, Task.Delay(-1, token));
                await timeoutTask; // wait on the returned task to observe any exceptions.
                Logger.Log(LogLevel.Debug, "[WStream] >>{0,3} bytes sent : {1}", count, ByteArrayToString(bytes, offset, count));
                await OnBytesSent(count);
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, "[WStream] writing {0} bytes failed", count, ex);
                return;
            }
        }
        
        public async Task SendAsync(byte[] bytes, int offset, int count)
        {
            // push to sending queue (does not actually send).
            while (true)
            {
                if (Status == ClientStatus.Connected)
                {
                    ByteSendQueue.Enqueue(bytes, offset, count);
                    return;
                }
                await Task.Delay(2);
            }
        }
        #endregion

        private static string ByteArrayToString(byte[] buffer, int start, int count)
        {
            return BitConverter.ToString(buffer, start, count).Replace("-", " ");
        }

        #region Test
        public async Task SendBytes(byte[] bytes, int maxCount, int delay)
        {
            int count = 0;
            while (maxCount < 0 || count < maxCount)
            {
                count += 1;
                try
                {
                    await WriteAsync(bytes, 0, bytes.Length);
                }
                catch (Exception)
                {
                    throw;
                }

                await Task.Delay(delay);
            }
        }
        #endregion
    }



}
