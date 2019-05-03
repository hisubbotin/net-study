using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace TimeMeasuring
{

    public class StringConcatenation
    {
        private const int N = 10000;
        private readonly string[] strings;

        public StringConcatenation()
        {
            string pattern = "Repeat it!";
            strings = new String[] {pattern, pattern, pattern};
        }

        [Benchmark]
        public void Join() {
            string res = string.Join("", strings);
        }

        [Benchmark]
        public void StringBuilder() {
            StringBuilder sb = new StringBuilder();
            foreach(string s in strings)  sb.Append(s);
            string res = sb.ToString();
        }

        [Benchmark]
        public void Concatenation() {
            string res = String.Empty;
            foreach(string s in strings) res += s;
        }
    }    
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<StringConcatenation>();
        }
    }
}
