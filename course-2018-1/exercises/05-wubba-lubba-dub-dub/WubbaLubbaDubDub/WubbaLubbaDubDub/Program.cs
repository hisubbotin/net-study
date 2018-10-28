using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Characteristics;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using MyBenchmarks;

namespace MyBenchmarks
{
    public class ConcatCompare
    {
        private char[] data;

        public int N = 10000000;

        public void Setup()
        {
            data = new char[N];
            for (int i = 0; i < N; i++)
            {
                data[i] = 'a';
            }
        }

        public string Join() => string.Join("", data);

        public string Concatenate() => string.Concat(data);

        public string Build()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb = sb.Append(data[i]);
            }

            return sb.ToString();
        }
    }
}

namespace WubbaLubbaDubDub
{
    class Program
    {
        public static void Main(string[] args)
        {

            var compare = new ConcatCompare();
            compare.Setup();
            var watch = Stopwatch.StartNew();
            compare.Join();
            watch.Stop();
            System.Console.WriteLine(watch.ElapsedMilliseconds);

            watch = Stopwatch.StartNew();
            compare.Concatenate();
            watch.Stop();
            System.Console.WriteLine(watch.ElapsedMilliseconds);

            watch = Stopwatch.StartNew();
            compare.Build();
            watch.Stop();
            System.Console.WriteLine(watch.ElapsedMilliseconds);

        }
    }
}
