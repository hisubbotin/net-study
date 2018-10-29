using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Text;

namespace WubbaLubbaDubDub
{
    internal class TimeComparison
    {
        private static void Main()
        {
            String str_join = "";
            Stopwatch my_stopwatch = new Stopwatch();
            my_stopwatch.Start();
            for (int i = 0; i < 100000; i++)
            {
                string.Join("a", str_join);
            }
            TimeSpan ts1 = my_stopwatch.Elapsed;
            double str_join_time = ts1.TotalMilliseconds;

            StringBuilder str_builder = new StringBuilder("");
            my_stopwatch.Restart();
            for (int i = 0; i < 100000; i++)
            {
                str_builder.Append("a");
            }
            TimeSpan ts2 = my_stopwatch.Elapsed;
            double str_builder_time = ts2.TotalMilliseconds;
            
            String str_concat = "";
            my_stopwatch.Restart();
            for (int i = 0; i < 100000; i++)
            {
                str_concat = str_concat + "a";
            }
            TimeSpan ts3 = my_stopwatch.Elapsed;
            double str_concat_time = ts3.TotalMilliseconds;
            
            Console.WriteLine("Time for string.Join: " + str_join_time + "ms\n" + 
                              "Time for StringBuilder: " + str_builder_time + "ms\n" + 
                              "Time for Concat: " + str_concat_time + "ms\n");
        }
    }
}