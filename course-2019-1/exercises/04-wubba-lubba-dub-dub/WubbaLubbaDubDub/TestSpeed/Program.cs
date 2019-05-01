using System;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace TestSpeed
{
    public class SpeedTester
    {
        private readonly string[] test_strings =
            ("...На краю дороги стоял дуб. Он был, вероятно, в десять раз старше берез, составлявших лес, в десять раз толще и в два раза выше каждой березы. Это был огромный, в два обхвата дуб, с обломанными суками и корой, заросшей старыми болячками. С огромными, неуклюже, несимметрично растопыренными корявыми руками и пальцами, он старым, сердитым и презрительным уродом стоял между улыбающимися березами. Только он один не хотел подчиниться обаянию весны и не хотел видеть ни весны, ни солнца. " +
             "Этот дуб как будто говорил: «Весна, и любовь, и счастье! И как не надоест вам все один и тот же глупый, бессмысленный обман! Все одно и то же, и все обман! Нет ни весны, ни солнца, ни счастья. Вон смотрите, сидят задавленные мертвые ели, всегда одинокие, и вон я растопырил свои обломанные, ободранные пальцы, выросшие из спины, из боков — где попало. Как выросли — так и стою, и не верю вашим надеждам и обманам»."
            ).Split(" ");

        [Benchmark]
        public string JoinTest()
        {
            return string.Join(" ", test_strings);
        }
        
        
        [Benchmark]
        public string BuilderTest() {
            var build = new StringBuilder();
            foreach (string s in test_strings)
            {
                build.Append(s + " ");
            }
            return build.ToString();
        }
        
        [Benchmark]
        public string ConcatinationTest()
        {
            String result = "";
            foreach (String s in test_strings)
            {
                result += s + " ";
                
            }
            return result;
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