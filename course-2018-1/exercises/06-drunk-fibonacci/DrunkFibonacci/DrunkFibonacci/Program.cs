using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestDrunkFibonacci")]

namespace DrunkFibonacci
{
    internal class Program
    {
        private static void Main()
        {
           
            Dictionary<int,int> dict = new Dictionary<int, int>();
            IEnumerable<int> a = Enumerable.Range(1, 80);

            var l = a.GroupBy(y => y % 8);
            int count = 0;
            foreach (var VARIABLE in l)
            {
                count++;
                Console.WriteLine("gr_size:" + VARIABLE.Count().ToString());
                
            }
            
            Console.WriteLine("l_size: " + l.Count().ToString());
           
            /*

            Console.WriteLine("GetDrunkFibonacci: " + string.Join(',', DrunkFibonacci.GetDrunkFibonacci().Take(100)));
            Console.WriteLine("GetMaxOnRange: " + DrunkFibonacci.GetMaxOnRange(1000, 400));
            Console.WriteLine("GetNextNegativeRange: " + string.Join(',', DrunkFibonacci.GetNextNegativeRange().Take(100)));
            Console.WriteLine("GetXoredWithLaggedItself: " + string.Join(',', DrunkFibonacci.GetXoredWithLaggedItself().Take(100)));
            Console.WriteLine("GetInChunks: " + string.Join(Environment.NewLine, DrunkFibonacci.GetInChunks().Select(x => $"[{string.Join(',', x)}]").Take(3)));
            Console.WriteLine("FlattenChunkedSequence: " + string.Join(',', DrunkFibonacci.FlattenChunkedSequence().Take(60)));
            Console.WriteLine("GetGroupSizes: " + string.Join(',', DrunkFibonacci.GetGroupSizes()));*/
        }
    }
}
