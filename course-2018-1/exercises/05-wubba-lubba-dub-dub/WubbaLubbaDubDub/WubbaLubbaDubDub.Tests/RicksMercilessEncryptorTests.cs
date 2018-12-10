using System;
using Xunit;
using WubbaLubbaDubDub;
using System.Collections.Immutable;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Fact]
        public void Test_SplitToLines()
        {
            var s = "Line 1\nLine 2\nLine 3";
            var expected = new string[] { "Line 1", "Line 2", "Line 3" };
            Assert.Equal(expected, s.SplitToLines());
        }

        [Fact]
        public void Test_SplitToWords()
        {
            var s = "Word w--ord\t w12ord          word";
            var expected = new string[] { "Word", "w--ord", "w12ord", "word" };
            Assert.Equal(expected, s.SplitToWords());
        }

        [Theory]
        [InlineData("string", "str")]
        [InlineData("qwert", "qw")]
        public void Test_GetLeftHalf(string s, string expected)
        {
            Assert.Equal(expected, s.GetLeftHalf());
        }

        [Theory]
        [InlineData("string", "ing")]
        [InlineData("qwert", "ert")]
        public void Test_GetRightHalf(string s, string expected)
        {
            Assert.Equal(expected, s.GetRightHalf());
        }

        [Fact]
        public void Test_Replace()
        {
            var s = "Hello world";
            var expected = "Hello universe";

            Assert.Equal(expected, s.Replace("world", "universe"));
        }

        [Fact]
        public void Test_CharsToCodes()
        {
            var s = "Text";
            var expected = "\\u0054\\u0065\\u0078\\u0074";

            Assert.Equal(expected, s.CharsToCodes());
        }

        [Fact]
        public void Test_GetReversed()
        {
            var s = "Text";
            var expected = "txeT";

            Assert.Equal(expected, s.GetReversed());
        }

        [Fact]
        public void Test_InverseCase()
        {
            var s = "Text";
            var expected = "tEXT";

            Assert.Equal(expected, s.InverseCase());
        }

        [Fact]
        public void Test_ShiftInc()
        {
            var s = "Text";
            var expected = "Ufyu";

            Assert.Equal(expected, s.ShiftInc());
        }

        [Fact]
        public void Test_GetUsedObjects()
        {
            var s = "Text 0000:0000";
            var expected = (new long[] { 0 }).ToImmutableList();

            Assert.Equal(expected, s.GetUsedObjects());
        }
    }
}