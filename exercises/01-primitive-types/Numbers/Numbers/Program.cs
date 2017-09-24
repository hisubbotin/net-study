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

            Console.WriteLine(0.ToString("X"));
            Console.WriteLine(1.ToString("X"));
            Console.WriteLine(14.ToString("X"));
            Console.WriteLine(12315.ToString("X"));
            Console.WriteLine((-289823).ToString("X"));

            //Console.WriteLine(double.NaN);
            //Console.WriteLine(double.MaxValue + double.MaxValue);
            //Console.WriteLine(double.MaxValue/double.Epsilon);
            //Console.WriteLine(double.PositiveInfinity / double.PositiveInfinity);
            //Console.WriteLine(double.PositiveInfinity);
            //Console.WriteLine(Math.Sqrt(-1));
            //Console.WriteLine(Math.Asin(2));
        }
    }
}
