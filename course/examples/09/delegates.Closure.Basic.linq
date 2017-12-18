<Query Kind="Program" />

static Action CreateAction()
{
    int count = 0;
    return () =>
    {
        count++;
        Console.WriteLine("Count = {0}", count);
    };
}

static void Main(string[] args)
{
    var action = CreateAction();
    action();
    action();
}