using System;
using System.Collections.Immutable;
using System.Diagnostics;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
	public class RicksMercilessEncryptorTests
	{

		[Theory]
		[InlineData("Wubba\nLubba\nDub Dub", new[] { "Wubba", "Lubba", "Dub Dub" })]
		public static void TestSplitToLines(string s, string[] ans)
		{
			Assert.Equal(ans, RicksMercilessEncryptor.SplitToLines(s));
		}

		[Theory]
		[InlineData("Wubba\nLubba\nDub Dub", new[] { "Wubba", "Lubba", "Dub", "Dub" })]
		public static void TestSplitToWords(string s, string[] ans)
		{
			Assert.Equal(ans, RicksMercilessEncryptor.SplitToWords(s));
		}

		[Theory]
		[InlineData("abcdef")]
		[InlineData("abcdefg")]
		public static void TestGetHalves(string s)
		{
			var left = RicksMercilessEncryptor.GetLeftHalf(s);
			var right = RicksMercilessEncryptor.GetRightHalf(s);
			Assert.Equal(s.Length / 2, left.Length);
			Assert.Equal(s.Length - s.Length / 2, right.Length);
			Assert.Equal(s, left + right);
		}

		[Theory]
		[InlineData("A cake is a lie", "A lie is a cake")]
		public static void TestReplace(string s, string ans)
		{
			var a = RicksMercilessEncryptor.Replace(s, "cake", "tmp");
			a = RicksMercilessEncryptor.Replace(a, "lie", "cake");
			a = RicksMercilessEncryptor.Replace(a, "tmp", "lie");
			Assert.Equal(ans, a);
		}

		[Theory]
		[InlineData("まどか", @"\u307E\u3069\u304B")]
		public static void TestCharsToCodes(string s, string ans)
		{
			Assert.Equal(ans, RicksMercilessEncryptor.CharsToCodes(s));
		}

		[Theory]
		[InlineData("abcdef", "fedcba")]
		public static void TestGetReversed(string s, string ans)
		{
			Assert.Equal(ans, RicksMercilessEncryptor.GetReversed(s));
		}

		[Theory]
		[InlineData("PrEvEd ", "pReVeD ")]
		public static void TestInverseCase(string s, string ans)
		{
			Assert.Equal(ans, RicksMercilessEncryptor.InverseCase(s));
		}

		[Theory]
		[InlineData("abcdef\u0001\u0002", "bcdefg\u0002\u0003")]
		public static void TestShiftInc(string s, string ans)
		{
			Assert.Equal(ans, RicksMercilessEncryptor.ShiftInc(s));
		}

		[Theory]
		[InlineData("// line comment 1111:2222\nasdasd  3333:4444/*asd\nmultiline */ sa5555:6666xzxc", new long[] { 0x33334444, 0x55556666 })]
		[InlineData("Wubba 0000:0000 Lubba 00:200222 Dub 0000:0001 Dub 0000:0002", new long[] { 0, 1, 2})]
		public static void TestGetUsedObjects(string s, long[] ans)
		{
			Assert.Equal(ans, RicksMercilessEncryptor.GetUsedObjects(s));
		}
	}
}
