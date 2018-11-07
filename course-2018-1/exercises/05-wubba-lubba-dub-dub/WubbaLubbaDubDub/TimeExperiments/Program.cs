using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TimeExperiments
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = String.Empty;
            int num = 500;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < num; i++)
            {
                string.Join("a", text);
            }
            sw.Stop();
            Console.WriteLine("Join: {0}", sw.Elapsed);
            Console.WriteLine(text);
            text = String.Empty;
            sw.Reset();
            sw.Start();
            for (int i = 0; i < num; i++)
            {
                text = text + "a";
            }
            sw.Stop();
            Console.WriteLine("Concatenation: {0}", sw.Elapsed);
            StringBuilder sb = new StringBuilder("");
            sw.Reset();
            sw.Start();
            for (int i = 0; i < num; i++)
            {
                sb.Append("a");
            }
            sw.Stop();
            Console.WriteLine("StringBuilder: {0}", sw.Elapsed);
        }
    }
}
