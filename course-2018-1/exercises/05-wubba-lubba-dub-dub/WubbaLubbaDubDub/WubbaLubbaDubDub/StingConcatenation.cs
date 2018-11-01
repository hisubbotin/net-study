using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace WubbaLubbaDubDub
{
    public class StingConcatenation
    {
        public static void Run()
        {
            var stringArray = GenerateStrings();
            var stopWatch = new Stopwatch();
            
            stopWatch.Start();
            var builder = new StringBuilder();
            foreach (var s in stringArray)
            {
                builder.Append(s);
            }
            stopWatch.Stop();
            Console.WriteLine(String.Format("StringBuilder: {0}", stopWatch.ElapsedMilliseconds));
            
            stopWatch.Restart();
            String.Join("", stringArray);
            stopWatch.Stop();
            Console.WriteLine(String.Format("Join: {0}", stopWatch.ElapsedMilliseconds));
            
            stopWatch.Restart();
            String.Concat(stringArray);
            stopWatch.Stop();
            Console.WriteLine(String.Format("Concat: {0}", stopWatch.ElapsedMilliseconds));

            
            
            string[] GenerateStrings()
            {
                var size = 1000000;
                var result = new string[size];
                for (int i = 0; i < size; i++)
                {
                    result[i] = new Random().Next(0, 100).ToString();
                }

                return result;
            }
        }
    }
}