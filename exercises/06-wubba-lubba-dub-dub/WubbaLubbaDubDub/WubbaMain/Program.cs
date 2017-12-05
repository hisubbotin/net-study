using System;
using System.Collections.Immutable;
using WubbaLubbaDubDub;

namespace WubbaMain
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "//Barselooona \n /* dfjhdk \n skjfhk AAAA:5555 \n */ BBBB:4444";
            //Console.WriteLine(line);
            IImmutableList<long> ans = line.GetUsedObjects().ToImmutableArray();
            Console.WriteLine(ans[0]);
            Console.WriteLine("FSGA");
            Console.ReadKey();
        }
    }
}
