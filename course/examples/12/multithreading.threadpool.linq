<Query Kind="Program" />

public static void Main()
{
    Console.WriteLine("Main thread: starting");
    ThreadPool.QueueUserWorkItem(Compute, 5);
    
    Console.WriteLine("Main thread: 10 sec waiting");
    Thread.Sleep(10000);
    
    Console.WriteLine("Main thread: exit");
}

private static void Compute(Object state)
{
    Console.WriteLine($"Compute: state = {state}");
    Thread.Sleep(1000);
}