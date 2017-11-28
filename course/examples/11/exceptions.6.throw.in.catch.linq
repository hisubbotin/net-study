<Query Kind="Program" />

static void Main(string[] args)
{
    try
    {
        try
        {
            int t = int.Parse("s");
        }
        catch(Exception e)
        {
        }
        finally
        {
            throw new InvalidOperationException();
        }
    }
    catch(Exception e)
    {
        Console.WriteLine(e.ToString());
    }
}

