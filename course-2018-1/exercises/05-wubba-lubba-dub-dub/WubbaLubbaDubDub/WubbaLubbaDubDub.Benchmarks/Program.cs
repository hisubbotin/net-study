using System;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace WubbaLubbaDubDub.Benchmarks {
    public class JoinVsSbVsConcat {

        private string[] strings = {
            "Lorem Ipsum is simply dummy text of the ", "printing and typesetting industry. Lorem Ipsum ",
            "has been the industry's standard dummy text ", "ever since the 1500s, when an unknown printer ",
            "took a galley of type and scrambled it to make a ", "type specimen book. It has survived not only five ",
            "centuries, but also the leap into electronic"
        };

        [Benchmark]
        public string Join() => string.Join("", strings);

        [Benchmark]
        public string Build() =>
            strings.Aggregate(new StringBuilder(), (current, str) => current.Append(str)).ToString();

        [Benchmark]
        public string Concat() => strings.Aggregate("", (current, str) => current + str);
    }
    
    class Program {

        static void Main(string[] args) {
            BenchmarkRunner.Run<JoinVsSbVsConcat>();
            
            /*
             *   Method |     Mean |    Error |    StdDev |
             *  ------- |---------:|---------:|----------:|
             *     Join | 147.6 ns | 2.991 ns |  3.889 ns |
             *    Build | 436.2 ns | 8.728 ns | 21.079 ns |
             *   Concat | 363.5 ns | 7.347 ns | 11.219 ns |
             */
        }
    }
}
