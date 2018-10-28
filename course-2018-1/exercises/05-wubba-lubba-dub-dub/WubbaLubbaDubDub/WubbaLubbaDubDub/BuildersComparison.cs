using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace WubbaLubbaDubDub
{
    internal class BuildersComparison
    {
        private static void Main()
        {
            var numOfIterations = 1000000;
            var charArray = new char[numOfIterations];
            for (int i = 0; i < numOfIterations; i++)
            {
                charArray[i] = 'a';
            }

            var sw = Stopwatch.StartNew();
            string.Join(' ', charArray);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            sw = Stopwatch.StartNew();
            StringBuilder sb = new StringBuilder();
            sb.Append(charArray);
            Console.WriteLine(sw.Elapsed);

            sw = Stopwatch.StartNew();
            string.Concat(charArray);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            //получаем следующие результаты:
            // string.Join -- 00:00:00.1125908
            // StringBuilder -- 00:00:00.0055353
            // string.Concat -- 00:00:00.0761168

            Console.Read();
        }
    }
}
