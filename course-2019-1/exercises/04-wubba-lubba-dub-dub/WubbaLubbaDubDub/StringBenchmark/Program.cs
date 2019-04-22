using System;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace StringBenchmark
{
    [CoreJob]
    [RPlotExporter, RankColumn]
    public class StringBenchmark
    {

        [Params(10, 100, 1000)] 
        public int NumberOfStrings;

        [Params(10, 100, 1000)] 
        public int StringLength;

        public string[] StringArray;

        [GlobalSetup]
        public void Setup()
        {
            var baseString = new string(' ', StringLength);
            StringArray = Enumerable.Repeat(baseString, NumberOfStrings).ToArray();
        }

        [Benchmark]
        public string StringJoin()
        {
            return string.Join("", StringArray);
        }

        [Benchmark]
        public string StringBuilder()
        {
            var builder = new StringBuilder();
            foreach (var s in StringArray)
            {
                builder.Append(s);
            }
            return builder.ToString();
        }

        [Benchmark]
        public string StringConcat()
        {
            var result = "";
            foreach (var s in StringArray)
            {
                result += s;
            }
            return result;
        }

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<StringBenchmark>();
        }
    }
}