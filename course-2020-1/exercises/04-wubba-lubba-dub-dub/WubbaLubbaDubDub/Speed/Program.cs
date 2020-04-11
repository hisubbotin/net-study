using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Text;

namespace MyBenchmarks
{
    public class SpeedComparator
    {
        /// <summary>
        /// Возвращает список из символов алфавита 
        /// </summary>
        private static List<string> GetAlphabet(bool upper)
        {
            List<string> alphabet = new List<string>();
            int charValue = upper ? 65 : 97;
            for (int ctr = 0; ctr <= 25; ctr++)
                alphabet.Add(Convert.ToChar(charValue + ctr).ToString());
            return alphabet;
        }
        // это будет наш тестовый ввод
        List<string> test_str_list = GetAlphabet(true);
        [Benchmark]
        public string TestJoin()
        {
            return string.Join(" ", test_str_list);
        }


        [Benchmark]
        public string TestStringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(test_str_list);
            return sb.ToString();
        }

        [Benchmark]
        public string TestConcat()
        {
            string result = string.Empty;
            foreach (string symbol in test_str_list)
            {
                result = String.Concat(result, symbol);
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SpeedComparator>();
        }
    }
}