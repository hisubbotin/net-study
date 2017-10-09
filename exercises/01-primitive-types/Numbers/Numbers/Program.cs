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

            Console.WriteLine(Integers.HalfIntMaxValue());
            Console.WriteLine(Integers.Cube(3));
            Console.WriteLine(Integers.CubeWithoutOverflowCheck(3));
            Console.WriteLine(Integers.CubeWithoutOverflowCheck(3));
            Console.WriteLine(Integers.ToString(12));
            Console.WriteLine(Integers.Parse("12"));
            Console.WriteLine(Integers.TenTimes(3));
            Console.WriteLine(Integers.ToHexString(2));
            Console.WriteLine(Integers.ToHexString(10));

            Console.WriteLine();

            Console.WriteLine(FloatNumbers.IsNaN(5.3));
            Console.WriteLine(FloatNumbers.IsNaN(double.NaN));
            Console.WriteLine(FloatNumbers.GetNaN());
            Console.WriteLine(FloatNumbers.Compare(1, 2, 1e-150));
            Console.WriteLine(FloatNumbers.Compare(2, 1, 1e-150));
            Console.WriteLine(FloatNumbers.Compare(2, 2, 1e-150));

            Console.ReadLine();
        }
    }
}
