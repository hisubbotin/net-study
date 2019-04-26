using System;
using System.Linq;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("aab\n aa", new [] {"aab", " aa"})]
        [InlineData("aab\r\n aabbb\nanndcr\r\ner", new [] {"aab", " aabbb", "anndcr", "er"})]
        public void Test_SplitToLines(string test, string[] res)
        {
            Assert.Equal(res, test.SplitToLines());
        }

        [Theory]
        [InlineData("ab 234 rr\nee     AT4D", new [] {"ab", "234", "rr", "ee", "AT4D"})]
        public void Test_SplitToWords(string test, string[] res)
        {
            Assert.Equal(res, test.SplitToWords());
        }

        [Theory]
        [InlineData("123456", "123")]
        [InlineData("abcdefg", "abc")]
        public void Test_GetLeftHalf(string s, string res)
        {
            Assert.Equal(res, s.GetLeftHalf());
        }
        
        [Theory]
        [InlineData("123456", "456")]
        [InlineData("abcdefg", "defg")]
        public void Test_GetRightHalf(string s, string res)
        {
            Assert.Equal(res, s.GetRightHalf());
        }

        [Theory]
        [InlineData("abcdefcdg", "cd", "xy", "abxyefxyg")]
        [InlineData("babaabaaabbab", "b", "cc", "ccaccaaccaaaccccacc")]
        public void Test_Replace(string s, string old, string @new, string res)
        {
            Assert.Equal(res, s.Replace(old, @new));
        }

        [Theory]
        [InlineData("139", @"\u0031\u0033\u0039")]
        public void Test_CharsToCodes(string s, string result)
        {
            Assert.Equal(result, s.CharsToCodes());
        }
        
        [Theory]
        [InlineData("567 6 \n 6", "6 \n 6 765")]
        [InlineData("aer4&#2", "2#&4rea")]
        [InlineData("a$zer 4&# \n2", "2\n #&4 rez$a")]
        public void Test_GetReversed(string s, string result)
        {
            Assert.Equal(result, s.GetReversed());
        }
        
        [Theory]
        [InlineData("AAA aaa aaAA BBaa 34rN", "aaa AAA AAaa bbAA 34Rn")]
        public void Test_InverseCase(string s, string result)
        {
            Assert.Equal(result, s.InverseCase());
        }
        
        [Theory]
        [InlineData("458", "569")]
        [InlineData("adrED4T", "besFE5U")]
        public void Test_ShiftInc(string s, string result)
        {
            Assert.Equal(result, s.ShiftInc());
        }

        [Theory]
        [InlineData("¶1234:0000¶ // ¶0000:0001¶ /* ¶0000:0002¶ \n ¶0000:0003¶ // ¶0000:0004¶ */ ¶0000:0005¶", new[] {12340000L, 3L})]
        [InlineData("¶0000:0000¶ /* ¶0000:0001¶ \n ¶0000:0002¶ // ¶0000:0003¶ */ ¶0000:1234¶", new[] {0L, 1234L})]
        private void TestGetUsedObjects(string text, long[] ids) {
            Assert.Equal(ids, text.GetUsedObjects().ToArray());
        }
    }
}
