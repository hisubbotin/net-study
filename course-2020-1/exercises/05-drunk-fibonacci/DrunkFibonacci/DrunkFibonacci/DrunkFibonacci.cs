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
            for (var i = 0; i < arr.Length; ++i, seed += step)
            {
                arr[i] = seed;
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
            const int seed = 42;
            var rnd = new Random(seed);
            while (true)
            {
                yield return rnd.Next();
            }
        }

        /// <summary>
        /// Возвращает последовательность Фибоначчи, которая слегка перебрала и теперь путается, что-то забывает или по десятому разу рассказывает одни и те же шутки :)
        /// </summary>
        public static IEnumerable<int> GetDrunkFibonacci()
        {
            bool IsSilent(int position) => position % 6 == 0;
            bool AddThreeHundred(int position) => IsSilent(position) && position > 6 * 4;

            var prevValue = 1;
            var currValue = 1;
            var currPos = 2;
            
            var randomEnumerator = GetDeterministicRandomSequence().GetEnumerator();
            randomEnumerator.MoveNext();
            randomEnumerator.MoveNext();
            
            while (true)
            {
                ++currPos;
                randomEnumerator.MoveNext();
                prevValue += currValue;
                (prevValue, currValue) = (currValue, prevValue);
                
                if (AddThreeHundred(currPos))
                {
                    ++currPos;
                    randomEnumerator.MoveNext();
                    prevValue = currValue;
                    currValue = 300;
                }
                
                if ((randomEnumerator.Current & 42) != 0)
                {
                    currValue &= ~42;
                }

                if (!IsSilent(currPos))
                {
                    yield return currValue;
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
            return GetDrunkFibonacci().Zip(GetDrunkFibonacci().Skip(42), (left, right) => left ^ right);
        }

        /// <summary>
        /// Возвращает последовательность DrunkFibonacci пачками по 16 значений.
        /// </summary>
        public static IEnumerable<int[]> GetInChunks()
        {
            var fibEnumerator = GetDeterministicRandomSequence().GetEnumerator();
            while (true)
            {
                const int len = 16;
                var chunk = new int[len];
                for (var i = 0; i < len; ++i)
                {
                    chunk[i] = fibEnumerator.Current;
                    fibEnumerator.MoveNext();
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
                    (mod, vals) => new
                    {
                        mod, 
                        count = vals.Count()
                    })
                .ToDictionary(item => item.mod, item => item.count);
        }
    }
}
