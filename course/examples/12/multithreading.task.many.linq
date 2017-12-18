<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

public static void Main()
{
    Task[] tasks = new Task[3]
    {
        new Task(() => Console.WriteLine("First")),
        new Task(() => Console.WriteLine("Second")),
        new Task(() => Console.WriteLine("Third"))
    };
    foreach (var t in tasks)
    {
        t.Start();
    }
    Task.WaitAll(tasks);

    Console.WriteLine("End");
}
