using System;
using System.Collections.Generic;
using System.Linq;

namespace DrunkFibonacci
{
    internal static class DrunkFibonacci
    {
        /// <summary>
        /// Создает пустой массив заданной длины.
        /// </summary>
        /// <param name="len">Длина массива</param>
        public static int[] CreateIntArray(int len)
        {
            return new int[len];
        }

        /// <summary>
        /// Заполняет заданный массив значениями арифметической прогрессии на основе <see cref="seed"/> и <see cref="step"/>.
        /// </summary>
        /// <param name="arr">Заданный массив.</param>
        /// <param name="seed">База прогрессии.</param>
        /// <param name="step">Шаг прогрессии.</param>
        public static void FillIntArray(int[] arr, int seed, int step)
        {
            arr[0] = seed;
            for (var i = 1; i < arr.Length; ++i)
            {
                arr[i] = arr[i - 1] + step;
            }
        }

        /// <summary>
        /// Возвращает массив из первых пяти значений последовательности Фибоначчи.
        /// </summary>
        /// <returns></returns>
        public static int[] GetFirstFiveFibonacci()
        {
            return new int[] {1, 1, 2, 3, 5};
        }

        /// <summary>
        /// Возвращает последовательность случайных чисел, которая сгенерирована на основе некоторого постоянного определителя.
        /// </summary>
        public static IEnumerable<int> GetDeterministicRandomSequence()
        {
            const int seed = 51;
            var generator = new Random(seed);
            while (true)
            {
                yield return generator.Next();
            }
        }

        /// <summary>
        /// Возвращает последовательность Фибоначчи, которая слегка перебрала и теперь путается, что-то забывает или по десятому разу рассказывает одни и те же шутки :)
        /// </summary>
        public static IEnumerable<int> GetDrunkFibonacci()
        {
            yield return 1;
            yield return 1;
            
            var probs = GetDeterministicRandomSequence().Skip(2);
            var prev = 1;
            var curr = 1;
            var i = 2;

            foreach (var prob in probs)
            {
                ++i;
                
                var next = unchecked(prev + curr);
                prev = curr;
                curr = next;
                
                if ((42 & prob) == 42)
                {
                    next &= ~42;
                }
                
                if (i % 6 == 4)
                {
                    next = 300;
                }
                
                if (i % 6 != 0)
                {
                    yield return next;
                }
            }
        }

        /// <summary>
        /// Возвращает максимальное число на отрезке последовательности DrunkFibonacci.
        /// </summary>
        /// <param name="from">Индекс начала отрезка. Нумерация с единицы.</param>
        /// <param name="cnt">Длина отрезка.</param>
        public static int GetMaxOnRange(int from, int cnt)
        {
            return GetDrunkFibonacci()
                .Skip(from - 1)
                .Take(cnt)
                .Max();
        }

        /// <summary>
        /// Возвращает следующий отрезок из отрицательных значений последовательности DrunkFibonacci в виде списка, начиная поиск с индекса <see cref="from"/>.
        /// </summary>
        /// <param name="from">Индекс начала поиска отрезка. Нумерация с единицы.</param>
        public static List<int> GetNextNegativeRange(int from = 1)
        {
            return GetDrunkFibonacci()
                .Skip(from - 1)
                .SkipWhile(x => x >= 0)
                .TakeWhile(x => x < 0)
                .ToList();
        }

        /// <summary>
        /// Возвращает последовательность чисел вида F(i) = DrunkFibonacci(i) XOR DrunkFibonacci(i + 42)
        /// </summary>
        public static IEnumerable<int> GetXoredWithLaggedItself()
        {
            return GetDrunkFibonacci().Zip(GetDrunkFibonacci().Skip(42), (lhs, rhs) => lhs ^ rhs);
        }

        /// <summary>
        /// Возвращает последовательность DrunkFibonacci пачками по 16 значений.
        /// </summary>
        public static IEnumerable<int[]> GetInChunks()
        {
            var generator = GetDrunkFibonacci();
            var chunk = CreateIntArray(16);
            var i = 0;

            foreach (var element in generator)
            {
                chunk[i % 16] = element;
                if (++i % 16 == 0)
                {
                    yield return chunk;
                }
            }
        }

        /// <summary>
        /// Возвращает выравненную последовательность GetInChunks, где из каждой пачки берется только 3 самых маленьких по модулю значения.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> FlattenChunkedSequence()
        {
            return GetInChunks().SelectMany(chunk => chunk.OrderBy(Math.Abs).Take(3));
        }

        /// <summary>
        /// Возвращает словарь пар { класс вычета по модулю 8; число значений в классе среди первых 10000 элементов последовательности DrunkFibonacci }.
        /// Учитываются только непустые классы.
        /// </summary>
        /// <remarks>
        /// Класс вычетов - мн-во значений, имеющих одинаковый остаток от деления на нек-е число (в данном случае 8).
        /// В общем на выходе словарь пар, где ключ - остаток от деления на 8, а значение - кол-во элементов с таким остатком среди первых 10000 элементов посл-ти.
        /// </remarks>
        public static Dictionary<int, int> GetGroupSizes()
        {
            return GetDrunkFibonacci()
                .Take(10000)
                .GroupBy(value => Math.Abs(value) % 8)
                .OrderBy(value => value.Key)
                .ToDictionary(value => value.Key, value => value.Count());
        }
    }
}
