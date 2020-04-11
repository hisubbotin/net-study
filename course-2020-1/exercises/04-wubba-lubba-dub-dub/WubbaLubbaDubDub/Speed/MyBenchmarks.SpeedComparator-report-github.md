``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18362.720 (1903/May2019Update/19H1)
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.202
  [Host]     : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), X64 RyuJIT
  DefaultJob : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), X64 RyuJIT


```
|            Method |      Mean |     Error |    StdDev |
|------------------ |----------:|----------:|----------:|
|          TestJoin | 489.00 ns |  9.619 ns |  9.878 ns |
| TestStringBuilder |  86.29 ns |  1.756 ns |  2.156 ns |
|        TestConcat | 569.31 ns | 11.258 ns | 16.851 ns |
