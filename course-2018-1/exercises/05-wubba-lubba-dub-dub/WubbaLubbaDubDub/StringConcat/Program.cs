using System;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace StringConcat
{
    public class StringConcat
    {
        private const int strlen = 10;
        private const int arrlen = 10;
        private readonly string[] data;

        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static Random random = new Random();
        private StringBuilder sb = new StringBuilder();

        public StringConcat()
        {
            data = new string[arrlen];
            for (int i = 0; i < arrlen; i++)
            {
                data[i] = new string(Enumerable.Repeat(chars, strlen).Select(s => s[random.Next(s.Length)]).ToArray());
            }
        }


        [Benchmark]
        public string StrBuilder()
        {
            for (int i = 0; i < arrlen; i++)
            {
                sb.Append(data[i]);
            }
            return sb.ToString();
        }

        [Benchmark]
        public string Concat() => String.Concat(data);

        [Benchmark]
        public string Join() => String.Join("", data);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<StringConcat>();
            var _ = Console.ReadLine();

        }
    }
}
