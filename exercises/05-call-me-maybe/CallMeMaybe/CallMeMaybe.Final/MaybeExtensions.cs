using System;
using System.Collections.Generic;

namespace CallMeMaybe.Maybe
{
    public static class MaybeExtensions
    {
        public static MaybeV1<T> ToMaybe<T>(this T value)
        {
            return value;
        }
        public static MaybeV1<T> ToMaybe<T>(this T? value)
            where T : struct
        {
            return value ?? MaybeV1<T>.Nothing;
        }
        public static MaybeV1<T> ToMaybe<T>(this IEnumerable<T> seq)
        {
            using (var iter = seq.GetEnumerator())
            {
                return iter.MoveNext() ? iter.Current : MaybeV1<T>.Nothing;
            }
        }
        public static MaybeV1<T> Unwrap<T>(this MaybeV1<MaybeV1<T>> m)
        {
            throw new NotImplementedException();
        }
    }
}
