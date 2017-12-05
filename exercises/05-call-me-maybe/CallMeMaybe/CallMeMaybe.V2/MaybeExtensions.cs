using System;
using System.Collections.Generic;

namespace CallMeMaybe.V2
{
    public static class MaybeExtensions
    {
        public static Maybe<T> ToMaybe<T>(this T value) => value;

        public static Maybe<T> ToMaybe<T>(this T? value) where T : struct
        {
            return value ?? Maybe<T>.Nothing;
        }

        public static Maybe<T> ToMaybe<T>(this IEnumerable<T> seq)
        {
            using (var iter = seq.GetEnumerator())
            {
                /*
                    изначально iter никуда не указывает - попытка обращения к iter.Current вызовет исключение
                    само же итерирование производится с помощью метода .Next().
                    Обрати внимание на его сигнатуру.
                */
                /*
                 * Имелось в виду .MoveNext()?
                 */
                if (!iter.MoveNext())
                {
                    return Maybe<T>.Nothing;
                }
                return iter.Current;
            }
        }
    }
}
