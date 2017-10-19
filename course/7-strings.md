# Strings

<!-- TOC -->

- [Strings](#strings)
  - [Char](#char)
    - [Char methods](#char-methods)
  - [String](#string)
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
sw.WriteLine(strng);                // ä
```

## String

Строка - последовательная коллекция `char`

- Строка в C# - Массив символов

## Создание, преобразование строк. Класс StringBuilder

## Кодировки, преобразование строк в байт
