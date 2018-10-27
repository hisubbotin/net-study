<Query Kind="Program" />

public static void Main()
{
    double e = 2.33333333;
    int ee = (int)e;
    Console.WriteLine(ee);
    
    object o = (object) e;
    //int e2 = (int)o;
    //Console.WriteLine(e2);
    
    double i = 3;
    double i2 = i;
    object o1 = i;
    object o2 = i2;
    object o3 = i;
    Console.WriteLine(i == i2); // true
    Console.WriteLine(o1 == o2); // false
    Console.WriteLine(o1 == o3); // false
}