``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18362.720 (1903/May2019Update/19H1)
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.202
  [Host]     : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), X64 RyuJIT
  DefaultJob : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), X64 RyuJIT


```
|            Method |     Mean |   Error |  StdDev |
|------------------ |---------:|--------:|--------:|
|          TestJoin | 493.7 ns | 7.10 ns | 6.64 ns |
| TestStringBuilder | 242.2 ns | 2.93 ns | 2.74 ns |
|        TestConcat | 591.7 ns | 6.04 ns | 5.04 ns |
