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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Заполняет заданный массив значениями арифметической прогрессии на основе <see cref="seed"/> и <see cref="step"/>.
        /// </summary>
        /// <param name="arr">Заданный массив.</param>
        /// <param name="seed">База прогрессии.</param>
        /// <param name="step">Шаг прогрессии.</param>
        public static void FillIntArray(int[] arr, int seed, int step)
        {
            for (int i=0;i<arr.Length;i++)
            {
                arr[i] = seed;
                seed += step;
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает массив из первых пяти значений последовательности Фибоначчи.
        /// </summary>
        /// <returns></returns>
        public static int[] GetFirstFiveFibonacci()
        {
            return new int[] {1, 1, 2, 3, 5};
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает последовательность случайных чисел, которая сгенерирована на основе некоторого постоянного определителя.
        /// </summary>
        public static IEnumerable<int> GetDeterministicRandomSequence()
        {
            Random rnd = new Random(20);
            while(true)
            {
                yield return rnd.Next();
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает последовательность Фибоначчи, которая слегка перебрала и теперь путается, что-то забывает или по десятому разу рассказывает одни и те же шутки :)
        /// </summary>
        public static IEnumerable<int> GetDrunkFibonacci()
        {
            /*
                Первые два значения: 1 и 1.
                Каждое 6е число забывает озвучить (но учитывает при подсчете следующего).
                Каждое 6е, начиная с 4го, вставляет очередную "шутку за 300": число 300.
                У получившегося числа с некоторой вероятностью зануляет биты, 
                соответствующие числу 42 (т.е. те биты, которые в бинарном представлении числа 42 равны единице).
                    Вероятность считается так. На каждом i-ом этапе вычисления нового значения X последовательности берешь так же число Y
                    из последовательности GetDeterministicRandomSequence и проверяешь, есть ли у числа Y единичные биты числа 42.
                При вычислении сложения переполнение типа разрешено и всячески поощряется.
            */
            int drunk = 1;
            int fibonacci = 1;
            int count = 1;
            IEnumerable<int> random = GetDeterministicRandomSequence();
            
            foreach (int rand in random)
            {
                if (count == 1)
                {
                    if ((rand & 42) > 0)
                    {
                        yield return drunk & (~42);
                    }
                    else
                    {
                        yield return drunk;
                    }
                }
                else
                {
                    if (count % 6 != 0)
                    {
                        if (count > 4 && (count - 4) % 6 == 0)
                        {
                            yield return 300;
                        }
                        else
                        {
                            if ((rand & 42) > 0)
                            {
                                yield return fibonacci & (~42);
                            }
                            else
                            {
                                yield return fibonacci;
                            }
                        }
                    }

                    int newFibonacci = drunk + fibonacci;
                    drunk = fibonacci;
                    fibonacci = newFibonacci;
                }
                count += 1;
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает максимальное число на отрезке последовательности DrunkFibonacci.
        /// </summary>
        /// <param name="from">Индекс начала отрезка. Нумерация с единицы.</param>
        /// <param name="cnt">Длина отрезка.</param>
        public static int GetMaxOnRange(int from, int cnt)
        {
            return GetDrunkFibonacci().Skip(from-1).Take(cnt).Max();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает следующий отрезок из отрицательных значений последовательности DrunkFibonacci в виде списка, начиная поиск с индекса <see cref="from"/>.
        /// </summary>
        /// <param name="from">Индекс начала поиска отрезка. Нумерация с единицы.</param>
        public static List<int> GetNextNegativeRange(int from = 1)
        {
            return GetDrunkFibonacci().Skip(from - 1).SkipWhile(num => num > 0).TakeWhile(num => num < 0).ToList();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает последовательность чисел вида F(i) = DrunkFibonacci(i) XOR DrunkFibonacci(i + 42)
        /// </summary>
        public static IEnumerable<int> GetXoredWithLaggedItself()
        {
            IEnumerable<int> fib42 = GetDrunkFibonacci().Skip(42);
            return GetDrunkFibonacci().Zip(fib42, (num, num42) => num ^ num42);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает последовательность DrunkFibonacci пачками по 16 значений.
        /// </summary>
        public static IEnumerable<int[]> GetInChunks()
        {
            IEnumerable<int> fib = GetDrunkFibonacci();
            while (true)
            {
                yield return fib.Take(16).ToArray();
                fib = fib.Skip(16);
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает выравненную последовательность GetInChunks, где из каждой пачки берется только 3 самых маленьких по модулю значения.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> FlattenChunkedSequence()
        {
            return GetInChunks().SelectMany(arr => arr.OrderBy(num => Math.Abs(num)).Take(3));
            throw new NotImplementedException();
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
                .GroupBy(num => num % 8, (group, nums) =>  new KeyValuePair<int,int>(group, nums.Count()))
                .ToDictionary(x => x.Key, x => x.Value);
            throw new NotImplementedException();
        }
    }
}
