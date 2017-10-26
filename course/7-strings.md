# Strings

<!-- TOC -->

- [Strings](#strings)
  - [Char](#char)
    - [Char methods](#char-methods)
  - [String](#string)
    - [Сравнение строк](#сравнение-строк)
    - [Compare](#compare)
  - [Создание, преобразование строк. Класс StringBuilder](#создание-преобразование-строк-класс-stringbuilder)
  - [Кодировки, преобразование строк в байт](#кодировки-преобразование-строк-в-байт)

<!-- /TOC -->

<div style="page-break-after: always;"></div>

## Char

[сhar](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/char) - 16 bite символ [UTF-16](https://en.wikipedia.org/wiki/UTF-16)

- Представляет собой структуру [System.Char](https://docs.microsoft.com/en-us/dotnet/api/system.char?view=netstandard-2.0)
- Value type

```cs
public struct Char : IComparable, IComparable<char>, IConvertible, IEquatable<char>

char[] chars = new char[4];

chars[0] = 'X';        // Character literal
chars[1] = '\x0058';   // Hexadecimal
chars[2] = (char)88;   // Cast from integral type
chars[3] = '\u0058';   // Unicode
```

- Разница между `\x`, `\u\` - [SOF Jon Skeet](https://stackoverflow.com/questions/32175482/what-is-the-difference-between-using-u-and-x-while-representing-character-lite):
  - `\x` - 1-4 hex digits
  - `\u` - 4 hex digits
- implicit convert to `ushort, int, uint, long, ulong, float, double, decimal`.

<div style="page-break-after: always;"></div>

### Char methods

```cs
char chA = 'A', ch1 = '1';
string str = "test string";

chA.CompareTo('B');         // "-1" (meaning 'A' is 1 less than 'B')
chA.Equals('A');            // True
Char.GetNumericValue(ch1);  // 1
Char.IsControl('\t');       // True
Char.IsDigit(ch1);          // True
Char.IsLetter(',');         // False
Char.IsLower('u');          // True
Char.IsNumber(ch1);         // True
Char.IsPunctuation('.');    // True
Char.IsSeparator(str, 4);   // True
Char.IsSymbol('+');         // True
Char.IsWhiteSpace(str, 4);  // True
Char.Parse("S");            // S
Char.ToLower('M');          // m
'x'.ToString();             // x
```

<div style="page-break-after: always;"></div>

Unicode символ вообще кодируется 21 бит, поэтому иногда символ кодируется двумя `char`

- Если символ выходит за пределы стандартных
- Если используются глифы

```cs
char[] chars = { '\u0061', '\u0308' };
string strng = new String(chars);
Console.WriteLine(strng);               // ä

string good = "Tab\x9Good compiler";    // Tab  Good compiler
string bad =  "Tab\x9Bad compiler";     // Tab鮭 compiler

```

## String

Строка - неизменяемая упорядоченная коллекция `char`

- ссылочный тип
- неизменяемые (immutable)
- класс sealed из-за оптимизации

```cs
String s = "Hi\r\nthere.";                  // неправильно
s = "Hi" + Environment.NewLine + "there.";  // правильно

s = "";           // плохо
s = string.Empty; // норм

s = "Hi" + " " + "there."; // Строки литеральные, выполнится при компиляции
s = string.Concat("Hi", " ", "there.");
s = string.Format("{0} {1}", "Hi", "there.");
s = $"{myVariable1} some text {myClassVariable.SomeProperty}"; // интерполяция
```

- Для verbatim строк символ `\` не рассматривается как управляющий

```cs
string file = "C:\\Windows\\System32\\Notepad.exe";
String file = @"C:\Windows\System32\Notepad.exe"; // Verbatim string
```

- Строки неизменяемы (3ий повтор фразы)
- Чем больше методов, тем больше объектов в куче
- На одинаковые строки могут ссылаться разные объекты
- Нет проблем с многопоточностью

```cs
if (s.ToUpperInvariant().Substring(10, 21).EndsWith("EXE"))
{
}
```

### Сравнение строк

```cs
if (myStr == myStr2) // Не надо так

// Лучше так:
Boolean Equals(String value, StringComparison comparisonType);
static Boolean Equals(String a, String b, StringComparison comparisonType);
```

```cs
public enum StringComparison
{
    CurrentCulture = 0,
    CurrentCultureIgnoreCase = 1,
    InvariantCulture = 2,
    InvariantCultureIgnoreCase = 3,
    Ordinal = 4,
    OrdinalIgnoreCase = 5
}
```

- Ordinal сравнивает по unicode кодам
- Invariant по некому "дефолтному" списку символов

[MSDN Strings Best Practice](https://docs.microsoft.com/en-us/dotnet/standard/base-types/best-practices-strings), [SOF Ordinal Vs Invariant](https://stackoverflow.com/questions/492799/difference-between-invariantculture-and-ordinal-string-comparison):

- Используйте перегруженные версии Equals для сравнения строк
- Используйте `StringComparison.Ordinal` or `StringComparison.OrdinalIgnoreCase` по-дефолту, когда вам не важна локаль
- Ordinal намного быстрее Invariant ([to 10x](https://rhale78.wordpress.com/2011/05/16/string-equality-and-performance-in-c/))
- Используйте `CurrentCulture` для отображения пользователю
- Используйте `String.ToUpperInvariant` вместо Lower для нормализации сравнения
- Не используйте `Invariant` в большинстве случаев, кроме суперредких ситуаций, когда вам важны спец символы, но при этом не важны особенности культуры

### Compare

```cs
static int Compare(String strA, String strB, StringComparison comparisonType);
static int Compare(string strA, string strB, Boolean ignoreCase, CultureInfo culture);
static int Compare(String strA, String strB, CultureInfo culture, CompareOptions options);
```

- Используйте Compare только для сортировки, не для равенства!

```cs
[Flags]
public enum CompareOptions
{
    None = 0,
    IgnoreCase = 1,
    IgnoreNonSpace = 2,
    IgnoreSymbols = 4,
    IgnoreKanaType = 8,
    IgnoreWidth = 0x00000010,
    Ordinal = 0x40000000,
    OrdinalIgnoreCase = 0x10000000,
    StringSort = 0x20000000
}
```

```cs
bool StartsWith(String value, StringComparison comparisonType);
bool StartsWith(String value, Boolean ignoreCase, CultureInfo culture);

bool EndsWith(String value, StringComparison comparisonType);
bool EndsWith(String value, Boolean ignoreCase, CultureInfo culture);
```

### Interning

- Создается внутренняя хеш-таблица
- В ней содержатся ссылки на объекты строк в куче
- Строки указанные в хеш-таблице не освобождаются GC!

```cs
public static String Intern(String str); // Добавляет строку, если не нашел
public static String IsInterned(String str); // Возвращает null, если не нашел
```

- По-умолчанию clr интернирует все литеральные строки, описанные в метаданных. Но не надо на это рассчитывать
- Можно рассчитывать только на ручной вызов `Intern`

```cs
String s1 = "Hello";
String s2 = "Hello" + string.Empty;
String s3 = "Hell" + string.Empty + "o";
Console.WriteLine(Object.ReferenceEquals(s1, s2)); // True
Console.WriteLine(Object.ReferenceEquals(s1, s3)); // false

s1 = String.Intern(s1);
s3 = String.Intern(s3);
Console.WriteLine(Object.ReferenceEquals(s1, s3)); // True
```

## Создание, преобразование строк. Класс StringBuilder

## Кодировки, преобразование строк в байт
