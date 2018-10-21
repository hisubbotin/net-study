using System;
using System.Diagnostics;

namespace GarbageCollector
{
    public class Dog
    {
        public string name = "Scooty";
    }

    internal class Program
    {
        private static void Main()
        {
            string s = "";
            while(GC.GetGeneration(s) < 2)
            {
                s += "a";
            }
            Console.WriteLine("The smallest length for ASCII string to be added to LOH: {0}", s.Length);

            string s1 = "";
            while (GC.GetGeneration(s1) < 2)
            {
                s1 += "ñ";
            }
            Console.WriteLine("The smallest length for Unicode string to be added to LOH: {0}", s1.Length);

            int[] arr_int = new int[0];
            int i = 1;
            while (GC.GetGeneration(arr_int) < 2)
            {
                arr_int = new int[i];
                i++;
            }
            Console.WriteLine("The smallest length for integer array to be added to LOH: {0}", arr_int.Length);

            double[] arr_double = new double[0];
            int j = 1;
            while (GC.GetGeneration(arr_double) < 2)
            {
                arr_double = new double[j];
                j++;
            }
            Console.WriteLine("The smallest length for double array to be added to LOH: {0}", arr_double.Length);
            
            Stopwatch sw = new Stopwatch();
            var dogs = new Dog[5];
            var dogs1 = new Dog[5];
            for (int k = 0; k < 5; k++) {
                var dog = new Dog();
            }
            sw.Start();
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            GC.WaitForFullGCComplete();
            sw.Stop();
            GC.Collect();
            Console.WriteLine("Time to collect Generation 0: {0}", sw.Elapsed);

            Console.WriteLine(GC.GetGeneration(dogs));
            dogs = new Dog[5];
            sw.Restart();
            GC.Collect(1, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            GC.WaitForFullGCComplete();
            sw.Stop();
            GC.Collect();
            Console.WriteLine("Time to collect Generation 1: {0}", sw.Elapsed);

            Console.WriteLine(GC.GetGeneration(dogs1));
            dogs1 = new Dog[5];
            sw.Restart();
            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            GC.WaitForFullGCComplete();
            sw.Stop();
            GC.Collect();
            Console.WriteLine("Time to collect Generation 2: {0}", sw.Elapsed);
        }
    }
}
