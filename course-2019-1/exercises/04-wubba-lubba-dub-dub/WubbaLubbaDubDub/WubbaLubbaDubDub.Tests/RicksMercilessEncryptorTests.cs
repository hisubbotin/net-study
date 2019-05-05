using System;
using System.Linq;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        
        [Theory]
        [InlineData("aa bb cc", new [] {"aa bb cc"})]
        [InlineData("aaa\n\nbbb\nccc", new [] {"aaa", "", "bbb", "ccc"})]
        public void Test_SplitToLines(string before, string[] expected)
        {
            Assert.Equal(expected, before.SplitToLines());
        }
        
        [Theory]
        [InlineData("aa bb cc", new [] {"aa", "bb", "cc"})]
        [InlineData("I'm not superman!", new [] {"I", "m", "not", "superman"})]
        public void Test_SplitToWords(string before, string[] expected)
        {
            Assert.Equal(expected, before.SplitToWords());
        }
        
        [Theory]
        [InlineData("123456", "123")]
        [InlineData("123", "1")]
        [InlineData("", "")]
        public void Test_GetLeftHalf(string before, string expected)
        {
            Assert.Equal(expected, before.GetLeftHalf());
        }
        
        [Theory]
        [InlineData("123456", "456")]
        [InlineData("123", "23")]
        [InlineData("", "")]
        public void Test_GetRightHalf(string before, string expected)
        {
            Assert.Equal(expected, before.GetRightHalf());
        }
        
        [Theory]
        [InlineData("llllolllllol", "lol", "kek", "lllkeklllkek")]
        [InlineData("ababababadfaba", "aba", "!", "!b!badf!")]
        [InlineData("qqq", "q", "", "")]
        public void Test_Replace(string before, string old, string @new, string expected)
        {
            Assert.Equal(expected, before.Replace(old, @new));
        }
        
        [Theory]
        [InlineData("jkz", @"\u6a\u6b\u7a")]
        [InlineData("11*", @"\u31\u31\u2a")]
        public void Test_CharsToCodes(string before, string expected)
        {
            Assert.Equal(expected, before.CharsToCodes());
        }
        
        [Theory]
        [InlineData("madam, i'm adam", "mada m'i ,madam")]
        [InlineData("abc", "cba")]
        public void Test_GetReversed(string before, string expected)
        {
            Assert.Equal(expected, before.GetReversed());
        }
        
        [Theory]
        [InlineData("AAAbbbAAA", "aaaBBBaaa")]
        [InlineData("!!!aA123", "!!!Aa123")]
        public void Test_InverseCase(string before, string expected)
        {
            Assert.Equal(expected, before.InverseCase());
        }
        
        [Theory]
        [InlineData("abc", "bcd")]
        [InlineData("xyz", "yz{")]
        public void Test_ShiftInc(string before, string expected)
        {
            Assert.Equal(expected, before.ShiftInc());
        }
        
        [Theory]
        [InlineData("¶1000:1000¶ ¶1234:4321¶ ¶1000:0000¶", new [] {10001000L, 12344321L, 10000000L})]
        [InlineData("aaa ¶0000:0042¶ /* ¶1000:1000¶ bbb\n */ ccc // ddd ¶1000:1000¶ \n /* \n\n */ ¶1000:0001¶", new [] {42L, 10000001L})]
        public void Test_GetUsedObjects(string before, long[] expected)
        {
            Assert.Equal(expected, before.GetUsedObjects());
        }
    }
}
