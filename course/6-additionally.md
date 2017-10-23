# Additionally

<!-- TOC -->

- [Additionally](#additionally)
  - [Generic](#generic)
    - [Open / Closed constructed types](#open--closed-constructed-types)
    - [Обобщения при наследовании](#обобщения-при-наследовании)
    - [Generic Interface](#generic-interface)
    - [Generic Delegate](#generic-delegate)
    - [Ограничения обобщений](#ограничения-обобщений)
    - [Работа с переменными обобщенного типа](#работа-с-переменными-обобщенного-типа)
      - [Сравнение](#сравнение)
      - [Сравнение с null](#сравнение-с-null)
      - [`default`](#default)
      - [Приведение переменной обобщенного типа](#приведение-переменной-обобщенного-типа)
      - [Использование в качестве операндов](#использование-в-качестве-операндов)
    - [Рекомендации](#рекомендации)
  - [Some Interfaces](#some-interfaces)
    - [Ковариантность](#ковариантность)
    - [Контрвариантность](#контрвариантность)
  - [Equals](#equals)
  - [Анонимные типы, dynamic](#анонимные-типы-dynamic)

<!-- /TOC -->

<div style="page-break-after: always;"></div>

## Generic

Позволяют многократно использовать алгоритмы, создавая типизированные параметры.
[MSDN](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/)

- Можно сделать Generic Class, method, delegate, interface

Common Class:

```cs
class Element
{
    public object Key { get; set; }
    public int Value { get; set; }
}

Element element = new Element { Value = 32, Key = 2 };
Element another = new Element { Value = 33, Key = "4356" };
int key = (int)element.Key;
string key2 = (string)another.Key;
```

<div style="page-break-after: always;"></div>

Generic Class:

- T - type parameters
- Стандартный codestyle: использовать в этом качестве имена, начинающиеся с T: `T`, `TKey`, `TValue`, `TResult` или однобуквенные `K`, `V`

```cs
class Element<T>
{
    public T Key { get; set; }
    public int Value { get; set; }
}

// Boxing/Unboxing не происходит
Element<int> element = new Element<int> { Value = 32, Key = 2 }; 
Element<string> another = new Element<string> { Value = 33, Key = "4356" };
int key = element.Id;
string key2 = another.Id;
```

<div style="page-break-after: always;"></div>

Если надо задать несколько типов:

```cs
class Element<TKey, TValue>
{
    public TKey Key { get; set; }
    public TValue Value { get; set; }
}
```

Если хочется обобщить только метод:

```cs
public static void WriteToLog<T>(T x)
{
    ILogger.Log(x);
}
```

<div style="page-break-after: always;"></div>

Пример с обобщенной коллекцией `List<T>`:

```cs
[Serializable]
public class List<T> : IList<T>, ICollection<T>, IEnumerable<T>, IList, ICollection, IEnumerable
{
    public List();
    public void Add(T item);
    public Int32 BinarySearch(T item);
    public void Clear();
    public Boolean Contains(T item);
    public Int32 IndexOf(T item);
    public Boolean Remove(T item);
    public void Sort();
    public void Sort(IComparer<T> comparer);
    public void Sort(Comparison<T> comparison);
    public T[] ToArray();
    public Int32 Count { get; }
    public T this[Int32 index] { get; set; }
}
```

<div style="page-break-after: always;"></div>

Плюсы Generic:

- быстродействие
- типизация
- простота кода
- не надо быть в курсе алгоритма, чтобы его использовать

<div style="page-break-after: always;"></div>

### Open / Closed constructed types

- [MSDN](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-classes), [SOF Jon Skeet Answer](https://stackoverflow.com/questions/1735035/generics-open-and-closed-constructed-types), [SOF Another Answer](https://stackoverflow.com/questions/2173107/what-exactly-is-an-open-generic-type-in-net)
- Типа разделяют все generic типы на открытые, которые оперируют неизвестным типом, и закрытые (все остальные)

```cs
void Swap<T>(List<T> list1, List<T> list2)
{
    //code to swap items
}

void Swap(List<int> list1, List<int> list2)
{
    //code to swap items
}
```

<div style="page-break-after: always;"></div>

Еще пример:

```cs
class BaseNode { }
class BaseNodeGeneric<T> { }

class NodeConcrete<T> : BaseNode { }        // concrete type

class NodeClosed<T> : BaseNodeGeneric<int> { } //closed constructed type

class NodeOpen<T> : BaseNodeGeneric<T> { }  //open constructed type
```

<div style="page-break-after: always;"></div>

- Open constructed types - нельзя создать экземпляр объекта

```cs
using System;
using System.Collections.Generic;

Оbject o = Activator.CreateInstance(typeof(List<>));
// Exception: Cannot create an instance of ... because Type.ContainsGenericParameters is true.

o = Activator.CreateInstance(typeof(List<string>)); // Создастся
```

- Разделение в целом умозрительное и на практике не используемое

<div style="page-break-after: always;"></div>

- CLR на каждый тип данных создает объект (type objects)
- Для каждого closed constructed type создается отдельный объект, что увеличивает рабочий размер приложения
- Статические поля для каждого такого объекта будут разными
- Статический конструктор (он же без параметров) будет вызван один на всех
- Для всех ссылочных таких типов CLR генерирует один код, что ускоряет ситуацию

```cs
internal sealed class GenericTypeThatRequiresAnEnum<T>
{
    static GenericTypeThatRequiresAnEnum()
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("T must be an enumerated type");
        }
    }
}
```

<div style="page-break-after: always;"></div>

### Обобщения при наследовании

Никак не препятствуют наследованию:

```cs
class BaseNodeGeneric<T> { }

class Node1 : BaseNodeGeneric<int> { }      //No error
class Node2<T> : BaseNodeGeneric<T> { }     //No error
class Node3<T> : BaseNodeGeneric<int> { }   //No error
class Node4<T, V> : BaseNodeGeneric<T> { }  //No error
class Node5 : BaseNodeGeneric<T> {}         //Generates an error
class Node6 : T {}                          //Generates an error
```

<div style="page-break-after: always;"></div>

Для случая с двуми параметрами:

```cs
class BaseNodeMultiple<T, U> { }

class Node4<T> : BaseNodeMultiple<T, int> { }   //No error
class Node5<T, U> : BaseNodeMultiple<T, U> { }  //No error
class Node6<T> : BaseNodeMultiple<T, U> {}      //Generates an error
```

<div style="page-break-after: always;"></div>

### Generic Interface

```cs
public interface IEnumerator<T> : IDisposable, IEnumerator
{
    T Current { get; }
}
```

```cs
public interface IList : ICollection, IEnumerable
```

### Generic Delegate

```cs
public delegate TReturn CallMe<TReturn, TKey, TValue>(TKey key, TValue value);
```

<div style="page-break-after: always;"></div>

### Ограничения обобщений

- Ограничения помогают компилятору знать, что можно делать c объектами открытого типа
- Когда мы ничего не знаем об открытом типе, то generic не удобны - метод вызвать не можем, как создать элемент непонятно

```cs
public static T Min<T>(T o1, T o2) where T : IComparable<T>
{
    if (o1.CompareTo(o2) < 0)
        return o1;
    return o2;
}
```

Multiple constrains:

```cs
class Base { }
class Test<T, U>
    where U : struct
    where T : Base, new() { }
```

<div style="page-break-after: always;"></div>

Какие бывают ограничения:

- Main constraint (может быть только одно)
  - `where T : struct` - T - значимый тип (кроме Nullable)
  - `where T : class` - любой ссылочный тип (class, interface, delegate, or array type).
  - `where T : <base class name>` - должен наследоваться (или являться) от базового класса. Нельзя указать `System.Object, System.Array, System.Delegate, System.MulticastDelegate, System.ValueType, System.Enum и System.Void`
- Secondary
  - `where T : <interface name>` - должен реализовывать указанный интерфейс
  - `where T : U` - ограничивает отношения между типами
- Constructor constraint (должен быть только один и быть последним)
  - `where T : new()` - должен иметь конструктор без параметров

```cs
class EmployeeList<T> where T : Employee, IEmployee, System.IComparable<T>, new()
{
    // ...
}
```

<div style="page-break-after: always;"></div>

```cs
internal sealed class ConstructorConstraint<T> where T : new()
{
    public static T Factory()
    {
        return new T();
    }
}
```

<div style="page-break-after: always;"></div>

### Работа с переменными обобщенного типа

- всегда можно конвертить к `System.Object` или явно к интерфейсу любому
- можно брать typeof и использовать reflection

#### Сравнение

```cs
private static void Comparing<T>(T o1, T o2)
{
    if (o1 == o2) { } // Ошибка
}
```

- `!=` and `==` нельзя использовать, потому что компилятор не знает, поддерживает ли тип это или нет
- Вообще значимые типы можно сравнивать только после перегрузки оператора `==`
- Если добавить ограничение `class`, то код будет работать
- Для значимых типов общего решения нет, вариантом может быть использование констрейнта интерфейса `IEquatable<T>` или реализация не обобщенных типов/методов

<div style="page-break-after: always;"></div>

#### Сравнение с null

```cs
private static void ComparingWithNull<T>(T obj)
{
    if (obj == null)
    { /* Этот код никогда не исполняется для значимого типа */ }
}
```

- Сравнивать с null можно всегда
- для значимых типов всегда вернет false
- бессмысленно при ограничении 'struct', компилятор ругнется

<div style="page-break-after: always;"></div>

#### `default`

- `default` используется для получения дефолтного значения в Generic типах/методах, поскольку null просто так получить не можем (для значимых)
- для ссылочных возвращает `null`
- для значимых 0 (инициализированное нулями значение)

```cs
class Element<T>
{
    T id = default(T);
}
```

```cs
private static void Example<T>()
{
    T temp = null; // Нельзя будет ошибка, потому что тип может быть значимым
    T temp = default(T);
}
```

<div style="page-break-after: always;"></div>

#### Приведение переменной обобщенного типа

Так не надо:

```cs
static void Cast<T>(T obj)
{
    int x = (Int32) obj ;       // Ошибка
    string s = (String) obj;    // Ошибка
}
```

Надо так:

```cs
static void Cast<T>(T obj)
{
    int x = (Int32) (Object) obj ;      // Все хорошо
    string s = (String) (Object) obj;   // Все хорошо
    string s2 = obj as String;          // Все хорошо
}
```

<div style="page-break-after: always;"></div>

#### Использование в качестве операндов

Всё плохо

```cs
static T Sum<T>(T num) where T : struct
{
    T sum = default(T) ;
    for (T n = default(T); n < num ; n++)
    {
        sum += n;
    }
    return sum;
}
// error CS0019: Operator '<' cannot be applied to operands
// error CS0023: Operator '++' cannot be applied to operand of type 'T'
// error CS0019: Operator '+=' cannot be applied to operands of type 'T' and 'T'
```

<div style="page-break-after: always;"></div>

### Рекомендации

Общие рекомендации по generic:

- Всегда используйте generic версии вместо `object` / `dynamic`!
- Ограничивайте констрейнтами!
- Для упрощения кода
  - никогда не делайте так:  `class DateTimeList : List<DateTime> {}`
  - можно так:  `using DateTimeList = System.Collections.Generic.List<System.DateTime>;`

Можно отметить:

- Нельзя сделать generic свойства, индексаторы, события, операторные методы, конструкторы, деструкторы (И вообщем это не нужно)
- Нельзя делать кастомных ограничений на конструкторы, только конструктор по-умолчанию
- Слабая поддержка операндов
- Нет! блин! ограничения на Enum / Delegate [SOF Eric Lippert + Jon Skeet Answers](https://stackoverflow.com/questions/1331739/enum-type-constraints-in-c-sharp/1331811#1331811), [SOF Another](https://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum), [EnumNet](https://github.com/TylerBrinkley/Enums.NET)

<div style="page-break-after: always;"></div>

Пример того, как вообще можно, забавный хак:

```cs
public abstract class AbstractEnumHelper<TClass> where TClass : class
{
    public static TStruct Parse<TStruct>(string value) where TStruct : struct, TClass
    {
        return (TStruct) Enum.Parse(typeof(TStruct), value);
    }
}

public class EnumHelper : AbstractEnumHelper<Enum> {}

//usage:
EnumHelper.Parse<MyEnum>("value");
```

<div style="page-break-after: always;"></div>

Более простой вариант:

```cs
public T Parse<T>(string value) where T : struct, IComparable, IFormattable, IConvertible
{
   if (!typeof(T).IsEnum)
   {
      throw new ArgumentException("T must be an enumerated type");
   }

   return (T) Enum.Parse(typeof(T), value);
}
```

<div style="page-break-after: always;"></div>

## Some Interfaces

### Ковариантность

### Контрвариантность

## Equals

## Анонимные типы, dynamic

<div style="page-break-after: always;"></div>