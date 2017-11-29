<Query Kind="Program" />

static void Main(string[] args)
{
    var list = new List<string>() { "3", "-1", "fff", "222222222222222222222222" };

    foreach(var s in list)
    {
        try
        {
            int i = int.Parse(s);
            if (i < 0)
                throw new InvalidOperationException("Wrong situation");
        }
        catch(InvalidOperationException e)
        {
            Console.WriteLine("Wrong situation");
        }
        catch(FormatException e)
        {
            Console.WriteLine("Wrong Input");
        }
        catch(Exception e)
        {
            Console.WriteLine("all, non CLS compliant exceptions starting C# 2.0");
        }
        catch
        {
            Console.WriteLine("all");
        }
    }
}