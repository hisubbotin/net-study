<Query Kind="Program" />

public static void Main()
{
    var s = new S(5, "Test");
    Console.WriteLine(s);
}

public readonly struct S
{
    public int Age { get; set; } // низя
    public S(int age)
    {
        this.Age = age;
    }

    public S(S other)
    {
        this = other;
    }

    public S Replace(S other)
    {
        S value = this;
        this = other; // низя
        return value;
    }
}