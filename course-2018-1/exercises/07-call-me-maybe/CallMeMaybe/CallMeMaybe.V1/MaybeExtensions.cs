namespace CallMeMaybe.V1
{
    public static class MaybeExtensions
    {
        /*
            здесь мог бы быть твой код
        */

        /*
         * Класс MaybeExtensions содержит методы расширения ToMaybe<T>
         * позволяющие объекты любого типа обернуть в Maybe<T>
         * нужно два метода:
         * один для ToMaybe<T>: T --> Maybe<T>
         * второй для значимых типов обернутых в Nullable:
         * ToMaybe<T?>: T? --> Maybe<T>
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
