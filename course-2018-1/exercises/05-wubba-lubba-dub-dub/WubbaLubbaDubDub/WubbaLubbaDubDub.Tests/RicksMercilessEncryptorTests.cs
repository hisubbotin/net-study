using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("l i n e 1   \n    line2\n.l 1 ne3", new[] { "l i n e 1   ", "    line2", ".l 1 ne3"})]
        [InlineData("line1\n\nline3\n", new[] { "line1", "", "line3", "" })]
        public static void Test_SplitToLines(string s, string[] ans)
        {
            Assert.Equal(ans, s.SplitToLines());
        }
        
        [Theory]
        [InlineData("word1    word2 3.1 3-2", new[] { "word1", "word2", "3.1", "3-2" })]
        public static void Test_SplitToWords(string s, string[] ans)
        {
            Assert.Equal(ans, s.SplitToWords());
        }
        
        [Theory]
        [InlineData("abcd", "ab")]
        [InlineData("abc", "a")]
        public static void Test_GetLeftHalf(string s, string ans)
        {
            Assert.Equal(ans, s.GetLeftHalf());
        }
        
        [Theory]
        [InlineData("abcd", "cd")]
        [InlineData("abc", "bc")]
        public static void Test_GetRightHalf(string s, string ans)
        {
            Assert.Equal(ans, s.GetRightHalf());
        }
        
        [Theory]
        [InlineData("ab a b\n", "ab", ".", ". a b\n")]
        [InlineData("ab a b\n \n", " ", "-", "ab-a-b\n-\n")]
        public static void Test_Replace(string s, string old, string @new, string ans)
        {
            Assert.Equal(ans, RicksMercilessEncryptor.Replace(s, old, @new));
        }
        
        [Theory]
        [InlineData("a1. #\t\n", @"\u0061\u0031\u002e\u0020\u0023\u0009\u000a")]
        public static void Test_CharsToCodes(string s, string ans)
        {
            Assert.Equal(ans, s.CharsToCodes());
        }
        
        [Theory]
        [InlineData("12 345.", ".543 21")]
        [InlineData("ab cde.", ".edc ba")]
        public static void Test_GetReversed(string s, string ans)
        {
            Assert.Equal(ans, s.GetReversed());
        }
        
        [Theory]
        [InlineData("AbCd12.\n", "aBcD12.\n")]
        public static void Test_InverseCase(string s, string ans)
        {
            Assert.Equal(ans, s.InverseCase());
        }
        
        [Theory]
        [InlineData("a-+1\t", "b.,2\n")]
        public static void Test_ShiftInc(string s, string ans)
        {
            Assert.Equal(ans, s.ShiftInc());
        }
        
        [Theory]
        [InlineData("7890:1234\n7890:1234", new long[] { 78901234 })]
        [InlineData("//0123:4567\n7890:1234", new long[] { 78901234 })]
        [InlineData("/*\n7890:1234\n*/\n0123:4567\n asd 8901:2345", new long[] { 1234567, 89012345})]
        public static void Test_GetUsedObjects(string s, long[] ans)
        {
            Assert.Equal(ans, s.GetUsedObjects());
        }
    }
}
