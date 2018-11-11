using System.Collections;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace WubbaLubbaDubDub.Benchmarks
{
    public class SpeedTest
    {
        public SpeedTest()
        {
            for (int i = 0; i < 100; i++)
            {
                strings.Add(token);
            }
        }

        private string token = "Gucci Gang, ";
        private ArrayList strings = new ArrayList();

        [Benchmark]
        public string Join() => string.Join("", strings);

        [Benchmark]
        public string Build() => new StringBuilder().Append(strings).ToString();

        [Benchmark]
        public string Concat()
        {
            string result = "";
            foreach(var token in strings) {
                result += token;
            }
            return result;
        }
    }

    class Tester
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SpeedTest>();

           
        }
    }
}
