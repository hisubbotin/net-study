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
            Console.WriteLine(Integers.HalfIntMaxValue());
            Console.WriteLine(Integers.CubeWithoutOverflowCheck(Integers.HalfIntMaxValue()));
            Console.WriteLine(Integers.ToString(8087));
            Console.WriteLine(Integers.Parse("80907"));
            Console.WriteLine(Integers.TenTimes(876));
            Console.WriteLine(Integers.ToHexString(255));
            Console.WriteLine(FloatNumbers.GetNaN());
            Console.WriteLine(2.1 / 2.3);
            Console.WriteLine(FloatNumbers.Compare(2.1 / 2.3, 4.2 / (2.3 * 2.0))); // выдает 0
                
            Console.WriteLine("Hello World!");
        }
    }
}
