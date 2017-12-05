<Query Kind="Program" />

static void Main(string[] args)
{
    try
    {
        throw new MyException {Status = Status.Forbidden};
    }
    catch(MyException e) when (e.Status == Status.Forbidden)
    {
        Console.WriteLine(e.ToString());
    }
}

internal class MyException: InvalidOperationException
{
    internal Status Status {get;set;}
    public override string ToString()
    {
        return $"{Status} Application error, {base.ToString()}";
    }
}

internal enum Status
{
    Forbidden = 1,
    Conflicted = 2,
    RetryFailed = 3
}