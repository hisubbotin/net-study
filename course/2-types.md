## Types

### System.Object

Все классы неявно наследуются от object ([System.Object](https://msdn.microsoft.com/ru-ru/library/system.object(v=vs.110).aspx))
Общие методы:

- Public
  - ToString `*` - строковое представление экземпляра объекта, по дефолту `this.GetType().FullName()`
  - GetType - получить тип объекта
  - GetHashCode `*` - хэш-код для хранения в качестве ключа хэш-таблиц
  - Equals `*` - true, если объекты равны
- Protected
  - MemberwiseClone - создает новый экземпляр и присваивает все поля исходного объекта (без вложенных классов)
  - Finalize `*` - используется для очистки ресурсов, вызывается, когда сборщик мусора пометил объект для удаления, но до освобождения памяти

`*` - Методы, которые можно переопределить в своих классах

## Приведение типов

CLR гарантирует безопасность типов.
Всегда можно получить `.GetType()`, который нельзя переопределить.
В C# разрешено неявное безопасное приведение к базовому типу:

``` C#
int i = 1;
object a = i;
```

А так же расширяющие безопасные приведения базовых типов:

``` C#
byte > short > int > long > decimal
int > double
short > float > double
```

Для приведения к производному типу или в небезопасных  нужно явное приведение:

``` C#
int b = (int) a;
```

***IS*** - проверяет совместимость с типом, возвращает bool, никогда не генерирует исключение.

``` C#
object a = new object();
bool b = a is object; // true
bool b2 = a is int; // false
``` 

По факту CLR приходится 2 раза производить проверку типов при использовании `is`. Поэтому сделали:

***AS*** - проверяет совместимость и если можно, то приводит к заданному типу и возвращает его. Иначе возвращает null

``` C#
decimal a = o as decimal;
if (a != null)
{
// Используем a внутри инструкции if
}
```

Отличается от явного приведения только тем, что не генерит исключение.

### Базовые типы

| Type                  | Alias            | Size                    | Explanation  |
| --------------------- | ---------------- | ----------------------- | ------------ |
| System.Boolean        | boolean          | [1 byte][bool-url]      | true / false |
| System.Byte / SByte   | byte / sbyte     | 1 byte                  | Unsigned integer 0 to 255             |
| System.Int16 / UInt16 | short / ushort   | 2 byte                  | 32,767             |
| System.Int32 / UInt32 | int / uint       | 4 byte                  | 2,147,483,647             |
| System.Int64 / UInt64 | long / ulong     | 8 byte                  | 9,223,372,036,854,775,807             |
| System.Single         | float            | 4 byte                  | ~3.40 e38             |
| System.Double         | double           | 8 byte                  | ~1.7977 e308             |
| System.Decimal        | decimal          | 16 byte                 | Decimal number < 10 e28             |
| System.Char           | char             | 2 byte                  | Single unicode char             |
| System.String         | string           |            |Sequence of char             |
| System.Object         | object           | 4 / 8 (x86/x64, в стеке)| Base Type             |
| System.Guid           | [Guid][guid-url] | 16 byte                 |              |

[bool-url]:https://stackoverflow.com/questions/2308034/primitive-boolean-size-in-c-sharp
[guid-url]:https://msdn.microsoft.com/en-us/library/system.guid(v=vs.110).aspx

### Операторы

- Бинарные
  - `+` - сложение `int x = 5 + 7;`
  - `-` - вычитание
  - `/` - деление. Надо иметь в виду, что деление двух целых чисел вернет результат округленный до целого числа
  - `*` - умножение
  - `%` - остаток от деления
- Унарные
  - `++` Инкремент
  - `--` Декремент

У инкремента, декремента выше приоритет, чем у операций умножения, сложения, остатка.

``` C#
int x = 2;
int y = ++x;
Console.WriteLine($"{x} - {y}"); // y=3; x=3

int a = 2;
int b = a++;
Console.WriteLine($"{a} - {b}"); // b=2; a=3
```

#### Логические операторы

Поразрядные операции над двоичной формой числа.

`&` И
`|` ИЛИ
`^` исключающее ИЛИ / XOR
`~` инверсия
`x<y` / `x>>y` логический сдвиг, сдвигает число x на y разрядов

Логические операторы:

`||` / `&&` - оптимизированные операции ИЛИ / И для bool
`!` - логическое отрицание
`==` равенство `if (a == b)`
`!=` неравенство
`??` [null-coalescing](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-conditional-operator) `int x = param1 ?? localDefault;`
`?:` ternary operator `int result = Check() ? 1 : 0;`, [example](https://stackoverflow.com/questions/3312786/benefits-of-using-the-conditional-ternary-operator)
`?.` [null-conditional operator](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-conditional-operators) - проверяет на null до доступа к полю/свойству/индексу обьекта

``` C#
int? length = customers?.Length; // null if customers is null
Customer first = customers?[0];  // null if customers is null
int? count = customers?[0]?.Orders?.Count();  // null if customers, the first customer, or Orders is null
```

Операции с присваиванием
 `+=`, `-=`, `^=`, ...
 `x += y` эквивалент `x = x + y`

### Локальная инициализация

``` C#
int x;
System.Int32 x = new System.Int32(); // Эквивалент
bool isValid = true;
double y = 3.0;
float f = 33.1f; // Используем суфикс, чтобы студия не считала его double
decimal d = 11.1m; // m для decimal
string s = "Hello!";
char c = 's';
int z = x + 5;
```

#### Неявная типизация

Компилятор сам понимает, какой тип.

``` C#
var x = 1;
var y = null; // Нельзя
```

[Microsoft C# coding convensions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions) var usage:

``` C#
// Используйте неявную типизацию для локальных переменных, когда тип элементарно понимается из правого выражения или не важен
var x = new MyClass();
var i = 3;
var list = new List<int>();
var db = new Data(_connection) { RetryPolicy = _retryPolicy };

// Не используете var, если тип не очевиден из правой части
var ExampleClass.ResultSoFar();
var ticketLifeTime = getTicketLifeTime(licenses);
var newCounters = mergeResult
    .Where(x => x.LicenseId == license.Id)
    .ToDictionary(x => x.Name, y => y.Value);

// Используйте в циклах
foreach (var element in myList)
{
    // ...
}
```

### Namespaces

### Переполнение

По-умолчанию проверка переполнения выключена. Код выполняется быстрее.

Операторы `checked`/`unchecked`

``` C#
byte b = checked((Byte) (100 + 200));  // OverflowException
byte b = (Byte)checked(100 + 200);   // b содержит 44

checked
{
    // Начало проверяемого блока
    Byte b = 100;
    b = (Byte) (b + 200);
}
```

Decimal не примитивный тип. Это структура, которая обрабатывается медленее. 
checked / unchecked для него не работают. Кидает `OverflowException`.

### Referenced VS Value types

[Referenced types](https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/reference-types)

[Value Types stored, Eric Lippert](https://blogs.msdn.microsoft.com/ericlippert/2010/09/30/the-truth-about-value-types/)

[Heap vs steak](http://www.c-sharpcorner.com/article/C-Sharp-heaping-vs-stacking-in-net-part-i/)