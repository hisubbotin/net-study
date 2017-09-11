using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Numbers.Tests")]

namespace Numbers
{
    internal static class Program
    {

        private static void Main()
        {
            TestDecimal();
            TestDouble();

            Console.WriteLine(-double.Epsilon);
            Console.WriteLine(0d / 0d);
        }

        private static void TestDecimal()
        {
            var d1 = decimal.One;
            var d2 = 18.3m;

            var res = d1 / d2;
            Console.WriteLine(res);
            res *= 123137123m;
            Console.WriteLine(res);
            res = decimal.Remainder(18.7m, 13m);
            Console.WriteLine(res);
        }

        private static void TestDouble()
        {
            var d1 = 1.0;
            var d2 = 18.3;
            var res = d1 / d2;
            Console.WriteLine(res);
            res *= 123137123;
            Console.WriteLine(res);
            var rem = 18.7 - 13 * Math.Floor(18.7 / 13);
            Console.WriteLine(rem);
        }
    }
}
