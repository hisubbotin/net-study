namespace CallMeMaybe.V1
{
    public static class MaybeExtensions
    {
        /*
            здесь мог бы быть твой код
            а мог бы и не быть, вопрос бытия...
        */

        public static Maybe<T> ToMaybe<T>(this T value)
        {
            return value;
        }

        public static Maybe<T> ToMaybe<T>(this T? value)
            where T : struct
        {
            return value ?? Maybe<T>.Nothing;
        }
    }
}
