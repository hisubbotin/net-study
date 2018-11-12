``` ini

BenchmarkDotNet=v0.11.2, OS=macOS Mojave 10.14 (18A391) [Darwin 18.0.0]
Intel Core i5-6267U CPU 2.90GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.1.302
  [Host]     : .NET Core 2.1.2 (CoreCLR 4.6.26628.05, CoreFX 4.6.26629.01), 64bit RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 2.1.2 (CoreCLR 4.6.26628.05, CoreFX 4.6.26629.01), 64bit RyuJIT


```
|        Method |        Mean |      Error |     StdDev |
|-------------- |------------:|-----------:|-----------:|
| StringBuilder | 1,045.82 ns | 11.4764 ns | 10.1735 ns |
|          Join |   792.10 ns |  4.8079 ns |  4.0148 ns |
|        Concat |    25.88 ns |  0.6109 ns |  0.5715 ns |
