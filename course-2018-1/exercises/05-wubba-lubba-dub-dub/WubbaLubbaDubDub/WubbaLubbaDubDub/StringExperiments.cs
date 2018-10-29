using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WubbaLubbaDubDub;

namespace StringExperiments    
{
    class Program
    {
        static void StrConcat( List<string> strings )
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            string.Concat(strings.ToArray());
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, 
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("StrConcat:" + elapsedTime);
        }
        static void StrBuilder(List<string> strings)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            
            StringBuilder builder = new StringBuilder();
            for( int i = 0; i < strings.Count; i++ )
            {
                builder.Append(strings[i]);
            }
            string s = builder.ToString();
            
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, 
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("StrBuilder:" + elapsedTime);
        }
        
        static void StrJoin(List<string> strings)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            
            string.Join("", strings.ToArray());

            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, 
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("StrJoin:" + elapsedTime);        
        }
        static void Measurements(int numStrings, int numSymbols)
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
            StrConcat(strings);
            StrBuilder(strings);
            StrJoin(strings);
        }
        static void Main(string[] args)
        {
            /*Measurements(2, 1024 * 1024 * 128);
            Measurements(1024, 1024 * 128);
            Measurements(1024 * 2, 512 * 128);
            Regex reg1 = new Regex(@"\p{P}");
            Regex reg2 = new Regex(@"\s");
            
            string[] s = Regex.Split(". , ; a , \n \r\n , a , ; ; b ; ", reg1 + "|" + reg2);
            string[] a = s.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            string[] result = {"a", "a", "b"};
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(string.Equals(a[i], result[i]));
            }*/
            //            
        }
    }
}