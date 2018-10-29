using System.Linq;
using System.Text;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;

namespace WubbaLubbaDubDub
{
    public class Benchmarks
    {
        private StringBuilder sb = new StringBuilder();
        private string[] strings = {
            "Somebody once told me the world is gonna roll me",
            "I ain't the sharpest tool in the shed",
            "She was looking kind of dumb with her finger and her thumb",
            "In the shape of an \"L\" on her forehead"
        };

        [Benchmark]
        public string SB() => strings.Aggregate(new StringBuilder(), (result, str) => result.Append(str)).ToString();

        [Benchmark]
        public string Join() => string.Join("", strings);
        
        [Benchmark]
        public string Concat() => string.Concat("", strings);
    }
    
    internal class Program
    {
        private static void Main()
        {
            BenchmarkRunner.Run<Benchmarks>();
            
            /*
             
                 Method |      Mean |     Error |    StdDev |
                ------- |----------:|----------:|----------:|
                     SB | 286.71 ns | 2.2572 ns | 2.1114 ns |
                   Join |  93.06 ns | 0.8077 ns | 0.7556 ns |
                 Concat |  23.03 ns | 0.2275 ns | 0.2128 ns |
             
             */
        }
    }
}