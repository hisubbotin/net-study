## Types

### Базовые типы

| Type                  | Alias                  | Size                     | Explanation                 |
| --------------------- | ---------------------- | ------------------------ | ------------------------------- |
| System.Boolean        | boolean                | [1 byte][bool-url]       | true / false                             |
| System.Byte / SByte   | byte / sbyte           | 1 byte                   | Unsigned integer 0 to 255                |
| System.Int16 / UInt16 | short / ushort         | 2 byte                   | Signed integer ±32,767                   |
| System.Int32 / UInt32 | int / uint             | 4 byte                   | ... ±2,147,483,647                       |
| System.Int64 / UInt64 | long / ulong           | 8 byte                   | ... ±9,223,372,036,854,775,807           |
| System.Single         | [float][float-url]     | 4 byte                   | [Single-precision][single-pre] floating-point  ±3.4*10^38 |
| System.Double         | double                 | 8 byte                   | Double-precision floating point ±1.7*10^308 |
| System.Decimal        | [decimal][decimal-url] | 16 byte                  | decimal number ±7.9*10^28                |
| System.Char           | char                   | 2 byte                   | Single unicode char                      |
| System.String         | string                 |                          | Sequence of char                         |
| System.Object         | object                 | 4 / 8 (x86/x64, в стеке) | Base Type                                |
| System.Guid           | [Guid][guid-url]       | 16 byte                  |                                          |

[bool-url]:https://stackoverflow.com/questions/2308034/primitive-boolean-size-in-c-sharp
[guid-url]:https://msdn.microsoft.com/en-us/library/system.guid(v=vs.110).aspx
[decimal-url]:https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/decimal
[float-url]:https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/float
[single-pre]:https://en.wikipedia.org/wiki/Single-precision_floating-point_format

Не рекомендуется использовать Sbyte / UInt как не CLS совместимые. Помимо этого:

- Многие стандартные методы возвращают обычные типы (получится дополнительная конвертация).
- Если не хватает размера, то увеличение в 2 раза не решает проблему.

#### Decimal vs (Float/Double)

|         | bits | base | mantissa | exponent | precision digits |
| ------- | ---- | ---- | -------- | -------- | ---------------- |
| float   | 32   | 2    | 23       | 8        | 7                |
| double  | 64   | 2    | 52       | 11       | 15-16            |
| decimal | 128  | 10   | 96       | 5 (0-28) | 28-29            |

decimal - не примитивный тип и работает сильно медленее double (до 20 раз).
Используется для валют и чисел, которые исконно "десятичные" (CAD, engineering, etc).

Не надо сравнивать double через `==`.
У double есть зарезервированные значения `double.NaN`, `double.Epsilon`, `double.Infinity`.

``` C#
double a = 0.1;
double b = 0.2;
Console.WriteLine(a + b == 0.3); // false

decimal c = 0.1M;
decimal d = 0.2M;
Console.WriteLine(c + d == 0.3M); // true
```

### Локальная инициализация

``` C#
<datatype> <variable name>;
<datatype> <variable name> = <value>;
```

``` C#
int x;
System.Int32 x = new System.Int32(); // Эквивалент
bool isValid = true;
double y = 3.0;
int t = 0x1D; // шестнадцатиричное представление 29
float f = 33.1f; // Используем суфикс, чтобы студия не считала его double
decimal d = 11.1m; // m для decimal
string s = "Hello!";
char c = 's';
int z = x + 5;
int i, j, k, l = 0;
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
    .ToDictionary(x => x.Name, y => y.Value); // Дискуссионно, потому что итоговый тип может быть громоздким и будет отвлекать внимание от основного кода

// Используйте в циклах
foreach (var element in myList)
{
    // ...
}
```

### Namespaces

Пространства имен нужны для логической группировки родственных типов.
Делают имя класса уникальным для компилятора.

``` C#
using System.IO; // директива заставляет компилятор добавлять этот префикс к классам, пока не найдет

using myButton = Abbyy.SharedControls.Button; // Добавляем alias для класса при пересечении с другим таким же классом
```

Пространства имен и сборки могут не быть связаны друг с другом. Типы одного пространства имен могут быть реализованы разными сборками.

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

Поразрядные операции над двоичной формой числа:

- `&` И
- `|` ИЛИ
- `^` исключающее ИЛИ / XOR
- `~` инверсия
- `x<<y` / `x>>y` сдвигает число `x` на `y` разрядов

Операции с присваиванием
 `+=`, `-=`, `^=`, ...
 `x += y` эквивалент `x = x + y`

#### Логические операторы

Логические операторы возвращают bool

- `|`, `&` - логическое ИЛИ / И
- `||` / `&&` - оптимизированные операции ИЛИ / И: второе условие вычисляется только, если первое прошло проверку
- `!` - логическое отрицание
- `^` - исключающие ИЛИ

- `==` равенство `if (a == b)`
- `!=` неравенство

#### Ternary operator

Тернарный оператор `?:` по bool условию возвращает левое или правое значение.

`result = condition ? left : right`

``` C#
// Аналог
if (condition)
    result = left;
else 
    result = right;

// Лучше всего использовать для присвоения / возврата простых значений
int result = Check() ? 1 : 0;

// Использование в качестве параметра метода
someMethod((sampleCondition) ? 3 : 1);

// Еще пример
int ticketLifetime = licenses.Any()
    ? licenses.Select(x => x.TicketExpiration).Min()
    : TicketMinutesLifetime;

// Можно делать вложенные, но не стоит увлекаться, делает код нечитаемым.
int x = 1, y = 2;
string result = x > y
    ? "x > y"
    : x < y
        ? "x < y"
        : x == y
            ? "x = y"
            : "lul";
```

[SOF Examples of usage](https://stackoverflow.com/questions/3312786/benefits-of-using-the-conditional-ternary-operator)

#### Null coalescing operator

[Null-coalescing](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-conditional-operator) `??` оператор возвращает левый объект, если он не равен null, иначе возвращает правый.

`result = left ?? right;`

Можно складывать в цепочку.

 ``` C#
 int x = param1 ?? localDefault;
 string anybody = getValue() ?? localDefault ?? globalDefault;
 ```

 [SOF Discussion](https://stackoverflow.com/questions/278703/unique-ways-to-use-the-null-coalescing-operator)

#### Null conditional operator

 [null-conditional operator](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-conditional-operators) `?.` проверяет на null до доступа к полю/свойству/индексу обьекта, и если объект null, то возвращает null, иначе возвращает член объекта.

 Позволяет убрать некоторое количество проверок объектов на null / упростить использование тернарного оператора

``` C#
int? length = customers?.Length; // null if customers is null

// Вместо примерно такого кода
int? length = customers == null ? (int?) null : customers.Length;
// или такого
if (customers == null)
    length = null;
else
    length = customers.Length;


Customer first = customers?[0];  // Доступ к индексу
int? count = customers?[0]?.Orders?.Count();  // Множественный сложный вариант
```

### Переполнение

По-умолчанию проверка переполнения выключена. Код выполняется быстрее.

Операторы `checked`/`unchecked`

``` C#
byte a = 100;
byte b = checked((Byte) (a + 200));  // OverflowException
byte c = (Byte)checked(a + 200);   // b содержит 44, потому что сначала сложение конвертируется к Int32, потом проверяется, а потом кастуется к byte

checked
{
    // Начало проверяемого блока
    Byte d = 100;
    b = (Byte) (d + 200);
}
```

Decimal не примитивный тип. `checked / unchecked` для него не работают. Кидает `OverflowException`.

Рихтер рекомендует в процессе разработки ставить флаг компилятору `checked+`, чтобы проверка по-дефолту была включена всегда, программист уже руками расставляет `cheched / unchecked`, где нужно. А при релизе убрать этот флаг компилятора.

### Stack & Heap

Есть Stack (стэк) и есть Heap (управляемая куча) (Ваш КЭП).
Обычно OS выделяет одну кучу на приложение (но можно сделать несколько).
На каждый поток (thread) OS создает свой выделенный стэк (в винде по-умолчанию 1Mb).
И то и другое живет в RAM. Стэк намного быстрее из-за более простого управления хранением объектов, плюс cpu имеет регистры для работы со стеком и помещает частодоступные объекты из стека в кэш.

Куча управляется clr, стек более низкоуровневая фигня вплоть до процессорной архитектуры.

Стек представляет собой LastInFirstOutput очередь. Размер стека конечен, его нельзя расширить и в него нельзя пихать большие объекты. Примерная его работа понятна по картинке:

![Stack](pics/stack.png)

После завершения метода память выделенная под него в стеке сразу же освобождается.

CLR сама решает, где хранить объекты в стеке или куче, у программиста нет прямой возможности управлять этим.

[SOF explanation stack & heap](https://stackoverflow.com/questions/79923/what-and-where-are-the-stack-and-heap?rq=1)

### Referenced VS Value types

Все объекты в C# делятся на 2 типа: [Value types](https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/value-types) и [Referenced types](https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/reference-types) (Значимые и ссылочные типы).
**Ссылочные** типы всегда хранятся в куче, в стеке помещается указатель на объект в куче (поэтому и Reference).
**Значимые** типы **могут** храниться в стеке, как локальные переменные.

Значимые типы, сохраненные в стеке, «легче» ссылочных: для них не нужно выделять память в управляемой куче, их не затрагивает сборка мусора, к ним нельзя обратиться через указатель.

Value Types:

- **enum**
- **struct**
  - bool
  - byte / short / int / long
  - decimal
  - char
  - float / double

Reference Types:

- object
- **class**
  - string

Все классы - ссылочные типы (в том числе всякие делегаты и пр).
Все структуры и перечисления (enum) - значимые (базовые типы - это тоже структуры).

Рекомендации от Рихтера по создаю своего value type:

- малый размер - до 16 байт
- ведет себя как базовый: в частности immutable поведение, отсутсвие методов изменяющих состояние полей, по сути readonly
- тип не имеет базового и производных от него

Почитать:

- [Heap vs steak in C#](http://www.c-sharpcorner.com/article/C-Sharp-heaping-vs-stacking-in-net-part-i/)
- [Value Types stored, Eric Lippert](https://blogs.msdn.microsoft.com/ericlippert/2010/09/30/the-truth-about-value-types/)

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

### Приведение типов

CLR гарантирует безопасность типов.
Всегда можно получить `.GetType()`, который нельзя переопределить.
В C# разрешено неявное безопасное приведение к базовому типу:

``` C#
int i = 1;
object a = i;
```

А так же расширяющие безопасные приведения базовых типов:

> byte > short > int > long > decimal
> int > double
> short > float > double

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

### Enum

Перечисление

``` C#
public enum Color
{
    Red = 1,
    Green = 2,
    Blue = 3
}

Console.WriteLine(Color.Red);
Console.WriteLine((int)Color.Red);
```

### Datetime

### GUID