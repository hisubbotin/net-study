<Query Kind="Program" />

public static void Main()
{
    Console.WriteLine("Main thread");
    Thread dedicatedThread = new Thread(ComputeBoundOp);
    dedicatedThread.Start(5);
    Console.WriteLine("Main thread: Doing other work");
    Thread.Sleep(2000); // Имитация другой работы (10 секунд)
    dedicatedThread.Join(); // Ожидание завершения потока
    Console.WriteLine("Main thread: ending");
}

// Передаем делегат ParameterizedThreadStart в конструктор Thread
private static void ComputeBoundOp(Object state)
{
    Console.WriteLine("In ComputeBoundOp: state={0}", state);
    Thread.Sleep(1000); // Имитация другой работы (1 секунда)
}