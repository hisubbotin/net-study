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
            arr[0] = seed;
            for (int i = 1; i < arr.Length; i++)
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
            const int seed = 1;
            Random rand = new Random(seed);
            while (true)
            {
                yield return rand.Next();
            }
        }

        private static bool nextIterationForget(int count)
        {
            return ((count + 1)% 6) == 0;
        }

        private static bool nextIterationJoke(int count)
        {
            return ((count + 1) % 6) == 4;
        }

        private static void shiftWindow(ref int cur, ref int next, ref int count)
        {
            count++;
            next = next + cur;
            cur = next - cur;
        }
        
        /// <summary>
        /// Проверяет есть ли у left, биты right
        /// </summary>
        /// <param name="left">проверяемое число</param>
        /// <param name="right">маска</param>
        /// <returns>
        /// true: если left имеет хотя бы 1 бит из right
        /// </returns>
        private static bool hasOneBits(int left, int right)
        {
            return (left & right) != 0;
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
            int cur = 0;
            int next = 1;
            // В новой последовательность 2- е модификации: повторения и вставки 300, sзануление битов не учитывается в формировании последовательности
            // см. определение ф-ции
            int count = 0;
            while (true)
            {
                var iter = GetDeterministicRandomSequence();
                int Y = iter.GetEnumerator().Current;
                shiftWindow( ref cur, ref next, ref count);
                if ( nextIterationForget(count) )
                {
                    next = next + cur;
                }
                if( nextIterationJoke(count) )
                {
                    next = 300;
                }
                int val = cur;
                /*if ( hasOneBits(Y, 42) )
                {
                    val = val & ~42;
                }*/
                yield return val;
            }
        }

        /// <summary>
        /// Возвращает максимальное число на отрезке последовательности DrunkFibonacci.
        /// </summary>
        /// <param name="from">Индекс начала отрезка. Нумерация с единицы.</param>
        /// <param name="cnt">Длина отрезка.</param>
        public static int GetMaxOnRange(int from, int cnt)
        {
            // научишься пропускать и брать фиксированную часть последовательности, агрегировать. Максимум есть среди готовых функций агрегации.
            return GetDrunkFibonacci().Skip(from).Take(cnt).Max();
        }

        /// <summary>
        /// Возвращает следующий отрезок из отрицательных значений последовательности DrunkFibonacci в виде списка, начиная поиск с индекса <see cref="from"/>.
        /// </summary>
        /// <param name="from">Индекс начала поиска отрезка. Нумерация с единицы.</param>
        public static List<int> GetNextNegativeRange(int from = 1)
        {
            // научишься пропускать и брать по условию, превращать в список (см. ToList).
            return GetDrunkFibonacci().Skip(from).SkipWhile(element => element >= 0).TakeWhile(element => element < 0).ToList();
        }

        /// <summary>
        /// Возвращает последовательность чисел вида F(i) = DrunkFibonacci(i) XOR DrunkFibonacci(i + 42)
        /// </summary>
        public static IEnumerable<int> GetXoredWithLaggedItself()
        {
            // узнаешь о существовании функции Zip.
            return GetDrunkFibonacci().Zip(GetDrunkFibonacci().Skip(42), (left, right) => left ^ right);
        }

        /// <summary>
        /// Возвращает последовательность DrunkFibonacci пачками по 16 значений.
        /// </summary>
        public static IEnumerable<int[]> GetInChunks()
        {
            // ни чему особо не научишься, просто интересная задачка :)
            int count = 0;
            int[] arr = CreateIntArray(16);
            foreach (var drunkFib in GetDrunkFibonacci())
            {
                arr[count] = drunkFib;
                count++;
                if (count == 16)
                {
                    count = 0;
                    yield return arr;
                }
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
            return GetInChunks().SelectMany(chunk => chunk.OrderBy(chunkElement => chunkElement).Take(3));
        }

        /// <summary>
        /// Возвращает словарь пар { класс вычета по модулю 8; число значений в классе среди первых 10000 элементов последовательности DrunkFibonacci }.
        /// Учитываются только непустые классы.
        /// </summary>/
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
            return GetDrunkFibonacci().Take(10000).GroupBy(fib => fib % 8).ToDictionary(group => group.Key, group=> group.ToList().Count);
        }
    }
}
