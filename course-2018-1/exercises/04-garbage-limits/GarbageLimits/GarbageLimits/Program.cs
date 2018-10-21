using System;

namespace GarbageLimits
{
    class Program
    {
        static void Main(string[] args)
        {

            GarbageUtils.GenerateSmallGarbage(5000);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            GC.Collect(0, GCCollectionMode.Forced);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);


            GarbageUtils.GenerateFinalizedGarbage(5000);
            watch.Reset();
            GC.Collect(1, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            GC.Collect(1, GCCollectionMode.Forced);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);

            GarbageUtils.GenerateLargeGarbage(5);
            watch.Reset();
            GC.Collect(2, GCCollectionMode.Forced);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);

        }
    }
}
