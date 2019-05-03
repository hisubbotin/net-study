using System;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ConsoleApp1
{
    public class Benchmark
    {
        private string[] strings = {
            "Live in virtue, no desire",
            "In the grave an angel's choir", 
            "You look to heaven and wonder wh",
            "No one can see them in the sky",
            "Just as the clouds have gone to sleep",
            "Angels can be seen in heavens keep"
        };

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

        [Benchmark]
        public string Join() => string.Join("", strings);

        [Benchmark]
        public string Concat() => string.Concat("", strings);
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

/*
|        Method |      Mean |      Error |     StdDev |    Median |
|-------------- |----------:|-----------:|-----------:|----------:|
| StringBuilder | 684.59 ns | 13.7632 ns | 29.0312 ns | 677.33 ns |
|          Join | 241.40 ns |  4.9096 ns | 12.8476 ns | 237.35 ns |
|        Concat |  25.36 ns |  0.6874 ns |  0.7916 ns |  25.08 ns |
*/
