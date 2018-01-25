using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("some 'text' with stra454nge words that aren't so simple!",
            new[] { "some", "text", "with", "stra454nge", "words", "that", "aren't", "so", "simple" })]
        public void TestSplitToWords(string line, string[] result)
        {
            Assert.Equal(result, line.SplitToWords());
        }

        [Theory]
        [InlineData("we would say anything just to hear what we want", "ust to hear what we want")]
        public void TestGetRightHalf(string text, string result)
        {
            Assert.Equal(result, text.GetRightHalf());
        }

        [Theory]
        [InlineData("we would sell anything  just to buy what we are not", "we would sell anything  j")]
        public void TestGetLeftHalf(string text, string result)
        {
            Assert.Equal(result, text.GetLeftHalf());
        }

        [Theory]
        [InlineData("we\r\nkill\rour\nway\r\nto\nHeaven", new[] { "we", "kill", "our", "way", "to", "Heaven" })]
        public void TestSplitToLines(string text, string[] result)
        {
            Assert.Equal(result, text.SplitToLines());
        }

        [Theory]
        [InlineData("abc", "bbc")]
        public void TestReplace(string text, string result)
        {
            Assert.Equal(result, text.Replace("a", "b"));
        }

        [Theory]
        [InlineData("abc!", "\\u0061\\u0062\\u0063\\u0021")]
        public void TestCharsToCodes(string text, string result)
        {
            Assert.Equal(result, text.CharsToCodes());
        }

        [Theory]
        [InlineData("abc!", "!cba")]
        public void TestGetReversed(string text, string result)
        {
            Assert.Equal(result, text.GetReversed());
        }

        [Theory]
        [InlineData("ZaBoRcHiK", "zAbOrChIk")]
        public void TestInverseCase(string text, string result)
        {
            Assert.Equal(result, text.InverseCase());
        }

        [Theory]
        [InlineData("abc78!", "bcd89\"")]
        public void TestShiftInc(string text, string result)
        {
            Assert.Equal(result, text.ShiftInc());
        }

        [Theory]
        [InlineData("// comment \r\n/* com\r\nment */ FFFF:0000\r\nABCD:0899", new[] { 4294901760L, 2882341017L })]
        public void TestGetUsedObjects(string text, long[] result)
        {
            Assert.Equal(result, text.GetUsedObjects());
        }
    }
}
