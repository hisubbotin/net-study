using System;
using System.Collections.Generic;
using System.Linq;

namespace DrunkFibonacci
{
    internal class Program
    {
        private static void Describe<T>(string message, IEnumerable<T> data, int count = 10)
        {
            Console.WriteLine(message + ":");
            Console.Write(string.Join(", ", data.Take(count)));
            if (data.Skip(count).Any())
            {
                Console.WriteLine("...");
            }
            else
            {
                Console.WriteLine();
            }
        }
        
        private static void Main()
        {
            Describe("Deterministic Random", DrunkFibonacci.GetDeterministicRandomSequence());
            Describe("Drunk Values", DrunkFibonacci.GetDrunkFibonacci(), 20);
            List<int[]> buckets = DrunkFibonacci.GetInChunks().Take(3).ToList();
            foreach (var bucket in buckets)
            {
                Describe("Drunk Values in chunks", bucket, 16);
            }
            
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
