﻿using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;

namespace WubbaLubbaDubDub
{
    public static class RicksMercilessEncryptor
    {
        /// <summary>
        /// Возвращает массив строк исходного текста.
        /// </summary>
        public static string[] SplitToLines(this string text)
        {
            return text.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
        }

        /// <summary>
        /// Возвращает массив слов исходной строки.
        /// В данной реализации внутри слова и в начале могут быть посторонние знаки (например, "don't", "1.234", "@pkuderov", "AAAAA!!!@@#@#AAA")
        /// Вообще говоря, нужно точное ТЗ на "слово" и вспоминается 2 задание. 
        /// </summary>
        public static string[] SplitToWords(this string line)
        {
            return Regex.Matches(line, @"\w*[^\s]*\w+").Select(match => match.Value).ToArray();
        }

        /// <summary>
        /// Возвращает левую половину строки, где граница считается с округлением вниз.
        /// Т.е. и для длины 2n, и для длины 2n + 1 -> первые n символов.
        /// </summary>
        public static string GetLeftHalf(this string s)
        {
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
            return s.Replace(old, @new);
        }

        /// <summary>
        /// Возвращает строку, у которой каждый символ заменен на \uFFFF,
        /// где FFFF - соответствующая шестнадцатиричная кодовая точка.
        /// </summary>
        public static string CharsToCodes(this string s)
        {
            return string.Concat(s.Select(CharToCode));

            string CharToCode(char c)
            {
                return $"\\u{Convert.ToInt32(c):X4}";
            }
        }

        /// <summary>
        /// Возвращает строку задом наперёд.
        /// </summary>
        public static string GetReversed(this string s)
        {
            return string.Concat(s.Reverse());
        }

        /// <summary>
        /// Возвращает строку, у которой регистр букв заменён на противоположный.
        /// </summary>
        public static string InverseCase(this string s)
        {
            return string.Concat(s.Select(c => char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)));
        }

        /// <summary>
        /// Возвращает строку, у которой каждый символ заменен на следующий за ним символ Юникода.
        /// Т.е. каждый символ с кодовой точкой X заменен на символ с кодовой точкой X+1.
        /// </summary>
        public static string ShiftInc(this string s)
        {
            return string.Concat(s.Select(c => $"{char.ConvertFromUtf32(Convert.ToInt32(c) + 1)}"));
        }


        #region Чуть посложнее

        /// <summary>
        /// Возвращает список уникальных идентификаторов объектов, используемых в тексте <see cref="text"/>.
        /// Идентификаторы объектов имеют длину 8байт и представлены в тексте в виде ¶X:Y¶, где X - старшие 4 байта, а Y - младшие 4 байта.
        /// Текст <see cref="text"/> так же содержит строчные (//) и блоковые (/**/) комментарии, которые нужно игнорировать.
        /// Т.е. в комментариях идентификаторы объектов искать не нужно. И, кстати, блоковые комментарии могут быть многострочными.
        /// </summary>
        public static IImmutableList<long> GetUsedObjects(this string text)
        {
            var id = new Regex("[0-9A-Fa-f]{4}:[0-9A-Fa-f]{4}");
            var comment = new Regex(@"//.*|/\*((?!(\*/)).|\n|\r)*\*/");

            return comment.Split(text)
                .SelectMany(txt => id.Matches(txt).Select(match => match.Groups[0].Value))
                .Select(s => Convert.ToInt64(s.Replace(":", string.Empty), 16))
                .ToImmutableList();
        }

        #endregion
    }
}
