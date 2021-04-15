using System;
using System.Runtime.CompilerServices;
using Numbers;
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
            Console.WriteLine(Integers.Cube(7));
            // Console.WriteLine(Integers.CubeWithOverflowCheck(10000));
            Console.WriteLine(Integers.CubeWithoutOverflowCheck(10000));
            Console.WriteLine(Integers.TenTimes(11));
            Console.WriteLine(Integers.ToHexString(15));
            Console.WriteLine(FloatNumbers.GetNaN());
            Console.WriteLine(FloatNumbers.IsNaN(FloatNumbers.GetNaN()));
            Console.WriteLine(FloatNumbers.Compare(1, 2, 0.0000001));
            Console.WriteLine(FloatNumbers.Compare(1.001, 0.999, 0.1));
            Console.WriteLine(FloatNumbers.Compare(2, 1, 0));
        }
    }
}
