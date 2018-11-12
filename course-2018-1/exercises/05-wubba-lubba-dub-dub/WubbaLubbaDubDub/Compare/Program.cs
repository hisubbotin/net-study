using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Compare
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            var random = new Random();
            var countOfStrings = 300;
            var lengthsOfStrings = new int[] { 1, 10, 100, 1000, 10000, 100000 };
            var strings = new string[] { };
            for (var i = 0; i < countOfStrings; i++)
            {
                strings.Append(RandomString(lengthsOfStrings[Convert.ToInt32(Math.Floor(6 * random.NextDouble()))]));
            }

            timer.Start();
            var join = string.Join(null, strings);
            timer.Stop();
            Console.WriteLine("Time Join: {0}", timer.Elapsed);

            timer.Restart();
            var concat = string.Concat(strings);
            timer.Stop();
            Console.WriteLine("Time Concat: {0}", timer.Elapsed);

            timer.Restart();
            var stringBuilder = new StringBuilder();
            var build = stringBuilder.AppendJoin(null, strings).ToString();
            timer.Stop();
            Console.WriteLine("Time StringBuilder: {0}", timer.Elapsed);
            Console.ReadLine();
            string RandomString(int length)
            {
                var builder = new StringBuilder();
                for (var i = 0; i < length; ++i)
                {
                    var c = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(c);
                }

                return builder.ToString();
            }
        }
    }
}
