using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _04_garbage_collector
{
    class Program
    {
        static void Main(string[] args)
        {
            /// https://habr.com/post/83929/ 
            var decimalvar = new double[85000 / sizeof(decimal)];
            Console.WriteLine("Gen: {0}", GC.GetGeneration(decimalvar));

            //Generations();
        }

    

        //private static void Generations()
        //{
        //    var sw = new Stopwatch();

        //    for (var i = 0; i < 1000; ++i)
        //    {
        //        _ = new int[100500];
        //    }

        //    if (GC.CollectionCount(0) <= 0) return;
        //    sw.Start();
        //    GC.Collect(0, GCCollectionMode.Forced);
        //    GC.WaitForPendingFinalizers();
        //    sw.Stop();
        //    Console.WriteLine("Generation: 0\tElapsed: {0}", sw.Elapsed);

        //    if (GC.CollectionCount(1) <= 0) return;
        //    sw.Restart();
        //    GC.Collect(1, GCCollectionMode.Forced);
        //    GC.WaitForPendingFinalizers();
        //    sw.Stop();
        //    Console.WriteLine("Generation: 1\tElapsed: {0}", sw.Elapsed);

        //    if (GC.CollectionCount(2) <= 0) return;
        //    sw.Restart();
        //    GC.Collect(2, GCCollectionMode.Forced);
        //    GC.WaitForPendingFinalizers();
        //    sw.Stop();
        //    Console.WriteLine("Generation: 2\tElapsed: {0}", sw.Elapsed);
        //}
    }
}
