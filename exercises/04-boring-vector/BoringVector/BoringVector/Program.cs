using System;

namespace BoringVector
{    
    internal class Program
    {
        private static void Main()
        {
            Vector vec1 = new Vector(1.0, 1.0);            
            Vector vec2 = new Vector(2.0, -2.5);
            Vector vec3 = new Vector(1.0, -1.0);           
            Console.WriteLine(vec1.GetRelation(vec2));
            Console.WriteLine(vec1.GetRelation(vec3));
        }
    }
}
