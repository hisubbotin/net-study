# Types

## System.Object

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

Для приведения к производному типу нужо явное приведение:

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

## Базовые типы

| Type                  | Alias            | Size                    | Explanation  |
| --------------------- | ---------------- | ----------------------- | ------------ |
| System.Boolean        | boolean          | [1 byte][bool-url]      | true / false |
| System.Byte / SByte   | byte / sbyte     | 1 byte                  |              |
| System.Int16 / UInt16 | short / ushort   | 2 byte                  |              |
| System.Int32 / UInt32 | int / uint       | 4 byte                  |              |
| System.Int64 / UInt64 | long / ulong     | 8 byte                  |              |
| System.Single         | float            | 4 byte                  |              |
| System.Double         | double           | 8 byte                  |              |
| System.Decimal        | decimal          | 16 byte                 |              |
| System.Char           | char             | 2 byte                  |              |
| System.String         | string           | array of char           |              |
| System.Object         | object           | 4 / 8 + 4 / 8 (x86/x64) |              |
| System.Guid           | [Guid][guid-url] | 16 byte                 |              |

[bool-url]:https://stackoverflow.com/questions/2308034/primitive-boolean-size-in-c-sharp
[guid-url]:https://msdn.microsoft.com/en-us/library/system.guid(v=vs.110).aspx