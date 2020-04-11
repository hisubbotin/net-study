using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;
using System.Linq;

namespace WubbaLubbaDubDub
{
    public static class RicksMercilessEncryptor
    {
        /// <summary>
        /// Возвращает массив строк исходного текста.
        /// </summary>
        public static string[] SplitToLines(this string text)
        {
            string[] strings = text.Split(new char[] { '\n' });
            // У строки есть специальный метод. Давай здесь без регулярок
            return strings;
        }

        /// <summary>
        /// Возвращает массив слов исходной строки.
        /// </summary>
        public static string[] SplitToWords(this string line)
        {
            string[] strings = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return strings;
        }

        /// <summary>
        /// Возвращает левую половину строки, где граница считается с округлением вниз.
        /// Т.е. и для длины 2n, и для длины 2n + 1 -> первые n символов.
        /// </summary>
        public static string GetLeftHalf(this string s)
        {
            // у строки есть метод получения подстроки
            return  s.Substring(0, s.Length/2);
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
            string CharToCode(char c)
            {
                return String.Format("\\u{0:x4}", (int)c);
            }

            string[] parts = new string[s.Length];
            for (var i = 0; i < s.Length; ++i)
            {
                parts[i]=CharToCode(s[i]);
            }

            return string.Concat(parts);
        }

        /// <summary>
        /// Возвращает строку задом наперёд.
        /// </summary>
        public static string GetReversed(this string s)
        {
            char[] chars = new char[s.Length];
            for (var i = s.Length - 1; i >= 0; --i)
            {
                chars[s.Length - i - 1] = s[i];
            }
            return string.Concat(chars);

            /*
                Собрать строку из последовательности строк можно несколькими способами.
                Один из низ - статический метод Concat. Но ты можешь выбрать любой.
            */

        }

        /// <summary>
        /// Возвращает строку, у которой регистр букв заменён на противоположный.
        /// </summary>
        public static string InverseCase(this string s)
        {

            char[] chars = new char[s.Length];
            for (var i = 0; i < s.Length; ++i)
            {
                chars[i] = (char.IsLower(s[i]) ? char.ToUpper(s[i]) : char.ToLower(s[i]));
            }
            return string.Concat(chars);
            
            /*
                Здесь тебе помогут статические методы типа char.
                На минуту задержись здесь и посмотри, какие еще есть статические методы у char.
                Например, он содержит методы-предикаты для определения категории Юникода символа, что очень удобно.
            */
        }

        /// <summary>
        /// Возвращает строку, у которой каждый символ заменен на следующий за ним символ Юникода.
        /// Т.е. каждый символ с кодовой точкой X заменен на символ с кодовой точкой X+1.
        /// </summary>
        public static string ShiftInc(this string s)
        {
            char[] chars = new char[s.Length];
            for (var i = 0; i < s.Length; ++i)
            {
                chars[i] = (char)(s[i] + 1);
            }
            return string.Concat(chars);
           
        }


        #region Чуть посложнее

        /// <summary>
        /// Возвращает список уникальных идентификаторов объектов, используемых в тексте <see cref="text"/>.
        /// Идентификаторы объектов имеют длину 8байт и представлены в тексте в виде ¶X:Y¶, где X - старшие 4 байта, 
        /// а Y - младшие 4 байта.
        /// Текст <see cref="text"/> так же содержит строчные (//) и блоковые (/**/) комментарии,
        /// которые нужно игнорировать.
        /// Т.е. в комментариях идентификаторы объектов искать не нужно. И, кстати,
        /// блоковые комментарии могут быть многострочными.
        /// </summary>
        public static IImmutableList<long> GetUsedObjects(this string text)
        {
            /*
                Задача на поиграться с регулярками - вся сложность в том, чтобы аккуратно игнорировать комментарии.
                Экспериментировать онлайн можно, например, здесь: http://regexstorm.net/tester и https://regexr.com/
            */
            string withoutComments = Regex.Replace(text, @"(\/\*((?!\*\/)(.|\n))*\*\/)|(\/\/.*)", " ");
            var result = Regex.Matches(withoutComments, @"([0-9A-F]{4}):([0-9A-F]{4})");
            return result.OfType<Match>().Select(str => str.Value.Replace(":", "")).Distinct().Select(Id => Convert.ToInt64(Id)).ToImmutableList();
           
        }
        

        #endregion
    }
}
