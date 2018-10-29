# 06. Wubba Lubba Dub Dub

## Entry Point

Как обычно, рядом с этим документом расположена папка с солюшеном `WubbaLubbaDubDub`, открывай его.

В этот раз немного расслабимся - никаких лонгридов, никаких сотен методов, никаких отсылок к монадам и никаких глупых шуток (кроме названия).

Реализуй методы-расширения типа `string` в статическом классе `RicksMercilessEncryptor`, а затем добавь каждому из них юнит-тесты в классе `RicksMercilessEncryptorTests` проекта `WubbaLubbaDubDub.Tests`. Смотри, не заскучай!

И не забудь часть задания в произвольной форме - сравнить по скорости:

- `string.Join()`
- `StringBuilder`
- Конкатенацию

Напоминаю, что классно делать это с помощью [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet), терпимо с помощью `StopWatch` и нетерпимо с помощью `DateTime.UtcNow`