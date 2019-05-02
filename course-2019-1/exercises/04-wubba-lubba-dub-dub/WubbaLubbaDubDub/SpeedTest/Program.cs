using System;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace SpeedTest
{
    
    public class SpeedTester
    {
        private readonly string[] _testStringArray = Enumerable.Repeat("I like whales.", 10).ToArray();
        
        [Benchmark]
        public string JoinTest()
        {
            return string.Join("", _testStringArray);
        }


        [Benchmark]
        public string StringBuilderTest() {
            var result = new StringBuilder();
            
            foreach (var s in _testStringArray)
            {
                result.Append(s + " ");
            }
            return result.ToString();
        }

        [Benchmark]
        public string ConcatTest()
        {
            return _testStringArray.Aggregate("", (current, s) => current + s + " ");
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
