using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace GarbageCollector1
{
    class Program
    {
        static void LargeObjectHeap()
        {

            UInt64 size = 1;
            var ints64 = new UInt64[size];
            while (GC.GetGeneration(ints64) < 2)
            {
                size += 1;
                ints64 = new UInt64[size];
            }
            Console.WriteLine("UInt64 : {0}", size * sizeof(UInt64));

            size = 1;
            var ints32 = new UInt32[size];
            while (GC.GetGeneration(ints32) < 2)
            {
                size += 1;
                ints32 = new UInt32[size];
            }
            Console.WriteLine("UInt32 : {0}", size * sizeof(UInt32));

            size = 1;
            var ints16 = new UInt16[size];
            while (GC.GetGeneration(ints16) < 2)
            {
                size += 1;
                ints16 = new UInt16[size];
            }
            Console.WriteLine("UInt16 : {0}", size * sizeof(UInt16));
        }

        static void CleanUpGen(int gen)
        {
            Stopwatch timer = new Stopwatch();

            GC.TryStartNoGCRegion(10000 * 1024 * sizeof(int) * 2);

            ArrayList lst = new ArrayList();
            for (int i = 0; i < 10000; ++i)
            {
                lst.Add(new int[1024]);
            }

            int temp = gen - 1;

            timer.Start();

            GC.EndNoGCRegion();

            while (temp >= 0) {
                GC.Collect(temp, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
                temp--;
            }
            GC.Collect(gen, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            timer.Stop();

            Console.WriteLine("Generation {0}: {1}", gen, timer.Elapsed);
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            LargeObjectHeap();

            CleanUpGen(0);
            CleanUpGen(1);
            CleanUpGen(2);

            Console.ReadLine();
        }
    }
}