using System;
using System.Linq;

namespace DrunkFibonacci
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine();
            Console.WriteLine("GetFibonacciOriginal: " + string.Join(',', DrunkFibonacci.GetFibonacciOriginal().Take(100)));
            Console.WriteLine();
            Console.WriteLine("GetDrunkFibonacci   : " + string.Join(',', DrunkFibonacci.GetDrunkFibonacci().Take(100)));
            Console.WriteLine();
            Console.WriteLine("GetMaxOnRange: " + DrunkFibonacci.GetMaxOnRange(1000, 400));
            Console.WriteLine();
            Console.WriteLine("GetNextNegativeRange: " + string.Join(',', DrunkFibonacci.GetNextNegativeRange().Take(100)));
            Console.WriteLine();
            Console.WriteLine("GetXoredWithLaggedItself: " + string.Join(',', DrunkFibonacci.GetXoredWithLaggedItself().Take(100)));
            Console.WriteLine();
            Console.WriteLine("GetInChunks: " + string.Join(Environment.NewLine, DrunkFibonacci.GetInChunks().Select(x => $"[{string.Join(',', x)}]").Take(5)));
            Console.WriteLine();
            Console.WriteLine("FlattenChunkedSequence: " + string.Join(',', DrunkFibonacci.FlattenChunkedSequence().Take(60)));
            Console.WriteLine();
            Console.WriteLine("GetGroupSizes: " + string.Join(',', DrunkFibonacci.GetGroupSizes()));
        }
    }
}
