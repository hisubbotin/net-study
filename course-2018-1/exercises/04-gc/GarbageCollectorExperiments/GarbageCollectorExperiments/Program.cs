using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ex4_GC
{
    class Exp
    {
        private int[] a = { };


        public Exp()
        {
            a = new int[20000];
            for (int i = 0; i < 20000; i++)
            {
                a[i] = 42;
            }
        }

        ~Exp()
        {

        }
    }

    class Program
    {
        static void experiment(int gen)
        {
            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            Stopwatch SW = new Stopwatch();
            int n = 2;
            Exp[] a1 = new Exp[n];
            for (int i = 0; i < n; i++)
            {
                a1[i] = new Exp();
            }

            for (int i = 0; i < gen; i++)
            {
                GC.Collect(i, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            }
            Console.WriteLine("Generations of a1 is {0}", GC.GetGeneration(a1));
            a1 = new Exp[1];
            SW.Start();
            GC.Collect(gen, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            GC.Collect(gen, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            SW.Stop();
            Console.WriteLine("Time to collect this obj is {0}", SW.ElapsedTicks);
            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
        }

        static void findLimit()
        {
            string s = "1";
            while (GC.GetGeneration(s) < 2)
            {
                s += "1";
            }
            Console.WriteLine("LOH string: {0}", s.Length);

            int size = 1;
            int[] a = new int[size];
            while (GC.GetGeneration(a) < 2)
            {
                size++;
                a = new int[size];
            }
            Console.WriteLine("LOH int[]: {0}", size);

            size = 1;
            double[] b = new double[size];
            while (GC.GetGeneration(b) < 2)
            {
                size++;
                b = new double[size];
            }
            Console.WriteLine("LOH double[]: {0}", size);
        }

        static void Main(string[] args)
        {
            findLimit();
            for (int i = 0; i < 3; i++)
            {
                experiment(i);
            }
        }
    }
}