﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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
            return text.Split(new [] {"\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Возвращает массив слов исходной строки.
        /// </summary>
        public static string[] SplitToWords(this string line)
        {
            // А вот здесь поиграйся с регулярками.
            Regex reg1 = new Regex(@"\p{P}");
            Regex reg2 = new Regex(@"\s");
            string[] s = Regex.Split(line, reg1 + "|" + reg2);
            string[] y = s.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            return y;
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
            return s.Substring(s.Length / 2 );
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
            string CharToCodePoint(char c)
            {
                
                //String.Concat(new string[] {@"\\u",  Char.ConvertToUtf32(new string(c,1), 0).ToString() });
                string k = $"\\u{Char.ConvertToUtf32(new string(c, 1), 0):X4}";
                return k;
            }
            return string.Join(string.Empty, s.Select(ch => CharToCodePoint(ch)));
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
            StringBuilder builder = new StringBuilder();
            for(int i = s.Length - 1; i >= 0; i-- )
            {
                builder.Append(s[i]);
            }
            return builder.ToString();
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
            StringBuilder builder = new StringBuilder();
            foreach (var ch in s)
            {
                builder.Append(Char.IsUpper(ch) ? Char.ToLower(ch) : Char.ToUpper(ch));
            }
            return builder.ToString();
        }

        /// <summary>
        /// Возвращает строку, у которой каждый символ заменен на следующий за ним символ Юникода.
        /// Т.е. каждый символ с кодовой точкой X заменен на символ с кодовой точкой X+1.
        /// </summary>
        public static string ShiftInc(this string s)
        {
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < s.Length; i++)
            {
                builder.Append(Char.ConvertFromUtf32(Char.ConvertToUtf32(s, i) + 1));
;            }
            return builder.ToString();
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
            // Убираем /* */
            var toErase = new Regex(@"\/\*[^*]*\*+([^\/][^*]*\*+)*\/");
            var splited = toErase.Split(text);
            text = String.Join("", splited);
            // Убираем //
            toErase = new Regex(@"\/\/[^*]*\n");
            var splited2 = toErase.Split(text);
            var name = new Regex(@"[A-Za-z]\w:\w\w");
            // Выделяем X:Y
            var selected = splited2.Select(txt => name.Match(txt) );
            var enumer = selected.GetEnumerator();
            List<long> builder = new List<long>();
            while (enumer.MoveNext())
            {
                if (enumer.Current.ToString() != "")
                {
                    var v = enumer.Current;
                    string k = v.ToString();
                    string p = k.Replace(":", string.Empty);
                    char[] z = p.ToCharArray();
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(z);
                    builder.Add(BitConverter.ToInt32(bytes, 0));
                }
            }

            return  builder.ToImmutableList();
        }

        #endregion
    }
}
