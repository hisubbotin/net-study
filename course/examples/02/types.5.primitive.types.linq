<Query Kind="Program" />

public static void Main()
{
    double a = 0.1;
    double b = 0.2;
    Console.WriteLine(a + b == 0.3); // false

    decimal c = 0.1M;
    decimal d = 0.2M;
    Console.WriteLine(c + d == 0.3M); // true
}