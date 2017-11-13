# Delegates

<!-- TOC -->

- [Delegates](#delegates)
  - [Delegate](#delegate)
    - [Generic delegates](#generic-delegates)
    - [Covariance & Contravariance](#covariance--contravariance)
  - [Event](#event)
  - [Lambdas](#lambdas)
  - [Closures](#closures)

<!-- /TOC -->

<div style="page-break-after: always;"></div>

## Delegate

- Безопасный к типам обратный вызов
- `Invoke` чтобы вызвать

Простейший пример объявления делегата:

```cs
internal delegate void WriteMessage();

static void Main(string[] args)
{
    WriteMessage writeDelegate = WriteA;
    writeDelegate.Invoke();
}

internal static void WriteA() => Console.WriteLine("Write Aaa!");
```

<div style="page-break-after: always;"></div>

```cs
delegate int BinaryOperation(int x, int y);

private static int Add(int x, int y) => x + y;
private static int Multiply (int x, int y) => x * y;

static void Main(string[] args)
{
    BinaryOperation del = Add;
    Console.WriteLine(del.Invoke(4, 5));

    del = Multiply;
    Console.WriteLine(del.Invoke(4, 5));
}
```

<div style="page-break-after: always;"></div>

```cs
internal delegate void MyDelegate(int value);

internal static void WriteA(int value) => Console.WriteLine($"Aaa {value}");
internal static void WriteB(int value) => Console.WriteLine($"Bbb {value}");
internal class Example
{
    internal void WriteC(int value) => Console.WriteLine($"Ccc {value}");
}

private static void UseDelegate(Int32 value, MyDelegate del) => del(value);

static void Main(string[] args)
{
    MyDelegate delegateA = WriteA;          // Статический метод
    MyDelegate delegateB = new MyDelegate(WriteB);
    var example = new Example();
    MyDelegate delegateC = example.WriteC;  // Экземплярный

    delegateA(1);
    delegateB.Invoke(2);
    delegateC(3);

    MyDelegate chain = delegateA;
    chain = (MyDelegate)Delegate.Combine(chain, delegateB);
    chain += delegateC;
    chain -= delegateA;

    UseDelegate(4, chain);
}
```

<div style="page-break-after: always;"></div>

```cs
internal delegate void Message(Int32 value);

internal class Message : System.MulticastDelegate
{
    public Feedback(Object object, IntPtr method);
    public virtual void Invoke(Int32 value);

    // Устаревшие асинхронные методы
    public virtual IAsyncResult BeginInvoke(Int32 value, AsyncCallback callback, Object object);
    public virtual void EndInvoke(IAsyncResult result);
}
```

<div style="page-break-after: always;"></div>

Типичное использование обычных делегатов:

```cs
button1.Click += new EventHandler(button1_Click);

...

///
/// Здесь button1_Click — метод, который выглядит примерно так:
///
void button1_Click(Object sender, EventArgs e)
{
    // Действия после нажатие на кнопку
}
```

<div style="page-break-after: always;"></div>

### Generic delegates

По-большому счету обычно не нужно объявлять свои делегаты, достаточно стандартных generic вариантов

- `Action<T>` - не возвращает значение

```cs
public delegate void Action(); // Этот делегат не обобщенный
public delegate void Action<T>(T obj);
public delegate void Action<T1, T2>(T1 arg1, T2 arg2);
public delegate void Action<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);
...
public delegate void Action<T1, ..., T16>(T1 arg1, ..., T16 arg16);
```

<div style="page-break-after: always;"></div>

- `Func<T>` - возвращает значение

```cs
public delegate TResult Func<TResult>();
public delegate TResult Func<T, TResult>(T arg);
public delegate TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2);
public delegate TResult Func<T1, T2, T3, TResult>(T1 arg1, T2 arg2, T3 arg3);
...
public delegate TResult Func<T1,..., T16, TResult>(T1 arg1, ..., T16 arg16);
```

<div style="page-break-after: always;"></div>

```cs
static void WriteSum(int x, int y) => Console.WriteLine("Sum: " + (x + y));
static void WriteMulpiply(int x, int y) => Console.WriteLine("Multiply: " + (x * y));
static int Add(int x, int y) => x + y;

static void Operation(int x, int y, Action<int, int> op) => op(x, y);

static void Main(string[] args)
{
    Operation(10, 6, WriteSum); // Можно не создавать объект делегата
    Operation(3, 3, WriteMulpiply);
    Operation(7, 5, (x,y) => {Console.WriteLine(x - y);}); // lambda

    Action<int, int> op = WriteSum;
    op.Invoke(1, 1);

    Func<int, int, int> add = Add;
    int result = add(1,2);
    Console.WriteLine(result);
}
```

<div style="page-break-after: always;"></div>

- `Predicate<T>` - в принципе тоже самое, что `Func<T,bool>`
- Делегат для проверки условия
- [Может использоваться](https://stackoverflow.com/questions/1710301/what-is-a-predicate-in-c) для фильтрации коллекций в linq
- Вообще он по сути [Deprecated](https://blogs.msdn.microsoft.com/mirceat/2008/03/12/linq-framework-design-guidelines/) и лучше вместо него использовать `Func<T,bool>`

```cs
Predicate<int> isPositive = delegate (int x) { return x > 0; };
Predicate<Person> oscarFinder = (Person p) => { return p.Name == "Oscar"; };
```

<div style="page-break-after: always;"></div>

Рекомендации:

- Всегда используйте `Action` / `Func`
- Их может не хватить при использовании `out`, `ref` параметров. По возможности можно не использовать `out`, `ref` параметры :)

```cs
// Не надо так
delegate bool Tester(int i);

class AClass
{
    public Tester MyTester {get;set;}
}

// Надо так
class AClass
{
    public Func<int,bool> MyTester {get;set;}
}
```

<div style="page-break-after: always;"></div>

### Covariance & Contravariance

## Event

## Lambdas

## Closures

http://sergeyteplyakov.blogspot.ru/2010/04/c.html