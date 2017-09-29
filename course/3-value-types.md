# Value types

## Overview

- Value Types
  - [Struct](#struct)
  - [Nullable](#nullable)
  - [Guid](#guid)
  - [DateTime](#datetime)
    - [TimeSpan](#timespan)
    - [DateTimeOffset](#datetimeoffset)
  - [Enum](#enum)

<div style="page-break-after: always;"></div>

## Struct

<div style="page-break-after: always;"></div>

## Nullable

<div style="page-break-after: always;"></div>

## Guid

<div style="page-break-after: always;"></div>

## DateTime

<div style="page-break-after: always;"></div>

### TimeSpan

<div style="page-break-after: always;"></div>

### DateTimeOffset

<div style="page-break-after: always;"></div>

## Enum

[Enum](https://msdn.microsoft.com/en-us/library/system.enum(v=vs.110).aspx) - Перечисление - набор связанных констант, основанных на целочисленном типе int, byte, short, long (по-дефолту `int`).

```cs
enum Color
{
    Red,
    Green,
    Blue
}

Color myVariable = Color.Green;
Console.WriteLine(myVariable); // Green

int i = (int) myVariable;
Console.WriteLine(i); // 1

Color value = (Color) (i + 1);
Console.WriteLine(value); // Blue
```

Можно задавать значения вручную. Аналогичный предыдущему результат:

```cs
enum Color : int
{
    Red = 0,
    Green = 1,
    Blue = 2
}
```

Значение по-умолчанию для первого элемента 0, потом инкремент от предыдущего:

```cs
public enum Color
{
    Red,
    Green = 4,
    Blue
}

public static void Main()
{
    foreach(var color in Enum.GetValues(typeof(Color)))
    {
        Console.WriteLine($"{color} - {(int)color}");
    }
    // Red - 0
    // Green - 4
    // Blue - 5
}
```

Посмотрим, что будет, если отрицательное значение зафигачить:

```cs
public enum Color
{
    Red,
    Green = -1,
    Blue
}

public static void Main()
{
    foreach(var color in Enum.GetValues(typeof(Color)))
    {
        Console.WriteLine($"{color} - {(int)color}");
    }
    // Red - 0
    // Red - 0
    // Green - -1
}
```

Поэтому рекомендация: всегда явно указывать значения всех элементов

Возможны невалидые состояния:

- Мы можем сконвертить к enum любой int и это не вызывет ошибки.
- Значение по-умолчанию для enum `0` и даже, если вы не задали такого элемента, то clr всё равно выставит дефолтом `0`.

```cs
public enum Color
{
    Red = 2,
    Green = 3,
    Blue = 4
}

public static void Main()
{
    Color c = new Color();
    Console.WriteLine($"{c} - {(int)c}"); // 0 - 0

    c = (Color) (-1); // -1 - -1
    bool flag = Enum.IsDefined(typeof(Color), c); // False

    c = (Color) 2; // Red - 2
}
```

Посмотрим, как работает парсинг из строки:

```cs
public enum Color
{
    Red = 2,
    Green = 3,
    Blue = 4
}

public static void Main()
{
    string[] test = new []
    {
        "Red",  // Red | 2 | True
        "red",  // Exception: Requested value 'red' was not found.
        "3",    // Green | 3 | True
        "0",    // 0 | 0 | False
        "",     // Exception: Must specify valid information for parsing in the string.
        "-7",   // -7 | -7 | False
        "Red, Green" // Green | 3 | True      ~WTF~LUL~
    };

    foreach (string s in test)
    {
        try
        {
            Color value = (Color) Enum.Parse(typeof(Color), s);
            Console.WriteLine($"`{s}`: {value} | {(int)value} | {Enum.IsDefined(typeof(Color), value)}");
        }
        catch(Exception e)
        {
            Console.WriteLine($"`{s}`, Exception: {e.Message}");
        }
    }
}
```

В связи со всем этим рекомендуют:

- Создавать отдельный элемент Unknown / None / Default = 0 enuma
- Пользоваться методом `Enum.IsDefined` для проверки валиднсти значения enum
- Не создавать элементы enum "на будущее"

### Enum Flags