using System;
using System.Text;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MyBenchmarks
{
    public class StringAdd
    {
        private const int N = 1000;
        private readonly string data;

        private readonly StringBuilder stringbuilder = new StringBuilder("");

        public StringAdd()
        {
            data = new string('*', N);
        }

        [Benchmark]
        public string Join() => string.Join("", data);

        [Benchmark]
        public string BuilderJoin() => stringbuilder.AppendJoin("", data).ToString();

        [Benchmark]
        public string Concatenate() => string.Concat(data);
    }

    public class Program
    {
        public static void Main()
        {
            var summary = BenchmarkRunner.Run<StringAdd>();
        }
    }
}
