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
        [InlineData("a\nb\nc", new string[] {"a", "b", "c"})]
        public void Test_SplitToLine(string s, string[] res)
        {
            Assert.Equal(s.SplitToLines(), res);
        }
        
        [Theory]
        [InlineData("aba caba\nabca", new string[] { "aba", "caba", "abca"})]
        public void Test_SplitToWords(string s, string[] res)
        {
            Assert.Equal(s.SplitToWords(), res);
        }

        [Theory]
        [InlineData("abacaba", "aba")]
        public void Test_GetLeftHalf(string s, string res)
        {
            Assert.Equal(s.GetLeftHalf(), res);
        }

        [Theory]
        [InlineData("abacaba", "caba")]
        public void Test_GetRightHalf(string s, string res)
        {
            Assert.Equal(s.GetRightHalf(), res);
        }

        [Theory]
        [InlineData("chucha", "ch", "zh", "zhuzha")]
        public void Test_Replace(string s, string r, string to, string res)
        {
            Assert.Equal(s.Replace(r, to), res);
        }

        [Theory]
        [InlineData("z", "\\u007A")]
        public void Test_CharsToCodes(string s, string res)
        {
            Assert.Equal(s.CharsToCodes(), res);
        }

        [Theory]
        [InlineData("abcd", "dcba")]
        public void Test_GetReversed(string s, string res)
        {
            Assert.Equal(s.GetReversed(), res);
        }

        [Theory]
        [InlineData("aBcD", "AbCd")]
        public void Test_InverseCase(string s, string res)
        {
            Assert.Equal(s.InverseCase(), res);
        }

        [Theory]
        [InlineData("abc", "bcd")]
        public void Test_ShiftInc(string s, string res)
        {
            Assert.Equal(s.ShiftInc(), res);
        }
        [Theory]
        [InlineData("¶1234:5678¶ ¶1234:5678¶", new long[] { 0x12345678 })]
        [InlineData("¶1234:5678¶/*testesttest*/¶1234:5678¶", new long[] { 0x12345678 })]
        public void Test_GetUsedObjects(string s, long[] list)
        {
            Assert.Equal(s.GetUsedObjects(), list);
        }
    }
}