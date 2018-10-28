using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Text Text Text Text\nText Text Text\nText Text\nText", 
            new [] {"Text Text Text Text", "Text Text Text", "Text Text", "Text" })]
        public void TestSplitToLines(string text, string[] result)
        {
            Assert.Equal(text.SplitToLines(), result);
        }
        
        [Theory]
        [InlineData("Text Text \n Text",
            new[] { "Text", "Text", "Text"})]
        public void TestSplitToWords(string line, string[] res)
        {
            Assert.Equal(line.SplitToWords(), res);
        }
        
        [Theory]
        [InlineData("123456789", "1234")]
        [InlineData("12345678", "1234")]
        public void TestGetLeftHalf(string s, string res)
        {
            Assert.Equal(s.GetLeftHalf(), res);
        }
        
        [Theory]
        [InlineData("123456789", "56789")]
        [InlineData("12345678", "5678")]
        public void TestGetRightHalf(string s, string res)
        {
            Assert.Equal(s.GetRightHalf(), res);
        }
        
        [Theory]
        [InlineData("123 456", "123", "456", "456 456")]
        public void TestReplace(string s, string old, string @new, string res)
        {
            Assert.Equal(s.Replace(old, @new), res);
        }
        
        [Theory]
        [InlineData("123", "\\u0031\\u0032\\u0033")]
        public void TestCharsToCodes(string s, string res)
        {
            Assert.Equal(s.CharsToCodes(), res);
        }
        
        [Theory]
        [InlineData("123", "321")]
        public void TestGetReversed(string s, string res)
        {
            Assert.Equal(s.GetReversed(), res);
        }

        [Theory]
        [InlineData("123", "234")]
        public void TestShiftInc(string s, string res)
        {
            Assert.Equal(s.ShiftInc(), res);
        }
    }
}
