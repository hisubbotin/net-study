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
            // на создание массивов заданной длины
            if (len < 0) {
                throw new ArgumentException("Parameter cannot be negative", nameof(len));
            }

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
            // на задание значений массива
            if (arr == null) {
                throw new ArgumentNullException(nameof(arr), "Parameter cannot be null");
                // почему сначала идет paramName, а потом message?
                // https://msdn.microsoft.com/en-us/library/k8a0dfcy(v=vs.110).aspx
            }

            for (var i = 0; i < arr.Length; ++i) {
                arr[i] = seed + i * step;
            }
        }

        /// <summary>
        /// Возвращает массив из первых пяти значений последовательности Фибоначчи.
        /// </summary>
        /// <returns></returns>
        public static int[] GetFirstFiveFibonacci()
        {
            // на создание массива с инициализацией
            return new[] {1, 1, 2, 3, 5};
        }

        /// <summary>
        /// Возвращает последовательность случайных чисел, которая сгенерирована на основе некоторого постоянного определителя.
        /// </summary>
        public static IEnumerable<int> GetDeterministicRandomSequence()
        {
            /*
                Воспользуйся классом Random.
                Для того, чтобы данный объект генерировал одну и ту же последовательность,
                его следует инициализировать одной и той же константой (параметр конструктора seed).

                Задача на ленивую генерацию последовательностей.
            */
            var randomSequence = new Random(0);
            while (true) {
                yield return randomSequence.Next() % 100;
            }
        }

        /// <summary>
        /// Возвращает последовательность Фибоначчи, которая слегка перебрала и теперь путается, что-то забывает или по десятому разу рассказывает одни и те же шутки :)
        /// </summary>
        public static IEnumerable<long> GetDrunkFibonacci()
        {
            /*
                Первые два значения: 1 и 1.
                Каждое 6е число забывает озвучить (но учитывает при подсчете следующего).
                Каждое 6е, начиная с 4го, вставляет очередную "шутку за 300": число 300.
                У получившегося числа с некоторой вероятностью зануляет биты, 
                соответствующие числу 42 (т.е. те биты, которые в бинарном представлении числа 42 равны единице).
                    Вероятность считается так. На каждом i-ом этапе вычисления нового значения X последовательности берешь также число Y
                    из последовательности GetDeterministicRandomSequence и проверяешь, есть ли у числа Y единичные биты числа 42.
                При вычислении сложения переполнение типа разрешено и всячески поощряется.
            */
            using (var enumeratorOfRandomSequence = GetDeterministicRandomSequence().GetEnumerator())
            {
                for (var n = 0; true; ++n, enumeratorOfRandomSequence.MoveNext()) {
                    switch (n % 6)
                    {
                        case 0:
                            continue;
                        case 4:
                            yield return 300;
                            continue;
                    }

                    var goldenRatio = (1 + Math.Sqrt(5)) / 2;
                    var nthFibonacciNumber = (long)((Math.Pow(goldenRatio, n) - Math.Pow(-goldenRatio, -n)) / Math.Sqrt(5));
                    if ((enumeratorOfRandomSequence.Current & 42) == 42) {
                        nthFibonacciNumber &= ~42;
                    }

                    yield return nthFibonacciNumber;
                }
            }
        }

        /// <summary>
        /// Возвращает максимальное число на отрезке последовательности DrunkFibonacci.
        /// </summary>
        /// <param name="from">Индекс начала отрезка. Нумерация с единицы.</param>
        /// <param name="cnt">Длина отрезка.</param>
        public static long GetMaxOnRange(int from, int cnt)
        {
            // научишься пропускать и брать фиксированную часть последовательности, агрегировать. Максимум есть среди готовых функций агрегации.
            if (from < 1 || cnt < 1) {
                throw new ArgumentException("you're a dumbass");
            }

            return GetDrunkFibonacci().Skip(from - 1).Take(cnt).Max();
        }

        /// <summary>
        /// Возвращает следующий отрезок из отрицательных значений последовательности DrunkFibonacci в виде списка, начиная поиск с индекса <see cref="from"/>.
        /// </summary>
        /// <param name="from">Индекс начала поиска отрезка. Нумерация с единицы.</param>
        public static List<long> GetNextNegativeRange(int from = 1)
        {
            // научишься пропускать и брать по условию, превращать в список (см. ToList).
            if (from < 1) {
                throw new ArgumentException("Mistaaaaaaaaaaaake!");
            }

            return GetDrunkFibonacci().Skip(from - 1).SkipWhile(x => (x >= 0)).TakeWhile(x => (x < 0)).ToList();
        }

        /// <summary>
        /// Возвращает последовательность чисел вида F(i) = DrunkFibonacci(i) XOR DrunkFibonacci(i + 42)
        /// </summary>
        public static IEnumerable<long> GetXoredWithLaggedItself()
        {
            // узнаешь о существовании функции Zip.
            return GetDrunkFibonacci().Zip(GetDrunkFibonacci().Skip(42), (first, second) => first ^ second);
        }

        /// <summary>
        /// Возвращает последовательность DrunkFibonacci пачками по 16 значений.
        /// </summary>
        public static IEnumerable<long[]> GetInChunks()
        {
            // ничему особо не научишься, просто интересная задачка :)
            for (var drunkFibonacciSequence = GetDrunkFibonacci(); true; drunkFibonacciSequence = drunkFibonacciSequence.Skip(16)) {
                yield return drunkFibonacciSequence.Take(16).ToArray();
            }
        }

        /// <summary>
        /// Возвращает выравненную последовательность GetInChunks, где из каждой пачки берется только 3 самых маленьких по модулю значения.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<long> FlattenChunkedSequence()
        {
            /*
                Узнаешь о встроенных функциях сортировки и функции SelectMany,
                которая сглаживает (flatten) последовательность последовательностей в просто последовательность.

                Вообще говоря, SelectMany умеет много чего и мегаполезна.
                Она в какой-то степени эквивалентна оператору `bind` над монадами (в данном случае над монадами последовательностей).
            */
            return GetInChunks().SelectMany(chunk => chunk.Select(Math.Abs).OrderBy(item => item).Take(3));
        }

        /// <summary>
        /// Возвращает словарь пар { класс вычета по модулю 8; число значений в классе среди первых 10000 элементов последовательности DrunkFibonacci }.
        /// Учитываются только непустые классы.
        /// </summary>
        /// <remarks>
        /// Класс вычетов - мн-во значений, имеющих одинаковый остаток от деления на нек-е число (в данном случае 8).
        /// В общем, на выходе словарь пар, где ключ - остаток от деления на 8, а значение - кол-во элементов с таким остатком среди первых 10000 элементов посл-ти.
        /// </remarks>
        public static Dictionary<long, int> GetGroupSizes()
        {
            /*
                Хочется увидеть решение через группировку и агрегацию. Для группировки существуют два метода-расширения GroupBy и ToLookup.
                Они внешне немного похожи, но на самом деле очень сильно различаются семантически.

                Первый - ленивый (как Take, Where, Select и куча других) и лишь декларирует группировку, т.е. конструирует 
                новый объект с информацией о том, как производить группировку (сама итерация по исходной последовательности 
                при вызове метода GroupBy не производится). Это бывает удобно, например, при описании запросов к БД, используя ORM'ки - 
                GroupBy будет правильно истолковано конструктором запросов и группировка будет произведена на стороне БД, а не на стороне кода,
                что и быстрее, и требует передачи меньшего кол-ва данных.
                Если у объекта, полученного вызовом .GroupBy дважды вызвать методы, инициирующие итерацию, то она будет произведена дважды.

                Второй - не ленивый и производит непосредственно саму группировку. Можно трактовать это как "промежуточное кэширование" группировки для быстрого
                [и возможно повторного] доступа к группам. Т.е. ты один раз произвел группировку, дальше пользуешься уже ей отдельно от оригинальной последовательности - 
                это не потребует повторных итераций по ней.
                По сути ILookup<TKey, TVal> аналогичен IDictionary<TKey, IEnumerable<TVal>> - разница лишь в том, что
                обращение к несуществующему ключу лукапа будет выдавать пустую последовательность, в то время как словарь сгенерирует исключение.

                Конкретно в этом задании более к месту будет выглядеть использование GroupBy. Но можешь ради интереса воспользоваться и ToLookup.

                Итого научишься группировать и создавать на их основе словарь (см. ToDictionary).
            */
            return GetDrunkFibonacci().Take(10000).GroupBy(number => number % 8).ToDictionary(item => item.Key, item => item.Count());
        }
    }
}
