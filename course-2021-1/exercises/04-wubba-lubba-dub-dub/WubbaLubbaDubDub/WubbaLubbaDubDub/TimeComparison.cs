using System;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

namespace WubbaLubbaDubDub
{

    [Config(typeof(Config))]
    public class TimeComparison
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                Add(DefaultConfig.Instance);

                AddJob(Job.Default
                    .WithLaunchCount(1)
                    .WithWarmupCount(1));
            }
        }
        
        private StringBuilder sb;
        private string[] data;

        [Params(100, 1000, 1000000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            data = Enumerable.Repeat("x", N).ToArray();
            sb = new StringBuilder();
        }

        [Benchmark]
        public String Join() => String.Join("", data);

        [Benchmark]
        public String StringBuilder()
        {
            foreach (var s in data) 
            { 
                sb.Append(s);
            }
            return sb.ToString();
        }

        [Benchmark]
        public String Concat() => String.Concat(data);
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<TimeComparison>();
        }
    }
}