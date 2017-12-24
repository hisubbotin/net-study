using System;
using System.Collections.Immutable;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData(
            "The concepts of line feed\nand carriage return\rare closely associated, and can be considered either separately or together\r\n.",
            new string[]
            {
                "The concepts of line feed", "and carriage return",
                "are closely associated, and can be considered either separately or together", "."
            })]
        public void Test_SplitToLines(string text, string[] expected)
        {
            Assert.Equal(expected, text.SplitToLines());
        }

        [Theory]
        [InlineData(@"The concepts of line    feed",
            new string[] {"The", "concepts", "of", "line", "feed"})]
        public void Test_SplitToWords(string line, string[] expected)
        {
            Assert.Equal(expected, line.SplitToWords());
        }

        [Theory]
        [InlineData("LHalfRHalf", "LHalf")]
        [InlineData("LHalf RHalf", "LHalf")]
        [InlineData("", "")]
        public void Test_GetLeftHalf(string s, string expected)
        {
            Assert.Equal(expected, s.GetLeftHalf());
        }

        [Theory]
        [InlineData("LHalfRHalf", "RHalf")]
        [InlineData("LHalf RHalf", " RHalf")]
        [InlineData("", "")]
        public void Test_GetRightHalf(string s, string expected)
        {
            Assert.Equal(expected, s.GetRightHalf());
        }

        [Theory]
        [InlineData("The concepts\nof\rline\tfeed", "\n", " ", @"The concepts of\rline\tfeed")]
        public void Test_Replace(string s, string old, string @new, string expected)
        {
            Assert.Equal(expected, s.Replace(old, @new));
        }

        [Theory]
        [InlineData("together\n", @"\u0074\u006F\u0067\u0065\u0074\u0068\u0065\u0072\u005C\u006E")]
        [InlineData("Straße", @"\u0053\u0074\u0072\u0061\u00DF\u0065")]
        public void Test_CharsToCodes(string s, string expected)
        {
            Assert.Equal(expected, s.CharsToCodes());
        }
        
        [Theory]
        [InlineData("Reversed", "desreveR")]
        public void Test_GetReversed(string s, string expected)
        {
            Assert.Equal(expected, s.GetReversed());
        }
        
        [Theory]
        [InlineData("Reversed", "rEVERSED")]
        [InlineData("123", "123")]
        public void Test_InverseCase(string s, string expected)
        {
            Assert.Equal(expected, s.InverseCase());
        }
        
        [Theory]
        [InlineData("123", "234")]
        [InlineData("abc", "bcd")]
        public void Test_ShiftInc(string s, string expected)
        {
            Assert.Equal(expected, s.ShiftInc());
        }
        
        [Theory]
        [InlineData("0000:0000 // one-line 0000:0001", new long[]{0L})]
        [InlineData("0000:0000 /* multiline-line 0000:0001 \n 0000:0002 */", new long[]{0L})]
        public void Test_GetUsedObjects(string s, long[] expected)
        {
            Assert.Equal(expected, s.GetUsedObjects());
        }
    }
}
