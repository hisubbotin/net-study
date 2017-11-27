<Query Kind="Program" />

public class Publisher
{
    public delegate void CallEveryOne();
    public CallEveryOne call = null;
}

public class Subscriber
{
    public Subscriber(Publisher p)
    {
        p.call += ShowMessage;
    }
    
    public void ShowMessage() => Console.WriteLine("S"); 
}

static void Main(string[] args)
{
    var p = new Publisher();
    var s = new Subscriber(p);
    p.call.Invoke();
}