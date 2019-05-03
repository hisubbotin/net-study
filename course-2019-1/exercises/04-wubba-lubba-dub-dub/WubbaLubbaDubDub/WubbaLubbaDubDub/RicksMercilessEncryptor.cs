using System;
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
            string[] stringSeparators = new string[] {Environment.NewLine};
            return text.Split(stringSeparators, 
                            StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Возвращает массив слов исходной строки.
        /// </summary>
        public static string[] SplitToWords(this string line)
        {
            string pattern = @"[\s-.?!)(,:+]";
            return Regex.Split(line, pattern).Where(s => !String.Equals(s, String.Empty)).ToArray();
            // return (from Match match in Regex.Matches(line, pattern) select match.Value).ToList().ToArray();
        }

        /// <summary>
        /// Возвращает левую половину строки, где граница считается с округлением вниз.
        /// Т.е. и для длины 2n, и для длины 2n + 1 -> первые n символов.
        /// </summary>
        public static string GetLeftHalf(this string s)
        {
            int length = s.Length/2;
            return s.Substring(0, length);
        }

        /// <summary>
        /// Возвращает правую половину строки, где граница считается с округлением вниз.
        /// Т.е. для длины 2n: последние n, а для длины 2n + 1 -> последние n + 1 символов.
        /// </summary>
        public static string GetRightHalf(this string s)
        {
            int start_index = s.Length/2;
            return s.Substring(start_index);
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
            StringBuilder sb = new StringBuilder();
            foreach(char c in s) {
                sb.Append(ConvertToCode(c));
            }

            return sb.ToString();

            String ConvertToCode(char c) {
                StringBuilder local_sb = new StringBuilder(@"\u");
                char[] chars = new char[] {c};
                Encoding  u16 = Encoding.Unicode;
                byte[] bytes = u16.GetBytes(chars);
                foreach(byte b in bytes) {
                    local_sb.Append(b);
                }
                return local_sb.ToString();
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
            char[] array = s.ToCharArray();
            array = array.Reverse().ToArray();
            return(String.Concat(array));
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
            return String.Concat((from c in s select ChangeCase(c)).ToArray());

            char ChangeCase(char c) {
                if(char.IsLower(c)) {
                    return char.ToUpper(c);
                } else {
                    return char.ToLower(c);
                }
            }
        }

        /// <summary>
        /// Возвращает строку, у которой каждый символ заменен на следующий за ним символ Юникода.
        /// Т.е. каждый символ с кодовой точкой X заменен на символ с кодовой точкой X+1.
        /// </summary>
        public static string ShiftInc(this string s)
        {
            return String.Concat((from c in s select (char)(c + 1)).ToArray());
        }


        #region Чуть посложнее

        /// <summary>
        /// Возвращает список уникальных идентифика     торов объектов, используемых в тексте <see cref="text"/>.
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
            string rm_comments_pattern = @"(\/\*([^*]|[\r\n]|(\*+([^*\/]|[\r\n])))*\*+\/)|(\/\/.*)";
            string text_no_comments = Regex.Replace(text, rm_comments_pattern, "");
            string id_pattern = @"¶[\s\S][\s\S]:[\s\S][\s\S]¶";
            return (from match in Regex.Matches(text_no_comments, id_pattern) select ExtractId(match.Value)).ToImmutableList();

            long ExtractId(string s) {
                char[] chars = new char[] {s[1], s[2], s[4], s[5]};
                var unicode = Encoding.Unicode;
                return BitConverter.ToInt64(unicode.GetBytes(chars), 0);
            }
        }

        #endregion
    }
}
