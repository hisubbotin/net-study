using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
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
            return text.Split(Environment.NewLine);
        }

        /// <summary>
        /// Возвращает массив слов исходной строки.
        /// </summary>
        public static string[] SplitToWords(this string line)
        {
            var wordsRegex = new Regex(@"\b\w+\b");
            return wordsRegex.Matches(line)
                .Select(match => match.Value)
                .ToArray();
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
            var restLength = s.Length - s.Length / 2;
            return s.Substring(s.Length / 2, restLength);
        }

        /// <summary>
        /// Возвращает строку, в которой все вхождения строки <see cref="old"/> заменены на строку <see cref="@new"/>.
        /// </summary>
        public static string ReplaceExt(this string s, string old, string @new)
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
                return $"\\u{Convert.ToUInt32(c):X4}";
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
            return string.Concat(s.Select(ch => char.IsLower(ch) ? char.ToUpper(ch) : char.ToLower(ch)));
        }

        /// <summary>
        /// Возвращает строку, у которой каждый символ заменен на следующий за ним символ Юникода.
        /// Т.е. каждый символ с кодовой точкой X заменен на символ с кодовой точкой X+1.
        /// </summary>
        public static string ShiftInc(this string s)
        {
            return string.Concat(s.Select(c => (char) (c + 1)));
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
            /*
                Задача на поиграться с регулярками - вся сложность в том, чтобы аккуратно игнорировать комментарии.
                Экспериментировать онлайн можно, например, здесь: http://regexstorm.net/tester и https://regexr.com/
            */
            string s1 = Vzhuh(text);
            string[] ids = ExtractIdentifiers(s1).ToArray();

            var result = ids.Select(ConvertIdentifierToLong).ToArray();
            return ImmutableList.Create(result);

            string Vzhuh(string s)
            {
                return Regex.Replace(s,
                    @"(@(?:""[^""]*"")+|""(?:[^""\n\\]+|\\.)*""|'(?:[^'\n\\]+|\\.)*')|//.*|/\*(?s:.*?)\*/", " ");
            }

            IEnumerable<string> ExtractIdentifiers(string s)
            {
                var regexId = new Regex("¶[0-9a-fA-F]{4}:[0-9a-fA-F]{4}¶");
                return regexId.Matches(s).Select(match => match.Value);
            }

            long ConvertIdentifierToLong(string idStr)
            {
                string[] parts = Regex.Matches(idStr, @"[0-9a-fA-F]{4}")
                    .Select(match => match.Value)
                    .ToArray();

                Debug.Assert(parts.Length == 2);
                return (ConvertHexStrToLong(parts[0]) << 16)
                       + ConvertHexStrToLong(parts[1]);
            }

            long ConvertHexStrToLong(string hexStr)
            {
                return Convert.ToInt64(hexStr, 16);
            }
        }

        #endregion
    }
}