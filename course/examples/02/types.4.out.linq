<Query Kind="Program" />

public static void Main()
{
    string s = "33";

    if (Int32.TryParse(s, out int value))
        Console.WriteLine(value);
    else
        Console.WriteLine($"Unable to convert '{s}'");
}

