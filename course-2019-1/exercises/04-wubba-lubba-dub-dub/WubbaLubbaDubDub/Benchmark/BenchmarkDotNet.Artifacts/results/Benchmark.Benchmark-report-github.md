``` ini

BenchmarkDotNet=v0.11.5, OS=ubuntu 18.04
Intel Core i5-8250U CPU 1.60GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.203
  [Host] : .NET Core 2.2.4 (CoreCLR 4.6.27521.02, CoreFX 4.6.27521.01), 64bit RyuJIT
  Core   : .NET Core 2.2.4 (CoreCLR 4.6.27521.02, CoreFX 4.6.27521.01), 64bit RyuJIT

Job=Core  Runtime=Core  

```
|        Method |    N | WordLength |           Mean |         Error |        StdDev | Rank |
|-------------- |----- |----------- |---------------:|--------------:|--------------:|-----:|
|    **StringJoin** |   **20** |         **10** |       **325.3 ns** |      **6.591 ns** |     **15.406 ns** |    **1** |
| StringBuilder |   20 |         10 |       446.7 ns |      8.960 ns |     22.147 ns |    3 |
|        Concat |   20 |         10 |       544.0 ns |     10.388 ns |      9.717 ns |    4 |
|    **StringJoin** |   **20** |        **100** |       **401.4 ns** |      **7.371 ns** |      **5.755 ns** |    **2** |
| StringBuilder |   20 |        100 |       721.8 ns |      9.597 ns |      8.014 ns |    5 |
|        Concat |   20 |        100 |     1,988.0 ns |     59.785 ns |     49.923 ns |    6 |
|    **StringJoin** | **1000** |         **10** |    **17,025.1 ns** |     **31.618 ns** |     **24.686 ns** |    **8** |
| StringBuilder | 1000 |         10 |    11,237.7 ns |    220.583 ns |    336.854 ns |    7 |
|        Concat | 1000 |         10 |   347,939.2 ns |  4,271.218 ns |  3,566.660 ns |   11 |
|    **StringJoin** | **1000** |        **100** |    **26,905.8 ns** |    **536.603 ns** |    **501.939 ns** |    **9** |
| StringBuilder | 1000 |        100 |    39,400.6 ns |  1,224.511 ns |  1,310.214 ns |   10 |
|        Concat | 1000 |        100 | 5,357,166.5 ns | 86,981.491 ns | 72,633.484 ns |   12 |
