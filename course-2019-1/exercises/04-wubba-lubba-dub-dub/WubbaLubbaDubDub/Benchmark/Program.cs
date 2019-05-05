using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmark
{
    [CoreJob]
    [RPlotExporter, RankColumn]
    public class Benchmark
    {
        private string[] data;

        [Params(20, 1000)]
        public int N;

        [Params(10, 100)] 
        public int WordLength;

        [GlobalSetup]
        public void Setup()
        {
            Random rand = new Random();
            data = new string[N];
            for (int i = 0; i < N; ++i)
            {
                data[i] = new String('a', rand.Next(1, WordLength));
            }
        }

        [Benchmark]
        public string StringJoin() => String.Join("", data);

        [Benchmark]
        public string StringBuilder() {
            StringBuilder builder = new StringBuilder();
            foreach (string str in data)
            {
                builder.Append(str);
            }

            return builder.ToString();
        }

        [Benchmark]
        public string Concat()
        {
            var res = "";
            foreach (string str in data)
            {
                res += str;
            }

            return res;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmark>();
        }
    }
}