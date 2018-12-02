using System;
using System.Diagnostics;

namespace GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Размеры массивов int, double, char, при которых CLR помещает объекты в LOH");
            FindSizeToEpoch();
            System.Console.WriteLine("Время сборки мусора для разных поколений");
            FindGarbageTime();
        }


        private static void FindSizeToEpoch()
        {
            var limit = 1000;
            var intObject = new int[limit];
            while (GC.GetGeneration(intObject) != 2)
            {
                intObject = new int[limit];
                limit += 1;
            }

            Console.WriteLine("Int limit={0}", limit);

            limit = 1000;
            var doubleObject = new double[limit];
            while (GC.GetGeneration(doubleObject) != 2)
            {
                doubleObject = new double[limit];
                limit += 1;
            }

            Console.WriteLine("Double limit={0}", limit);

            limit = 1000;
            var charObject = new char[limit];
            while (GC.GetGeneration(charObject) != 2)
            {
                charObject = new char[limit];
                limit += 1;
            }

            Console.WriteLine("Char limit={0}", limit);
        }


        private static void FindGarbageTime()
        {
            for (var i = 0; i < 1000; ++i)
            {
                var mass100 = new int[100];
                var mass1000 = new int[1000];
                var mass10000 = new int[10000];
                var mass100000 = new int[100000];
                var mass1000000 = new int[1000000];
            }

            DateTime start = DateTime.Now;
            var count = GC.CollectionCount(0);
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            DateTime finish = DateTime.Now;
            Console.WriteLine("Generation: 0    Timespan: {0}", (finish - start) * 10000 / count);

            start = DateTime.Now;
            count = GC.CollectionCount(1);
            GC.Collect(1, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            finish = DateTime.Now;
            Console.WriteLine("Generation: 1    Timespan: {0}", (finish - start) * 10000 / count);

            start = DateTime.Now;
            count = GC.CollectionCount(2);
            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            finish = DateTime.Now;
            Console.WriteLine("Generation: 2    Timespan: {0}", (finish - start) * 10000 / count);
        }
    }
}