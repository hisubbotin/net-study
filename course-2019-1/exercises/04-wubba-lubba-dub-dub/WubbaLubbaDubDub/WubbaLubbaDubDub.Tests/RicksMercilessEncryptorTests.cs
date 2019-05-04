using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("abc\ndef", new[] { "abc", "def" })]
        public void SplitToLinesTest(string test, string[] result)
        {
            Assert.Equal(result, test.SplitToLines());
        }

        [Theory]
        [InlineData("    Aa Bb   Cc   ", new[] { "", "Aa", "Bb", "Cc", "" })]
        public void SplitToWordsTest(string test, string[] result)
        {
            Assert.Equal(result, test.SplitToWords());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("q", "")]
        [InlineData("qwert", "qw")]
        [InlineData("qwerty", "qwe")]
        public void GetLeftHalfTest(string test, string result)
        {
            Assert.Equal(result, test.GetLeftHalf());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("q", "q")]
        [InlineData("qwert", "ert")]
        [InlineData("qwerty", "rty")]
        public void GetRightHalfTest(string test, string result)
        {
            Assert.Equal(result, test.GetRightHalf());
        }

        [Theory]
        [InlineData("AA_BB_CC", "AA0BB0CC", "_", "0")]
        [InlineData("bcabc", "bc", "abc", "")]
        [InlineData("QQIIIIIIQQ", "QQIIIIIIQQ", "E", "ASS")]
        public void ReplaceTest(string test, string result, string old, string @new)
        {
            Assert.Equal(result, test.Replace(old, @new));
        }

        [Theory]
        [InlineData("123", @"\u0031\u0032\u0033")]
        [InlineData("\uFFFF", @"\uFFFF")]
        public void CharsToCodesTest(string s, string result)
        {
            Assert.Equal(result, s.CharsToCodes());
        }

        [Theory]
        [InlineData("Abc", "cbA")]
        [InlineData("", "")]
        [InlineData("1", "1")]
        public void GetReversedTest(string s, string result)
        {
            Assert.Equal(result, s.GetReversed());
        }

        [Theory]
        [InlineData("AbCd", "aBcD")]
        [InlineData("Lifeforce Assembly 2007", "lIFEFORCE aSSEMBLY 2007")]
        public void InverseCaseTest(string s, string result)
        {
            Assert.Equal(result, s.InverseCase());
        }

        [Theory]
        [InlineData("ef", "fg")]
        [InlineData("", "")]
        [InlineData("123", "234")]
        public void ShiftIncTest(string s, string result)
        {
            Assert.Equal(result, s.ShiftInc());
        }

        [Theory]
        [InlineData("/* aqweqweqweqweqwebsasdas -00qsd0 qs0d 000 \n 00000000:00000002 */ 0a:0b 00000000:00000003", new[] { 3L })]
        [InlineData("00000000:00000002 10000000:00000001", new[] { 2L, 0x1000000000000001L })]
        [InlineData("// 00000000:00000000 \n 00000000:00000001", new[] { 1L })]
        public void Test_GetUsedObjects(string s, long[] result)
        {
            Assert.Equal(result, s.GetUsedObjects());
        }
    }
}
