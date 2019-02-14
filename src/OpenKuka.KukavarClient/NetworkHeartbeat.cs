using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace OpenKuka.Kukavar
{
    // ICM Ping
    public class NetworkHeartbeat
    {
        public bool Running { get; private set; }
        public int PingTimeout { get; private set; }
        public int HeartbeatDelay { get; private set; }
        public IPAddress[] EndPoints { get; private set; }
        public int Count => EndPoints.Length;
        public PingReply[] PingResults { get; private set; }
        private Ping[] Pings { get; set; }

        public NetworkHeartbeat(IEnumerable<IPAddress> hosts, int pingTimeout, int heartbeatDelay)
        {
            PingTimeout = pingTimeout;
            HeartbeatDelay = heartbeatDelay;

            EndPoints = hosts.ToArray();
            PingResults = new PingReply[EndPoints.Length];
            Pings = EndPoints.Select(h => new Ping()).ToArray();
        }

        public async void Start()
        {
            if (!Running)
            {
                try
                {
                    Debug.WriteLine("Heartbeat : starting ...");

                    // set up the tasks
                    var chrono = new Stopwatch();
                    var tasks = new Task<PingReply>[Count];

                    Running = true;

                    while (Running)
                    {
                        // set up and run async ping tasks                 
                        OnPulseStarted(DateTime.Now, chrono.Elapsed);
                        chrono.Restart();
                        for (int i = 0; i < Count; i++)
                        {
                            tasks[i] = PingAndUpdateAsync(Pings[i], EndPoints[i], i);
                        }
                        await Task.WhenAll(tasks);
                                        
                        for (int i = 0; i < tasks.Length; i++)
                        {
                            var pingResult = tasks[i].Result;

                            if (pingResult != null)
                            {
                                if (PingResults[i] == null)
                                {
                                    if (pingResult.Status == IPStatus.Success)
                                        OnPingUp(i);
                                }
                                else if (pingResult.Status != PingResults[i].Status)
                                {
                                    if (pingResult.Status == IPStatus.Success)
                                        OnPingUp(i);
                                    else if (PingResults[i].Status == IPStatus.Success)
                                        OnPingDown(i);
                                }
                            }
                            else
                            {
                                if (PingResults[i] != null && PingResults[i].Status == IPStatus.Success)
                                    OnPingUp(i);
                            }

                            PingResults[i] = tasks[i].Result;
                            Debug.WriteLine("> Ping [" + PingResults[i].Status.ToString().ToUpper() + "] at " + EndPoints[i] + " in " + PingResults[i].RoundtripTime + " ms");
                        }

                        OnPulseEnded(DateTime.Now, chrono.Elapsed);

                        // heartbeat delay
                        var delay = Math.Max(0, HeartbeatDelay - (int)chrono.ElapsedMilliseconds);
                        await Task.Delay(delay);
                    }
                    Debug.Write("Heartbeat : stopped");
                }
                catch (Exception)
                {
                    Debug.Write("Heartbeat : stopped after error");
                    Running = false;
                    throw;
                }
            }
            else
            {
                Debug.WriteLine("Heartbeat : already started ...");
            }
        }

        public void Stop()
        {
            Debug.WriteLine("Heartbeat : stopping ...");
            Running = false;
        }

        private async Task<PingReply> PingAndUpdateAsync(Ping ping, IPAddress epIP, int epIndex)
        {
            try
            {
                return await ping.SendPingAsync(epIP, PingTimeout);
            }
            catch (Exception ex)
            {
                Debug.Write("-[" + epIP + "] : error in SendPing()");
                OnPingError(epIndex, ex);
                return null;
            }
        }

        // Event on ping errors
        public event EventHandler<PingErrorEventArgs> PingError;
        public class PingErrorEventArgs : EventArgs
        {
            public int EndPointIndex { get; private set; }
            public Exception InnerException { get; private set; }

            public PingErrorEventArgs(int epIndex, Exception ex)
            {
                EndPointIndex = epIndex;
                InnerException = ex;
            }
        }
        private void OnPingError(int epIndex, Exception ex) => PingError?.Invoke(this, new PingErrorEventArgs(epIndex, ex));

        // Event on ping Down
        public event EventHandler<int> PingDown;
        private void OnPingDown(int epIndex)
        {
            Debug.WriteLine("# Ping [DOWN] at " + EndPoints[epIndex]);
            PingDown?.Invoke(this, epIndex);
        }

        // Event on ping Up
        public event EventHandler<int> PingUp;
        private void OnPingUp(int epIndex)
        {
            Debug.WriteLine("# Ping [UP] at " + EndPoints[epIndex] );
            PingUp?.Invoke(this, epIndex);
        }

        // Event on pulse started
        public event EventHandler<PulseEventArgs> PulseStarted;
        public class PulseEventArgs : EventArgs
        {
            public DateTime TimeStamp { get; private set; }
            public TimeSpan Delay { get; private set; }

            public PulseEventArgs(DateTime date, TimeSpan delay)
            {
                TimeStamp = date;
                Delay = delay;
            }
        }
        private void OnPulseStarted(DateTime date, TimeSpan delay)
        {
            Debug.WriteLine("# Heartbeat [PULSE START] after " + (int)delay.TotalMilliseconds + " ms");
            PulseStarted?.Invoke(this, new PulseEventArgs(date, delay));
        }

        // Event on pulse ended
        public event EventHandler<PulseEventArgs> PulseEnded;
        private void OnPulseEnded(DateTime date, TimeSpan delay)
        {
            PulseEnded?.Invoke(this, new PulseEventArgs(date, delay));
            Debug.WriteLine("# Heartbeat [PULSE END] after " + (int)delay.TotalMilliseconds + " ms");
        }
    }
}
