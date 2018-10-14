using System;

namespace BoringVector
{
    internal class Program
    {
        private static void Main()
        {

            Console.WriteLine("Hello World!");
            Vector v = new Vector(0.1, 0.0);
            Vector v2 = new Vector(1.0, 2.3);


            Vector pre_ans = v.Add(v2);

            Console.WriteLine(Math.Abs(pre_ans.X) - 1.1);
            Console.WriteLine(Math.Abs(pre_ans.Y) - 2.3);
        }
    }
}
