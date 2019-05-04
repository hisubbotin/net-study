using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace WubbaLubbaDubDub
{
    public class BenchmarkTest
    {
        public BenchmarkTest()
        {
            text = new string[200];
            var rndGenerator = new Random(1337);
            for (int i = 0; i < 200; ++i)
            {
                for (int j = 0; j < 200; ++j)
                {
                    text[i] += (char) rndGenerator.Next();
                }
            }
        }

        [Benchmark]
        public string Join() => string.Join("", text);

        [Benchmark]
        public string StringBuilder()
        {
            var sb = new StringBuilder();
            foreach (string s in text)
            {
                sb.Append(s);
            }

            return sb.ToString();
        }

        [Benchmark]
        public string Concatenate()
        {
            return string.Concat(text);
        }

        [Benchmark]
        public string SimpleAdd()
        {
            string result = "";
            foreach (string s in text)
            {
                result += s;
            }

            return result;
        }

        private string[] text;
    }

    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkTest>();
        }
    }
}
