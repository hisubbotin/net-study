namespace CallMeMaybe.V1
{
    public static class MaybeExtensions
    {
        /*
            здесь мог бы быть твой код
        */

        public static Maybe<T> ToMaybe<T>(this T value) => value;
        public static Maybe<T> ToMaybe<T>(this T? value) where T : struct => value ?? Maybe<T>.Nothing;
    }
}
