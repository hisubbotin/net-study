using System;

namespace GarbageCollector
{
    internal class Program
    {
        private static void Main()
        {
            int index = 0;

            string str = "";
            while (GC.GetGeneration(str) != 2)
            {
                str += '0';
            }
            Console.WriteLine($"Объекты типа string помещаются в LOH начиная с {str.Length * sizeof(char)} байт");


            int[] array = new int[0];
            for (int i = 1; GC.GetGeneration(array) != 2; ++i)
            {
                // Сгенерируем несколько объектов 1 поколения
                if (i % 10 == 0)
                { 
                    GC.Collect(0);
                }
                array = new int[i];
            }
            Console.WriteLine($"Массив типа int помещается в LOH начиная с {array.Length * sizeof(int)} байт");


            double[] array_double = new double[0];
            for (int i = 1; GC.GetGeneration(array_double) != 2; ++i)
            {
                array_double = new double[i];
                index = i;
            }
            Console.WriteLine($"Массив типа double помещается в LOH начиная с {array_double.Length * sizeof(double)} байт");

            // Добавим еще немного объектов в LOH
            for (int i = index; i < index * 3; ++i)
            {
                array_double = new double[i];
            }

            for (int i = index; i < index * 5 / 2; ++i)
            {
                array = new int[i * 1000];
            }


            DateTime start = DateTime.Now;
            GC.Collect(0, GCCollectionMode.Forced);
            TimeSpan time = DateTime.Now - start;
            Console.WriteLine(time.TotalMilliseconds);

            start = DateTime.Now;
            GC.Collect(1, GCCollectionMode.Forced);
            time = DateTime.Now - start;
            Console.WriteLine(time.TotalMilliseconds);

            start = DateTime.Now;
            GC.Collect(2, GCCollectionMode.Forced);
            time = DateTime.Now - start;
            Console.WriteLine(time.TotalMilliseconds);
        }
    }
}
