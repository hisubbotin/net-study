``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17134.407 (1803/April2018Update/Redstone4)
AMD A10-9600P RADEON R5, 10 COMPUTE CORES 4C+6G, 1 CPU, 4 logical and 4 physical cores
Frequency=2339359 Hz, Resolution=427.4675 ns, Timer=TSC
.NET Core SDK=2.1.202
  [Host] : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), 64bit RyuJIT  [AttachedDebugger]


```
|        Method | Mean | Error |
|-------------- |-----:|------:|
| StringBuilder |   NA |    NA |
|          Join |   NA |    NA |
|        Concat |   NA |    NA |

Benchmarks with issues:
  Benchmarks.StringBuilder: DefaultJob
  Benchmarks.Join: DefaultJob
  Benchmarks.Concat: DefaultJob
