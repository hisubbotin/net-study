<Query Kind="Program" />

public static void Main()
{
    int v = 1;
    ValueMethod(ref v);
    Console.WriteLine(v); // 11
}

static void ValueMethod(ref int v) { v = v + 10; }