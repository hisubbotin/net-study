using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.Serialization;

namespace GarbageLimits
{
    class Program
    {
        static void Main(string[] args)
        {
            GC.Collect(2, GCCollectionMode.Forced);

            GCSettings.LatencyMode = GCLatencyMode.Batch;
            GarbageUtils.GenerateSmallGarbage(5000);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            GC.Collect(0, GCCollectionMode.Forced);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Generation " + i.ToString() + " collected " + GC.CollectionCount(i).ToString());
            }

            {
                List<object> objects = GarbageUtils.GenerateFinalizedGarbage(5000);
                GC.Collect(0, GCCollectionMode.Forced);
            }
            watch = System.Diagnostics.Stopwatch.StartNew();
            GC.Collect(1, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            GC.Collect(1, GCCollectionMode.Forced);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Generation " + i.ToString() + " collected " + GC.CollectionCount(i).ToString());
            }


            {
                List<object> objects = GarbageUtils.GenerateSmallGarbage(5000);
                GC.Collect(0, GCCollectionMode.Forced);
                GC.Collect(1, GCCollectionMode.Forced);
            }
            watch = System.Diagnostics.Stopwatch.StartNew();
            GC.Collect(2, GCCollectionMode.Forced);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);


            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Generation " + i.ToString() + " collected " + GC.CollectionCount(i).ToString());
            }

        }
    }
}
