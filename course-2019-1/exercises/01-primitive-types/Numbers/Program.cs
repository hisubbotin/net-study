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
            Console.WriteLine(FloatNumbers.Compare(0.111111111111111111, 0.1111111111111111112, 30));
            Console.WriteLine((1.1111111111111112 - 1.111) * 100000);
            Console.WriteLine(0.100000000000000000000000000000001);
        }
    }
}
