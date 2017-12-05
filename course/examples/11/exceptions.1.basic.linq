<Query Kind="Program" />

static void Main(string[] args)
{
    try
    {
        int i = int.Parse("f3");
    }
    catch(Exception e)
    {
        Console.WriteLine("WrongInput");
    }
    finally
    {
        Console.WriteLine("Garanted code");
    }
}