using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringExperiments    
{
    class Program
    {
        void Measure(Func<List<string>> method, string methodName)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, 
                                                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine(methodName + ": " + elapsedTime);
        }
        void StrConcat( List<string> strings )
        {
            string.Concat(strings.ToArray());
        }
        void StrBuilder(List<string> strings)
        {
            StringBuilder builder = new StringBuilder();
            for( int i = 0; i < strings.Count; i++ )
            {
                builder.Append(strings[i]);
            }
        }
        void StrJoin(List<string> strings)
        {
            string.Join("", strings.ToArray());
        }
        void Measurements(int numStrings, int numSymbols)
        {
            if (numStrings < 2)
            {
                throw new Exception("Measurements: numStrings must be >= 2");
            }
            if (numStrings < 1)
            {
                throw new Exception("Measurements: numSymbols must be >= 1");
            }
            List<string> strings = new List<string>();
            for (int i = 0; i < numStrings; i++)
            {
                 strings.Add(new string('a', numSymbols));
            }

            Console.WriteLine(String.Concat("numStrings: ", numStrings.ToString(), "\n", 
                                            "numSymbols: ", numSymbols.ToString()));
           
        }
        static void Main(string[] args)
        {
            Regex.Split("hello , world ; , new day   , , , , , , , , ,, , , , , , America, Russia", @"\p{P}");
        }
    }
}