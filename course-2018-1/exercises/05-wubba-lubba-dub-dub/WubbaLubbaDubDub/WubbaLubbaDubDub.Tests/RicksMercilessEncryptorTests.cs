using Xunit;
using System;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData(new string[]{"line1", "line2", "line3"}, "line1\nline2\nline3")]
        [InlineData(new string[] { "line1", "", "line2", "line3" }, "line1\n\nline2\nline3")]
        private void TestSplitToLines(string[] splitted, string text)
        {
            Assert.Equal(splitted, text.SplitToLines());
        }

        [Theory]
        [InlineData(new string[] { "line1", "line2", "line3" }, "line1\nline2\nline3")]
        [InlineData(new string[] { "line1", "line2", "line3" }, "line1\n\n\n\nline2\nline3")]
        [InlineData(new string[] { "word1", "word2", "word3" }, "word1 \tword2\nword3")]
        private void TestSplitToWords(string[] splitted, string text)
        {
            Assert.Equal(splitted, text.SplitToWords());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("a", "")]
        [InlineData("ab", "a")]
        private void TestGetLeftHalf(string source, string target)
        {
            Assert.Equal(target, source.GetLeftHalf());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("ab", "b")]
        private void TestGetRightHalf(string source, string target)
        {
            Assert.Equal(target, source.GetRightHalf());
        }

        [Theory]
        [InlineData("", "x", "", "")]
        [InlineData("ahia", "hi", "hello", "ahelloa")]
        private void TestReplace(string source, string old, string @new, string result)
        {
            Assert.Equal(result, source.Replace(old, @new));
        }

        [Theory]
        [InlineData("tester", "\u0074\u0065\u0073\u0074\u0065\u0072")]
        [InlineData("hello", "\u0068\u0065\u006C\u006C\u006F")]
        private void TestCharsToCodes(string source, string target)
        {
            Assert.Equal(target, source);
        }

        [Theory]
        [InlineData("pop", "pop")]
        [InlineData("pam", "map")]
        [InlineData("ab", "ba")]
        private void TestGetReversed(string source, string target)
        {
            Assert.Equal(target, source.GetReversed());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("normal", "NORMAL")]
        [InlineData("dOn'T fEeL sO gOoD", "DoN't FeEl So GoOd")]
        private void TestInverseCase(string source, string target)
        {
            Assert.Equal(target, source.InverseCase());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("12345", "23456")]
        private void TestShiftInc(string source, string target)
        {
            Assert.Equal(target, source.ShiftInc());
        }

        [Theory]
        [InlineData("id 00000000:00000000" +
            " // not id 00000000:00000001 \n" +
            " /* still not id 00000000:00000002 \n */" +
            "id 00000000:00000005", new[] { 0L, 5L })]
        private void TestGetUsedObjects(string text, long[] ids)
        {
            Assert.Equal(ids, text.GetUsedObjects());
        }
    }
}
