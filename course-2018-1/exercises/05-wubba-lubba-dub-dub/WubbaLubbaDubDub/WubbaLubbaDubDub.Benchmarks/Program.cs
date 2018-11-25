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
        public string Build() {
            var sb = new StringBuilder();
            foreach (var str in strings)
            {
                sb.Append(str);
            }
            return sb.ToString();
        }
        
        [Benchmark]
        public string Concat() => strings.Aggregate("", (current, str) => current + str);
    }
    
    class Program {

        static void Main(string[] args) {
            BenchmarkRunner.Run<JoinVsSbVsConcat>();
            
            /*
             *  Method |     Mean |    Error |    StdDev |   Median |
             * ------- |---------:|---------:|----------:|---------:|
             *    Join | 153.2 ns | 3.104 ns |  3.925 ns | 151.6 ns |
             *   Build | 343.3 ns | 6.865 ns | 11.280 ns | 338.0 ns |
             *  Concat | 388.0 ns | 7.849 ns | 17.393 ns | 381.6 ns |

             */
        }
    }
}
