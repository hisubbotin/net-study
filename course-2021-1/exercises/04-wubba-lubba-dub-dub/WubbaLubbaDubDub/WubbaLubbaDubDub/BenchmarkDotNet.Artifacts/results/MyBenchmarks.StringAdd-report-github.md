``` ini

BenchmarkDotNet=v0.13.0, OS=ubuntu 20.04
Intel Core i5-8250U CPU 1.60GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.203
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  DefaultJob : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT


```
|      Method |             Mean |             Error |            StdDev |
|------------ |-----------------:|------------------:|------------------:|
|        Join |         26.94 ns |          0.526 ns |          0.439 ns |
| BuilderJoin | 85,051,155.23 ns | 11,071,144.320 ns | 32,643,518.817 ns |
| Concatenate |         15.47 ns |          2.106 ns |          6.209 ns |
