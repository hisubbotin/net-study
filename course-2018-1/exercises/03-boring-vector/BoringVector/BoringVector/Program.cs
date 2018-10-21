using System;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("BoringVector.Tests")]


namespace BoringVector
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello World!");
            
            Vector v = new Vector(1, 2);
        }
    }
}
