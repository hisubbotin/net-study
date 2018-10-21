using System;

namespace GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            GCTest.TestInt();
            GCTest.TestDouble();
            GCTest.TestString();
            
            GCTest.MakeSomeGarbage();
            
            for (var i = 0; i < 3; ++i)
            {
                GCTest.CountCollectingTime(i);
            }
        }
    }
}