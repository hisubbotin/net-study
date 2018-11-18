namespace CallMeMaybe.V1
{
	public static class MaybeExtensions
	{
		public static Maybe<T> ToMaybe<T>(this T obj)
		{
			return obj; // Само скастится
		}
		public static Maybe<T> ToMaybe<T>(this T? obj) where T : struct
		{
			return obj.HasValue ? obj.Value : Maybe<T>.Nothing; // Само скастится
		}
	}
}
