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
        }
    }
}
