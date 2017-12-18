<Query Kind="Program" />

internal delegate void MyDelegate(int value);

internal static void WriteA(int value) => Console.WriteLine($"Aaa {value}");
internal static void WriteB(int value) => Console.WriteLine($"Bbb {value}");
internal class Example
{
    internal void WriteC(int value) => Console.WriteLine($"Ccc {value}");
}

private static void UseDelegate(Int32 value, MyDelegate del) => del(value);

static void Main(string[] args)
{
    MyDelegate delegateA = WriteA;          // Статический метод
    MyDelegate delegateB = new MyDelegate(WriteB);
    var example = new Example();
    MyDelegate delegateC = example.WriteC;  // Экземплярный

    delegateA(1);
    delegateB.Invoke(2);
    delegateC(3);

    MyDelegate chain = delegateA;
    chain = (MyDelegate)Delegate.Combine(chain, delegateB);
    chain += delegateC;
    chain -= delegateA;

    UseDelegate(4, chain);
}

