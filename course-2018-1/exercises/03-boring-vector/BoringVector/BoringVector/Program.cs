using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BoringVector.Tests")]

namespace BoringVector
{
    internal class Program
    {
        private static void Main()
        {
            
            new Vector(1, 1);
            Console.WriteLine("Hello World!");
        }
    }
}
