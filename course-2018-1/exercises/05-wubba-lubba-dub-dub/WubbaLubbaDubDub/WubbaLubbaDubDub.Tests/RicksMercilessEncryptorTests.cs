using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Fact]
        public void Test_SplitToWords()
        {
            string s = "dgeg eg d sgeg";
            string[] words = s.SplitToWords();
            Assert.Equal(words[0], "dgeg");
            Assert.Equal(words[1], "eg");
        }

        [Fact]
        public void Test_GetLeftHalf()
        {
            string s = "aBCdeFbcBc!BCcb hg";
            Assert.Equal(s.GetLeftHalf(), "gh !FedCBa");
        }

        [Fact]
        public void Test_Replace()
        {
            string s = "aBCdeFbcBc!BCcb hg";
            Assert.Equal(s.Replace("BC", "XY"), "gh !FedCBa");
        }

        [Fact]
        public void Test_CharToCodes()
        {
            string s = "aBCdeF! hg";
            Assert.Equal(s.CharsToCodes(), "gh !FedCBa");
        }

        [Fact]
        public void Test_GetReversed()
        {
            string s = "aBCdeF! hg";
            Assert.Equal(s.GetReversed(), "gh !FedCBa");
        }

        [Fact]
        public void Test_InverseCase()
        {
            string s = "aBCdeF!";
            Assert.Equal(s.InverseCase(), "AbcDEf!");
        }

        [Fact]
        public void Test_ShiftInc()
        {
            string s = "abcdef";
            Assert.Equal(s.ShiftInc(), "bcdefg");
        }
    }
}
