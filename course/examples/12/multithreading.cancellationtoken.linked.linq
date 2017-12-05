<Query Kind="Program" />

public static void Main()
{
    var cts1 = new CancellationTokenSource();
    cts1.Token.Register(() => Console.WriteLine("cts1 canceled"));
    var cts2 = new CancellationTokenSource();
    cts2.Token.Register(() => Console.WriteLine("cts2 canceled"));
    
    var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts1.Token, cts2.Token);
    linkedCts.Token.Register(() => Console.WriteLine("linkedCts canceled"));

    cts2.Cancel(); // Отмена любого из дочерних приводит к отмене общего

    Console.WriteLine("cts1 canceled={0}, cts2 canceled={1}, linkedCts={2}", 
        cts1.IsCancellationRequested, cts2.IsCancellationRequested, linkedCts.IsCancellationRequested);
}
