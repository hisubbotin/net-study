# Курс .NET

- 1 [.NET]
  - CLR 
  - .Net Framework
  - .Net Core
  - Сборки
  - Nuget
- 2 Типы данных, значимые типы
  - Ссылочные / значимые типы
  - System.Object
  - Базовые типы, enum, decimal, datetime, timespan
  - Struct
  - Базовые операции и операторы
- 3 Классы
  - Конструкторы
  - Модификаторы доступа
  - Модификаторы типов: static, abstract, partial, sealed
  - Наследование, полиморфизм, интерфейсы
  - Перегрузка методов, операторов
  - Аттрибуты
  - Generic типы и методы, constraint
  - Анонимные типы, dynamic
  - Extension methods
  - Сборка мусора:
    - Алгоритм, GC
    - Финализаторы
    - Внешние ресурсы, IDisposable pattern
- 4 Строки
  - Символы и строки
  - Создание, преобразование строк. Класс StringBuilder
  - Кодировки, преобразование строк в байт
- 5 Управление программой
  - Циклы, IEnumerable, yield
  - Условные операторы
- 6 Коллекции
  - Типы коллекций и различия между ними
- 7 Делегаты и события
  - Делегаты и обобщенные делегаты, лямбда выражения
  - События
  - Замыкания
- 8 LINQ
  - Отложенные и неотложенные запросы
  - Стандартный и Query Expressions синтакис запросов
- 9 Обработка ошибок
  - Exception
  - throw / try / catch / finally
  - Debug / Trace
- 10 Reflection
- 11 Многопоточность и ассинхронность
  - Проблемы многопоточности
  - Примитивы синхронизации
  - Thread / Threadpool
  - TPL. Класс Task, Continuation, Cancellation
  - async / await, SyncronizationContext
- 12 Сериализация данных
  - JSON
  - XML
- 13 Ввод / вывод
  - Потоки
  - Чтение и запись текстовой информации
  - Работа с файловой системой. System.IO
- 14 Работа с базами данных
  - ADO.Net
  - Entity Framework
  - Simple mapper: dapper, linq2db
- 15 Принципы и паттерны проектирования
  - SOLID
  - Связь классов: наследование, ассоциация, композиция, агрегация
  - Dependency Injection, IOC, управление зависимостями
  - Тестируемость приложения, unit-test, Moq
  - Паттерны: Singleton, Factory, Strategy, Facade, Repository
- 16 Работа в web
  - Http в .Net, класс HttpClient
  - ASP.Net MVC Core

## .Net

### Литература

- [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- Jeffrey Richter, CLR Via C# (4th edition)
- Jon Skeet, C# in Depth
- Andrew Troelsen, C# 6.0 and the .NET 4.6 Framework (Самый низкий порог вхождения в изучение C#)
- Сергей Тепляков, [Набор доступных статей про принципам проектирования](http://sergeyteplyakov.blogspot.ru/2013/10/articles.html), книга "Паттерны проектирования на платформе .NET"

### История версий

C# | C# 1.0 | C# 2.0 | C# 3.0 | C# 4.0 | C# 5.0 | C# 6.0 | C# 7.0
-- | ----- | ----- | ----- | ----- | ----- | ----- | -----
[.NET&nbsp;Framework][NETFRWK] | 1.0/1.1 | 2.0 | 3.0/3.5 | 4.0 | 4.5 | 4.5/4.6 | 4.5-[4.7][Net47]
Visual&nbsp;Studio | 2002 | 2005 | 2008 | 2010 | 2012/13 | 2013/2015 | 2017
[Net Core][NetCore] | - | - | - | - | - | 1.0 | 1.1/2.0
Features | Basic | Generics Partial Nullable Properties Static Delegates | AnonymousTypes Extensions QueryExp Lambda |dynamic OptionalArgs Generic covariance| Async | [C# 6.0 New][C#6.0New] | [C# 7.0 New][C#7.0New]

[NetCore]:https://www.microsoft.com/net/
[NETFRWK]:https://www.microsoft.com/net/download/framework
[C#6.0New]:https://msdn.microsoft.com/ru-ru/magazine/dn879355.aspx
[C#7.0New]:https://blogs.msdn.microsoft.com/dotnet/2017/03/09/new-features-in-c-7-0/
[Net47]:https://blogs.msdn.microsoft.com/dotnet/2017/04/05/announcing-the-net-framework-4-7/

- [.NET Framework Guide](https://docs.microsoft.com/en-us/dotnet/framework/)
- [.NET Core Roadmap](https://github.com/dotnet/core/blob/master/roadmap.md)
- [C#7.0 with .Net Framework 4.0/4.5](https://stackoverflow.com/questions/42482520/does-c-sharp-7-0-work-for-net-4-5)

### Использование и применение

- Высокоуровневый ооп язык
- Строгая типизация
- Автоматическое управление памятью

Плюсы:
- Синтаксис и возможности
- Быстрое развитие
- IDE
- Отсутствие проблем с версиями (DLL хелл)

Минусы:
- До .Net Core сильнейшая привязка к Windows

[Java vs C# Stackoverflow](https://stackoverflow.com/questions/610199/the-art-of-programming-java-vs-c-sharp)

#### Применение
- ServerSide
- GameDev (Unity, ServerSide, etc)
- UWP / WPF / WinForms Application

### IDE

- Visual Studio 2017 + Resharper
- Visual Studio Code

### CLR