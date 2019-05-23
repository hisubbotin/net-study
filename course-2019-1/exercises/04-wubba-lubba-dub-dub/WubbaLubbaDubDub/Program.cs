using System;
using System.Text;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace TimeTester
{
    [InProcessAttribute]
    public class SpeedComparator
    {
        private string[] text;

        [Params(100, 500, 1000, 5000)]
        public int N;

        [Benchmark]
        public string StringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string item in strings)
            {
                sb.AppendLine(item);
            }
            return sb.ToString();
        }


        text = new string[N];

            for (int i = 0; i < N; ++i)
            {
                text[i] = GenerateRandomString();
            }
        }

        [Benchmark]
        public string Join() => string.Join("", text);

        [Benchmark]
        public string StringBuilder() => new StringBuilder().AppendJoin("", text).ToString();

        [Benchmark]
        public string Concat() => string.Concat(text);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BenchmarkRunner.Run<Benchmark>();
            Console.ReadLine();
        }
    }
}