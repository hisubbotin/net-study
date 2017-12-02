<Query Kind="Program" />

internal static int MyMethod(string s)
{
    try
    {
        int t = int.Parse(s);
        if (t < 0)
            throw new ArgumentOutOfRangeException(nameof(s));
        return t;
    }
    catch(FormatException e)
    {
        throw e; // CLR считает, что исключение возникло тут
    }
    catch(ArgumentOutOfRangeException _)
    {
        throw; // CLR не меняет информацию о начальной точке исключения.
    }
}

static void Main(string[] args)
{
    var list = new List<string>() { "3", "-1", "fff" };

    foreach(var s in list)
    {
        try
        {
            MyMethod(s);
        }
        catch(Exception e) {  Console.WriteLine(e);  }
    }
}