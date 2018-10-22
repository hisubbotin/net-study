using System;
using System.Diagnostics;

namespace GC_Experiments
{
    class Program
    {
        private static void Generations()
        {
            var stopwatch = new Stopwatch();
            
            var exp_arr = new double[10000];
            
            stopwatch.Start();
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            stopwatch.Stop();
            Console.WriteLine("Generation 0: " + stopwatch.Elapsed);

            stopwatch.Restart();
            GC.Collect(1, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            stopwatch.Stop();
            Console.WriteLine("Generation 1: " + stopwatch.Elapsed);
            
            stopwatch.Restart();
            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            stopwatch.Stop();
            Console.WriteLine("Generation 2: " + stopwatch.Elapsed);
        }
        
        static void Main(string[] args)
        {
//            Generations();
           
            var str = "";
            while (GC.GetGeneration(str) != 2)
            {
                str += "a";
            }
            Console.WriteLine("Strings: " + str.Length);

            var intArrMaxSize = 0;
            var intArr = new int[intArrMaxSize];
            while (GC.GetGeneration(intArr) != 2)
            {
                intArr = new int[++intArrMaxSize];
            }
            Console.WriteLine("Int arrays: " + intArrMaxSize);
            
            var doubleArrMaxSize = 0;
            var doubleArr = new double[doubleArrMaxSize];
            while (GC.GetGeneration(doubleArr) != 2)
            {
                doubleArr = new double[++doubleArrMaxSize];
            }
            Console.WriteLine("Double arrays: " + doubleArrMaxSize);
        }
    }
}