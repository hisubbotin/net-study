using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace WubbaLubbaDubDub.Benchmarks
{
    public class BenchmarkTest {

        private string[] strings = {
            "Of be talent me answer do relied. ", "Mistress in on so laughing throwing endeavor occasion welcomed. ",
            "Gravity sir brandon calling can. ", "No years do widow house delay stand. ", 
            "Prospect six kindness use steepest new ask. ", "High gone kind calm call as ever is. ",
            "Introduced melancholy estimating motionless on up as do. ", 
            "Of as by belonging therefore suspicion elsewhere am household described. ",
            "Domestic suitable bachelor for landlord fat." 
        };

        [Benchmark]
        public string Join() => string.Join("", strings);

        [Benchmark]
        public string Concat() => string.Concat(strings);

        [Benchmark]
        public string Builder() => (new StringBuilder()).AppendJoin("", strings).ToString();

    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkTest>();
        }
    }
}

// benchmark result:

/*

|  Method |       Mean |     Error |   StdDev |     Median |
|-------- |-----------:|----------:|---------:|-----------:|
|    Join | 1,146.0 ns |  46.36 ns | 133.0 ns | 1,126.0 ns |
|  Concat |   976.0 ns |  55.56 ns | 160.3 ns |   928.3 ns |
| Builder | 3,550.9 ns | 151.37 ns | 419.4 ns | 3,422.3 ns |

*/