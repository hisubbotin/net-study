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

            // Proof that we need TOLERANCE in Compare method
            const double x = .1;
            const double l = 10 * x;
            const double r = x + x + x + x + x + x + x + x + x + x;
            
            // We expect that `l == r`
            Console.WriteLine(FloatNumbers.Compare(l, r));
            Console.WriteLine("{0:R} - {1:R} != 0", l, r);
        }
    }
}
