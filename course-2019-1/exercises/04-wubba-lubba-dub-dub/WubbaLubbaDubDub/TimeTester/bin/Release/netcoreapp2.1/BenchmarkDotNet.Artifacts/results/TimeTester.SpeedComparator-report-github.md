``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.706 (1803/April2018Update/Redstone4)
Intel Core i5-8250U CPU 1.60GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
Frequency=1757811 Hz, Resolution=568.8894 ns, Timer=TSC
.NET Core SDK=2.1.504
  [Host] : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT  [AttachedDebugger]

Job=InProcess  Toolchain=InProcessEmitToolchain  

```
|            Method |    N |         Mean |      Error |     StdDev |       Median |
|------------------ |----- |-------------:|-----------:|-----------:|-------------:|
|          **TestJoin** |  **100** |   **1,194.3 ns** |   **6.272 ns** |   **5.560 ns** |   **1,193.5 ns** |
| TestStringBuilder |  100 |   1,853.8 ns |   8.075 ns |   7.159 ns |   1,853.5 ns |
|        TestConcat |  100 |     726.8 ns |   8.584 ns |   8.030 ns |     724.6 ns |
|          **TestJoin** |  **500** |   **6,619.1 ns** |  **62.648 ns** |  **58.601 ns** |   **6,625.1 ns** |
| TestStringBuilder |  500 |   9,083.9 ns | 163.526 ns | 152.962 ns |   9,059.3 ns |
|        TestConcat |  500 |   4,022.5 ns |  92.355 ns | 264.984 ns |   3,927.9 ns |
|          **TestJoin** | **1000** |  **15,701.2 ns** | **156.450 ns** | **138.689 ns** |  **15,665.8 ns** |
| TestStringBuilder | 1000 |  19,830.7 ns | 214.075 ns | 189.772 ns |  19,880.1 ns |
|        TestConcat | 1000 |   7,640.3 ns |  89.604 ns |  83.816 ns |   7,618.7 ns |
|          **TestJoin** | **5000** | **114,844.8 ns** | **588.460 ns** | **550.446 ns** | **114,686.0 ns** |
| TestStringBuilder | 5000 | 151,723.1 ns | 921.243 ns | 861.731 ns | 151,585.8 ns |
|        TestConcat | 5000 |  82,885.8 ns | 560.850 ns | 437.875 ns |  82,698.9 ns |
