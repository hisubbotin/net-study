using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GarbageCollector1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Примерно 85000 байт
            // 85000 / 8 байт = 10625 
            // А на самом делe: 10622 * 8 = 84 976
            var myDoubleList = new Double[10622];
            Console.WriteLine("myDoubleList generation: {0}", GC.GetGeneration(myDoubleList));
            
            // Примерно 85000 байт
            // 85000 / 8 байт = 21260 
            // А на самом делe: 21244 * 4 = 84 976
            var myIntList = new int[21244];
            Console.WriteLine("myIntList generation: {0}", GC.GetGeneration(myIntList));
            
            Stopwatch timer = new Stopwatch();
            var ints = new int[5];
                        
            for (var i = 0; i < 5; ++i) {
                var _ = new int[5];
            }

            timer.Start();
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            timer.Stop();
            GC.Collect();
            Console.WriteLine("Generation 0: {0}", timer.Elapsed);
            Console.WriteLine(GC.GetGeneration(ints));
            
            timer.Restart();
            GC.Collect(1, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            timer.Stop();
            GC.Collect();
            Console.WriteLine("Generation 1: {0}", timer.Elapsed);
            
            timer.Restart();
            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            timer.Stop();
            GC.Collect();
            Console.WriteLine("Generation 2: {0}", timer.Elapsed);
            
        }
    }
}