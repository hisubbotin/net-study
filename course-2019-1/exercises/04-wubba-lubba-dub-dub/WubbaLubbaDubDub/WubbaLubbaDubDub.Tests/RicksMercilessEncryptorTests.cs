using System;
using Xunit;
using System.Collections.Immutable;
    
namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        
        [Theory]
        [InlineData("text for splitting word test", new[] { "text", "for", "splitting", "word", "test" })]
        public void TestSplitToWords(string line, string[] result)
        {
            Assert.Equal(result, line.SplitToWords());
        }
        
        [Theory]
        [InlineData("First line\nSecond line\nThird line", new[] {"First line", "Second line", "Third line" })]
        public void TestSplitToLines(string text, string[] result)
        {
            Assert.Equal(result, text.SplitToLines());
        }

        [Theory]
        [InlineData("0123456789", "01234")]
        public void TestGetLeftHalf(string text, string result)
        {
            Assert.Equal(result, text.GetLeftHalf());
        }

        [Theory]
        [InlineData("0123456789", "56789")]
        public void TestGetRightHalf(string text, string result)
        {
            Assert.Equal(result, text.GetRightHalf());
        }

        [Theory]
        [InlineData("ababababab", "bababababa")]
        public void TestReplace(string text, string result)
        {
            Assert.Equal(result, text.Replace("ab", "ba"));
        }

        [Theory]
        [InlineData("abc", "\\u0061\\u0062\\u0063")]
        public void TestCharsToCodes(string text, string result)
        {
            Assert.Equal(result, text.CharsToCodes());
        }

        [Theory]
        [InlineData("hello, world!", "!dlrow ,olleh")]
        public void TestGetReversed(string text, string result)
        {
            Assert.Equal(result, text.GetReversed());
        }

        [Theory]
        [InlineData("HelLO", "hELlo")]
        public void TestInverseCase(string text, string result)
        {
            Assert.Equal(result, text.InverseCase());
        }

        [Theory]
        [InlineData("a1b2c3", "b2c3d4")]
        public void TestShiftInc(string text, string result)
        {
            Assert.Equal(result, text.ShiftInc());
        }

        [Theory]
        [InlineData("// com1 5678:4321\n/* com2 4685:9867 \n\n */ 1234:5678 some text\n9876:5432", new[] { 305419896L, 2557891634L })]
        public void TestGetUsedObjects(string text, long[] result)
        {
            Assert.Equal(result, text.GetUsedObjects());
        }
    }
}
