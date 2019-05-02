``` ini

BenchmarkDotNet=v0.11.5, OS=ubuntu 18.04
Intel Core i5-3337U CPU 1.80GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.2.203
  [Host]     : .NET Core 2.2.4 (CoreCLR 4.6.27521.02, CoreFX 4.6.27521.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.4 (CoreCLR 4.6.27521.02, CoreFX 4.6.27521.01), 64bit RyuJIT


```
|            Method |     Mean |     Error |    StdDev |
|------------------ |---------:|----------:|----------:|
|          JoinTest | 253.3 ns |  5.110 ns |  9.967 ns |
| StringBuilderTest | 980.2 ns | 25.832 ns | 41.714 ns |
|        ConcatTest | 718.4 ns | 14.906 ns | 42.042 ns |
