using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
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
                // UnionRule = ConfigUnionRule.AlwaysUseLocal;
            }
        }

        private readonly string _data = new string('a', 10000);

        [Benchmark(Description = "String.Join()")]
        public string TestJoin()
        { 
            return string.Join("", _data.ToCharArray());
        }

        [Benchmark(Description = "TestBuilder")]
        public string TestBuilder()
        {
            var testStringBuilder = new StringBuilder("");

            foreach (var sym in _data.ToCharArray())
            {
                testStringBuilder.Append(sym);
            }

            return testStringBuilder.ToString();
        }

        [Benchmark(Description = "Concat")]
        public string TestConcat()
        {
            return string.Concat(_data.ToCharArray());
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