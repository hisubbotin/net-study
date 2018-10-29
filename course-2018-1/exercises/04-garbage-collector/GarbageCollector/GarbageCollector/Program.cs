using System;
using System.Diagnostics;

namespace GarbageCollector
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int size = EstimateSizeForLOH<char>();
            Console.WriteLine("Limit for CHAR is: {0} elements or {1} bytes", size, size * sizeof(char));
            size = EstimateSizeForLOH<int>();
            Console.WriteLine("Limit for INT is: {0} elements or {1} bytes", size, size * sizeof(int));
            size = EstimateSizeForLOH<double>();
            Console.WriteLine("Limit for DOUBLE is: {0} elements or {1} bytes", size, size * sizeof(double));

            Console.WriteLine("Generation 0: {0}", EstimateTimeForGeneration(0).Elapsed);
            Console.WriteLine("Generation 1: {0}", EstimateTimeForGeneration(1).Elapsed);
            Console.WriteLine("Generation 2: {0}", EstimateTimeForGeneration(2).Elapsed);
        }

        private static int EstimateSizeForLOH<T>()
        {
            int generation = 0;
            int size = 80 * 1024/ DotNetCross.Memory.Unsafe.SizeOf<T>();
            while (generation != 2)
            {
                size++;
                var array = new T[size];
                generation = GC.GetGeneration(array);
            }
            return size;
        }

        private static Stopwatch EstimateTimeForGeneration(int numGeneration)
        {
            switch(numGeneration)
            {
                case 0:
                    for (var i = 0; i < 1000; ++i)
                    {
                        var tmp = new int[16];
                    }
                    break;
                case 1:
                    for (var i = 0; i < 1000; ++i)
                    {
                        var tmp = new int[10*1024/sizeof(int)];
                    }
                    break;
                case 2:
                    for (var i = 0; i < 1000; ++i)
                    {
                        var tmp = new int[90*1024/sizeof(int)];
                    }
                    break;
            }

            Stopwatch timer = new Stopwatch();

            timer.Start();
            GC.Collect(numGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            timer.Stop();
            return timer;
        }
    }
}