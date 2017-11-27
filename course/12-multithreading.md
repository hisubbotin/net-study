# Multithreading

<!-- TOC -->

- [Multithreading](#multithreading)
  - [Thread](#thread)
  - [TPL](#tpl)
    - [Класс Task, Continuation, Cancellation](#класс-task-continuation-cancellation)
    - [async / await](#async--await)
    - [SyncronizationContext](#syncronizationcontext)

<!-- /TOC -->

<div style="page-break-after: always;"></div>

## Thread

- Thread
  - Объект ядра потока (thread kernel object). контекст потока, набор регистров процессора ~ 1KB
  - Блок окружения потока (Thread Environment Block, TEB). 4KB, содержит заголовок цепочки обработки исключений, локальное хранилище данных для потока и некоторые структуры данных, используемые интерфейсом графических устройств (GDI) и графикой OpenGL.
  - Стек пользовательского режима (user-mode stack). По умолчанию на каждый стек Windows выделяет 1 Мбайт памяти.
  - Стек режима ядра (kernel-mode stack). x86 - 12 KB, X64 — 24 Кбайт.

<div style="page-break-after: always;"></div>

- `System.Threading.Thread` - соответствует потоку в ОС
- Самый низкоуровневый объект для работы с потоками
- Запрещен в приложениях для windows store

```cs
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
```

<div style="page-break-after: always;"></div>

Методы:

- `Abort` уведомить CLR, что надо прекратить поток (для проверки завершенности следует опрашивать свойство `ThreadState`)
- `Interrupt` прервать поток на время
- `Join` остановить вызвающий поток до завершения потока, экземляру которого был вызван данный метод
- `Resume` возобновить работу потока
- `Start` запустить поток (при этом поток непосредственно создается в ОС)
- `Suspend` приостановить
- `static Sleep` останавливить поток
- `static GetDomain` ссылка на домен приложения
- `static GetDomainId` id текущего домена приложения

<div style="page-break-after: always;"></div>

Приоритет потоков:

```cs
dedicatedThread.Priority = ThreadPriority.AboveNormal;
```

- Columns - Process priority
- 17+ - драйвера устройств

| CLR Priority  | Idle | Below Normal | Normal | Above Normal | High | Realtime |
| ------------- | ---- | ------------ | ------ | ------------ | ---- | -------- |
| Time-Critical | 15   | 15           | 15     | 15           | 15   | 31       |
| Highest       | 6    | 8            | 10     | 12           | 15   | 26       |
| Above Normal  | 5    | 7            | 9      | 11           | 14   | 25       |
| Normal        | 4    | 6            | 8      | 10           | 13   | 24       |
| Below Normal  | 3    | 5            | 7      | 9            | 12   | 23       |
| Lowest        | 2    | 4            | 6      | 8            | 11   | 22       |
| Idle          | 1    | 1            | 1      | 1            | 1    | 16       |

<div style="page-break-after: always;"></div>

В CLR все потоки делятся на foreground / background

- При завершении активного потока:
  - Принудительно завершит все фоновые потоки
  - Все фоновые потоки завершатся немедленно и без появления исключений
- `Thread` - по-умолчанию `foreground`, `ThreadPool` - background
- `IsBackground` - можно изменять в процессе работы
- Общая рекомендация - лучше использовать фоновые потоки

<div style="page-break-after: always;"></div>

```cs
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
```

<div style="page-break-after: always;"></div>

## Thread Pool

- CLR умеет управлять собственным пулом потоков, чтобы не плодить лишние потоки
- На каждый объект CLR создается свой пул потоков, которые используют все AppDomain
- Пулл потоков динамически определяет количество реальных потоков, которые необходимы приложению

<div style="page-break-after: always;"></div>

## TPL

### Класс Task, Continuation, Cancellation

### async / await

[async Main](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-1)

### SyncronizationContext