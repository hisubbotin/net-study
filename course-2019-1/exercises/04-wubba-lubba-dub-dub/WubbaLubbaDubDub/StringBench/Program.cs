using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace StringBench
{
    [InProcessAttribute] // использовано из-за антивирусов
    [RPlotExporter, RankColumn]
     public class StringJoinTest
    {
        public List<string> data;


        [Params(4, 1000, 10000, 1000000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            data = new List<string>();
            for(int i = 0; i < N; ++i)
            {
                data.Add("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789");
            }
        }


        [Benchmark]
        public string Join_tets() => String.Join("", data);

        [Benchmark]
        public string SB_test()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var row in data)
            {
                if (row.Length > 0)
                {
                    sb.Append(row);
                }
            }
            return sb.ToString();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<StringJoinTest>();
        }
    }
}
