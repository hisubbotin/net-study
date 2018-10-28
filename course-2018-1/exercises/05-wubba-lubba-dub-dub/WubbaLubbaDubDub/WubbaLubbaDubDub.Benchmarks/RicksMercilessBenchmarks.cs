using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Text;

namespace WubbaLubbaDubDub.Benchmarks
{
	[InProcessAttribute]
	public class RicksMercilessBenchmarks
	{
		public static int N = 1000;

		[Benchmark]
		public static void BenchmarkStringBuilder()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < N; ++i)
			{
				sb.Append('a');
			}
			var s = sb.ToString();
		}

		[Benchmark]
		public static void BenchmarkStringJoin()
		{
			char[] arr = new char[N];
			for (int i = 0; i < N; ++i)
			{
				arr[i] = 'a';
			}
			var s = String.Join("", arr);
		}

		[Benchmark]
		public static void BenchmarkStringConcat()
		{
			string s = "";
			for (int i = 0; i < N; ++i)
			{
				s += 'a';
			}
		}

		public static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<RicksMercilessBenchmarks>();
			System.Console.ReadKey();
		}
	}
}

//                 Method |       Mean |     Error |    StdDev |     Median |
//----------------------- |-----------:|----------:|----------:|-----------:|
// BenchmarkStringBuilder |   5.429 us | 0.3140 us | 0.9008 us |   4.998 us |
//    BenchmarkStringJoin |  30.082 us | 2.0072 us | 5.9184 us |  27.245 us |
//  BenchmarkStringConcat | 167.137 us | 1.1034 us | 0.9781 us | 167.316 us |
