<Query Kind="Program" />

public static void Main()
{
    Thread t = new Thread(Worker);
    t.IsBackground = true;
    t.Start();
    
    // Активный поток - приложение будет работать около 10 секунд
    // IsBackground = true - немедленно прекратит работу
    // В LINQPad5 работает криво, в студии работает нормально :)
    Console.WriteLine("Returning from Main");
}
private static void Worker()
{
    Thread.Sleep(10000); 
    Console.WriteLine("Returning from Worker");
}