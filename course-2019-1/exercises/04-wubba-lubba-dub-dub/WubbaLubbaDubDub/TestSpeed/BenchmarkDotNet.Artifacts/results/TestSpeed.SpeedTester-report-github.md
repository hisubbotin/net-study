``` ini

BenchmarkDotNet=v0.11.5, OS=ubuntu 18.04
Intel Core i5-3317U CPU 1.70GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.2.105
  [Host]     : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT


```
|            Method |      Mean |     Error |    StdDev |
|------------------ |----------:|----------:|----------:|
|          JoinTest |  3.033 us | 0.0837 us | 0.1328 us |
|       BuilderTest |  8.431 us | 0.0713 us | 0.0667 us |
| ConcatinationTest | 26.927 us | 0.4566 us | 0.4048 us |
