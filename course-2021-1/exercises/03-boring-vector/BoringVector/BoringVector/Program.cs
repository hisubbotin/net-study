using System;

namespace BoringVector
{
    internal class Program
    {
        private static void Main()
        {
            Vector vector = new Vector(1, 1);
            Console.WriteLine(vector.SquareLength());
        }
    }
}