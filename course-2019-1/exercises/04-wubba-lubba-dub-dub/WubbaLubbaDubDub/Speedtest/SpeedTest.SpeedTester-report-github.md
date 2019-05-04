``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.472 (1803/April2018Update/Redstone4)
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
Frequency=2156249 Hz, Resolution=463.7683 ns, Timer=TSC
.NET Core SDK=2.1.504
  [Host]     : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT


```
|            Method |       Mean |     Error |    StdDev |
|------------------ |-----------:|----------:|----------:|
|          TestJoin |   246.9 ns |  2.388 ns |  1.994 ns |
| TestConcatenation | 1,262.3 ns | 27.238 ns | 30.275 ns |
|       TestBuilder | 1,023.4 ns | 24.757 ns | 71.825 ns |
