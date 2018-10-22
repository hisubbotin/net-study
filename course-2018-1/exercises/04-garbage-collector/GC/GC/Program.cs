using System;
using System.Diagnostics;

namespace GarbageCollector
{
    class Program
    {
        // С какого размера объектов (string, массив int/double), CLR помещает объекты в LOH
        // Оценить время сборки мусора в разных поколениях
        static void Main(string[] args)
        {
            System.Console.WriteLine("С какого размера объектов " +
                                     "(string, массив int/double)," +
                                     " CLR помещает объекты в LOH");
            MeasureSize();
            System.Console.WriteLine("Оценить время сборки мусора в разных поколениях");
            MeasureTime();
            System.Console.ReadLine();
        }
        /// <summary>
        /// С какого размера объектов (string, массив int/double), CLR помещает объекты в LOH
        /// Для оптимизации большие объекты (>85kb) складываются в отдельную кучу (Large Object Heap)
        /// </summary>
        private static void MeasureSize()
        {
            var limit = 40000;
            var charObject = new char[limit];
            while (GC.GetGeneration(charObject) != 2 && limit <= 87040)
            {
                charObject = new char[limit];
                limit += 1;
            }
            Console.WriteLine("Char limit={0}", limit);
            
            limit = 20000;
            var intObject = new int[limit];
            while (GC.GetGeneration(intObject) != 2 && limit <= 87040)
            {
                intObject = new int[limit];
                limit += 1;
            }
            Console.WriteLine("Int limit={0}", limit);

            limit = 10000;
            var doubleObject = new double[limit];
            while (GC.GetGeneration(doubleObject) != 2 && limit <= 87040)
            {
                doubleObject = new double[limit];
                limit += 1;
            }
            Console.WriteLine("Double limit={0}", limit);
        }

        /// <summary>
        /// Оценить время сборки мусора в разных поколениях
        /// </summary>
        private static void MeasureTime()
        {
            for (var i = 0; i < 100; ++i)
            {
                _ = new int[100];
                _ = new int[1000];
                _ = new int[10000];
                _ = new int[100000];
            }
            DateTime start = DateTime.Now;
            var count = GC.CollectionCount(0);
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            DateTime end = DateTime.Now;
            Console.WriteLine("Generation: 0    " +
                              "Count: {0}   " +
                              "Timespan: {1}", 
                count,
                end-start);

            start = DateTime.Now;
            count = GC.CollectionCount(1);
            GC.Collect(1, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            end = DateTime.Now;
            Console.WriteLine("Generation: 1    " +
                              "Count: {0}   " +
                              "Timespan: {1}",
                count,
                end - start);

            start = DateTime.Now;
            count = GC.CollectionCount(2);
            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            end = DateTime.Now;
            Console.WriteLine("Generation: 2    " +
                              "Count: {0}   " +
                              "Timespan: {1}",
                count,
                end - start);
        }
    }
}
