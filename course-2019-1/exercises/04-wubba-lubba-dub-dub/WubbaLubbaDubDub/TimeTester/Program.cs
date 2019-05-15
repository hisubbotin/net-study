using System;
using System.Text;
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


        [GlobalSetup]
        public void Setup()
        {
            System.Random random = new Random(42);

            string GenerateRandomString()
            {
                int stringSize = random.Next(10);
                var stringBuilder = new StringBuilder();

                for (int i = 0; i < stringSize; ++i)
                {
                    stringBuilder.Append(random.Next(255));
                }

                return stringBuilder.ToString();
            }

            text = new string[N];

            for (int i = 0; i < N; ++i)
            {
                text[i] = GenerateRandomString();
            }
        }

        [Benchmark]
        public string TestJoin() => string.Join("", text);

        [Benchmark]
        public string TestStringBuilder() => new StringBuilder().AppendJoin("", text).ToString();

        [Benchmark]
        public string TestConcat() => string.Concat(text);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SpeedComparator>();
            Console.ReadLine();
        }
    }
}