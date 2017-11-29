<Query Kind="Program" />

static void Main(string[] args)
{
    string str = "Initial value";
    Action action = () => 
    {
        Console.WriteLine(str);
        str = "Modified by closure";
    };
    str = "After delegate creation";
    action();
    Console.WriteLine(str);
    
    var funcs = new List<Func<int>>();
    for (int i = 0; i < 3; i++)
    {
        funcs.Add(() => i);
    }
    
    foreach (var f in funcs)
        Console.WriteLine(f());
}