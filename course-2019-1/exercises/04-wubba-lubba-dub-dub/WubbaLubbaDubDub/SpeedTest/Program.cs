using System;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace SpeedTest
{
    
    public class SpeedTester
    {
        public readonly string[] test_string_array = Enumerable.Repeat("I like whales.", 10).ToArray();
        
        [Benchmark]
        public string JoinTest()
        {
            return string.Join(" ", test_string_array);
        }


        [Benchmark]
        public string StringBuilderTest() {
            var result = new StringBuilder();
            
            foreach (var s in test_string_array)
            {
                result.Append(s + " ");
            }
            return result.ToString();
        }

        [Benchmark]
        public string ConcatTest()
        {
            string result = "";
            
            foreach (var s in test_string_array)
            {
                result += s + " ";
            }
            return result;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SpeedTester>();
        }
    }
}