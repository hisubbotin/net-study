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
            //Console.WriteLine(Integers.CubeWithOverflowCheck(1000));
            Console.WriteLine(Integers.CubeWithoutOverflowCheck(Integers.HalfIntMaxValue()));
            Console.WriteLine(Integers.HalfIntMaxValue());
            Console.WriteLine("Hello World!");
            Console.WriteLine(Integers.Parse("5556"));
            Console.WriteLine(Integers.ToHexString(256));
            Console.WriteLine(FloatNumbers.Compare(3,3.3,0.5));
        }
    }
}