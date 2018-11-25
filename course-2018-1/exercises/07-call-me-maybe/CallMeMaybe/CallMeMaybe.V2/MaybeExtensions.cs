using System;
using System.Collections.Generic;

namespace CallMeMaybe.V2
{
    public static class MaybeExtensions
    {
        public static Maybe<T> ToMaybe<T>(this T value)
        {
            // скопируй из предыдущего шага
            return value;
        }
        public static Maybe<T> ToMaybe<T>(this T? value)
            where T : struct
        {
            // скопируй из предыдущего шага
            return value.HasValue ? value.Value : Maybe<T>.Nothing;
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
                bool res = iter.MoveNext();
                if (res)
                {
                    return iter.Current;
                } else
                {
                    return Maybe<T>.Nothing;
                }
            }
        }
    }
}
