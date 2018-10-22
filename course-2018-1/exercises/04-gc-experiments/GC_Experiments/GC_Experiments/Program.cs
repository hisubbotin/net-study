using System;
using System.Diagnostics;

namespace GC_Experiments
{
    class Program
    {
        private static void MeasureTimeOnGeneration(int gen)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            GC.Collect(gen, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            
            stopwatch.Stop();
            Console.WriteLine("Generation " + gen + ": " + stopwatch.Elapsed);
        }
        
        private static void MeasureGcTime()
        {
            var stopwatch = new Stopwatch();
            
            var exp_arr = new double[10000];
            
            
            MeasureTimeOnGeneration(0);
            MeasureTimeOnGeneration(1);
            MeasureTimeOnGeneration(2);
        }

        private static void CheckArrLength<T>()
        {
            var arrMaxSize = 0;
            var arr = new T[arrMaxSize];
            while (GC.GetGeneration(arr) != 2)
            {
                arr = new T[++arrMaxSize];
            }
            Console.WriteLine(typeof(T).FullName + " arrays: " + arrMaxSize);
        }

        private static void CheckStrLength()
        {
            var str = "";
            while (GC.GetGeneration(str) != 2)
            {
                str += "a";
            }
            Console.WriteLine("Strings: " + str.Length);
        }
        
        private static void CheckLength()
        {
            CheckStrLength();
            CheckArrLength<int>();
            CheckArrLength<double>();
        }
            
            
        static void Main(string[] args)
        {         
//            MeasureGcTime();
            CheckLength();
        }
    }
}