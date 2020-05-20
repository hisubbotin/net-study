using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = seed;
                seed += step;
            }
        }

        /// <summary>
        /// Возвращает массив из первых пяти значений последовательности Фибоначчи.
        /// </summary>
        /// <returns></returns>
        public static int[] GetFirstFiveFibonacci()
        {
            return new[] {0, 1, 1, 2, 3};
        }

        /// <summary>
        /// Возвращает последовательность случайных чисел, которая сгенерирована на основе некоторого постоянного определителя.
        /// </summary>
        public static IEnumerable<int> GetDeterministicRandomSequence()
        {
            const int seed = 127;
            var randomGenerator = new Random(seed);
            while (true)
            {
                yield return randomGenerator.Next();
            }
        }

        /// <summary>
        /// Возвращает последовательность Фибоначчи, которая слегка перебрала и теперь путается, что-то забывает или по десятому разу рассказывает одни и те же шутки :)
        /// </summary>
        public static IEnumerable<int> GetDrunkFibonacci()
        {
            bool RemainSilent(int pos) => pos % 6 == 0;
            bool Tell300Joke (int pos) => RemainSilent(pos) && pos >= 24;

            var prev = 0;
            var curr = 1;
            var index = 1;

            using var randomY= GetDeterministicRandomSequence().GetEnumerator();

            while (true)
            {
                ++index;
                randomY.MoveNext();
                prev += curr;
                (prev, curr) = (curr, prev);
                
                if ((randomY.Current & 42) != 0)
                {
                    curr &= ~42;
                }

                if (Tell300Joke(index))
                {
                    ++index;
                    randomY.MoveNext();
                    prev = curr;
                    curr = 300;
                }

                if (!RemainSilent(index))
                {
                    yield return curr;
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
            return GetDrunkFibonacci().Skip(from - 1).Take(cnt).Max();
        }

        /// <summary>
        /// Возвращает следующий отрезок из отрицательных значений последовательности DrunkFibonacci в виде списка, начиная поиск с индекса <see cref="from"/>.
        /// </summary>
        /// <param name="from">Индекс начала поиска отрезка. Нумерация с единицы.</param>
        public static List<int> GetNextNegativeRange(int from = 1)
        {
            return GetDrunkFibonacci().Skip(from - 1).SkipWhile(val => val >= 0).TakeWhile(val => val < 0).ToList();
        }

        /// <summary>
        /// Возвращает последовательность чисел вида F(i) = DrunkFibonacci(i) XOR DrunkFibonacci(i + 42)
        /// </summary>
        public static IEnumerable<int> GetXoredWithLaggedItself()
        {
            return GetDrunkFibonacci().Zip(GetDrunkFibonacci().Skip(42), (curr, next) => curr ^ next);
        }

        /// <summary>
        /// Возвращает последовательность DrunkFibonacci пачками по 16 значений.
        /// </summary>
        public static IEnumerable<int[]> GetInChunks()
        {
            using var fibonacci = GetDrunkFibonacci().GetEnumerator();
            while (true)
            {
                var chunk = new int[16];
                for (var i = 0; i < 16; i++)
                {
                    chunk[i] = fibonacci.Current;
                    fibonacci.MoveNext();
                }

                yield return chunk;
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
                .GroupBy(
                    val => val % 8,
                    (remainder, values) => new
                    {
                        remainder, 
                        count = values.Count()
                    })
                .ToDictionary(item => item.remainder, item => item.count);
        }
    }
}
