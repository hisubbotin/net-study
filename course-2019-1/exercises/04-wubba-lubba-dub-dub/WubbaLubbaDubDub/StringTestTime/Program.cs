using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace StringTestTime
{
    [CoreJob]
    [RPlotExporter, RankColumn]
    [InProcessAttribute]
    public class StringSpeedTests
    {
        [Params(10, 100, 1000, 100000)]
        public int stringCount;

        [Params(1, 100)]
        public int stringLength;

        public string[] strings;


        [Benchmark(Description = "Join")]
        public string TestJoin() => string.Join("", strings);

        [Benchmark(Description = "String builder")]
        public string TestStringBuilder() => new System.Text.StringBuilder().AppendJoin("", strings).ToString();

        [Benchmark(Description = "Concat")]
        public string TestConcat() => string.Concat(strings);


        [GlobalSetup]
        public void Setup()
        {
            var str = new string('a', stringLength);
            strings = Enumerable.Repeat(str, stringCount).ToArray();
        }

    }


    class Program
    {
        

        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<StringSpeedTests>();
            Console.ReadLine();
        }
    }

}

