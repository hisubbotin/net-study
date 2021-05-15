``` ini

BenchmarkDotNet=v0.12.1, OS=ubuntu 18.04
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.103
  [Host]     : .NET Core 5.0.3 (CoreCLR 5.0.321.7203, CoreFX 5.0.321.7203), X64 RyuJIT
  DefaultJob : .NET Core 5.0.3 (CoreCLR 5.0.321.7203, CoreFX 5.0.321.7203), X64 RyuJIT


```
|          Method |      Mean |     Error |    StdDev |
|---------------- |----------:|----------:|----------:|
|          MyJoin |  1.912 μs | 0.0637 μs | 0.1839 μs |
|        MyConcat |  1.135 μs | 0.0225 μs | 0.0375 μs |
| MyStringBuilder |  1.876 μs | 0.0372 μs | 0.0456 μs |
|  MyConcatAsPlus | 15.281 μs | 0.2821 μs | 0.2638 μs |
