# Collections

<!-- TOC -->

- [Collections](#collections)
  - [Управление программой](#управление-программой)
    - [switch](#switch)
  - [Array](#array)
  - [Foreach + `IEnumerable<T>`](#foreach--ienumerablet)
  - [yield](#yield)

<!-- /TOC -->

<div style="page-break-after: always;"></div>

## Управление программой

Циклы:

- for
- foreach
- do
- do while

Внутри циклов:

- continue - следующая итерация цикла
- break - выйти из цикла

Условные операторы:

- if { } else {}
- switch
- ternarny operator

<div style="page-break-after: always;"></div>

```cs
for (int i = 0; i < 10; i++)
{
    Console.WriteLine("Value of i: {0}", i);
}

int i = 0;

for(;;)
{
    if (i < 10)
    {
        Console.WriteLine("Value of i: {0}", i);
        i++;
    }
    else
        break;
}
```

<div style="page-break-after: always;"></div>

```cs
int i = 0;

while (true)
{
    Console.WriteLine("Value of i: {0}", i);
    i++;
    if (i > 10)
        break;
}

i = 0;

do
{
    Console.WriteLine("Value of i: {0}", i);
    i++;

} while (i < 10);

```

<div style="page-break-after: always;"></div>

### switch

- Обязательно должен использоваться `break`, `goto case`, `return` или `throw` при условии
- Нельзя просто так выполнить два условия сразу

```cs
int value = 1;
switch (value)
{
    case 1:
        Console.WriteLine("case 1");
        goto case 3; // переход к case 3
    case 2:
        Console.WriteLine("case 2");
        break;
    case 3:
        Console.WriteLine("case 3");
        break;
    default:
        Console.WriteLine("default");
        break;
}
```

<div style="page-break-after: always;"></div>

C# 7.0 [Pattern Matching](https://blogs.msdn.microsoft.com/dotnet/2016/08/24/whats-new-in-csharp-7-0/)

Patterns:

- const
- type
- var - всегда успешен

```cs
public static void IsPattern(object o)
{
    if (o is null) Console.WriteLine("Const pattern");
    if (o is int i) Console.WriteLine($"Type, int = {i}");
    if (o is Person p) Console.WriteLine($"Type, person: {p.FirstName}");
    if (o is var x) Console.WriteLine($"var pattern, type {x?.GetType()?.Name}");
```

<div style="page-break-after: always;"></div>

- В switch можно использовать любой тип
- В case можно использовать паттерны и дополнительные условия
- Порядок важен
- дефолт всегда выполнится последним (независимо от места)

```cs
switch(shape)
{
    case Circle c:
        WriteLine($"circle with radius {c.Radius}");
        break;
    case Rectangle s when (s.Length == s.Height):
        WriteLine($"{s.Length} x {s.Height} square");
        break;
    case Rectangle r:
        WriteLine($"{r.Length} x {r.Height} rectangle");
        break;
    default:
        WriteLine("<unknown shape>");
        break;
    case null:
        throw new ArgumentNullException(nameof(shape));
}
```

<div style="page-break-after: always;"></div>

## Array

- нумерация с нуля

```cs
int[] array = new int[3];
int[] array2 = new int[3] { 1, 3, 9 }; // Инициализатор
int[] array3 = new int[] { 1, 3, 9 };
int[] array4 = new[] { 1, 3, 9 };
int[] array5 = { 1, 3, 9 };

array[0] = 1;
array[1] = 2;
array[2] = 3;
array[3] = 3; // throw IndexOutOfRangeException (проверка обычно выполняется 1 раз за цикл и не влияет на производительность)
```

<div style="page-break-after: always;"></div>

Многомерные массивы:

```cs
int[] mdarray = new int[] { 0, 1, 2, 3 };
int[,] mdarray2 = { { 0, 1, 2 }, { 2, 1, 0 } };
int[,,] mdarray3 = new int[2, 3, 2];
```

jagged array:

```cs
int[][] jagged = new int[2][];
jagged[0] = new int[3] { 1, 2, 3 };
jagged[1] = new int[3] { 7, 7, 7 };
```

<div style="page-break-after: always;"></div>

```cs
int[][] jagged = new int[2][];
jagged[0] = new int[3] { 1, 2, 3 };
jagged[1] = new int[3] { 7, 7, 7 };

foreach(int[] row in jagged)
{
    foreach(int value in row)
    {
        Console.Write($"{value} ");
    }
    Console.WriteLine();
}
for (int i = 0; i < jagged.Length; i++)
{
    for (int k = 0; k < jagged[i].Length; k++)
    {
        Console.Write($"{numbers[i][k]} ");
    }
    Console.WriteLine();
}
```

<div style="page-break-after: always;"></div>

## Foreach + `IEnumerable<T>`

```cs
foreach (int x in src)
{
  // Do something with x.
}

public interface IEnumerable<out T> : IEnumerable
{
    IEnumerator<T> GetEnumerator();
}

public interface IEnumerator<out T> : IDisposable, IEnumerator
{
    T Current { get; }

    void Dispose();
    bool MoveNext();
    void Reset();
}
```

<div style="page-break-after: always;"></div>

```cs
foreach (int x in src)
{
  // Do something with x.
}

var e = src.GetEnumerator();
while (e.MoveNext())
{
  var x = (int)e.Current; // without the cast if src was an IEnumerable<T>
  // Do something with x.
}

using (var e = src.GetEnumerator())
{
    while (e.MoveNext())
    {
        int x = e.Current;
        // Do something with x.
    }
}
```

<div style="page-break-after: always;"></div>

```cs
public class List<T> : IEnumerable<T>
{
    // Итератор класса List<T>, Это структура, причем изменяемая!!!
    public struct Enumerator : IEnumerator<T>, IDisposable
    { }

    public List<T>.Enumerator GetEnumerator() { return new Enumerator(this); }

    // Явная реализация интерфеса
    IEnumerator<T> IEnumerator<T>.GetEnumerator()
    {
        return GetEnumerator();
    }
}
```

<div style="page-break-after: always;"></div>

```cs
var list = new List<int> {1, 2, 3};

// Вызываем List<T>.Enumerator GetEnumerator
foreach(var i in list)
{}

// Вызываем IEnumerable<T> GetEnumerator
foreach(var i in (IEnumerable<int>)list)
{}

// Пример интересного поведения связанного с изменяемыми структурами
var x = new { Items = new List<int> { 1, 2, 3 }.GetEnumerator() };
while (x.Items.MoveNext())
{
    Console.WriteLine(x.Items.Current);
}
```

<div style="page-break-after: always;"></div>

## yield

Ограничения

- Оператор yield return не разрешено использовать внутри блока try при наличии любых блоков catch
- не допускается применять оператор yield return или yield break в блоке finally
http://blogs.msdn.com/b/ericlippert/archive/tags/iterators/