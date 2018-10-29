using System;
using System.Diagnostics;

namespace GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            // Часть 1.
            Console.WriteLine("Part1:");
            
            // Для начала узнаем, сколько в байтах занимают известные нам типы:
            
            Console.WriteLine("Sizeof char: {0}", sizeof(char)); // 2
            Console.WriteLine("Sizeof int: {0}", sizeof(int)); // 4
            
            // Из интернета мы узнали, что CLR помещает в LOH объекты больше 85000 байт (примерно), остальные в SOH.
            // То есть, прикинем, сколько нам нужно интов и чаров, чтобы оказаться рядом с этим зничением.
            // 85000 / 2 = 42500, а 85000 / 4 = 21250
            
            // Проверим, попадаем ли массив 22000 интов во 2 поколение, а массив 21000 интов в 0 поколение, чтобы 
            // ограничить искомое значение снизу и сверху.

            var obj1 = new int[22000];
            var obj2 = new int[21000];
            Console.WriteLine("Generation obj int[22000]: {0}", GC.GetGeneration(obj1)); // 2
            Console.WriteLine("Generation obj int[21000]: {0}", GC.GetGeneration(obj2)); // 0
            
            // Далее в цикле найдем точное количество интов:

            for (var i = 21000; i < 22000; i++)
            {
                var obj = new int[i];
                
                if (GC.GetGeneration(obj) == 2)
                {
                    Console.WriteLine("Array int size: {0}", i);
                    break;
                }
            }
            
            // Получили число 21244. То есть в LOH помещаются все объекты больше чем 84976 байт.
            
            // Для лучшей точности проделаем все тоже самое с char:
            
            var obj3 = new char[42000];
            var obj4 = new char[43000];
            Console.WriteLine("Generation obj char[42000]: {0}", GC.GetGeneration(obj3)); // 0
            Console.WriteLine("Generation obj char[43000]: {0}", GC.GetGeneration(obj4)); // 2
         
            for (var i = 42000; i < 43000; i++)
            {
                var obj = new char[i];
                if (GC.GetGeneration(obj) == 2)
                {
                    Console.WriteLine("Array char size: {0}", i);
                    break;
                }
            }
            
            // Получили число 42488. Следовательно в LOH помещаются все объекты больше чем 84976 байт. (ШОК, получили такое же цисло)
            
            Console.WriteLine("\n");
            // Часть 2.
            Console.WriteLine("Part2:");
            
            var StopWatch = new Stopwatch();
            
            //Нагрузим CLR:
            for (var i = 0; i < 1000; i++)
            {
                var tmp = new int[50000];
            }
            
            // Поколение - 0:
            Console.WriteLine("BEFORE CollectionCount 0 generation: {0}", GC.CollectionCount(0));
            StopWatch.Start();
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            StopWatch.Stop();
            Console.WriteLine("Time 0 generation: {0}", StopWatch.Elapsed);
            Console.WriteLine("AFTER CollectionCount 0 generation: {0}", GC.CollectionCount(0));

            // Поколение - 1:
            Console.WriteLine("BEFORE CollectionCount 1 generation: {0}", GC.CollectionCount(1));
            StopWatch.Restart();
            GC.Collect(1, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            StopWatch.Stop();
            Console.WriteLine("Time 1 generation: {0}", StopWatch.Elapsed);
            Console.WriteLine("AFTER CollectionCount 1 generation: {0}", GC.CollectionCount(1));

            // Поколение - 2:
            Console.WriteLine("BEFORE CollectionCount 2 generation: {0}", GC.CollectionCount(2));
            StopWatch.Restart();
            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            StopWatch.Stop();
            Console.WriteLine("Time 2 generation: {0}", StopWatch.Elapsed);
            Console.WriteLine("AFTER CollectionCount 2 generation: {0}", GC.CollectionCount(2));
        }
    }
}