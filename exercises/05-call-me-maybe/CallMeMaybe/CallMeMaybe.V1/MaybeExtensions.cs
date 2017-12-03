namespace CallMeMaybe.V1
{
    public static class MaybeExtensions
    {
        public static Maybe<T> ToMaybe<T>(this T value)
        {
            return value;
        }
        
        public static Maybe<T> ToMaybe<T>(this T? nullable) where T : struct
        {
            return nullable ?? Maybe<T>.Nothing;
        }
    }
}
