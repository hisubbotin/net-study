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
            return text.Split('\n');
        }

        /// <summary>
        /// Возвращает массив слов исходной строки.
        /// </summary>
        public static string[] SplitToWords(this string line)
        {
            return Regex.Matches(line, "([A-Za-z]+)")
                .OfType<Match>()
                .Select(m => m.Value)
                .ToArray();
        }

        /// <summary>
        /// Возвращает левую половину строки, где граница считается с округлением вниз.
        /// Т.е. и для длины 2n, и для длины 2n + 1 -> первые n символов.
        /// </summary>
        public static string GetLeftHalf(this string s)
        {
            // у строки есть метод получения подстроки
            return s.Substring(0, s.Length / 2);
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
            return string.Concat(s.ToCharArray().Select(c => ToUTF16(c)).ToArray());

            string ToUTF16(char c)
            {
                return "\\u" + ((int)c).ToString("X4");
            }
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
            return string.Concat(Reverse(s));

            char[] Reverse(string s)
            {
                char[] rev = new char[s.Length];
                for (int i = 0; i < s.Length; ++i)
                {
                    rev[i] = s[s.Length - 1 - i];
                }
                return rev;
            }
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

            return string.Concat(
                s.ToCharArray().Select(c => Inverse(c)).ToArray());

            char Inverse(char c)
            {
                if (char.IsLower(c))
                {
                    return char.ToUpper(c);
                }
                return char.ToLower(c);
            }
        }

        /// <summary>
        /// Возвращает строку, у которой каждый символ заменен на следующий за ним символ Юникода.
        /// Т.е. каждый символ с кодовой точкой X заменен на символ с кодовой точкой X+1.
        /// </summary>
        public static string ShiftInc(this string s)
        {
            return string.Concat(
                s.ToCharArray().Select(c => (char)(c + 1)).ToArray());
        }


        #region Чуть посложнее

        /// <summary>
        /// Возвращает список уникальных идентификаторов объектов, используемых
        /// в тексте <see cref="text"/>.  Идентификаторы объектов имеют длину
        /// 8байт и представлены в тексте в виде ¶X:Y¶, где X - старшие 4 байта,
        /// а Y - младшие 4 байта.  Текст <see cref="text"/> так же содержит
        /// строчные (//) и блоковые (/**/) комментарии, которые нужно
        /// игнорировать.  Т.е. в комментариях идентификаторы объектов искать не
        /// нужно. И, кстати, блоковые комментарии могут быть многострочными.
        /// </summary>

        public static IImmutableList<long> GetUsedObjects(this string text)
        //public static string GetUsedObjects(this string text)
        {
            /*
                Задача на поиграться с регулярками - вся сложность в том, чтобы аккуратно игнорировать комментарии.
                Экспериментировать онлайн можно, например, здесь: http://regexstorm.net/tester и https://regexr.com/
            */
            // Filter comments: https://stackoverflow.com/a/12089866
            text = Regex.Replace(
                text, "(/\\*([^*]|[\r\n]|(\\*+([^*/]|[\r\n])))*\\*+/)|(//.*)", "");

            return Regex.Matches(text, "([\\da-fA-F]{4}:[\\da-fA-F]{4})")
                .OfType<Match>()
                .Select(m => Convert.ToInt64(m.Value.Replace(":", ""), 16))
                .ToImmutableList();
        }

        #endregion
    }
}
