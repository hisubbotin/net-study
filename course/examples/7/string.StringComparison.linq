<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	var s1 = "Strasse";
	var s2 = "Straße";

	Console.WriteLine(s1.Equals(s2, StringComparison.Ordinal));           // false
	Console.WriteLine(s1.Equals(s2, StringComparison.InvariantCulture));  // true
	Console.WriteLine("E".Equals("Ё", StringComparison.InvariantCulture));
	Console.WriteLine("E".Equals("Ё", StringComparison.Ordinal));


	var l = new List<string>
	    { "0", "9", "A", "Ab", "a", "aB", "aa", "ab", "ss", "ß",
	      "Ä", "Äb", "ä", "äb", "あ", "ぁ", "ア", "ァ", "Ａ", "亜", "Ё", "ё" };
	
	var comparers = new[]
	{
		StringComparer.Ordinal,
		StringComparer.OrdinalIgnoreCase,
		StringComparer.InvariantCulture,
		StringComparer.InvariantCultureIgnoreCase,
		StringComparer.Create(new CultureInfo("da-DK"), false),
		StringComparer.Create(new CultureInfo("de-DE"), false),
		StringComparer.Create(new CultureInfo("en-US"), false),
		StringComparer.Create(new CultureInfo("ja-JP"), false),
		StringComparer.Create(new CultureInfo("ru-RU"), false),
	};
	
	foreach (var comparer in comparers)
	{
		l.Sort(comparer);
		Console.WriteLine(string.Join(" ", l));
	}
}