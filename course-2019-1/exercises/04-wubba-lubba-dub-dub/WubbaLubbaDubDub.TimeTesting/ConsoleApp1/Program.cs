using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace ConsoleApp1
{

    //[ClrJob(baseline: true), CoreJob, MonoJob, CoreRtJob]
    //[RPlotExporter, RankColumn]
    
    public class StringJoiner
    {

        private string[] text;

        [Params(10, 100, 1000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            text = new string[N];
            
            var random = new Random(42);

            for (var i = 0; i < N; i++)
            {
                text[i] = NewRandomString();
            }

            string NewRandomString()
            {
                var size = random.Next(15);
                var stringBuilder = new StringBuilder();

                for (var i = 0; i < size; i++)
                {
                    stringBuilder.Append(random.Next(255));
                }

                return stringBuilder.ToString();
            }
            
        }

        [Benchmark]
        public string JoinFunction() => string.Join("", text);
        
        [Benchmark]
        public string ConcatFunction() => string.Concat(text);

        [Benchmark]
        public string StringBuilderFunction()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendJoin("", text);

            return stringBuilder.ToString();
        }
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<StringJoiner>();
            Console.WriteLine(summary.AllRuntimes);
        }
    }
}