<Query Kind="Program" />

static void Main(string[] args)
{
    try
    {
        using(var e = new SomeDisposable())
        {
            e.Action();
        }
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

public class SomeDisposable:IDisposable
{
    public void Action() 
    {
        throw new Exception("Action");
    }

    public void Dispose() 
    {
        throw new Exception("Dispose");
    }
}