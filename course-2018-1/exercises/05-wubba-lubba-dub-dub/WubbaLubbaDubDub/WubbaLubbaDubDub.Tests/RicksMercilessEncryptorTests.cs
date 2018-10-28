using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("a a a\n b b b ", new[] {"a a a", " b b b "})]
        [InlineData("It's line one\nIt's line two", new [] {"It's line one", "It's line two"})]
        public void Test_SplitToLines(string s, string[] result)
        {
            Assert.Equal(result, s.SplitToLines());
        }

        [Theory]
        [InlineData("a aa\nb  bb \t bbb", new[] {"a", "aa", "b", "bb", "bbb"})]
        [InlineData("firstword second\nthird\tforth", new[] {"firstword", "second", "third", "forth"})]
        public void Test_SplitToWords(string s, string[] result)
        {
            Assert.Equal(result, s.SplitToWords());
        }

        [Theory]
        [InlineData("abcd", "ab")]
        [InlineData("abcde", "ab")]
        public void Test_GetLeftHalf(string s, string result)
        {
            Assert.Equal(result, s.GetLeftHalf());
        }

        [Theory]
        [InlineData("abcd", "cd")]
        [InlineData("abcde", "cde")]
        public void Test_GetRightHalf(string s, string result)
        {
            Assert.Equal(result, s.GetRightHalf());
        }

        [Theory]
        [InlineData("abcd", "b", "k", "akcd")]
        [InlineData("abcde", "cde", "erty", "aberty")]
        public void Test_Replace(string s, string old, string @new, string result)
        {
            Assert.Equal(result, RicksMercilessEncryptor.Replace(s, old, @new));
        }

        [Theory]
        [InlineData("abc", "\\u0061\\u0062\\u0063")]
        public void Test_CharsToCodes(string s, string result)
        {
            Assert.Equal(result, s.CharsToCodes());
        }

        [Theory]
        [InlineData("abc", "cba")]
        public void Test_GetReversed(string s, string result)
        {
            Assert.Equal(result, s.GetReversed());
        }

        [Theory]
        [InlineData("aBc", "AbC")]
        public void Test_InverseCase(string s, string result)
        {
            Assert.Equal(result, s.InverseCase());
        }

        [Theory]
        [InlineData("abc", "bcd")]
        public void Test_ShiftInc(string s, string result)
        {
            Assert.Equal(result, s.ShiftInc());
        }

        [Theory]
        [InlineData("//comment ¶0000:0150¶ \n not comment ¶0000:0000¶", new[] {0L})]
        [InlineData("0000:0012 <- thats not it ¶0000:0000¶ thats better /* multiline-line 0000:0001 \n 0000:0002 */", new long[] { 0L })]
        [InlineData("/* comment again ¶0000:0010¶\n ¶0000:0130¶ */ ¶0000:0000¶ ", new[] {0L})]
        public void Test_GetUsedObjects(string s, long[] result)
        {
            Assert.Equal(result, s.GetUsedObjects());
        }

    }
}
