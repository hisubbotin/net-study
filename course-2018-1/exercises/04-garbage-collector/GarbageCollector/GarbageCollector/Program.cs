using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GarbageCollector {
    class Program {
        static int GetArraySize<T>() {
            var size = typeof(T) == typeof(char) ? 2 : Marshal.SizeOf<T>(); // Shame on me!
            
            var left = 1;
            var right = 100 * 1024 / size;
            
            while (GC.GetGeneration(new T[right]) != 2) {
                ++right;
            }

            while (left < right - 1) {
                var middle = (left + right) / 2;

                if (GC.GetGeneration(new T[middle]) == 2) {
                    right = middle;
                }
                else {
                    left = middle;
                }
            }

            return right;
        }

        static void Unused<T>(T t) {
        }

        static TimeSpan GetAverageTime(int generation, int size) {
            var testsCount = 1000;

            var g2 = TimeSpan.Zero;
            for (var i = 0; i < testsCount; ++i) {
                var sw = new Stopwatch();
                Unused(new int[size]);
                sw.Start();
                GC.Collect(generation, GCCollectionMode.Forced, true);
                GC.WaitForPendingFinalizers();
                sw.Stop();
                g2 += sw.Elapsed;
            }

            return g2 / testsCount;
        }

        static void Main(string[] args) {
            Console.WriteLine(GetArraySize<int>() * sizeof(int));
            Console.WriteLine(GetArraySize<double>() * sizeof(double));
            Console.WriteLine(GetArraySize<char>() * sizeof(char));

            Console.WriteLine(GetAverageTime(0, GetArraySize<int>() - 1));
            Console.WriteLine(GetAverageTime(2, GetArraySize<int>()));
        }
    }
}
