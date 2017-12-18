<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	string text = "hello world";
	int indexOfChar = text.IndexOf('o'); // равно 4
	Console.WriteLine(text.IndexOf("orl")); // равно 6

	Console.WriteLine(text.EndsWith("ld") == true); // true
	string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

	Console.WriteLine("   hello world ".Trim()); // результат "hello world"
	Console.WriteLine(text.Trim(new char[] { 'd', 'h' })); // результат "ello worl"
	Console.WriteLine("   hello world  ".TrimStart());  // "hello world  "
	Console.WriteLine("hell world".Insert(4, "o"));
	Console.WriteLine(text.Remove(0,6)); // "world"
	Console.WriteLine(text.Replace("hello","my"));
	Console.WriteLine(text.ToUpper()); // HELLO WORLD
	Console.WriteLine(text.Substring(1,4)); // ello
}