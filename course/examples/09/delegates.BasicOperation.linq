<Query Kind="Program" />

delegate int BinaryOperation(int x, int y);

private static int Add(int x, int y) => x + y;
private static int Multiply (int x, int y) => x * y;

static void Main(string[] args)
{
    BinaryOperation del = Add; 
    Console.WriteLine(del.Invoke(4, 5));

    del = Multiply;
    Console.WriteLine(del.Invoke(4, 5));
}
