``` ini

BenchmarkDotNet=v0.10.0
OS=Windows
Processor=?, ProcessorCount=4
Frequency=1562453 Hz, Resolution=640.0193 ns, Timer=TSC
Host Runtime=.NET Core 4.6.26212.01, Arch=64-bit  [RyuJIT]
GC=Concurrent Workstation
dotnet cli version=2.1.403
Job Runtime(s):

Job=Core  Runtime=Core  

```
      Method |     N | Mean |
------------ |------ |----- |
        **Join** |  **1000** |   **NA** |
 Concatenate |  1000 |   NA |
       Build |  1000 |   NA |
        **Join** | **10000** |   **NA** |
 Concatenate | 10000 |   NA |
       Build | 10000 |   NA |

Benchmarks with issues:
  ConcatCompare.Join: Core(Runtime=Core) [N=1000]
  ConcatCompare.Concatenate: Core(Runtime=Core) [N=1000]
  ConcatCompare.Build: Core(Runtime=Core) [N=1000]
  ConcatCompare.Join: Core(Runtime=Core) [N=10000]
  ConcatCompare.Concatenate: Core(Runtime=Core) [N=10000]
  ConcatCompare.Build: Core(Runtime=Core) [N=10000]
