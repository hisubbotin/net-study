``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 8.1 (6.3.9600.0)
Intel Core i7-3630QM CPU 2.40GHz (Ivy Bridge), 1 CPU, 8 logical and 4 physical cores
Frequency=2338436 Hz, Resolution=427.6362 ns, Timer=TSC
.NET Core SDK=2.1.504
  [Host] : .NET Core 2.1.8 (CoreCLR 4.6.27317.03, CoreFX 4.6.27317.03), 64bit RyuJIT


```
|        Method | Mean | Error |
|-------------- |-----:|------:|
|          Join |   NA |    NA |
| StringBuilder |   NA |    NA |
| Concatenation |   NA |    NA |

Benchmarks with issues:
  StringConcatenation.Join: DefaultJob
  StringConcatenation.StringBuilder: DefaultJob
  StringConcatenation.Concatenation: DefaultJob
