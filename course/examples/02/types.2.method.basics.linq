<Query Kind="Program" />

public static void Main()
{
    var r = new RefType { X = 1 };
    var v = new ValueType { X = 1 };
    RefMethod(r);
    Console.WriteLine(r.X);
    ValueMethod(v);
    Console.WriteLine(v.X);
}

class RefType { public Int32 X; }
struct ValueType { public Int32 X; }

static void RefMethod(RefType r) { r.X = 2; }
static void ValueMethod(ValueType r) { r.X = 2; }