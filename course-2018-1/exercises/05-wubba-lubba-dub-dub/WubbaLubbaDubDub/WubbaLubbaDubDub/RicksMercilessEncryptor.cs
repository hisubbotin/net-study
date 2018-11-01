using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design;
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
            return text.Split('\n').Where(line => line != "").ToArray();
        }

        /// <summary>
        /// Возвращает массив слов исходной строки.
        /// </summary>
        public static string[] SplitToWords(this string line)
        {
            return Regex.Split(line, "[ |.|!|:|;|,]+");
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
            var result = "";
            foreach (var c in s)
            {
                result += GetCode(c);
            }

            return result;

            string GetCode(char c)
            {
                return "\\u" + Convert.ToByte(c).ToString("x4");
            }
        }

        /// <summary>
        /// Возвращает строку задом наперёд.
        /// </summary>
        public static string GetReversed(this string s)
        {
            return new string(s.ToCharArray().Reverse().ToArray());
        }

        /// <summary>
        /// Возвращает строку, у которой регистр букв заменён на противоположный.
        /// </summary>
        public static string InverseCase(this string s)
        {
            var charArray = s.ToCharArray();
            for (var i = 0 ; i < charArray.Length; ++i)
            {
                if (Char.IsLower(charArray[i]))
                {
                    charArray[i] = Char.ToUpper(charArray[i]);
                }
                else
                {
                    charArray[i] = Char.ToLower(charArray[i]);
                }

            }

            return new string(charArray);
        }

        /// <summary>
        /// Возвращает строку, у которой каждый символ заменен на следующий за ним символ Юникода.
        /// Т.е. каждый символ с кодовой точкой X заменен на символ с кодовой точкой X+1.
        /// </summary>
        public static string ShiftInc(this string s)
        {
            var result = "";
            foreach (char c in s)
            {
                result += ShiftChar(c);
            }

            return result;

            char ShiftChar(char c)
            {
                return Convert.ToChar(Convert.ToByte(c) + 1);
            }
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

            var noCommentsString = Regex.Replace(text, "//[^\n]*\n|/\\*(.|\\n)*\\*/", "");
            var result = new Regex("¶[A-F0-9]{4}:[A-F0-9]{4}¶")
                .Matches(noCommentsString)
                .Select(matched => Convert.ToInt64(matched.Value.Substring(1, matched.Value.Length - 2)
                    .Replace(":", ""), 16))
                .ToImmutableList();
            return result;
        }

        #endregion
    }
}
