using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;


namespace ComparatorStringCreating
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            string s = string.Empty;
            for (int i = 0; i < 1000; i++)
            {
                s = string.Join(" ", s, "this");
            }
            sw.Stop();
            Console.WriteLine("string.Join: {0} ms", sw.Elapsed.TotalMilliseconds);

            sw.Restart();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1000; i++)
            {
                sb.AppendJoin(" ", "this ");
            }
            string str = sb.ToString();
            sw.Stop();
            Console.WriteLine("StringBuilder: {0} ms", sw.Elapsed.TotalMilliseconds);

            sw.Restart();
            string s1 = string.Empty;
            for (int i = 0; i < 1000; i++)
            {
                s1 += " this";
            }
            sw.Stop();
            Console.WriteLine("Concatenation: {0} ms", sw.Elapsed.TotalMilliseconds);

        }
    }
}
