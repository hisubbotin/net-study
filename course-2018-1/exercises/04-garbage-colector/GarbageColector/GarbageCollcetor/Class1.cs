using System;
using System.Linq;

namespace GarbageCollcetor
{
    public class Class1
    {
        static void Main()
        {
            string strPtr = new string("");
            for (int i = 0; i < 10; i++)
            {
                strPtr.Append('a');
                Console.WriteLine('a');
                Console.WriteLine(GC.GetGeneration(strPtr));
            }
        }
    }
}