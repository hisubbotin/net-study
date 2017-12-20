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
            if (arr == null)
            {
                return;
            }
            int value = seed;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = value;
                value += step;
            }
        }

        /// <summary>
        /// Возвращает массив из первых пяти значений последовательности Фибоначчи.
        /// </summary>
        /// <returns></returns>
        public static int[] GetFirstFiveFibonacci()
        {
            return new[] {1, 1, 2, 3, 5};
        }

        private static IEnumerable<int> GenerateFibonacci()
        {
            int current = 1;
            int next = 1;
            while (true)
            {
                yield return current;
                int newNext = current + next;
                current = next;
                next = newNext;
            }
        }


        /// <summary>
        /// Возвращает последовательность случайных чисел, которая сгенерирована на основе некоторого постоянного определителя.
        /// </summary>
        public static IEnumerable<int> GetDeterministicRandomSequence()
        {
            var random = new Random();
            while (true)
            {
                yield return random.Next();
            }
        }

        /// <summary>
        /// Возвращает последовательность Фибоначчи, которая слегка перебрала и теперь путается, что-то забывает или по десятому разу рассказывает одни и те же шутки :)
        /// </summary>
        public static IEnumerable<int> GetDrunkFibonacci()
        {
            int current = 1;
            int next = 1;

            using (var greatRandom = GetDeterministicRandomSequence().GetEnumerator())
            {
                for (var i = 0;; i++)
                {
                    // Преобразуем очередное значение согласно drunk-правилам
                    int? drunkCurrent = _applyDrunkRules(current, i, greatRandom.Current);
                    if (drunkCurrent.HasValue)
                    {
                        yield return drunkCurrent.Value;
                    }

                    // Двигаемся дальше
                    int newNext = unchecked (current + next);
                    current = next;
                    next = newNext;
                    greatRandom.MoveNext();
                }
            }
        }

        /// <summary>
        /// Первые два значения: 1 и 1.
        /// Каждое 6е число забывает озвучить (но учитывает при подсчете следующего).
        /// Каждое 6е, начиная с 4го, вставляет очередную "шутку за 300": число 300.
        /// 
        /// У получившегося числа с некоторой вероятностью зануляет биты, 
        /// соответствующие числу 42 (т.е. те биты, которые в бинарном представлении числа 42 равны единице).
        /// </summary>
        /// <param name="value">Очередное число</param>
        /// <param name="index">Порядковый номер очередного числа</param>
        /// <param name="greatRandom">Случайное число, по которому будут обнулятся биты результата</param>
        /// <param name="goCrazyAt">Номер, начиная с которого применяются правила</param>
        /// <param name="forgetAboutEach">Пропускаемые номера</param>
        /// <param name="jokeAtEach">Номера, на которых применяется правило шутки</param>
        /// <param name="startJokesFrom">Номер, начиная с которого применяется правило шутки</param>
        /// <param name="jokeValue">Значение, выдаваемое согласно правилу шутки</param>
        /// <param name="mask">Битовая маска, случайная подмаска которой будет обнуляться у результата применения предыдущий правил</param>
        /// <returns>Результат применения drunk-правил</returns>
        private static int? _applyDrunkRules(
            int value,
            int index,
            int greatRandom,
            int goCrazyAt = 3,
            int forgetAboutEach = 6,
            int jokeAtEach = 6,
            int startJokesFrom = 4,
            int jokeValue = 300,
            int mask = 42)
        {
            int? result = value;

            if (index < goCrazyAt)
            {
                // Первые два значения: 1 и 1.
                return value;
            }

            if (index % forgetAboutEach == 0)
            {
                // Каждое 6е число забывает озвучить (но учитывает при подсчете следующего).
                result = null;
            }
            else if (index > startJokesFrom && index % jokeAtEach == 0)
            {
                // Каждое 6е, начиная с 4го, вставляет очередную "шутку за 300": число 300.
                // Если что, ДО 4-го нет 6-ых
                result = jokeValue;
            }

            if (result == null)
            {
                return null;
            }

            // У получившегося числа с некоторой вероятностью зануляет биты, 
            // соответствующие числу 42 (т.е. те биты, которые в бинарном представлении числа 42 равны единице).
            return _nullifyRandomSubMask(result.Value, greatRandom, mask);
        }

        /// <summary>
        /// Вероятность считается так. На каждом i-ом этапе вычисления нового значения X последовательности берешь так же число Y
        /// из последовательности GetDeterministicRandomSequence и проверяешь, есть ли у числа Y единичные биты числа 42.
        /// </summary>
        /// <param name="value">Значние, определенные биты которого будут обнуляться</param>
        /// <param name="greatRandom">Случайное число, по которому будут обнулятся биты результата</param>
        /// <param name="mask">Битовая маска, случайныая подмаска которой будет обнуляться у результата применения предыдущий правил</param>
        /// <returns>Результат обнуления битов <see cref="value"/> по случайной подмаске маски<see cref="mask"/></returns>
        private static int _nullifyRandomSubMask(int value, int greatRandom, int mask)
        {
            int randomSubMask = mask & greatRandom;
            return value & (~randomSubMask);
        }

        /// <summary>
        /// Возвращает максимальное число на отрезке последовательности DrunkFibonacci.
        /// </summary>
        /// <param name="from">Индекс начала отрезка. Нумерация с единицы.</param>
        /// <param name="cnt">Длина отрезка.</param>
        public static int GetMaxOnRange(int from, int cnt)
        {
            return GetDrunkFibonacci().Skip(from).Take(cnt).Max();
        }

        /// <summary>
        /// Возвращает следующий отрезок из отрицательных значений последовательности DrunkFibonacci в виде списка, начиная поиск с индекса <see cref="from"/>.
        /// </summary>
        /// <param name="from">Индекс начала поиска отрезка. Нумерация с единицы.</param>
        public static List<int> GetNextNegativeRange(int from = 1)
        {
            return GetDrunkFibonacci()
                .SkipWhile(x => x < 0)
                .TakeWhile(x => x < 0)
                .ToList();
        }

        /// <summary>
        /// Возвращает последовательность чисел вида F(i) = DrunkFibonacci(i) XOR DrunkFibonacci(i + 42)
        /// </summary>
        public static IEnumerable<int> GetXoredWithLaggedItself()
        {
            var shifted = GenerateFibonacci().Skip(42);
            return GetDrunkFibonacci().Zip(shifted, (a, b) => a ^ b);
        }

        /// <summary>
        /// Возвращает последовательность DrunkFibonacci пачками по 16 значений.
        /// </summary>
        public static IEnumerable<int[]> GetInChunks()
        {
            const int bucketSize = 16;
            int i = 0;
            var bucket = new int[bucketSize];
            foreach (var number in GetDrunkFibonacci())
            {
                if (i >= bucketSize)
                {
                    yield return bucket;
                    bucket = new int[bucketSize];
                    i = 0;
                }
                bucket[i] = number;
                i++;
            }
        }

        /// <summary>
        /// Возвращает выравненную последовательность GetInChunks, где из каждой пачки берется только 3 самых маленьких по модулю значения.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> FlattenChunkedSequence()
        {
            /*
                Узнаешь о встроенных функциях сортировки и функции SelectMany,
                которая сглаживает (flatten) последовательность последовательностей в просто последовательность.

                Вообще говоря, SelectMany умеет много чего и мегаполезна.
                Она в какой-то степени эквивалентна оператору `bind` над монадами (в данном случае над монадами последовательностей).
            */
            return GetInChunks().SelectMany(ints => ints.OrderBy(x => -Math.Abs(x)).Take(3));
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
            return GetDrunkFibonacci()
                .Take(10000)
                .GroupBy(x => x % 8)
                .ToDictionary(grouping => grouping.Key, grouping => grouping.Count());
        }
    }
}