using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace StringBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<RandomStringMaker>();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    public class RandomStringMaker
    {
        public RandomStringMaker()
        {
            strings = new string[N];
            var random = new Random();
            for (int i = 0; i < N; i++)
            {
                strings[i] = new String('s', random.Next(100));
            }
        }

        [Benchmark]
        public string Join()
        {
            return String.Join("", strings);
        }

        [Benchmark]
        public string Builder()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                sb.Append(strings[i]);
            }

            return sb.ToString();
        }

        [Benchmark]
        public string Concat()
        {
            string S = "";
            for (int i = 0; i < N; i++)
            {
                S += strings[i];
            }

            return S;
        }

        private const int N = 1000;
        private readonly string[] strings;
    }
}
