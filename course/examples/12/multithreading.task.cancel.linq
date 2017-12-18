<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

public static void Main()
{
    CancellationTokenSource cts = new CancellationTokenSource();
    Task<int> t = new Task<int>(() => Sum(cts.Token, 2), cts.Token);
    
    t.Start();
    
    cts.Cancel(); // кстати задача уже может быть завершена
    try 
    {
        // В случае отмены задания метод Result генерирует исключение AggregateException
        Console.WriteLine("The sum is: " + t.Result);
    }
    catch (AggregateException x)
    {
        // Считаем обработанными все объекты OperationCanceledException, 
        // все остальные исключения попадают в новый объект AggregateException, состоящий только из необработанных исключений, который заново будет выкинут
        x.Handle(e => e is OperationCanceledException);

        Console.WriteLine("Sum was canceled");  // Строка выполняется, если все исключения уже обработаны
    }
}


private static Int32 Sum(CancellationToken ct, int n)
{
    int sum = 0;
    for (; n > 0; n--)
    {
        ct.ThrowIfCancellationRequested(); // исключение OperationCanceledException
        checked { sum += n; } 
        // исключение System.OverflowException
    }
    return sum;
}