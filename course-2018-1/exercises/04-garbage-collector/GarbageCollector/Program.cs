using System;
using System.Diagnostics;

namespace GarbageCollector
{
    class Program
    {
        private static void Main(string[] args)
        {
            Limits();
            Console.WriteLine("\n");
            Generations();
        }

        /// <summary>
        /// Поиск момента, начиная с которого объекты размещаются в LOH
        /// Идея: число где-то рядом с `85000 / sizeof(...)`
        /// </summary>
        private static void Limits()
        {
            var charLimit = new char[42488];
            Console.WriteLine("Generation: {0}", GC.GetGeneration(charLimit));
            
            var intLimit = new int[21244];
            Console.WriteLine("Generation: {0}", GC.GetGeneration(intLimit));
            
            var doubleLimit = new double[10622];
            Console.WriteLine("Generation: {0}", GC.GetGeneration(doubleLimit));
        }
        
        /// <summary>
        /// Измерение времени сборки мусора в поколениях
        /// </summary>
        private static void Generations()
        {
            var sw = new Stopwatch();
            
            for (var i = 0; i < 1000; ++i)
            {
                _ = new int[100500];
            }
            
            if (GC.CollectionCount(0) <= 0) return;
            sw.Start();
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            sw.Stop();
            Console.WriteLine("Generation: 0\tElapsed: {0}", sw.Elapsed);
            
            if (GC.CollectionCount(1) <= 0) return;
            sw.Restart();
            GC.Collect(1, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            sw.Stop();
            Console.WriteLine("Generation: 1\tElapsed: {0}", sw.Elapsed);
            
            if (GC.CollectionCount(2) <= 0) return;
            sw.Restart();
            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            sw.Stop();
            Console.WriteLine("Generation: 2\tElapsed: {0}", sw.Elapsed);
        }
    }
}
