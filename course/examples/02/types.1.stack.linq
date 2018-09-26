<Query Kind="Program" />

public static void Main()
{
    ValueTypeDemo();
}

class SomeRef { public Int32 x; } // Ссылочный тип
struct SomeVal { public Int32 x; } // Значимый тип

static void ValueTypeDemo()
{
    SomeRef r1 = new SomeRef(); // Размещается в куче
    SomeVal v1 = new SomeVal(); // Размещается в стеке
    r1.x = 5; // Разыменовывание указателя, изменение в куче
    v1.x = 5; // Изменение в стеке

    SomeRef r2 = r1; // Копируется только ссылка (указатель)
    SomeVal v2 = v1; // Помещаем в стек и копируем члены
    r1.x = 8; // Изменяются r1.x и r2.x
    v1.x = 9; // Изменяется v1.x, но не v2.x
    Console.WriteLine($"{r1.x}, {r2.x}, {v1.x}, {v2.x} "); // "8,8,9,5"
}