using System;

namespace CallMeMaybe.V1
{
    public static class MaybeExtensions
    {
        /*
            здесь мог бы быть твой код
        */
        public static Maybe<T> ToMaybe<T>(this T value)
        {
            return value;
        }

        public static Maybe<T> ToMaybe<T>(this T? value)
            where T : struct
        {
            return value == null ? Maybe<T>.Nothing : value.Value.ToMaybe();
        }
       

    }
}
