/*
    Welcome aboard!

    Если у тебя не открыта вкладочка с Solution Explorer'ом, то открой ее, пожалуйста (View -> Solution Explorer). Эта вкладка отображает дерево файлов и папок внутри проекта, а так же самих проектов внутри солюшена.
    Для начала разберемся немного с ними:
        - Solution - это просто некоторая логическая организация проектов. Представляет собой обычный файл с расширением *.sln, в котором записана
                    различная информация о проектах, которые он содержит, их идентификаторах (GUID'ы) и о конфигурациях компиляции каждого из них.
                    Он целиком и полностью у
*/



using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Numbers.Tests")]

namespace Numbers
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
