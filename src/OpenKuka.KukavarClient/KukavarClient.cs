using Kukavar;
using NLog;
using OpenKuka.KukavarClient.Protocol;
using OpenKuka.KukavarClient.TCP;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OpenKuka.KukavarClient
{
    /// <summary>
    /// A communication is the association of a request (from the client) and the corresponding answer (from the proxy).
    /// </summary>
    public struct KVCommunication
    {
        public int Id => Query.Id;
        public RWMode Mode => Query.Mode;
        public bool Successful => ((KVAnswer)Answer).Successful;

        public IKVMessage Query { get; private set; }
        public KVAnswer Answer { get; internal set; }
        
        public DateTime SendTime { get; internal set; }
        public TimeSpan RoundTripTime { get; private set; }

        private long msElapsed_start;

        public KVCommunication(IKVMessage query, Stopwatch chrono)
        {
            Query = query;
            Answer = KVAnswer.Pong;
            msElapsed_start = chrono.ElapsedMilliseconds;
            SendTime = DateTime.Now;
            RoundTripTime = TimeSpan.Zero;
        }

        public void SetAnswer(KVAnswer answer, Stopwatch chrono)
        {
            RoundTripTime = TimeSpan.FromMilliseconds((double)(chrono.ElapsedMilliseconds - msElapsed_start));
            Answer = answer;
        }
    }

    public class KukavarClient : AsyncTcpClient
    {

        private Stopwatch chrono = new Stopwatch();
        public ConcurrentQueue<KVCommunication> CommunicationQueue;
        

        public int MsgId { get; private set; } = 0; // the client should be reponsible to assign message ids.
        public new Logger Logger { get; private set; }

        public Func<KVCommunication, Task> KVAnswerReceivedCallback { get; set; }
        private Task OnKVAnswerReceived(KVAnswer answer)
        {
            KVCommunication com;
            if (CommunicationQueue.TryDequeue(out com))
            {
                com.SetAnswer(answer, chrono);
                if (com.Query.Id != com.Answer.Id)
                {
                    throw new Exception("Invalid Id");
                }
                else
                {
                    Logger.Log(LogLevel.Debug, "<< query dequeue : id={0}, len={1}, mode={2}, tm={3}", answer.Id, answer.MessageLength, answer.Mode, com.RoundTripTime.TotalMilliseconds);
                }
            }

            if (KVAnswerReceivedCallback != null)
                return KVAnswerReceivedCallback.Invoke(com);
            else
                return Task.CompletedTask;
        }

        public KukavarClient(int guid, Logger logger = null) : base(guid, 2, 2, 2048, logger)
        {
            chrono.Start(); // use this timer to get accurate measurement of roundtrip times
            Logger = logger ?? NLog.LogManager.CreateNullLogger();

            PingMsg = KVReadQuery.Ping.Message;
            PongMsg = KVAnswer.Pong.Message;

            CommunicationQueue = new ConcurrentQueue<KVCommunication>();

            
            BytesEnqueuedCallback = async (client, count) => {
                await DequeueAll(this.ByteBuffer.Content);
            };

            
        }

        #region Data EventHandlers
        private async Task BytesReceivedHandler(object sender, BytesReceivedEventArgs e)
        {
            Console.WriteLine("{0} bytes received", e.Count);
            await DequeueAll(ByteBuffer.Content);
        }

        #endregion

        #region Connection EventHandlers
        private async Task ConnectingHandler(object sender, EventArgs e)
        {
            var client = (KukavarClient)sender;
            if (client.Status == ClientStatus.Connecting)
            {
                Console.WriteLine("KV Connecting...");
            }
            else
            {
                if (client.ReconnectionAttemptsCount == 1)
                {
                    Console.WriteLine("KV Reconnecting...");
                }
            }    
        }
        private async Task ConnectedHandler(object sender, EventArgs e)
        {
            var client = (KukavarClient)sender;
            Console.WriteLine("KV Connected");
        }
        private async Task ConnectionErrorHandler(object sender, ConnectionErrorEventArgs e)
        {
            Console.WriteLine("Disconnected with error {0}", e.ErrorCode);
        }
        private async Task ClosingHandler(object sender, ClosingEventArgs e)
        {
            if (e.BrokenConnection)
            {
                Console.WriteLine("Closing (broken)...");
            }
            else
            {
                Console.WriteLine("Closing ...");
            }    
            
        }
        private async Task ClosedHandeler(object sender, EventArgs e)
        {
            Console.WriteLine("Closed");
        }
        #endregion

        public async Task<int> DequeueAll(IEnumerable<byte> buffer)
        {
            return await Dequeue(buffer,0).ConfigureAwait(false);
        }
        private async Task<int> Dequeue(IEnumerable<byte> buffer, int maxNumberOfMessageToDequeue)
        {
            KVAnswer answer;
            KVParsingStatus answerStatus;
            int dequeuedMessageCount = 0;
            int dequeuedBytesCount = 0;

            while (true)
            {
                try
                {
                    // we build as many answers as we can
                    answerStatus = KVAnswer.TryParse(buffer, ByteBuffer.Count, out answer);
                    if (answerStatus == KVParsingStatus.Valid || answerStatus == KVParsingStatus.Empty)
                    {
                        dequeuedMessageCount += 1;
                        dequeuedBytesCount += answer.MessageLength;
                        ByteBuffer.Dequeue(answer.MessageLength);

                        // throw the answer
                        await OnKVAnswerReceived(answer);

                        // test for max message to dequeue
                        if (maxNumberOfMessageToDequeue > 0 && dequeuedMessageCount >= maxNumberOfMessageToDequeue)
                        {
                            Debug.WriteLine("The maximum number of messages to dequeue has been reached");
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message);
                    throw;
                }
            }
            
            return dequeuedBytesCount;
        }

        public async Task<int> SendAsync(IKVMessage query)
        {
            query.Id = ++MsgId;
            await SendAsync(query.Message, 0, query.MessageLength);

            var com = new KVCommunication(query, chrono);
            CommunicationQueue.Enqueue(com);
            Logger.Log(LogLevel.Debug, ">> query enqueue : id={0}, len={1}, mode={2}", query.Id, query.MessageLength, query.Mode);
            return query.Id;
        }


        public new static void Test()
        {
            var client = new KukavarClient(1, KukavarLogManager.GetLogger(1));
            //client.Connected += (s, e) => { System.Windows.MessageBox.}
            client.ConnectAsync().Wait();
            
            var t2 = Task.Run(async () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    var query = KVReadQuery.Build(i+1, "$DATE");
                    await client.SendAsync(query);
                }
                await Task.Delay(0);
            });

            t2.Wait();
            var t1 = Task.Run(() => client.EnqueuingAsync());
        }
    }
}
