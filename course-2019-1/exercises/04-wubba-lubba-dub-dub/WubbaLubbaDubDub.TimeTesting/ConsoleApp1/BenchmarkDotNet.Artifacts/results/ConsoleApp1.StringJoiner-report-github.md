``` ini

BenchmarkDotNet=v0.11.5, OS=manjaro 
Intel Core i5-4200H CPU 2.80GHz (Haswell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.2.105
  [Host]     : .NET Core 2.2.3 (CoreCLR 4.6.27513.05, CoreFX 4.6.27513.05), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.3 (CoreCLR 4.6.27513.05, CoreFX 4.6.27513.05), 64bit RyuJIT


```
|                Method |    N |        Mean |      Error |     StdDev |      Median |
|---------------------- |----- |------------:|-----------:|-----------:|------------:|
|          **JoinFunction** |   **10** |    **258.7 ns** |   **5.855 ns** |  **16.704 ns** |    **254.9 ns** |
|        ConcatFunction |   10 |    172.7 ns |   3.324 ns |   3.557 ns |    171.8 ns |
| StringBuilderFunction |   10 |    522.3 ns |  27.117 ns |  79.955 ns |    501.8 ns |
|          **JoinFunction** |  **100** |  **1,765.5 ns** |  **34.951 ns** |  **42.923 ns** |  **1,758.9 ns** |
|        ConcatFunction |  100 |  1,236.7 ns |  23.592 ns |  23.171 ns |  1,237.2 ns |
| StringBuilderFunction |  100 |  2,873.3 ns |  88.450 ns | 255.200 ns |  2,784.4 ns |
|          **JoinFunction** | **1000** | **24,542.2 ns** | **338.332 ns** | **282.522 ns** | **24,549.6 ns** |
|        ConcatFunction | 1000 | 16,602.1 ns | 207.622 ns | 194.209 ns | 16,599.4 ns |
| StringBuilderFunction | 1000 | 36,171.3 ns | 706.268 ns | 785.015 ns | 36,122.6 ns |
