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
            Console.WriteLine(FloatNumbers.Compare(0.005, 0.004, 0.0001));
            Console.WriteLine(FloatNumbers.Compare(0.005, 0.004, 0.001));
            Console.WriteLine(FloatNumbers.Compare(0.005, 0.004, 0.01));
            Console.WriteLine(FloatNumbers.Compare(3, 7-4, 0.000001));
            Console.ReadLine();
        }
    }
}
