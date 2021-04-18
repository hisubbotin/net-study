using System;
using Xunit;
using WubbaLubbaDubDub;
using System.Text;
using System.Collections.Immutable;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Fact]
        public void SplitToLinesTest()
        {
            string s = string.Format("one,  {0} two ,{1}three ", Environment.NewLine, Environment.NewLine);
            string[] test_result = s.SplitToLines();
            Assert.Equal(test_result, new string[] { "one,  ", " two ,", "three " });
        }

        [Fact]
        public void SplitToWordsTest()
        {
            string s = "  hello, world ";
            string[] test_result = s.SplitToWords();
            Assert.Equal(test_result, new string[] { "hello", "world" });
        }

        [Fact]
        public void HalfsTest()
        {
            string s = "abacaba";
            string l_half_exp = s.GetLeftHalf();
            string r_half_exp = s.GetRightHalf();
            Assert.Equal(l_half_exp, "aba");
            Assert.Equal(r_half_exp, "caba");

            s = "abba";
            l_half_exp = s.GetLeftHalf();
            r_half_exp = s.GetRightHalf();
            Assert.Equal(l_half_exp, "ab");
            Assert.Equal(r_half_exp, "ba");
        }

        [Fact]
        public void RepaceTest()
        {
            string s = "ababab";
            string res = s.Replace("abab", "yyy");
            Assert.Equal(res, "yyyab");
        }

        [Fact]
        public void CharsToCodesTest()
        {
            string s_repr = "\u0061\u0062\u0043\u0062\u0061";
            string s = "abCba";
            string codes_s = s.CharsToCodes();
            Assert.Equal(s, s_repr);
        }

        [Fact]
        public void GetReversedTest()
        {
            string s = "hello";
            string s_reversed = s.GetReversed();
            Assert.Equal("olleh", s_reversed);
        }

        [Fact]
        public void InverseCaseTest_()
        {
            string s = "aB";
            string s_inversed = s.InverseCase();
            Assert.Equal("Ab", s_inversed);
        }
        [Fact]
        public void ShiftIncTest()
        {
            string s = "aBaCabA";
            string s_shifted = s.ShiftInc();
            Assert.Equal("bCbDbcB", s_shifted);
        }


    }
}
