using System;

namespace GarbageCollector
{
    public class GCTest
    {
        public static void MakeSomeGarbage()
        {
            Console.WriteLine("Making garbage...");
            Version v;

            for(var i = 0; i < 10000; i++)
            {
                v = new Version();
            }
        }

        public static void TestInt()
        {
            Console.WriteLine("Start testing INT...");
            var buf = new int[1];
            int i = 0;
            while (GC.GetGeneration(buf) != 2)
            {
                buf = new int[++i];
            }
            Console.WriteLine("INT object moves into LOH when increasing to {0} byte.", i * sizeof(int));
        }
        
        public static void TestDouble()
        {
            Console.WriteLine("Start testing DOUBLE...");
            var buf = new double[1];
            int i = 0;
            while (GC.GetGeneration(buf) != 2)
            {
                buf = new double[++i];
            }
            Console.WriteLine("DOUBLE object moves into LOH when increasing to {0} byte.", i * sizeof(double));
        }
        
        public static void TestString()
        {
            Console.WriteLine("Start testing STRING...");
            var buf = "";
            int i = 0;
            while (GC.GetGeneration(buf) != 2)
            {
                buf += "$";
                ++i;
            }
            Console.WriteLine("STRING object moves into LOH when increasing to {0} byte.", i * sizeof(char));
        }

        public static void CountCollectingTime(int generation)
        {
            Console.WriteLine("Collecting generation {0}...", generation);
            var start = DateTime.Now;
            GC.Collect(generation);
            GC.WaitForPendingFinalizers();
            var end = DateTime.Now;
            Console.WriteLine("Generation {0} has been collected in {1} milliseconds.",
                generation, (end-start).Milliseconds);
        }
    }
    
    
}