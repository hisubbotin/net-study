namespace CallMeMaybe.V1
{
    public static class MaybeExtensions
    {
        public static Maybe<T> ToMaybe<T>(this T value) => value;

        public static Maybe<T> ToMaybe<T>(this T? value) where T : struct
        {
            return value.HasValue ? value.Value : Maybe<T>.Nothing;
        }
        /*
            здесь мог бы быть твой код
        */
    }
}
 