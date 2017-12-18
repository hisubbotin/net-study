<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

void Main()
{
    var query = GetInts().Skip(5);

    Console.WriteLine("== First iteration:");
    Console.WriteLine(string.Join(",", query.Take(3).ToList()));
	
    Console.WriteLine("== Second iteration:");
	// вот здесь он по новой создаст автомат и прогенерирует заново
    Console.WriteLine(string.Join(",", query.Take(3).ToList()));
}

private IEnumerable<int> GetInts()
{
    var i = 0;
    while (true)
    {
        Console.WriteLine($"yield return {i}");
        yield return i++;
    }
}