<Query Kind="Program" />

internal delegate void WriteMessage();

static void Main(string[] args)
{
    WriteMessage writeDelegate = WriteA;
    writeDelegate.Invoke();
}

internal static void WriteA()
{
    Console.WriteLine("Write Aaa!");
}