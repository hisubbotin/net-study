﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace WubbaLubbaDubDub
{
    public static class RicksMercilessEncryptor
    {
        /// <summary>
        /// Возвращает массив строк исходного текста.
        /// </summary>
        public static string[] SplitToLines(this string text)
        {
            // У строки есть специальный метод. Давай здесь без регулярок
            return text.Split('\n');
        }

        /// <summary>
        /// Возвращает массив слов исходной строки.
        /// </summary>
        public static string[] SplitToWords(this string line)
        {
            // А вот здесь поиграйся с регулярками.
            string pattern = @"\.\s*|\s+|\!\s*|\?\s*";
            return Regex.Split(line, pattern).Where(x => x.Length > 0).ToArray();
        }

        /// <summary>
        /// Возвращает левую половину строки, где граница считается с округлением вниз.
        /// Т.е. и для длины 2n, и для длины 2n + 1 -> первые n символов.
        /// </summary>
        public static string GetLeftHalf(this string s)
        {
            // у строки есть метод получения подстроки
            return s.Substring(0 , s.Length / 2);
        }

        /// <summary>
        /// Возвращает правую половину строки, где граница считается с округлением вниз.
        /// Т.е. для длины 2n: последние n, а для длины 2n + 1 -> последние n + 1 символов.
        /// </summary>
        public static string GetRightHalf(this string s)
        {
            return s.Substring(s.Length / 2);
        }

        /// <summary>
        /// Возвращает строку, в которой все вхождения строки <see cref="old"/> заменены на строку <see cref="@new"/>.
        /// </summary>
        public static string Replace(this string s, string old, string @new)
        {
            // и такой метод у строки, очевидно, тоже есть
            return s.Replace(old, @new);
        }

        /// <summary>
        /// Возвращает строку, у которой каждый символ заменен на \uFFFF,
        /// где FFFF - соответствующая шестнадцатиричная кодовая точка.
        /// </summary>
        public static string CharsToCodes(this string s)
        {
            /*
                Может быть удобным здесь же сначала написать локальную функцию
                которая содержит логику для преобразования одного символа,
                а затем использовать её для посимвольного преобразования всей строки.
                FYI: локальную функцию можно объявлять даже после строки с return.
                То же самое можно сделать и для всех оставшихся методов.
            */
            return s.Select(c => ((int)c).ToString("X4")).
                Aggregate("", (x, y) => x + "u" + y);           
        }

        /// <summary>
        /// Возвращает строку задом наперёд.
        /// </summary>
        public static string GetReversed(this string s)
        {
            /*
                Собрать строку из последовательности строк можно несколькими способами.
                Один из низ - статический метод Concat. Но ты можешь выбрать любой.
            */
            return s.Reverse().Aggregate("",(string x, char y) => x + y);
        }

        /// <summary>
        /// Возвращает строку, у которой регистр букв заменён на противоположный.
        /// </summary>
        public static string InverseCase(this string s)
        {
            /*
                Здесь тебе помогут статические методы типа char.
                На минуту задержись здесь и посмотри, какие еще есть статические методы у char.
                Например, он содержит методы-предикаты для определения категории Юникода символа, что очень удобно.
            */
            return s.Select(c => char.IsLower(c) ? char.ToUpper(c) :
                char.IsUpper(c) ? char.ToLower(c) : c).
                Aggregate("", (string x, char y) => x + y);
        }

        /// <summary>
        /// Возвращает строку, у которой каждый символ заменен на следующий за ним символ Юникода.
        /// Т.е. каждый символ с кодовой точкой X заменен на символ с кодовой точкой X+1.
        /// </summary>
        public static string ShiftInc(this string s)
        {
            return s.Select(c => (char)(c + 1)).
                Aggregate("", (string x, char y) => x + y);
        }


        #region Чуть посложнее

        /// <summary>
        /// Возвращает список уникальных идентификаторов объектов, используемых в тексте <see cref="text"/>.
        /// Идентификаторы объектов имеют длину 8байт и представлены в тексте в виде ¶X:Y¶, где X - старшие 4 байта, а Y - младшие 4 байта.
        /// Текст <see cref="text"/> так же содержит строчные (//) и блоковые (/**/) комментарии, которые нужно игнорировать.
        /// Т.е. в комментариях идентификаторы объектов искать не нужно. И, кстати, блоковые комментарии могут быть многострочными.
        /// </summary>
        public static IEnumerable<long> GetUsedObjects(this string text)
        {

            /*
                Задача на поиграться с регулярками - вся сложность в том, чтобы аккуратно игнорировать комментарии.
                Экспериментировать онлайн можно, например, здесь: http://regexstorm.net/tester и https://regexr.com/
            */
            // 1. Удаляем однострочные комментарии
            string result = Regex.Replace(text, "//.*", " ");
            // 2. Преобразуем текст в одну строку, убираем \n
            result = result.Replace('\n', ' ');
            // 3. Убираем многострочные комментарии
            result = Regex.Replace(result, @"/\*.*\*/", " ");
            // 4. Находим нужные идентификаторы
            var matches = Regex.Matches(result, @"¶(\w{4}):(\w{4})¶");
            HashSet<long> hashSet = new HashSet<long>();
            foreach (Match match in matches)
            {
                var a = match.Groups[1].Value + match.Groups[2].Value;
                byte[] toBytes = Encoding.ASCII.GetBytes(a);
                long toLong = BitConverter.ToInt64(toBytes, 0);
                hashSet.Add(toLong);
            }
            return hashSet;           
        }

        #endregion
    }
}
