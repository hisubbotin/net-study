using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace WubbaLubbaDubDub
{
    public static class RicksMercilessEncryptor
    {
        /// <summary>
        /// Возвращает массив строк исходного текста.
        /// </summary>
        public static string[] SplitToLines(this string text)
        {
            text.Split('\n');
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает массив слов исходной строки.
        /// </summary>
        public static string[] SplitToWords(this string line)
        {
            Regex regex = new Regex(@"\w");
            return regex.Match(line)
                .Cast<Match>()
                .Select(m => m.Value)
                .ToArray();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает левую половину строки, где граница считается с округлением вниз.
        /// Т.е. и для длины 2n, и для длины 2n + 1 -> первые n символов.
        /// </summary>
        public static string GetLeftHalf(this string s)
        {
            return s.Substring(0, s.Length / 2 - 1);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает правую половину строки, где граница считается с округлением вниз.
        /// Т.е. для длины 2n: последние n, а для длины 2n + 1 -> последние n + 1 символов.
        /// </summary>
        public static string GetRightHalf(this string s)
        {
            return s.Substring(s.Length / 2, s.Length - 1);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает строку, в которой все вхождения строки <see cref="old"/> заменены на строку <see cref="@new"/>.
        /// </summary>
        public static string Replace(this string s, string old, string @new)
        {
            return s.Replace(old, @new);
            throw new NotImplementedException();
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

            string toCode(char c)
            {
                return Char.ConvertToUtf32(c.ToString(), 0).ToString();
            }
            
            string sToCodes = "";
            for (int i = 0; i < s.Length; i++)
            {
                sToCodes = sToCodes + toCode(s[i]);
            }

            return sToCodes;
            
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает строку задом наперёд.
        /// </summary>
        public static string GetReversed(this string s)
        {
            string reversed = "";
            for (int i = 0; i < s.Length; i++)
            {
                reversed = string.Concat(s[i].ToString(), reversed);
            }

            return reversed;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает строку, у которой регистр букв заменён на противоположный.
        /// </summary>
        public static string InverseCase(this string s)
        {
            string antiRegister = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsLower(s[i]))
                {
                    antiRegister = antiRegister + Char.ToUpper(s[i]);
                }
                else
                {
                    antiRegister = antiRegister + Char.ToLower(s[i]);
                }
            }

            return antiRegister;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает строку, у которой каждый символ заменен на следующий за ним символ Юникода.
        /// Т.е. каждый символ с кодовой точкой X заменен на символ с кодовой точкой X+1.
        /// </summary>
        public static string ShiftInc(this string s)
        {
            string toNextCode(char c)
            {
                return Char.ConvertFromUtf32(Char.ConvertToUtf32(c.ToString(), 0) + 1).ToString();
            }
            
            string sNextCodes = "";
            for (int i = 0; i < s.Length; i++)
            {
                sNextCodes = sNextCodes + toNextCode(s[i]);
            }

            return sNextCodes;
            
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        #endregion
    }
}
