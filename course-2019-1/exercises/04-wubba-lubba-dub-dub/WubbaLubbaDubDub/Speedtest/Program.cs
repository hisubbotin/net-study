using System;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace SpeedTest
{
    public class SpeedTester
    {
        private readonly string[] _strarr =
            { "One day, after Moses had grown up, he went out to where his own people were ",
              "and watched them at their hard labor. He saw an Egyptian beating a Hebrew, one ",
              "of his own people. Looking this way and that and seeing no one, he killed the ",
              "Egyptian and hid him in the sand. The next day he went out and saw two Hebrews ",
              "fighting. He asked the one in the wrong, “Why are you hitting your fellow Hebrew?",

              "The man said, “Who made you ruler and judge over us? Are you thinking of killing ",
              "me as you killed the Egyptian?” Then Moses was afraid and thought, “What I did ",
              " must have become known.",

              "When Pharaoh heard of this, he tried to kill Moses, but Moses fled from Pharaoh",
              "and went to live in Midian, where he sat down by a well. Now a priest of Midian ",
              "had seven daughters, and they came to draw water and fill the troughs to water their ",
              "father’s flock. Some shepherds came along and drove them away, but Moses got up ",
              "and came to their rescue and watered their flock." };

        [Benchmark]
        public string TestJoin()
        {
            return string.Join(" ", _strarr);
        }

        [Benchmark]
        public string TestConcatenation()
        {
            string result = "";
            foreach (var s in _strarr)
            {
                result += s + " ";
            }
            return result;
        }

        [Benchmark]
        public string TestBuilder()
        {
            var ans = new StringBuilder();
            foreach (var w in _strarr)
            {
                ans.Append(w + " ");
            }
            return ans.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SpeedTester>();
        }
    }
}