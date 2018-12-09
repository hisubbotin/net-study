/*
 * Поколение 0. Идентифицируется новый только что размещённый объект, который ещё никогда
 * не помечался как надлежащий удалению в процессе сборки мусора
 * 
 * Поколение 1. Идентифицирует объект, который уже «пережил» один процесс сборки мусора
 * (был помечен, как надлежащий удалению, но не был удалён из-за достаточного свободного
 * места в куче).
 * 
 * Поколение 2. Идентифицирует объект, который пережил более одного прогона сбора мусора
 */
// https://docs.microsoft.com/ru-ru/dotnet/standard/garbage-collection/fundamentals
// https://habr.com/post/125968/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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
                _ = new int[100];
                _ = new int[1000];
                _ = new int[10000];
                _ = new int[100000];
                _ = new int[1000000];
            }
            var sw = new Stopwatch();
            sw.Start();
            var count = GC.CollectionCount(0);
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            sw.Stop();
            Console.WriteLine("Gen0: \tElapsed: {0}", sw.Elapsed);

            sw.Restart();
            count = GC.CollectionCount(1);
            GC.Collect(1, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            sw.Stop();
            Console.WriteLine("Gen1: \tElapsed: {0}", sw.Elapsed);

            sw.Restart();
            count = GC.CollectionCount(2);
            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            sw.Stop();
            Console.WriteLine("Gen2: \tElapsed: {0}", sw.Elapsed);
        }
    }
}