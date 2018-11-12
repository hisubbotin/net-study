using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOHBenchmark
{
    public class SizeTester
    {
        [Benchmark]
        public void ZeroGeneration()
        {
            {
                for (int i = 0; i < 100; ++i)
                {
                    int[] toBeCollected = new int[10000];
                }
            }
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
        }

        [Benchmark]
        public void FirstGeneration()
        {
            {
                ArrayList lst = new ArrayList();
                for (int i = 0; i < 100; ++i)
                {
                    lst.Add(new int[10000]);
                }
                GC.Collect(0, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            }

            GC.Collect(1, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
        }

        [Benchmark]
        public void SecondGeneration()
        {
            {
                ArrayList lst = new ArrayList();
                for (int i = 0; i < 100; ++i)
                {
                    lst.Add(new int[10000]);
                }
                GC.Collect(0, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
                GC.Collect(1, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            }

            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
        }


        [Benchmark]
        public void LOHGeneration()
        {
            {
                for (int i = 0; i < 47; ++i)
                {
                    int[] toBeCollected = new int[21247];
                    //84988 байт
                    //Console.WriteLine(GC.GetGeneration(toBeCollected));
                }
                GC.Collect(0, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
                GC.Collect(1, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            }

            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
        }

        [Benchmark]
        public void LOHGenerationNoCollect()
        {
            {
                for (int i = 0; i < 47; ++i)
                {
                    int[] toBeCollected = new int[21247];
                    //84988 байт
                    //Console.WriteLine(GC.GetGeneration(toBeCollected));
                }
            }

            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<SizeTester>();
            /*
            |                 Method |       Mean |    Error |    StdDev |     Median |
            |----------------------- |-----------:|---------:|----------:|-----------:|
            |         ZeroGeneration |   639.3 us | 10.63 us |  9.940 us |   639.4 us |
            |        FirstGeneration |   850.1 us | 17.41 us | 50.798 us |   829.5 us |
            |       SecondGeneration | 1,163.5 us | 22.51 us | 25.925 us | 1,167.5 us |
            |          LOHGeneration | 1,244.9 us | 27.09 us | 30.110 us | 1,232.9 us |
            | LOHGenerationNoCollect | 1,086.0 us | 34.14 us | 99.601 us | 1,064.8 us |


            int[21246] выделяется еще на основной куче
            |                 Method |       Mean |    Error |   StdDev |     Median |
            |----------------------- |-----------:|---------:|---------:|-----------:|
            |         ZeroGeneration |   689.6 us | 21.80 us | 63.24 us |   668.1 us |
            |        FirstGeneration |   798.3 us | 14.61 us | 13.66 us |   796.9 us |
            |       SecondGeneration | 1,136.0 us | 21.71 us | 22.30 us | 1,126.5 us |
            |          LOHGeneration |   845.7 us | 16.80 us | 19.35 us |   842.5 us |
            | LOHGenerationNoCollect |   603.2 us | 12.03 us | 14.32 us |   606.5 us |
            */

        }
    }
}
