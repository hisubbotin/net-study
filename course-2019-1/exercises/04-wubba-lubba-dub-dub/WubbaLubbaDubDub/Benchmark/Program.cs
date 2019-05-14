using System;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Programm
{
    public class StringsOperations
    {
        static string[] strings_sample = Enumerable.Repeat("QQQQ AAAA BBBB CCCC dd", 10000).ToArray();

        [Benchmark]
        public string StringsJoin()
        {
            return string.Join("", strings_sample);
        }

        [Benchmark]
        public string StringsBuilder()
        {
            StringBuilder new_string = new StringBuilder();
            foreach (string str in strings_sample)
            {
                new_string.Append(str);
            }
            return new_string.ToString();
        }

        [Benchmark]
        public string StringsConcatination()
        {
            return string.Concat(strings_sample);
        }

        static void Main()
        {
            BenchmarkRunner.Run<StringsOperations>();
            Console.WriteLine("End benchmarks");
            var s = Console.ReadLine();
        }
    }
}