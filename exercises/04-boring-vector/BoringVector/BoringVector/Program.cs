using System;

namespace BoringVector
{
    internal class Program
    {
        private static void Main()
        {
            Vector vec1 = new Vector(1.0, 1.0);
            Vector vec2 = new Vector(2.0, -2.5);
            vec1.SquareLength();
            Console.WriteLine(VectorExtensions.GetRelation(vec1, vec2));
            Console.WriteLine("Hello World!");
        }
    }
}
