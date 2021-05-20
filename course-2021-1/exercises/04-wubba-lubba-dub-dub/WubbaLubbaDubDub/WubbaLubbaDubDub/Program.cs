using System;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters.Json;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;



namespace WubbaLubbaDubDub
{
    [Config(typeof(BenchmarkConfig))]
    public class MyBenchmark
    {
        
        private class BenchmarkConfig : ManualConfig
        {
            public BenchmarkConfig()
            {
                AddColumn(StatisticColumn.Mean);
                AddColumn(StatisticColumn.Median);
                AddColumn(StatisticColumn.StdDev);
                AddColumn(StatisticColumn.Max);
                AddLogger(ConsoleLogger.Default);
                AddExporter(CsvExporter.Default);
                UnionRule = ConfigUnionRule.AlwaysUseLocal;
            }
        }

        private readonly string data = new String('a', 1000);

        [Benchmark(Description = "String.Join()")]
        public string TestJoin()
        { 
            return String.Join("", data.ToCharArray());
        }

        [Benchmark(Description = "TestBuilder")]
        public string TestBuilder()
        {
            StringBuilder testStringBuilder = new StringBuilder("");
            
            foreach (var sym in data.ToCharArray())
            {
                testStringBuilder.Append(sym);
            }

            return testStringBuilder.ToString();
        }
        
        [Benchmark(Description = "Concat")]
        public string TestConcat()
        {
            return String.Concat(data.ToCharArray());
        }
    }

    public class Program
    {
        private static void Main()
        {
           var result = BenchmarkRunner.Run<MyBenchmark>();
        }
    }
}




