<Query Kind="Program" />

public static void Main()
{
    CancellationTokenSource cts = new CancellationTokenSource();
    
    ThreadPool.QueueUserWorkItem(o => Count(cts.Token, 1000));
    Thread.Sleep(1000);
    cts.Cancel(); // Если метод Count уже вернул управления, Cancel не оказывает никакого эффекта
    
    Thread.Sleep(1000);
    Console.WriteLine("Quit the programm");
}
private static void Count(CancellationToken token, Int32 countTo)
{
    for (Int32 count = 0; count < countTo; count++)
    {
        if (token.IsCancellationRequested)
        {
            Console.WriteLine("Count is cancelled");
            break;
        }
        Console.WriteLine(count);
        Thread.Sleep(200);
    }
    Console.WriteLine("Count is done");
}