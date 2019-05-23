using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace WubbaLubbaDubDub
{
    public static class RicksMercilessEncryptor
    {
        /// <summary>
        /// Возвращает массив строк исходного текста.
        /// </summary>
        public static string[] SplitToLines(this string text) => text.Split("\n");

        /// <summary>
        /// Возвращает массив слов исходной строки.
        /// </summary>
        public static string[] SplitToWords(this string line) => Regex.Split(line, @"[\s,\.?!;:]+");

        /// <summary>
        /// Возвращает левую половину строки, где граница считается с округлением вниз.
        /// Т.е. и для длины 2n, и для длины 2n + 1 -> первые n символов.
        /// </summary>
        public static string GetLeftHalf(this string s) => s.Substring(0, s.Length / 2);

        /// <summary>
        /// Возвращает правую половину строки, где граница считается с округлением вниз.
        /// Т.е. для длины 2n: последние n, а для длины 2n + 1 -> последние n + 1 символов.
        /// </summary>
        public static string GetRightHalf(this string s) => s.Substring(s.Length / 2);

        /// <summary>
        /// Возвращает строку, в которой все вхождения строки <see cref="old"/> заменены на строку <see cref="@new"/>.
        /// </summary>
        public static string Replace(this string s, string old, string @new) => s.Replace(old, @new);

        /// <summary>
        /// Возвращает строку, у которой каждый символ заменен на \uFFFF,
        /// где FFFF - соответствующая шестнадцатиричная кодовая точка.
        /// </summary>
        public static string CharsToCodes(this string s)
        {
            string CharToCode(char c) => string.Format("\\u{0}", ((int) c).ToString("X4"));

            string codes = "";
            for (int i = 0; i < s.Length; ++i)
            {
                codes += CharToCode(s[i]);
            }

            return codes;
        }

        /// <summary>
        /// Возвращает строку задом наперёд.
        /// </summary>
        public static string GetReversed(this string s)
        {
            string reversed = "";
            for (int i = s.Length - 1; i >= 0; --i)
            {
                reversed += s[i];
            }

            return reversed;
        }

        /// <summary>
        /// Возвращает строку, у которой регистр букв заменён на противоположный.
        /// </summary>
        public static string InverseCase(this string s)
        {
            string inversed = "";
            for (int i = 0; i < s.Length; ++i)
            {
                inversed += char.IsLower(s[i]) ? char.ToUpper(s[i]) :
                    char.IsUpper(s[i]) ? char.ToLower(s[i]) : s[i];
            }

            return inversed;
        }

        /// <summary>
        /// Возвращает строку, у которой каждый символ заменен на следующий за ним символ Юникода.
        /// Т.е. каждый символ с кодовой точкой X заменен на символ с кодовой точкой X+1.
        /// </summary>
        public static string ShiftInc(this string s)
        {
            string shifted = "";
            for (int i = 0; i < s.Length; ++i)
            {
                shifted += (char) (s[i] + 1);
            }

            return shifted;
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
            string objectId = @"¶[0-9a-fA-F]{8}:[0-9a-fA-F]{8}¶";
            string comments = @"/\*[\s\S]*?\*/|//.*?\n";

            string clearedText = string.Concat(Regex.Split(text, comments));
            MatchCollection matches = Regex.Matches(clearedText, objectId);
            var result = new List<long>();
            foreach (Match s in matches)
            {
                long id = (long.Parse(s.Value.Substring(1, 8), System.Globalization.NumberStyles.HexNumber) << 32) |
                    long.Parse(s.Value.Substring(10, 8), System.Globalization.NumberStyles.HexNumber);
                result.Add(id);
            }

            return result.ToImmutableList();
        }

        #endregion
    }
}
