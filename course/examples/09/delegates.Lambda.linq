<Query Kind="Program" />

static void Main(string[] args)
{
	Func<string> d1 = () => "test";
	Func<int, string> d2 = (int x) => x.ToString();
	Func<int, int, string> d3 = (int x, int y) => (x + y).ToString();
	
	Func<int, string> d4 = x => x.ToString();
	Func<int, int, string> d5 = (x, y) => (x + y).ToString();
	delWithOut d6 = (out int x) => x = 5;
	Func<int, int, string> d7 = (x, y) => 
		{
			int sum = x + y; 
			return sum.ToString();
		};

	Console.WriteLine(d1());
	Console.WriteLine(d2(3));
	Console.WriteLine(d3(3,2));
	Console.WriteLine(d4(9));
	Console.WriteLine(d5(6,2));
	d6(out int z);
	Console.WriteLine(z);
}

delegate void delWithOut(out int z);