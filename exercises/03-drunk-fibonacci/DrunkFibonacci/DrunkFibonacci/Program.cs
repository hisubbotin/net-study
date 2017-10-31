using System;
using System.Linq;

namespace DrunkFibonacci
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("GetDrunkFibonacci: " + string.Join(',', DrunkFibonacci.GetDrunkFibonacci().Take(100)));
            Console.WriteLine("GetMaxOnRange: " + DrunkFibonacci.GetMaxOnRange(1000, 400));
            Console.WriteLine("GetNextNegativeRange: " + string.Join(',', DrunkFibonacci.GetNextNegativeRange().Take(100)));
            Console.WriteLine("GetXoredWithLaggedItself: " + string.Join(',', DrunkFibonacci.GetXoredWithLaggedItself().Take(100)));
            Console.WriteLine("GetInChunks: " + string.Join(Environment.NewLine, DrunkFibonacci.GetInChunks().Select(x => $"[{string.Join(',', x)}]").Take(3)));
            Console.WriteLine("FlattenChunkedSequence: " + string.Join(',', DrunkFibonacci.FlattenChunkedSequence().Take(60)));
            Console.WriteLine("GetGroupSizes: " + string.Join(',', DrunkFibonacci.GetGroupSizes()));
        }
    }
}
