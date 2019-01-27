using System;
using System.Collections.Generic;
using System.Threading;

namespace gc_ex_counters
{
    class Program
    {

        static List<byte[]> load = new List<byte[]>();
        static void Main(string[] args)
        {
            Console.WriteLine("Application is running with server GC=" + System.Runtime.GCSettings.IsServerGC);
            Console.WriteLine(System.Runtime.GCSettings.LatencyMode);

            Thread tr = new Thread(new ThreadStart(() => { load.Clear(); Thread.Sleep(500); }));
            tr.Start();
          

            int lastCollCount = 0;
            int newCollCount = 0;


            while (true)
            {
                load.Add(new byte[100000]);
                newCollCount = GC.CollectionCount(2);
                if (newCollCount != lastCollCount)
                {
                    Console.WriteLine("Gen 2 collection count: {0}, {1}", newCollCount.ToString(), DateTime.UtcNow.Millisecond);
                    lastCollCount = newCollCount;
                }

                Thread.Sleep(500);
            }
        }
    }
}
