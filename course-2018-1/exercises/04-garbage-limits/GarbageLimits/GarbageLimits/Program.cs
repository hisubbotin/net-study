using System;

namespace GarbageLimits
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                GarbageUtils.GenerateGarbage();

                var watch = System.Diagnostics.Stopwatch.StartNew();
                GC.Collect(i, GCCollectionMode.Forced);
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine(elapsedMs);
            }
            Console.ReadKey();
        }
    }
}
