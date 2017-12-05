namespace CallMeMaybe.V1
{
    public static class MaybeExtensions
    {
        public static Maybe<T> ToMaybe<T>(this T value) => value;
        public static Maybe<T> ToMaybe<T>(this T? nullable) where T : struct => nullable ?? Maybe<T>.Nothing;
    }
}
