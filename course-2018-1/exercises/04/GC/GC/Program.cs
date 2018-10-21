using System;
using System.Diagnostics;

namespace GC
{
    class Program
    {
        private static void FindSizeForStrings()
        {
            var str = "";
            while (System.GC.GetGeneration(str) < 2)
            {
                str += " ";
            }
            Console.WriteLine("For strings: {0}", str.Length);
        }

        private static void FindSizeForInts()
        {
            var arrayOfInts = new int[0];
            for (var i = 0; System.GC.GetGeneration(arrayOfInts) < 2; ++i)
            {
                arrayOfInts = new int[i];
            }
            Console.WriteLine("For array of int-s: {0}", arrayOfInts.Length);
        }

        private static void FindSizeForDoubles()
        {
            var arrayOfDoubles = new double[0];
            for (var i = 0; System.GC.GetGeneration(arrayOfDoubles) < 2; ++i)
            {
                arrayOfDoubles = new double[i];
            }
            Console.WriteLine("For array of double-s: {0}", arrayOfDoubles.Length);

        }

        private static void TimeOfGarbageCollection(int generation)
        {
            if (generation > 2 || generation < 0)
            {
                return;
            }

            var garbageArray = new int[100];
            var sw = new Stopwatch();
            sw.Start();
            System.GC.Collect(generation, GCCollectionMode.Forced);
            System.GC.WaitForPendingFinalizers();
            System.GC.WaitForFullGCComplete();
            sw.Stop();
            System.GC.Collect();
            Console.WriteLine("{0} Generated: {1}", generation, sw.Elapsed.TotalMilliseconds);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Size from which objects are placed by clr in LOH:");
            FindSizeForStrings();
            FindSizeForInts();
            FindSizeForDoubles();
            
            Console.WriteLine("Time of collect garbage:");
            TimeOfGarbageCollection(0);
            TimeOfGarbageCollection(1);
            TimeOfGarbageCollection(2);

        }
    }
}