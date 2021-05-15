using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace JoinTests
{
    public class StringBuilderVsJoinVsConcat
    {
        private readonly List<string> _data = new List<string>();
        private readonly StringBuilder _stringBuilder = new StringBuilder();
        // private static readonly Random random = new Random();
        //
        // private static string RandomString(int length) 
        // { 
        //     const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //     return new string(Enumerable.Repeat(chars, length)
        //         .Select(s => s[random.Next(s.Length)]).ToArray());
        // }
             
        public StringBuilderVsJoinVsConcat()
        {
            _data = new List<string>() {"aa", "aa", "aa", "aa"};
        }
        
        [Benchmark] 
        public string StringBuilderJoin() 
        { 
            foreach (var s in _data) 
            { 
                _stringBuilder.Append(s);
            } 
            return _stringBuilder.ToString();
        }
        
        [Benchmark] 
        public string Join()
        { 
            return string.Join("", _data);
        }
        
        [Benchmark]
        public string Concat()
        {
            return string.Concat(_data);
        }
    }
     
    public static class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<StringBuilderVsJoinVsConcat>();
        }
    }
}