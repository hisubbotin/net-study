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

[Enum](https://msdn.microsoft.com/en-us/library/system.enum(v=vs.110).aspx) - Перечисление - набор связанных пар, состоящих из строки и целочисленном значении (int / byte / short / long, по-дефолту `int`).

Цепочка наследования System.Object -> System.ValueType -> System.Enum -> UserDefined Enum

```cs
enum Color  // Минималистичная форма записи
{
    Red,    // Компилятор выставит соответствие 0
    Green,  // 1
    Blue    // 2
}

Color myVariable = Color.Green;
Console.WriteLine(myVariable);  // Green

int i = (int) myVariable; // Явно приводится к целочисленному типу
Console.WriteLine(i);     // 1

Color value = (Color) (i + 1);  // И обратно приводится
Console.WriteLine(value);       // Blue
```

<div style="page-break-after: always;"></div>

Всегда задавайте все значения енама вручную, чтобы облегчить поддержку кода.

Аналогичный предыдущему результат:

```cs
enum Color : int
{
    Red = 0,
    Green = 1,
    Blue = 2
}
```

<div style="page-break-after: always;"></div>

Компилируется примерно в такую структуру.

Мы не можем сами написать такой код, унаследоваться от enum / valueType нельзя:

```cs
struct Color : System.Enum
{
    public const Color Red = (Color) 0;
    public const Color Green = (Color) 1;
    public const Color Blue = (Color) 2;

    public Int32 value__; // Нельзя обращаться напрямую
}
```

<div style="page-break-after: always;"></div>

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

<div style="page-break-after: always;"></div>

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

<div style="page-break-after: always;"></div>

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

<div style="page-break-after: always;"></div>

Основные методы для работы с enum:

```cs
// Получение списка значений
Color[] values = (Color[]) Enum.GetValues(typeof(Color));
string[] names = Enum.GetNames(typeof(Color));

// Парсинг из строки
Color value = (Color) Enum.Parse(typeof(Color), "Green");

Object Parse(Type enumType, String value);
Object Parse(Type enumType, String value, Boolean ignoreCase);
Boolean TryParse<TEnum>(String value, out TEnum result);
Boolean TryParse<TEnum>(String value, Boolean ignoreCase, out TEnum result);

// Is Defined
Boolean IsDefined(Type enumType, Object value);
// Проверяет допустимость числового значения для енама
// Работает через reflection, то есть медленно
// В него можно пихать строки, и он всегда с ними работает с учетом регистра
```

<div style="page-break-after: always;"></div>

Посмотрим, как работает парсинг из строки:

```cs
public enum Status
{
    New = 2,
    Commited = 3,
    Deleted = 4
}

public static void Main()
{
    string[] test = new []
    {
        "New",  // New | 2 | True
        "new",  // Exception: Requested value 'new' was not found.
        "3",    // Commited | 3 | True
        "0",    // 0 | 0 | False
        "",     // Exception: Must specify valid information for parsing in the string.
        "-1",   // -1 | -1 | False
        "New, Commited" // Commited | 3 | True      ~WTF~LUL~
    };

    foreach (string s in test)
    {
        try
        {
            Status value = (Status) Enum.Parse(typeof(Status), s);
            Console.WriteLine($"`{s}`: {value} | {(int)value} | {Enum.IsDefined(typeof(Status), value)}");
        }
        catch(Exception e)
        {
            Console.WriteLine($"`{s}`, Exception: {e.Message}");
        }
    }

    Enum.IsDefined(typeof(Status), "New, Commited"); // false
}
```

В связи со всем этим рекомендуют:

- Создавать отдельный элемент Unknown / None / Default = 0 в enumе
- Пользоваться методом `Enum.IsDefined` для проверки валиднсти значения enum
- Не создавать элементы enum "на будущее"

<div style="page-break-after: always;"></div>

### Enum Flags

Можно сделать енам, используемый для идентификации битовых флагов.

```cs
[Flags]     // Надо пометить класс аттрибутом Flags
enum Actions
{
    None = 0,       // Можно сделать дефолтное значение
    Read = 0x0001,  // Обязательно нужно проставить всем значения
    Write = 0x0002, // Обычно устанавливают значимым лишь один бит (то есть назначают степени двойки значениями)
    ReadWrite = Actions.Read | Actions.Write,
    Delete = 0x0004,
    Query = 0x0008,
    All = 0x000F,   // Можно назначить не степень двойки, тогда ToString вернет All
}

Actions actions = Actions.Read | Actions.Delete; // 0x0005
Console.WriteLine(actions.ToString());           // "Read, Delete"
// Методы, описанные ранее, работают и c битовыми флагами
// ToString, если нашел [Flags], то рассматривает перечисление, как набор битовых флагов

// IsDefined не работает правильно с битовыми флагами!
// Его форма работы со строками не принимает запятые
```

Как выглядит в коде примерная работа с битовыми флагами (вариант без проверок):

```cs
bool IsSet(Actions value, Actions valueToTest)
{
    return (value & valueToTest) == valueToTest;
}

bool IsClear(Actions value, Actions flagToTest)
{
    return !IsSet(value, flagToTest);
}

Actions Set(Actions value, Actions setFlags)
{
    return value | setFlags;
}

Actions Clear(Actions flags, Actions clearFlags)
{
    return flags & ~clearFlags;
}
```