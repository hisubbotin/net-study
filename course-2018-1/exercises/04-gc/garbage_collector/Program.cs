using System;
using System.Diagnostics;

namespace garbage_collector
{
    class Program
    {
        static void Main(string[] args)
        {

            // Нагугленно что после 85000 байт отправляется в LOH

            // Примерно 85000 байт
            // 85000 / 8 байт = 21260 
            // А на самом делe: 21244 * 4 = 84 976
            var shortIntList = new int[20244];
            Console.WriteLine("shortIntList generation: {0}", GC.GetGeneration(shortIntList));

            var longIntList = new int[22244];
            Console.WriteLine("longIntList generation: {0}", GC.GetGeneration(longIntList));

            Stopwatch timer = new Stopwatch();
            var ints = new int[5];

            for (var i = 0; i < 5; ++i)
            {
                var _ = new int[5];
            }

            Console.WriteLine("Before collect 0:{0}", GC.GetGeneration(ints));
            timer.Start();
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            timer.Stop();
            GC.Collect();
            Console.WriteLine("Generation 0: {0}", timer.Elapsed);
            Console.WriteLine("After: {0}", GC.GetGeneration(ints));

            for (var i = 1; i < 3; ++i)
            {
                timer.Start();
                GC.Collect(i, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
                timer.Stop();
                GC.Collect();
                Console.WriteLine("Generation {0}: {1}", i, timer.Elapsed);
            }
        }
    }
}
