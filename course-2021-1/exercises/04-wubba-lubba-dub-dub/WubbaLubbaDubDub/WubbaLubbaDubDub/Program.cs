using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using System.Text;

namespace MyBenchmarks
{
    public class JoinVsConcatVs
    {
        private const int N = 100;
        private readonly string[] data;

        public JoinVsConcatVs()
        {
            data = new string[N];
            int word_size = 20;
            char offset = 'a';
            const int lettersOffset = 26;
            for (var j = 0; j < N; j++)  
            {  
                var builder = new StringBuilder(word_size);
                for (var i = 0; i < word_size; i++)  
                {  
                    var @char = (char)(new Random(42)).Next(offset, offset + lettersOffset);  
                    builder.Append(@char);  
                }
                data[j] = builder.ToString();
            }
            
        }

        [Benchmark]
        public string MyJoin() => String.Join("", data);

        [Benchmark]
        public string MyConcat() => String.Concat(data);

        [Benchmark]
        public string MyStringBuilder() {
            StringBuilder sb = new StringBuilder();
            foreach (string s in data) {
                sb.Append(s);
            }
            return sb.ToString();
        }

        [Benchmark]
        public string MyConcatAsPlus() {
            string result = "";
            foreach (string s in data) {
                result += s;
            }
            return result;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<JoinVsConcatVs>();

        }
    }
}