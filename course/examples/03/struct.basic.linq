<Query Kind="Program" />

public static void Main()
{
    var vector = new Vector(5, 3);
    Console.WriteLine(vector);
}

struct Vector
{
    public readonly double X;
    public readonly double Y;

    public Vector(double x, double y)
    {
        X = x;
        Y = y;
    }
}

