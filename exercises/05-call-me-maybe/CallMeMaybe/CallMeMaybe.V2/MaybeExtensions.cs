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
            return value ?? Maybe<T>.Nothing;
        }

        public static Maybe<T> ToMaybe<T>(this IEnumerable<T> seq)
        {
            using (var iter = seq.GetEnumerator())
            {
                /*
                    изначально iter никуда не указывает - попытка обращения к iter.Current вызовет исключение
                    само же итерирование производится с помощью метода .MoveNext().
                    Обрати внимание на его сигнатуру.
                */
                return iter.MoveNext() ? iter.Current : Maybe<T>.Nothing;
            }
        }
    }
}
