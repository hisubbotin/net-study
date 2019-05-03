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
        public void Test_SplitToLines()
        {
            string s = string.Format("one,  {0} two ,{1}three ", Environment.NewLine, Environment.NewLine);
            string[] test_result = s.SplitToLines();
            Assert.Equal(test_result, new string[]{"one,  ", " two ,","three "});
        }
        
        [Fact]
        public void Test_SplitToWords()
        {
            string s = "  hello, world ";
            string s_2 = "Wow! But let's do it, okey? ( Do not worry, ha-ha. )";
            string[] test_result = s.SplitToWords();
            string[] test_2_result = s_2.SplitToWords();
            Assert.Equal(test_result, new string[]{"hello", "world"});
            Assert.Equal(test_2_result, new string[]{"Wow", "But", "let's", "do", "it", "okey", "Do", "not", "worry", "ha", "ha"});
        }

        [Fact]
        public void Test_Halfs()
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
        public void Test_Repace()
        {
            string s = "ababab";
            string res = s.Replace("abab", "yyy");
            Assert.Equal(res, "yyyab");
        }

        [Fact]
        public void Test_CharsToCodes() 
        {
            string s_repr = "\u0061\u0062\u0043\u0062\u0061";
            string s = "abCba";
            string codes_s = s.CharsToCodes();
            Assert.Equal(s, s_repr);
        }

        [Fact]
        public void Test_GetReversed()
        {
            string s = "hello";
            string s_reversed = s.GetReversed();
            Assert.Equal("olleh", s_reversed);
        }

        [Fact]
        public void Test_InverseCase()
        {
            string s = "aB";
            string s_inversed = s.InverseCase();
            Assert.Equal("Ab", s_inversed);
        }
        [Fact]
        public void Test_ShiftInc()
        {
            string s = "aBaCabA";
            string s_shifted = s.ShiftInc();
            Assert.Equal("bCbDbcB", s_shifted);
        }

        [Fact]
        public void Test_GetUsedObjects()
        {
            string s = "hello, ¶AB:CD¶, world,  /* \r\n ¶AB:CD¶ \r\n */ // jfskjf ¶AB:CD¶ \r\n fjsk jk  // ¶AB:CD¶ \r\n ¶AA:AA¶";
            var unicode = Encoding.Unicode;
            long[] data = {BitConverter.ToInt64(unicode.GetBytes("ABCD"), 0), BitConverter.ToInt64(unicode.GetBytes("AAAA"), 0)};
            ImmutableList<long> l = ImmutableList.CreateRange(data);
            ImmutableList<long> l_res = (ImmutableList<long>)s.GetUsedObjects();
            Assert.Equal(l, l_res);
        }
    }
}
