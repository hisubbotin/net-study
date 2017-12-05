namespace CallMeMaybe
{
    public static class MaybeExtensions
    {
        /*
         * Сюда даже не пришлось копировать. Вероятно, автор задачи просто
         * забыл заменить на throw new NotImplementedException()
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
