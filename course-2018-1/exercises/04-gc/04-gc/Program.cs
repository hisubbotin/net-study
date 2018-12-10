using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GarbageCollector1
{
    class Program
    {
        static void LOH()
        {
            UInt64 selectedSize = 1;
            var ints = new UInt64[selectedSize];
            while (GC.GetGeneration(ints) < 2) {
                selectedSize += 1; // Никуда не спешим
                ints = new UInt64[selectedSize];
            }
            Console.WriteLine("UInt64 moved to LOH at {0}", selectedSize * sizeof(UInt64));
            selectedSize = 1;
            var ints16 = new UInt16[selectedSize];
            while (GC.GetGeneration(ints16) < 2)
            {
                selectedSize += 1; 
                ints16 = new UInt16[selectedSize];
            }
            Console.WriteLine("UInt16 moved to LOH at {0}", selectedSize * sizeof(UInt16));

        }


        static void CleanUpGen0()
        {
            Stopwatch timer = new Stopwatch();

            GC.TryStartNoGCRegion(10000 * 1024 * 4 * 2);

            
            for (int i = 0; i < 10000; i++) {
                var _ = new int[1024];
            }

            timer.Start();

            GC.EndNoGCRegion();
            
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            timer.Stop();

            GC.Collect();

            // throws: Garbage collection was induced in NoGCRegion
            //

            Console.WriteLine("Generation 0: {0}", timer.Elapsed);
        }
        static void CleanUpGen1()
        {
            Stopwatch timer = new Stopwatch();


            GC.TryStartNoGCRegion(10000 * 1024 * 4 * 2);

            int[][] arr = new int[10000][];
            for (int i = 0; i < 10000; i++)
            {
                arr[i] = new int[1024];
            }

            
            
            timer.Start();
            GC.EndNoGCRegion();
            GC.Collect(0, GCCollectionMode.Forced);
            Console.WriteLine("Starting with gen {0} and {1}", GC.GetGeneration(arr), GC.GetGeneration(arr[0]));
            arr = new int[1][];


            GC.Collect(1, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            timer.Stop();

            GC.Collect();

            // throws: Garbage collection was induced in NoGCRegion
            //

            Console.WriteLine("Generation 0+1: {0}", timer.Elapsed);
        }


        static void CleanUpGen2()
        {
            Stopwatch timer = new Stopwatch();


            GC.TryStartNoGCRegion(10000 * 1024 * 4 * 2);

            int[][] arr = new int[10000][];
            for (int i = 0; i < 10000; i++)
            {
                arr[i] = new int[1024];
            }



            timer.Start();
            GC.EndNoGCRegion();
            GC.Collect(0, GCCollectionMode.Forced);
            GC.Collect(0, GCCollectionMode.Forced);
            Console.WriteLine("Starting with gen {0} and {1}", GC.GetGeneration(arr), GC.GetGeneration(arr[0]));
            arr = new int[1][];


            GC.Collect(1, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            timer.Stop();

            GC.Collect();

            // throws: Garbage collection was induced in NoGCRegion
            //

            Console.WriteLine("Generation 0+0+2: {0}", timer.Elapsed);
        }


        static void Main(string[] args)
        {
            LOH();


            CleanUpGen0();
            CleanUpGen1();
            CleanUpGen2();

            Console.ReadLine();

        }
    }
}