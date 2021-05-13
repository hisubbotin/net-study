using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Xunit;
using WubbaLubbaDubDub;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("a\nb\nc\n", new string[] {"a", "b", "c", ""})]
        [InlineData("", new string[] {""})]
        public void Test_SplitToLine(string s, string[] res)
        {
            Assert.Equal(s.SplitToLines(), res);
        }
        [Theory]
        [InlineData("aba caba\te\na")]
        public void Test_SplitToWords(string s)
        {
            Assert.Equal(s.SplitToWords(), new string[] { "aba", "caba", "e", "a"});
        }

        [Theory]
        [InlineData("abacaba", "aba")]
        [InlineData("abab", "ab")]
        [InlineData("", "")]
        public void Test_GetLeftHalf(string s, string res)
        {
            Assert.Equal(s.GetLeftHalf(), res);
        }

        [Theory]
        [InlineData("abacaba", "caba")]
        [InlineData("abab", "ab")]
        [InlineData("", "")]
        public void Test_GetRightHalf(string s, string res)
        {
            Assert.Equal(s.GetRightHalf(), res);
        }

        [Theory]
        [InlineData("abacaba", "ab", "R", "RacRa")]
        [InlineData("aaaa", "a", "R", "RRRR")]
        public void Test_Replace(string s, string r, string to, string res)
        {
            Assert.Equal(s.Replace(r, to), res);
        }

        [Theory]
        [InlineData("ab", "\\u0061\\u0062")]
        [InlineData("abab", "\\u0061\\u0062\\u0061\\u0062")]
        [InlineData("z", "\\u007A")]
        public void Test_CharsToCodes(string s, string res)
        {
            Assert.Equal(s.CharsToCodes(), res);
        }

        [Theory]
        [InlineData("ab", "ba")]
        [InlineData("abab", "baba")]
        [InlineData("acbac", "cabca")]
        [InlineData("", "")]
        public void Test_GetReversed(string s, string res)
        {
            Assert.Equal(s.GetReversed(), res);
        }

        [Theory]
        [InlineData("ab", "AB")]
        [InlineData("abAB", "ABab")]
        [InlineData("aBaCaBa1", "AbAcAbA1")]
        [InlineData("", "")]
        public void Test_InverseCase(string s, string res)
        {
            Assert.Equal(s.InverseCase(), res);
        }

        [Theory]
        [InlineData("ab", "bc")]
        [InlineData("abAB", "bcBC")]
        [InlineData("aBaCaBa1", "bCbDbCb2")]
        [InlineData("", "")]
        public void Test_ShiftInc(string s, string res)
        {
            Assert.Equal(s.ShiftInc(), res);
        }
        [Theory]
        [InlineData("¶1111AAAA:2222AAAA¶", new long[] { 0x1111AAAA2222AAAA })]
        [InlineData("¶1111AAAA:2222AAAA¶/*¶1111AAAA:2222AAAB¶*/¶1111AAAA:2222AAAA¶", new long[] { 0x1111AAAA2222AAAA, 0x1111AAAA2222AAAA })]
        [InlineData("¶1111AAAA:2222AAAA¶//¶1111AAAA:2222AAAB¶\n¶1111AAAA:2222AAAA¶", new long[] { 0x1111AAAA2222AAAA, 0x1111AAAA2222AAAA })]
        public void Test_GetUsedObjects(string s, long[] list)
        {
            Assert.Equal(s.GetUsedObjects().ToArray(), list);
        }
    }
}
