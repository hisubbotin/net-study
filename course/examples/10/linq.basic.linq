<Query Kind="Program" />

static void Main(string[] args)
{
    var list = new List<string> { "First", "Second", "Third", "Fourth", "Fifth"};
    
    int count = list.Where(x => x.Contains("i")).Count();
    var ordered = list.OrderBy(x => x).ToList();
    
    Console.WriteLine(count);
    foreach(var item in ordered)
        Console.WriteLine(item);
}

