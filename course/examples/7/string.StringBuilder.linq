<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	StringBuilder sb = new StringBuilder("Text");
	Console.WriteLine("Length: {0}", sb.Length); // 4
	Console.WriteLine("Capacity: {0}", sb.Capacity); // 16

	sb.Append(" 1 ");
	sb.AppendFormat("{0} {1}", "First", "Second");
	sb.Replace("Second", "Third");
	Console.WriteLine(sb.ToString());
}