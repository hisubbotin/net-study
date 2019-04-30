using System;

namespace BoringVector
{
    internal class Program
    {
        private static void Main()
        {
            Vector v = new Vector(1, 2);
            Vector d = new Vector(2, 4);
            Console.WriteLine(v.GetRelation(d));

            Console.WriteLine(v.ToString());

        }
    }
}
