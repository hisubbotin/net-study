``` ini

BenchmarkDotNet=v0.11.5, OS=ubuntu 18.04
Intel Pentium CPU N3700 1.60GHz, 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.2.202
  [Host]     : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT


```
|  Method |       Mean |     Error |   StdDev |     Median |
|-------- |-----------:|----------:|---------:|-----------:|
|    Join | 1,146.0 ns |  46.36 ns | 133.0 ns | 1,126.0 ns |
|  Concat |   976.0 ns |  55.56 ns | 160.3 ns |   928.3 ns |
| Builder | 3,550.9 ns | 151.37 ns | 419.4 ns | 3,422.3 ns |
