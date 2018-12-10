using System;
using System.Diagnostics;
using System.Text;

namespace Benchmark
{
    internal static class Program
    {
        private static void Main()
        {
            var arrLen = 100000000;
            var arr = new char[arrLen];
            for (var i = 0; i < arrLen; i++)
            {
                arr[i] = 'a';
            }

            var sw = Stopwatch.StartNew();
            string.Join("", arr);
            sw.Stop();
            Console.WriteLine("Join: {0}", sw.Elapsed);

            sw.Restart();
            var sb = new StringBuilder();
            sb.Append(arr);
            sb.ToString();
            sw.Stop();
            Console.WriteLine("StringBuilder: {0}", sw.Elapsed);

            sw.Restart();
            string.Concat(arr);
            sw.Stop();
            Console.WriteLine("Concat: {0}", sw.Elapsed);
        }
    }
}