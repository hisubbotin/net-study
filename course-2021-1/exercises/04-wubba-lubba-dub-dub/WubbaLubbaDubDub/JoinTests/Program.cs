using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Perfolizer.Horology;

namespace JoinTests
{
    public class FastConfig : ManualConfig
    {
        public FastConfig()
        {
            Add(DefaultConfig.Instance);
            AddJob(Job.Default.WithLaunchCount(1).WithIterationCount(5).WithWarmupCount(1));
        }
    }
    
    [Config(typeof(FastConfig))]
    // [SimpleJob(RunStrategy.Monitoring, targetCount: 10, invocationCount: 10)]
    public class StringBuilderVsJoinVsConcat
    {
        private readonly List<string> _data = new();
        private readonly StringBuilder _stringBuilder = new();
        private static readonly Random random = new Random();
        
        private static string RandomString(int length) 
        { 
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public StringBuilderVsJoinVsConcat()
        {
            var N = 1000000;
            for (var i = 0; i < N; ++i)
            {
                _data.Add("aaaa");
            }
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