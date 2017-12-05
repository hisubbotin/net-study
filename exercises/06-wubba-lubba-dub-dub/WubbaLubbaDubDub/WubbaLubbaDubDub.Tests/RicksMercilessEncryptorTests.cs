using System.IO;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {

        [Theory]
        [InlineData("abc\nabc\nabc", 3)]
        public void Test_SplitToLines(string text, int result_length)
        {
            Assert.Equal(result_length, text.SplitToLines().Length);
        }

        [Theory]
        [InlineData(
            "Wha Wha.. Wha!",
            new string[] { "Wha", "Wha", "Wha" }
        )]
        public void Test_SplitToWords(string s, string[] result)
        {
            Assert.Equal(result, s.SplitToWords());
        }

        [Theory]
        [InlineData("abccba", "abc")]
        public void Test_GetLeftHalf(string s, string result)
        {
            Assert.Equal(result, s.GetLeftHalf());
        }

        [Theory]
        [InlineData("abccba", "cba")]
        public void Test_GetRightHalf(string s, string result)
        {
            Assert.Equal(result, s.GetRightHalf());
        }

        [Theory]
        [InlineData("abcd", "bc", "cb", "acbd")]
        public void Test_Replace(string s, string old, string replaceWith, string result)
        {
            Assert.Equal(result, RicksMercilessEncryptor.Replace(s, old, replaceWith));
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
        [InlineData("abcABC", "ABCabc")]
        public void Test_InverseCase(string s, string result)
        {
            Assert.Equal(result, s.InverseCase());
        }

        [Theory]
        [InlineData("abc123", "cbd234")]
        public void Test_ShiftInc(string s, string result)
        {
            Assert.Equal(result, s.ShiftInc());
        }

        [Theory]
        [InlineData("AAAA:BBBB //BBBB:AAAA\n /* jdd\n DDDD:EEEE */", new long[] { 2863315899L })]
        public void Test_GetUsedObjects(string text, long[] result)
        {
            Assert.Equal(result, text.GetUsedObjects());
        }
    }
}
