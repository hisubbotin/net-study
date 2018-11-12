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
            "In the town where I was born\n",
            "Lived a man who sailed to sea\n",
            "And he told us of his life\n",
            "In the land of submarines\n",
            "So we sailed up to the sun\n",
            "Till we found a sea of green\n",
            "And we lived beneath the waves\n",
            "in our yellow submarine\n",
            "\n",
            "We all live in a yellow submarine\n",
            "Yellow submarine, yellow submarine\n",
            "We all live in a yellow submarine\n",
            "Yellow submarine, yellow submarine\n",
            "\n",
            "And our friends are all aboard\n",
            "Many more of them live next door\n",
            "And the band begins to play\n",
            "\n",
            "We all live in a yellow submarine\n",
            "Yellow submarine, yellow submarine\n",
            "We all live in a yellow submarine\n",
            "Yellow submarine, yellow submarine\n",
            "\n",
            "(Full speed ahead Mr. Boatswain, full speed ahead\n",
            "Full speed ahead it is, Sgt.\n",
            "Cut the cable, drop the cable\n",
            "Aye, Sir, aye\n",
            "Captain, captain)\n",
            "\n",
            "As we live a life of ease\n",
            "Every one of us has all we need\n",
            "Sky of blue and sea of green\n",
            "In our yellow submarine\n",
            "\n",
            "We all live in a yellow submarine\n",
            "Yellow submarine, yellow submarine\n",
            "We all live in a yellow submarine\n",
            "Yellow submarine, yellow submarine\n",
            "We all live in a yellow submarine\n",
            "Yellow submarine, yellow submarine"
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

/*
 RESULTS
        Method |        Mean |      Error |     StdDev |
-------------- |------------:|-----------:|-----------:|
 StringBuilder | 1,045.82 ns | 11.4764 ns | 10.1735 ns |
          Join |   792.10 ns |  4.8079 ns |  4.0148 ns |
        Concat |    25.88 ns |  0.6109 ns |  0.5715 ns |
*/