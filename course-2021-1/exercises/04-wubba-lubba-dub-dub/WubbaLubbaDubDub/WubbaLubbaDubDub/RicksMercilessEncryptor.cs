using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            // У строки есть специальный метод. Давай здесь без регулярок

            return text.Split("\n");
        }

        /// <summary>
        /// Возвращает массив слов исходной строки.
        /// </summary>
        public static string[] SplitToWords(this string line)
        {
            // А вот здесь поиграйся с регулярками.
            string regExpression = @"[ \n\t\0]";
            return Regex.Split(line, regExpression).Where(s => !String.IsNullOrEmpty(s)).ToArray();
        }

        /// <summary>
        /// Возвращает левую половину строки, где граница считается с округлением вниз.
        /// Т.е. и для длины 2n, и для длины 2n + 1 -> первые n символов.
        /// </summary>
        public static string GetLeftHalf(this string s)
        {
            // у строки есть метод получения подстроки
            return s.Substring(0,s.Length/2);
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
            string newString = "";
            foreach (char t in s)
            {
                newString += ConvertToCode(t);
            }

            return newString;

                string ConvertToCode(char c)
            {
                return "\\u" + Convert.ToByte(c).ToString("X4");
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
            string newString = "";

            for (int i = s.Length - 1; i >= 0; i--)
            {
                newString += s[i];
            }

            return newString;
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
            string newString = "";
            foreach (char c in s)
            {
                if (Char.IsLower(c))
                {
                    newString += Char.ToUpperInvariant(c);
                }
                else
                {
                    newString += Char.ToLowerInvariant(c);
                }
            }

            return newString;
        }

        /// <summary>
        /// Возвращает строку, у которой каждый символ заменен на следующий за ним символ Юникода.
        /// Т.е. каждый символ с кодовой точкой X заменен на символ с кодовой точкой X+1.
        /// </summary>
        public static string ShiftInc(this string s)
        {
            string newString = "";

            

            foreach (char c in s)
            {
                newString += (char)(Convert.ToByte(c) + 1);
            }

            return newString;
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
            string blockComments = @"/\*(.*?)\*/";
            string lineComments = @"\/\/[^\n\r]+(?:[\n\r]|\*\))*";

            string regexExpression = blockComments + "|" + lineComments;

            string newString = Regex.Replace(text, regexExpression, block =>
            {
                File.AppendAllText("output.txt", block.Value);
                if (block.Value.StartsWith("/*") || block.Value.StartsWith("//"))
                    return "";
                return block.Value;
            });

            string idPattern = @"\¶[0-9A-Fa-f]{4}:[0-9A-Fa-f]{4}\¶";
            string idInnerPattern = @"[\¶:]";
            var ids = Regex.Matches(newString, idPattern);


            List<long> idsList = new List<long>();
            foreach (Match idMatch in ids)
            {
                var splitted = Regex.Split(idMatch.Value, idInnerPattern);
                idsList.Add(Convert.ToInt64(splitted[1] + splitted[2], 16));

            }

            return idsList.ToImmutableArray();
        }

        #endregion
    }
}
