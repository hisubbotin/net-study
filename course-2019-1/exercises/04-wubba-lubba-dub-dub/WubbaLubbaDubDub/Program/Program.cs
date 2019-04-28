using System.Diagnostics;
using System;
using WubbaLubbaDubDub;
using System.Text;

namespace Program
{
    class Program
    {
        static string[] testStrings = "Sherlock is a British crime drama television series based on Sir Arthur Conan Doyle's Sherlock Holmes detective stories.".Split();

        static void ProccessJoin()
        {
            String.Join(" ", testStrings);
        }

        static void ProcessStringBuilder()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string lexem in testStrings)
            {
                stringBuilder.Append(lexem);
            }
        }

        static void ProcessConcat()
        {
            String.Concat(testStrings);
        }

        static void Main(string[] args)
        {
            int testSize = 10000000;

            Stopwatch stopwatch = new Stopwatch();
            TimeSpan ts = new TimeSpan();

            stopwatch.Start();
            for (int i = 0; i < testSize; ++i)
            {
                ProccessJoin();
            }
            stopwatch.Stop();
            ts = stopwatch.Elapsed;
            Console.WriteLine("ProccessJoin(), size - " + testSize.ToString());
            Console.WriteLine("total: " + ts.ToString());
            Console.Write("ProccessJoin(), mean - ");
            Console.WriteLine((ts.TotalMilliseconds / testSize).ToString());
            Console.WriteLine();

            stopwatch.Restart();
            for (int i = 0; i < testSize; ++i)
            {
                ProcessStringBuilder();
            }
            stopwatch.Stop();
            ts = stopwatch.Elapsed;
            Console.WriteLine("ProcessStringBuilder(), size - " + testSize.ToString());
            Console.WriteLine("total: " + ts.ToString());
            Console.Write("ProcessStringBuilder(), mean - ");
            Console.WriteLine((ts.TotalMilliseconds / testSize).ToString());
            Console.WriteLine();

            stopwatch.Restart();
            for (int i = 0; i < testSize; ++i)
            {
                ProcessConcat();
            }
            stopwatch.Stop();
            ts = stopwatch.Elapsed;
            Console.WriteLine("ProcessConcat(), size - " + testSize.ToString());
            Console.WriteLine("total: " + ts.ToString());
            Console.Write("ProcessConcat(), mean - ");
            Console.WriteLine((ts.TotalMilliseconds / testSize).ToString());
            Console.WriteLine();
        }
    }
}
