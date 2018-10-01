<Query Kind="Program" />

public static void Main()
{
    Console.WriteLine(Do(1,2,3));
    Console.WriteLine(Do(1,2,0));
}
public static double Do(double a, double b, double c)
{
    var resultA = f(a);
    var resultB = f(b);
    return resultA + resultB;

    double f(double x) => 2 * x + 3 + c;
}
 

