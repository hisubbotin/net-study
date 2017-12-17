using System;
using System.Collections.Generic;

namespace CallMeMaybe.V2
{
    public static class MaybeExtensions
    {
        public static Maybe<T> ToMaybe<T>(this T value)
        {
            return value;
        }

        public static Maybe<T> ToMaybe<T>(this T? value) 
            where T : struct
        {
            return value ?? Maybe<T>.Nothing;
        }
       
        public static Maybe<T> ToMaybe<T>(this IEnumerable<T> seq)
        {
            using (var iter = seq.GetEnumerator())
            {
                return iter.MoveNext() ? iter.Current : Maybe<T>.Nothing;
            }
        }
    }
}
