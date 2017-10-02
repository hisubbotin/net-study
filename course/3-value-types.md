# Value types

<!-- TOC -->

- [Value types](#value-types)
  - [Struct](#struct)
  - [Nullable](#nullable)
  - [Guid](#guid)
  - [DateTime](#datetime)
    - [TimeSpan](#timespan)
    - [DateTimeOffset](#datetimeoffset)
  - [Enum](#enum)
    - [Enum Flags](#enum-flags)

<!-- /TOC -->

<div style="page-break-after: always;"></div>

## Struct

[Структуры](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/structs) позволяют создавать пользовательские значимые типы.

```cs
struct Example
{
    public int Value;

    public string SomeString; // Можно указывать ссылочные типы

    public string ExampleMethod()
    {
        return $"{value} - {SomeString}";
    }
}

Example e = new Example();
e.Value = 1;
e.SomeString = "xmpl";

Console.WriteLine(e.ExampleMethod()); // 1 - xmpl
```

Ключевые особенности:

- Могут:
  - включать конструкторы, константы, поля, методы, свойства, события, операторы, вложенные типы
  - реализовывать интерфейс
- Не могут:
  - наследоваться от другой структуры или класса
  - выступать в качестве базового класса
  - содержать конструктор без параметров
- При присваивании к новой переменной создается копия объекта. Все изменения в новой копии не влияют на старую.

<div style="page-break-after: always;"></div>

Рекомендации от Рихтера по создаю своего value type:

- малый размер - до 16 байт
- ведет себя как примитивный: в частности immutable поведение, отсутсвие методов изменяющих состояние полей, по сути readonly
- тип не имеет базового и производных от него

```cs
struct Vector
{
    public double X {get;set;}

    public double Y {get;set;}

    public Vector(double x, double y)
    {
        X = x;
        Y = y;
    }
}

var vector = new Vector(5, 3);
```

<div style="page-break-after: always;"></div>

## Nullable

Ссылочным типам можно присваивать `null`. Ссылка будет содержать все 0. Никаких специальных полей для `null` нет.

Поэтому достаточно очевидно, что значимым полям, которые хранят только значение нельзя присвоить `null`.
В C# 1 нельзя было присваивать null значимым типам вообще и предлагалось всячески изощряться.

В C# 2 для значимых типов ввели конструкцию nullable, которая позволяет присвоить null.
Это делается через системную структуру `System.Nullable<T>`:

```cs
int? x = 10;
System.Nullable<int> x = 10; // Эквивалентные записи

Guid? y = null;
```

<div style="page-break-after: always;"></div>

Упрощенный вид `System.Nullable<T>`:

```cs
public struct Nullable<T> where T : struct
{
  private Boolean hasValue = false; // По дефолту null
  internal T value = default(T);    // По дефолту все биты обнулены

  public Nullable(T value)
  {
    this.value = value;
    this.hasValue = true;           // Выставляем, что есть значение
  }

  public Boolean HasValue { get { return hasValue; } }

  public T Value { get {
      if (!hasValue) // Бросаем исключение если идет доступ к элементу, когда его нет
          {throw new InvalidOperationException("Nullable object must have a value.");}

      return value; }}
```

<div style="page-break-after: always;"></div>

Остальные методы:

```cs
  // Получение Value или дефолтного значения
  public T GetValueOrDefault() { return value; }
  public T GetValueOrDefault(T defaultValue) { if (!HasValue) return defaultValue; return value;}

  public override Boolean Equals(Object other)
  {
    if (!HasValue)
      return (other == null); // Если оба объекта null, то они равны
    if (other == null)
      return false;
    return value.Equals(other);
  }
  public override int GetHashCode() { if (!HasValue) return 0; return value.GetHashCode();}
  public override string ToString() { if (!HasValue) return ""; return value.ToString();}

  public static implicit operator Nullable<T>(T value) { return new Nullable<T>(value);  }
  public static explicit operator T(Nullable<T> value) { return value.Value;  } }
```

<div style="page-break-after: always;"></div>

Пример использования nullable:

```cs

int? i = 6;
Console.WriteLine($"{ i.Value } { i.HasValue }");  // 6 true

int x = (int)i; // Явное приведение к обычному int
int? y = x;     // Неявное приведение от int
i++;            // i = 7 Можно выполнять операции
i = null;
Console.WriteLine($"{ i.Value } { i.HasValue }");    // false

if (i == null) {}
if (i.HasValue)
{
    int k = i.Value;
}
if (i == y) {}
```

<div style="page-break-after: always;"></div>

- Интересно, что при упаковке nullable к ссылочному типу (object, например), он упаковывается либо в null ссылку, либо в ссылку на сам тип (int, например).
- Сделать `Nullable<Nullable<int>>` нельзя :)
- К nullable типу можно применять стандартные операторы (`+`, `*`, `>`, `^`, `>>`, etc), но настоятельно рекомендуется этого не делать и обрабатывать ситуацию `if (!i.HasValue)` отдельно
- Если один из операндов равен `null`, то результат будет null/false в большинстве операций, но есть моменты
  - `==`, `!=` - если оба операнда `null`, то они считаются равными
  - `null | true` вернет `true`
- Надо ли рассказывать про хелпер System.Nullable ?
  - `public static int Compare<T>(Nullable<T> n1, Nullable<T> n2)`
  - `public static bool Equals<T>(Nullable<T> n1, Nullable<T> n2)`
  - `public static Type GetUnderlyingType(Type nullableType)`

<div style="page-break-after: always;"></div>

## Guid

Guid - global unique identifier - часто используемая в бд структура.

- 16 байт.
- Обеспечивает глобальную уникальность сущности, генерится по Mac-адресу сетевой карты, текущей даты и рандома. - Вероятность дублирования guid 10^-50.
- Позволяет генерить идентификаторы для базы данных на клиенте, особенно востребовано в шардированных nosql базах.
- `623ab58a-afc4-46c8-820e-c0a0686c1d90` Строковое представление, разделенное на 4 части.

```cs
Guid value = Guid.NewGuid(); // Генерация нового значения
value = Guid.Empty;  // Зарезервированное значение по-умолчанию (со всеми нулями)

value = Guid.Parse("c5d370a0-55d9-445a-b3d6-a2df47d2f233");
```

<div style="page-break-after: always;"></div>

## DateTime

<div style="page-break-after: always;"></div>

### TimeSpan

<div style="page-break-after: always;"></div>

### DateTimeOffset

<div style="page-break-after: always;"></div>

## Enum

[Enum](https://msdn.microsoft.com/en-us/library/system.enum(v=vs.110).aspx) - Перечисление - набор связанных пар, состоящих из строки и целочисленного значения (int / byte / short / long, по-дефолту `int`).

Цепочка наследования `System.Object` -> `System.ValueType` -> `System.Enum` -> UserDefined Enum

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

Компилируется примерно в такую структуру (мы, конечно, не можем сами написать такой код, унаследоваться от enum нельзя):

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

- GetValues / GetNames
- Parse / TryParse
- IsDefined - Проверяет допустимость числового значения для енама, работает через reflection, то есть медленно. В него можно пихать как значения типа, так и строки, и он всегда работает со строками с учетом регистра

```cs
Color[] values = (Color[]) Enum.GetValues(typeof(Color));
string[] names = Enum.GetNames(typeof(Color));
Color value = (Color) Enum.Parse(typeof(Color), "Green");

Object Parse(Type enumType, String value);
Object Parse(Type enumType, String value, Boolean ignoreCase);
Boolean TryParse<TEnum>(String value, out TEnum result);
Boolean TryParse<TEnum>(String value, Boolean ignoreCase, out TEnum result);
Boolean IsDefined(Type enumType, Object value);
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
        catch(Exception e) { Console.WriteLine($"`{s}`, Exception: {e.Message}"); }
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
```

- Методы, описанные ранее, работают и c битовыми флагами
- `IsDefined` не работает правильно с битовыми флагами! Его форма работы со строками не рассчитана на запятые (всегда возвращает false).
- `ToString`, если нашел `[Flags]`, то рассматривает перечисление, как набор битовых флагов

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