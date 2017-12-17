using System;

namespace CallMeMaybe.V1
{
    public static class MaybeExtensions
    {
        public static Maybe<T> ToMaybe<T>(this T value) => value;

        public static Maybe<T> ToMaybe<T>(this T? value) where T : struct
        {
            return value ?? Maybe<T>.Nothing;
        }
    }
}
