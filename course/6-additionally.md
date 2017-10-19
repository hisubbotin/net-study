# Additionally

<!-- TOC -->

- [Generic](#generic)
  - [Generic типы и методы, constraint](#generic-типы-и-методы-constraint)
  - [Анонимные типы, dynamic](#анонимные-типы-dynamic)

<!-- /TOC -->

<div style="page-break-after: always;"></div>

## Generic типы и методы, constraint

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

- `default` используется для получения дефолтного значения в Generic типах/методах, поскольку null просто так получить не можем (для значимых)
- для ссылочных возвращает `null`
- для значимых 0 (инициализированное нулями значение)

```cs
class Element<T>
{
    T id = default(T);

    Element() {...}

    Element(T someValue) {...}
}

Element<string> element = new Element("some text");
```

<div style="page-break-after: always;"></div>

Если надо задать несколько типов

```cs
class Element<TKey, TValue>
{
    public TKey Key { get; set; }
    public TValue Value { get; set; }
}
```

Если хочется обобщить метод

```cs
public static void WriteToLog<T>(T x)
{
    ILogger.Log(x);
}
```

## Анонимные типы, dynamic

<div style="page-break-after: always;"></div>