<Query Kind="Program" />

static void Main(string[] args)
{
    Factory d;
    d = Create; // ковариантность
    Base b = Create(3);
    b.Display();
}

delegate Base Factory(int value);

private static Derived Create(int value) => new Derived { I = value };

class Base
{
    public int I {get;set;}

    public void Display()
    {
        Console.WriteLine(I);
    }
}

class Derived : Base {}