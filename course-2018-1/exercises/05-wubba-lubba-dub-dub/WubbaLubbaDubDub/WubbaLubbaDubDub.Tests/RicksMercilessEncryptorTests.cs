using System;
using System.Collections.Immutable;
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
            Assert.Equal(s.GetLeftHalf(), "aBCdeFbcB");
        }

        [Fact]
        public void Test_Replace()
        {
            string s = "aBCdeFbcBc!BCcb hg";
            Assert.Equal(s.Replace("BC", "XY"), "aXYdeFbcBc!XYcb hg");
        }

        [Fact]
        public void Test_CharToCodes()
        {
            string s = "aBCdeF";
            Assert.Equal(s.CharsToCodes(), "\\u0061\\u0042\\u0043\\u0064\\u0065\\u0046");
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

        [Fact]
        public void Test_GetUsedObjects()
        {
            string text = "1234:5674//4568:8906\n" +
                          "4325:45\n" +
                          "/*6785:4567\n" +
                          "6755:4567*/\n" +
                          "364:1";
            var answer = (new long[] {12345674}).ToImmutableList();
            Assert.Equal(answer, text.GetUsedObjects());
        }
    }
}
