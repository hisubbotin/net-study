using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            var t = Time.WhatTimeIsIt();
            Console.WriteLine(t);
            var t2 = Time.WhatTimeIsItInUtc();
            Console.WriteLine(t2);
            Console.WriteLine(t2.Kind);
            var t3 = Time.SpecifyKind(t, DateTimeKind.Unspecified);
            Console.WriteLine(t3.Kind);
            
        }
    }
}
