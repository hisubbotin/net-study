using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BoringVector.Tests")]

namespace BoringVector
{
    internal class Program
    {

        private static void Main()
        {
            Vector newVec = new Vector(1d, 1d);
            Console.WriteLine("Hello World!");
        }
    }
}
