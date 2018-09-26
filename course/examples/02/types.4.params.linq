<Query Kind="Program" />

public static void Main()
{
    WriteParams();
    WriteParams(1);
    WriteParams(3, 3, 4, 1, 10);
    WriteParams(new int[]{2,2,2});
}

public static void WriteParams(params int[] array)
{
    Console.WriteLine(string.Join(",", array));
}