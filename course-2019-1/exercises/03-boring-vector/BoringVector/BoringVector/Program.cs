using System;

namespace BoringVector
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello World!");
            if (new Vector(0,0).IsZero())
            {
                Console.WriteLine("0");
                Console.WriteLine(new Vector(6, 7).ToString());
                Vector v = new Vector(6, 7);
                Vector y = v / 6.0;
            }
            else
            {
                Console.WriteLine("1");
            }
        }
    }
}
