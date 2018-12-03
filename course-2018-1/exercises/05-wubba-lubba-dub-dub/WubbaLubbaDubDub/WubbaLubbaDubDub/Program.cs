using System.Text;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
namespace WubbaLubbaDubDub
{
    internal class Program
    {
        private static void Main()
        {
            BenchmarkRunner.Run<Benchmarks>();
        }
    }
    public class Benchmarks
    {
        private string[] strings = {
        "White man came across the sea\n",
        "He brought us pain and misery\n",
        "He killed our tribes, killed our creed\n",
        "He took our game for his own need\n",
        "We fought him hard, we fought him well\n",
        "Out on the plains we gave him hell\n",
        "But many came too much for Cree\n",
        "Oh will we ever be set free?\n",

        "Riding through dust clouds and barren wastes\n",
        "Galloping hard on the plains\n",
        "Chasing the redskins back to their holes\n",
        "Fighting them at their own game\n",
        "Murder for freedom the stab in the back\n",
        "Women and children are cowards attack\n",

        "Run to the hills, run for your lives\n",
        "Run to the hills, run for your lives\n",


    };
        [Benchmark]
        public string StringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strings.Length; i++)
            {
                sb.Append(strings[i]);
            }
            return sb.ToString();
        }
        [Benchmark]
        public string Join()
        {
            return string.Join("", strings);
        }
        [Benchmark]
        public string Concat()
        {
            return string.Concat("", strings);
        }
    }
}
