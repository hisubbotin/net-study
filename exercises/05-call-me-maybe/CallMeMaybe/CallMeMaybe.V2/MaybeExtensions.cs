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
        
        public static Maybe<T> ToMaybe<T>(this T? nullable) 
            where T : struct
        {
            return nullable ?? Maybe<T>.Nothing;
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
