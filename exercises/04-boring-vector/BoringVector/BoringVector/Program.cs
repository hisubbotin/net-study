using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BoringVector.Tests2")]
namespace BoringVector
{
    internal class Program
    {
        private static void Main()
        {
            Vector ve = new Vector(1, 2);
            Console.WriteLine(ve.ToString());

            Vector ve2 = new Vector(3, 4);
            Console.WriteLine((ve + ve2).ToString());

            Console.WriteLine((ve2 - ve).ToString());

            Console.WriteLine((ve * 2).ToString());

            Console.WriteLine((ve / 2).ToString());

            Console.WriteLine(VectorExtenstions.IsZero(ve));

            Console.WriteLine(VectorExtenstions.Normalize(ve));

            Console.WriteLine(VectorExtenstions.GetAngleBetween(ve, ve2));

            Console.WriteLine(VectorExtenstions.GetAngleBetween(new Vector(1, 2), new Vector(2, 4)));

            Console.WriteLine(VectorExtenstions.GetRelation(new Vector(1, 2), new Vector(2, 4)));
            Console.WriteLine(VectorExtenstions.GetRelation(new Vector(0, 1), new Vector(1, 0)));
            Console.WriteLine(VectorExtenstions.GetRelation(new Vector(1, 2), new Vector(2, 3)));
        }
    }
}
