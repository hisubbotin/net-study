<Query Kind="Program" />

public class Publisher
{
    public delegate void CallEveryOne();
    public event CallEveryOne call;

    public void RunCall() => call();
}

public class Subscriber
{
    public Subscriber(Publisher p)
    {
        p.call += ShowMessage;
    }

    public void ShowMessage() => Console.WriteLine("Subscriber");
}

static void Main(string[] args)
{
    var p = new Publisher();
    var s = new Subscriber(p);
    p.RunCall();
}