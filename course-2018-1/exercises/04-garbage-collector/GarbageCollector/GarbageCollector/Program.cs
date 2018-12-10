using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;

namespace GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "";
            while (GC.GetGeneration(str) != 2)
            {
                str += 'a';
            }
            Console.WriteLine($"Length of string to be sent in LOH is {str.Length}");
            var arr = new int[0];
            while (GC.GetGeneration(arr) != 2)
            {
                arr = new int[arr.Length + 1];
            }
            Console.WriteLine($"Length of int array to be sent in LOH is {arr.Length}");
            var arrDoubles = new double[0];
            while (GC.GetGeneration(arrDoubles) != 2)
            {
                arrDoubles = new double[arrDoubles.Length + 1];
            }
            Console.WriteLine($"Length of double array to be sent in LOH is {arrDoubles.Length}");


            for (var i = 10000; i < arrDoubles.Length * 10; ++i)
            {
                _ = new double[i];
                _ = new int[i];
            }
            var timer = new Stopwatch();
            timer.Restart();
            GC.Collect(0, GCCollectionMode.Forced);
            timer.Stop();
            var zeroGen = timer.Elapsed;

            Console.WriteLine($"Collected 0 generation in {zeroGen.TotalMilliseconds} ms");

            timer.Restart();
            GC.Collect(1, GCCollectionMode.Forced);
            timer.Stop();
            var firstGen = timer.Elapsed;

            Console.WriteLine($"Collected 1 generation in {firstGen.TotalMilliseconds} ms");

            timer.Restart();
            GC.Collect(2, GCCollectionMode.Forced);
            timer.Stop();
            var secondGen = timer.Elapsed;

            Console.WriteLine($"Collected 2 generation in {secondGen.TotalMilliseconds} ms");
            //Length of string to be sent in LOH is 42484
            //Length of int array to be sent in LOH is 21244
            //Length of double array to be sent in LOH is 10622
            //Collected 0 generation in 1,9549 ms
            //Collected 1 generation in 0,1242 ms
            //Collected 2 generation in 0,7503 ms

            Console.ReadLine();
        }
    }
}
