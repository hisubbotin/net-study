using System;
using System.Linq;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("1 2\n3\n", new[] { "1 2", "3", "" })]
        public void SplitToLinesTest(string test, string[] result)
        {
            Assert.Equal(result, test.SplitToLines());
        }

        [Theory]
        [InlineData("1 2  3", new[] { "1", "2", "3" })]
        [InlineData("1 2\n3\n", new[] { "1", "2", "3" })]
        public void SplitToWordsTest(string test, string[] result)
        {
            Assert.Equal(result, test.SplitToWords());
        }

        [Theory]
        [InlineData("1234", "12")]
        [InlineData("12345", "12")]
        public void GetLeftHalfTest(string test, string result)
        {
            Assert.Equal(result, test.GetLeftHalf());
        }

        [Theory]
        [InlineData("1234", "34")]
        [InlineData("12345", "345")]
        public void GetRightHalfTest(string test, string result)
        {
            Assert.Equal(result, test.GetRightHalf());
        }

        [Theory]
        [InlineData("1234512345", "2234522345", "1", "2")]
        [InlineData("1234512345", "33453345", "12", "3")]
        public void ReplaceTest(string test, string result, string old, string @new)
        {
            Assert.Equal(result, test.Replace(old, @new));
        }

        [Theory]
        [InlineData("123", @"\u0031\u0032\u0033")]
        [InlineData("s", @"\u0073")]
        [InlineData("\uFFFF", @"\uFFFF")]
        public void CharsToCodesTest(string s, string result)
        {
            Assert.Equal(result, s.CharsToCodes());
        }

        [Theory]
        [InlineData("123", "321")]
        [InlineData("1234", "4321")]
        public void GetReversedTest(string s, string result)
        {
            Assert.Equal(result, s.GetReversed());
        }

        [Theory]
        [InlineData("QWERTYasdfg", "qwertyASDFG")]
        [InlineData("QwErTy", "qWeRtY")]
        public void InverseCaseTest(string s, string result)
        {
            Assert.Equal(result, s.InverseCase());
        }

        [Theory]
        [InlineData("123", "234")]
        [InlineData("abc", "bcd")]
        public void ShiftIncTest(string s, string result)
        {
            Assert.Equal(result, s.ShiftInc());
        }

        [Theory]
        [InlineData("", new long[] { })]
        [InlineData("00000000:0000000A", new[] { 10L })]
        [InlineData("00000000:0000000A 10000001:10000001", new[] { 10L, 0x1000000110000001L })]
        [InlineData("// 00000000:00000000 \n qwerty 00000000:0000000A", new[] { 10L })]
        [InlineData("/* 00000000:00000000 \n qwerty */  00000000:0000000A", new[] { 10L })]
        public void Test_GetUsedObjects(string s, long[] result)
        {
            var res = s.GetUsedObjects();
            Assert.Equal(result, res);
        }
    }
}