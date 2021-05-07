using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Numbers.Tests")]

/*
 * Привет! Это файл с входной точкой приложения, здесь ты можешь играться с кодом, запускать и тестировать свое решение задач.
 * Попробуй запустить приложение и поиграйся с консолью.
 * 
 * Как будешь готов[а], переходи в Integers.cs.
*/

namespace Numbers
{
    internal class Program
    {
        private static void Main()
        {
            // твои бро: Console.WriteLine и Console.ReadLine

            Console.WriteLine("Hello World!");
            Console.WriteLine(Numbers.Integers.HalfIntMaxValue());
            Console.WriteLine(Numbers.Integers.Cube(3));
            // Console.WriteLine(Numbers.Integers.CubeWithOverflowCheck(1234567891));
            // Console.WriteLine(Numbers.Integers.CubeWithoutOverflowCheck(1234567891));
            Console.WriteLine(Numbers.Integers.ToString(1234));
            Console.WriteLine(Numbers.Integers.Parse("38216283"));
            Console.WriteLine(Numbers.Integers.TenTimes(54321));
            Console.WriteLine(Numbers.Integers.ToHexString(1234));
            Console.WriteLine(Numbers.FloatNumbers.GetNaN());
            Console.WriteLine(Numbers.FloatNumbers.IsNaN(Numbers.FloatNumbers.GetNaN()));
            Console.WriteLine(Numbers.FloatNumbers.IsNaN(double.NaN));
            Console.WriteLine(Numbers.FloatNumbers.IsNaN(7.55));
            double x = 33.5321;
            double y = 33.5320;
            Console.WriteLine(Numbers.FloatNumbers.Compare(x, y, 0.001));
            Console.WriteLine(Numbers.FloatNumbers.Compare(x, y, 0.0001));
            Console.WriteLine(Numbers.FloatNumbers.Compare(y, x, 0.0001));
        }
    }
}
