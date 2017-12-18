<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

public static void Main()
{
    Task taskA = Task.Run( () => Console.WriteLine("Hello from thread '{0}'.", Thread.CurrentThread.ManagedThreadId ));
    
    Console.WriteLine("Hello from thread '{0}'.", Thread.CurrentThread.ManagedThreadId );
    taskA.Wait();
}
