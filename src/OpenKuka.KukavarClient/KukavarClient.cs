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
    public delegate Task KVReplyCallback(KVReply reply);
    public struct KVReply
    {
        private long msElapsed_start;
        
        public int Id => Query.Id;
        public RWMode Mode => Query.Mode;
        public bool Successful => ((KVAnswer)Answer).Successful;
        public IKVMessage Query { get; private set; }
        public KVAnswer Answer { get; internal set; }
        public DateTime SendTime { get; internal set; }
        public TimeSpan RoundTripTime { get; private set; }
        internal KVReplyCallback Callback { get; set; }

        public KVReply(IKVMessage query, Stopwatch chrono, KVReplyCallback callback = null)
        {
            Query = query;
            Answer = KVAnswer.Pong;
            msElapsed_start = chrono.ElapsedMilliseconds;
            SendTime = DateTime.Now;
            RoundTripTime = TimeSpan.Zero;
            Callback = callback;
        }
        internal void SetAnswer(KVAnswer answer, Stopwatch chrono)
        {
            RoundTripTime = TimeSpan.FromMilliseconds((double)(chrono.ElapsedMilliseconds - msElapsed_start));
            Answer = answer;
        }
    }

    public class KukavarClient : AsyncTcpClient
    {
        private object lockObject = new object();
        private Stopwatch chrono = new Stopwatch();
        private ConcurrentDictionary<int, KVReply> ReplyQueue;
        
        public int MsgId { get; private set; } = 0; // the client should be repsonsible to assign message ids.
        private new Logger Logger { get; set; }
  
        public KukavarClient(int guid, Logger logger = null) : base(guid, 2, 2, 2048, logger)
        {
            chrono.Start(); // use this timer to get accurate measurement of roundtrip times
            Logger = logger ?? NLog.LogManager.CreateNullLogger();

            PingMsg = KVReadQuery.Ping.Message;
            PongMsg = KVAnswer.Pong.Message;

            ReplyQueue = new ConcurrentDictionary<int, KVReply>();

            BytesEnqueuedCallback = async (client, count) => {
                await DequeueAll(this.ByteBuffer.Content);
            };
        }
        public async Task<int> SendAsync(IKVMessage query, KVReplyCallback callback = null)
        {
            lock (lockObject)
            {
                query.Id = ++MsgId;
                SendAsync(query.Message, 0, query.MessageLength).Wait();
                var reply = new KVReply(query, chrono, callback);
                ReplyQueue[reply.Id] = reply;
                Logger.Log(LogLevel.Debug, ">> query enqueue : id={0}, len={1}, mode={2}", query.Id, query.MessageLength, query.Mode);
                return query.Id;
            }
        }
        public void ClearQueue()
        {
            // dequeue until no more items are in the queue.
            ReplyQueue.Clear();
        }

        private async Task<int> DequeueAll(IEnumerable<byte> buffer)
        {
            return await Dequeue(buffer, 0).ConfigureAwait(false);
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
        private Task OnKVAnswerReceived(KVAnswer answer)
        {
            KVReply reply;
            
            if (ReplyQueue.TryRemove(answer.Id, out reply))
            {
                reply.SetAnswer(answer, chrono);
                Logger.Log(LogLevel.Debug, "<< query dequeue : id={0}, len={1}, mode={2}, tm={3}", answer.Id, answer.MessageLength, answer.Mode, reply.RoundTripTime.TotalMilliseconds);

                if (reply.Callback != null)
                    return reply.Callback.Invoke(reply);
            }
            else
            {
                Logger.Log(LogLevel.Warn, "the answer was not paired with a query"); 
            }

            return Task.CompletedTask;
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
            client.Run();
        }
    }
}
