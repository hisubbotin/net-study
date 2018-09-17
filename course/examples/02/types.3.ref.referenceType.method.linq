<Query Kind="Program" />

public static void Main()
{
    var r = new RefType { X = 1 };
    RefMethod(r);
    Console.WriteLine(r.X); // 1
    RefMethod(ref r);
    Console.WriteLine(r.X); // 15
}

class RefType { public Int32 X; }
static void RefMethod(RefType r) { r = new RefType { X = 15 }; }
static void RefMethod(ref RefType r) { r = new RefType { X = 15 }; }
