# LINQ

<!-- TOC -->

- [LINQ](#linq)
  - [LINQ to](#linq-to)
  - [Methods](#methods)
  - [Deferred, Immediate Query Execution](#deferred-immediate-query-execution)
  - [Стандартный и Query Expressions синтакис запросов](#стандартный-и-query-expressions-синтакис-запросов)

<!-- /TOC -->

<div style="page-break-after: always;"></div>

## LINQ to

Пачка linq запросов к различным сущностям

- LINQ to Objects: операции с массивами и коллекциями
- LINQ to Entities: используется при обращении к базам данных через технологию Entity Framework
- [Deprecated] LINQ to Sql: технология доступа к данным в MS SQL Server
- LINQ to XML: операции с XML
- Parallel LINQ (PLINQ): параллельные запросы

По сути это набор extension методов для коллекций разного вида и QueryExpression синтаксис для них

<div style="page-break-after: always;"></div>

## Methods

Отложенные выборки:

- Select: определяет проекцию выбранных значений
- Where: определяет фильтр выборки
- OrderBy: упорядочивает элементы по возрастанию
- OrderByDescending: упорядочивает элементы по убыванию
- Reverse: располагает элементы в обратном порядке
- Distinct: удаляет дублирующиеся элементы из коллекции
- `Take`, `Skip`, `TakeWhile`, `SkipWhile` - пейджинг в выборке

<div style="page-break-after: always;"></div>

Отложенные объединения и группировки:

- Join: соединяет две коллекции по определенному признаку
- GroupBy: группирует элементы по ключу
- ToLookup: группирует элементы по ключу, при этом все элементы добавляются в словарь
- Concat: объединяет две коллекции
- Zip: объединяет две коллекции в соответствии с определенным условием
- Except: возвращает разность двух коллекцию, то есть те элементы, которые содератся только в одной коллекции
- Union: объединяет две однородные коллекции
- Intersect: возвращает пересечение двух коллекций, то есть те элементы, которые встречаются в обоих коллекциях

<div style="page-break-after: always;"></div>

Неотложенные:

- All: определяет, все ли элементы коллекции удовлятворяют определенному условию
- Any: определяет, удовлетворяет хотя бы один элемент коллекции определенному условию
- Contains: определяет, содержит ли коллекция определенный элемент
- `Count` - количество элементов коллекции, которые удовлетворяют определенному условию
- `Sum`, `Average`, `Min`, `Max` - арифметические вычисления

<div style="page-break-after: always;"></div>

Немедленная выборка конкретного элемента:

- First: выбирает первый элемент коллекции
- FirstOrDefault: выбирает первый элемент коллекции или возвращает значение по умолчанию
- Single: выбирает единственный элемент коллекции, если коллекция содердит больше или меньше одного элемента, то генерируется исключение
- SingleOrDefault: выбирает первый элемент коллекции или возвращает значение по умолчанию
- ElementAt: выбирает элемент последовательности по определенному индексу
- ElementAtOrDefault: выбирает элемент коллекции по определенному индексу или возвращает значение по умолчанию, если индекс вне допустимого диапазона
- Last: выбирает последний элемент коллекции
- LastOrDefault: выбирает последний элемент коллекции или возвращает значение по умолчанию

<div style="page-break-after: always;"></div>

```cs
var list = new List<string> { "First", "Second", "Third", "Fourth", "Fifth"};

IEnumerable<string> query = list.Where(x => x.Contains("i");
int count = query.Count();
string element = query.LastOrDefault();
var ordered = list.OrderBy(x => x).ToList();
```

<div style="page-break-after: always;"></div>

Пример, как можно писать в функциональном стиле :)

FizzBuzz - Counting from 1 to 100, and
  every time a number is divisible by 3 calling "Fizz",
  every time a number is divisible by 5 calling "Buzz" and
  every time a number is divisible by 3 and 5, calling "FizzBuzz instead of the number

<div style="page-break-after: always;"></div>

```cs
public void DoFizzBuzz()
{
    for (int i = 1; i <= 100; i++)
    {
        bool fizz = i % 3 == 0;
        bool buzz = i % 5 == 0;
        if (fizz && buzz)
            Console.WriteLine ("FizzBuzz");
        else if (fizz)
            Console.WriteLine ("Fizz");
        else if (buzz)
            Console.WriteLine ("Buzz");
        else
            Console.WriteLine (i);
    }
}
```

<div style="page-break-after: always;"></div>

```cs
Enumerable.Range(1, 100)
    .Select(x =>
        (x % 15 == 0) ? "FIZZBUZZ"
        : (x % 5 == 0) ? "BUZZ"
        : (x % 3 == 0) ? "FIZZ"
        : x.ToString()
    ).ToList().ForEach(console.WriteLine);
```

<div style="page-break-after: always;"></div>

Использование метода `ForEach(x=> ...)` вместо цикла `foreach` считается не очень

- ухудшает читаемость
- появляются замыкания

```cs
var list = new List<string> { "First", "Second", "Third", "Fourth", "Fifth"};

// лучше не так
list.ForEach(x=> Console.WriteLine(x));

// Делайте так:
foreach(var x in list)
    Console.WriteLine(x);

```

<div style="page-break-after: always;"></div>

## Deferred, Immediate Query Execution

Запросы делятся на [отложенные и неотложенные](https://msdn.microsoft.com/ru-ru/library/bb738633(v=vs.110).aspx):

- Отложенные запросы `Where`, `OrderBy`, `Join`, etc не выполняются сразу
- Реально выполнение запроса будет происходить только при вызове неотложенных запросов (`Count`, `SingleOrDefault`, `First`, `ToList`, etc) или при переборе `foreach`

```cs
string[] teams = { "First", "Second", "Third", "Fourth", "Fifth"};

IEnumerable<string> query = teams.Where(x=>x.Contains("i"));

Console.WriteLine(query.Count());  // 3
teams[1] = "Linq";
Console.WriteLine(query.Count());  // 4
```

<div style="page-break-after: always;"></div>

Можно фильтровать, не выполняя запрос:

```cs
IEnumerable<User> users = getAllUsers;

if (filter.Type != CredentialType.Undefined)
    users = users.Where(c => c.CredentialType == credentialType);

if (! string.IsNullOrEmpty(filter.Credential))
    users = users.Where(c => c.Credential == filter.Credential);

users = users.Skip(10).Take(6);
users = users.ToList();             // Реальное выполнение только здесь
```

<div style="page-break-after: always;"></div>

Подробно как выполняются отложенные запросы:

```cs
void Main()
{
    var query = GetInts().Skip(5);

    Console.WriteLine("== First iteration:");
    Console.WriteLine(string.Join(",", query.Take(3).ToList()));

    Console.WriteLine("== Second iteration:");
    // вот здесь он по новой создаст автомат и прогенерирует заново
    Console.WriteLine(string.Join(",", query.Take(3).ToList()));
}

private IEnumerable<int> GetInts()
{
    var i = 0;
    while (true)
    {
        Console.WriteLine($"yield return {i}");
        yield return i++;
    }
}
```

<div style="page-break-after: always;"></div>

## Стандартный и Query Expressions синтакис запросов

- Помимо вызова Extension методов можно использоть Query Expressions синтаксис, который отдаленно напоминает tsql
- Используется для более наглядного написания join'ов

Inner join:

```cs
from l in db.Licenses
join il in db.InstanceLicenses on l.Id equals il.LicenseId
where il.InstanceId == instanceId
select l
```

<div style="page-break-after: always;"></div>

left outer join [SOF](http://stackoverflow.com/questions/267488/linq-to-sql-multiple-left-outer-joins?rq=1):

```cs
var userQuery =
    from user in context.GetTable<User>()
    from email in context.GetTable<UserEmail>().Where(x => x.EmailId == userProfile.EmailId).DefaultIfEmpty()
    where userProfile.UserId == userId
    select new { User = user, Email = email};

var result = userQuery.SingleOrDefault();
```

<div style="page-break-after: always;"></div>

multiple group by [SOF](https://stackoverflow.com/questions/5231845/c-sharp-linq-group-by-on-multiple-columns)

```cs
var consolidated =
    from x in elementList
    group x by new
    {
        x.Type,
        x.Key,
        x.Value,
    } into gcs
    select new
    {
        Type = gcs.Key.Type,
        Key = gcs.Key.Key,
        Value = gcs.Key.Value,
        List = gcs.ToList(),
    };
```