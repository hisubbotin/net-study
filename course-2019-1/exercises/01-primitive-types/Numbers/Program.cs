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
        /* 
        private static void Main()
        {
            // твои бро: Console.WriteLine и Console.ReadLine

            Console.WriteLine("Hello World!");
        }
        */
        public static void Main()
        {
            var r = new RefType { X = 1 };
            RefMethod(r);
            Console.WriteLine(r.X);
            RefMethod(ref r);
            Console.WriteLine(r.X);
        }

        class RefType { public Int32 X; }
        static void RefMethod(RefType r) { r = new RefType { X = 15 }; }
        static void RefMethod(ref RefType r)
        {
            r = new RefType { X = 15 };
        }
    }
}
