using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;

namespace DrunkFibonacci
{
    public class RandomEnumerator : IEnumerator<int>
    {

        private Random _rand;
        private int _random_seed;
        private int _current_elem;

        public RandomEnumerator(int random_seed)
        {
            _rand = new Random(random_seed);
            _random_seed = random_seed;
            _current_elem = _rand.Next();
        }

        public bool MoveNext()
        {
            _current_elem = _rand.Next();
            return true;
        }

        public void Reset()
        {
            _rand = new Random(_random_seed);
            _current_elem = _rand.Next();
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public int Current
        {
            get
            {
                return _current_elem;
            }
        }

        public void Dispose()
        {
            
        }
    }

    public class RandomGenerator: IEnumerable<int> {

        private int _random_seed;

        public RandomGenerator(int random_seed) {
            _random_seed = random_seed;
        }

        
        public IEnumerator<int> GetEnumerator()
        {
            return new RandomEnumerator(_random_seed);
        }

        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator1();
        }

    }
    
    internal static class DrunkFibonacci
    {
        /// <summary>
        /// Создает пустой массив заданной длины.
        /// </summary>
        /// <param name="len">Длина массива</param>
        public static int[] CreateIntArray(int len)
        {
            // на создание массивов заданной длины
            var res_array = new int[len];
            for(int i = 0 ; i < len ; ++i) {
                res_array[i] = 0;
            }
            return res_array;
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
            if(arr.Length == 0) {
                return;
            }
            arr[0] = seed;
            for(int i = 1; i < arr.Length; ++i) {
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
            var res_array = new int[5];
            res_array[0] = 1;
            res_array[1] = 1;
            res_array[3] = 2;
            res_array[4] = 3;
            res_array[5] = 5;
            return res_array;
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
            int random_seed = 42;
            return new RandomGenerator(random_seed);
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
            int curr = 1;
            int prev = 0;
            int round = 0;

            foreach(int rnd_num in DrunkFibonacci.GetDeterministicRandomSequence()) {
                int res = curr;

                // update number
                int buff = curr;
                curr = unchecked(prev + buff);
                prev = buff;

                // forget the number
                if(round == 5) {
                    round += 1;
                    round %= 6;
                    continue;
                }

                // joke for trista
                if(round == 3 && prev != 5) {
                    res = 300;
                }

                if((rnd_num & 42) != 0) {
                    res &= ~42;
                }

                round += 1;
                round %= 6;

                yield return res;
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
            return DrunkFibonacci.GetDrunkFibonacci()
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
            // научишься пропускать и брать по условию, превращать в список (см. ToList).
            return DrunkFibonacci.GetDrunkFibonacci()
                .Skip(from - 1)
                .SkipWhile(val => val >= 0)
                .TakeWhile(val => val < 0)
                .ToList();
        }

        /// <summary>
        /// Возвращает последовательность чисел вида F(i) = DrunkFibonacci(i) XOR DrunkFibonacci(i + 42)
        /// </summary>
        public static IEnumerable<int> GetXoredWithLaggedItself()
        {
            // узнаешь о существовании функции Zip.
            return DrunkFibonacci.GetDrunkFibonacci()
                .Zip(DrunkFibonacci.GetDrunkFibonacci().Skip(42), (x, y) => x ^ y);
        }

        /// <summary>
        /// Возвращает последовательность DrunkFibonacci пачками по 16 значений.
        /// </summary>
        public static IEnumerable<int[]> GetInChunks()
        {
            // ни чему особо не научишься, просто интересная задачка :)
            int pos = 0;
            while(true) {
                yield return DrunkFibonacci.GetDrunkFibonacci().Skip(pos * 16).Take(16).ToArray();
                pos += 1;
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
            return DrunkFibonacci.GetInChunks()
                .SelectMany(el => Sorter(el).Take(3));
                
            
            int[] Sorter(int[] arr) {
                Array.Sort(arr);
                return arr;
            }
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
            return DrunkFibonacci.GetDrunkFibonacci()
                .Take(10000)
                .ToLookup(elem => Math.Abs(elem) % 8, elem => elem)
                .ToDictionary(elem => elem.Key, elem => elem.Count());
        }
    }
}
