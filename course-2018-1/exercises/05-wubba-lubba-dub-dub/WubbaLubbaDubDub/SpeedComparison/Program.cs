using System;
using System.Diagnostics;
using System.Text;

namespace SpeedComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cравним по скорости string.Join(), StringBuilder и Конкатенацию с помощью StopWatch:
            
            var sizeString = 1000000;
            var StopWatch = new Stopwatch();
            var random = new Random((int)DateTime.Now.Ticks);
            string RandomString(int size)
            {
                var builder = new StringBuilder();
                for (var i = 0; i < size; i++)
                {
                    var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));                 
                    builder.Append(ch);
                }

                return builder.ToString();
            }
            
            StopWatch.Start();
            var tmpJoin = string.Join(null, new string[] {RandomString(sizeString), RandomString(sizeString)});
            StopWatch.Stop();
            Console.WriteLine("Time string.Join(): {0}", StopWatch.Elapsed);
            
            StopWatch.Restart();
            var tmpPlus = RandomString(sizeString) + RandomString(sizeString);
            StopWatch.Stop();
            Console.WriteLine("Time Plus: {0}", StopWatch.Elapsed);
            
            StopWatch.Restart();
            var build = new StringBuilder();
            build.Append(RandomString(sizeString));
            build.Append(RandomString(sizeString));
            var tmpStringBuilder = build.ToString();
            StopWatch.Stop();
            Console.WriteLine("Time StringBuilder: {0}", StopWatch.Elapsed);
        }
    }
}