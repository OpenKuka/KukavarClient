using Kukavar;
using OpenKuka.KukavarClient.Protocol;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenKuka.KukavarClient.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new KukavarClient(1, KukavarLogManager.GetLogger(1))
            //var client = new KukavarClient(1, null)
            {
                ServerIP = IPAddress.Parse("192.168.10.4"),
                ServerPort = 7000,
                MaxIdleTime = TimeSpan.FromMilliseconds(2000)
            };

            client.ConnectAsync().Wait();
            client.Run();
            Task.Run(() => {
                Task.Delay(1000);
                var chrono = Stopwatch.StartNew();
                for (int i = 0; i < 50; i++)
                {
                    client.SendAsync(KVReadQuery.Build(0, "$OV_PRO"));
                }
                chrono.Stop();
                Debug.WriteLine("chrono = " + chrono.ElapsedMilliseconds);


            });

            //client.Connecting += ConnectingHandler;
            //client.Connected += Connected;
            //client.ConnectionError += ConnectionErrorHandler;
            //client.Closing += ClosingErrorHandler;
            //client.Closed += ClosedErrorHandler;

            Console.ReadKey();
        }
    }
}
