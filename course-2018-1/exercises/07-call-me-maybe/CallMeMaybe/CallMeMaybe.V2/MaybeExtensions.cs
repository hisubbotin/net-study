using System;
using System.Collections.Generic;

namespace CallMeMaybe.V2
{
    public static class MaybeExtensions
    {
        public static Maybe<T> ToMaybe<T>(this T value)
        {
            // скопируй из предыдущего шага
            throw new NotImplementedException();
        }
        public static Maybe<T> ToMaybe<T>(this T? value)
            where T : struct
        {
            // скопируй из предыдущего шага
            throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }
    }
}
