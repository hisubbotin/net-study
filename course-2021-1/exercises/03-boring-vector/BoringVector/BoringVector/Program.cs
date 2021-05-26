using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BoringVector.Tests")]

namespace BoringVector
{
    internal class Program
    {
        private static void Main()
        {
            var v = new ExtendedVector(1, -1);
            Console.WriteLine(v.Normilize().ToString());

            var u1 = new Vector(5, 5);
            
            Console.WriteLine(u1.SquareLength());
            Console.WriteLine(u1 + u1 * 3);
            Console.WriteLine(u1.DotProduct(v));
            Console.WriteLine(u1.CrossProduct(v));
        }
    }
}
