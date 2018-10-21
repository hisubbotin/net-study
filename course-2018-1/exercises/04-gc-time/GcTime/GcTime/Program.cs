using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace GcTime
{
	class Program
	{
		private static bool Asserts = true;

		static void TestArr<T>()
		{
			T[] arr = new T[0];
			int generation = 0;
			for (int i = 1; generation != 2; ++i)
			{
				arr = new T[i];
				int curGeneration = GC.GetGeneration(arr);
				if (curGeneration != generation)
				{
					Console.WriteLine($"Array of type {typeof(T).Name} moved to gen {curGeneration} at length {arr.Length} (size {Marshal.SizeOf(typeof(T)) * arr.Length})");
					generation = curGeneration;
				}
			}
		}

		static void TestString()
		{
			String s = "";
			int generation = 0;
			for (int i = 1; generation != 2; ++i)
			{
				s += 'a';
				int curGeneration = GC.GetGeneration(s);
				if (curGeneration != generation)
				{
					Console.WriteLine($"String moved to gen {curGeneration} at length {s.Length} (size {s.Length * sizeof(char)})");
					generation = curGeneration;
				}
			}
		}

		static T[][] GetGen0Arr<T>(int N, int size)
		{
			T[][] arr = new T[N][];
			for (int n = 0; n < N; ++n)
			{
				arr[n] = new T[size];
			}

			if (Asserts)
			{
				Debug.Assert(GC.GetGeneration(arr[0]) == 0);
			}
			return arr;
		}

		static T[][] GetGen1Arr<T>(int N, int size)
		{
			T[][] arr = new T[N][];
			for (int n = 0; n < N; ++n)
				arr[n] = new T[size];
			GC.Collect();
			if (Asserts)
			{
				Debug.Assert(GC.GetGeneration(arr[0]) == 1);
			}
			return arr;
		}

		static T[][] GetGen2Arr<T>(int N, int size)
		{
			T[][] arr = new T[N][];
			for (int n = 0; n < N; ++n)
				arr[n] = new T[size];
			for (int i = 0; i < 2; ++i)
				GC.Collect();
			if (Asserts)
			{
				Debug.Assert(GC.GetGeneration(arr[0]) == 2);
			}
			return arr;
		}

		static void TestGeneration<T>(int gen, int repeats, int size, int N, Func<int, int, T[][]> action)
		{
			GC.Collect(gen, GCCollectionMode.Forced);
			GC.WaitForPendingFinalizers();
			GC.WaitForFullGCComplete();
			double totalElapsed = 0;
			for (int i = -5; i < repeats; ++i)
			{
				Stopwatch sw = new Stopwatch();
				{
					T[][] arr = action(N, size);
					if (Asserts)
					{
						Debug.Assert(GC.GetGeneration(arr[0]) == gen);
					}
				}
				sw.Start();
				GC.Collect(gen, GCCollectionMode.Forced);
				GC.WaitForPendingFinalizers();
				GC.WaitForFullGCComplete();
				sw.Stop();
				double elapsedMs = sw.Elapsed.TotalMilliseconds;
				totalElapsed += elapsedMs;
			}

			Console.WriteLine($"Gen {gen}: {totalElapsed / repeats} ms");
		}

		static void Main(string[] args)
		{
			TestString();
			TestArr<int>();
			TestArr<double>();

			int size = 10; // Length of creating arrays
			int repeats = 1000; // Number of launches to get mean
			int N = 10000; // Number of arrays to be created

			TestGeneration(0, repeats, size, N, GetGen0Arr<int>);
			TestGeneration(1, repeats, size, N, GetGen1Arr<int>);
			TestGeneration(2, repeats, size, N, GetGen2Arr<int>);

			/*if (!GC.TryStartNoGCRegion((long) 256*1024))
			{
				Console.WriteLine("Failed to disable GC");
			}
			else
			{
				TestGeneration(0, repeats, size, N, GetGen0Arr<int>);
				TestGeneration(1, repeats, size, N, GetGen1Arr<int>);
				TestGeneration(2, repeats, size, N, GetGen2Arr<int>);
				GC.EndNoGCRegion();
			}*/

			Console.WriteLine("End");
			Console.ReadKey();
		}
	}
}
