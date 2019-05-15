using System;
using Xunit;
using System.Collections.Immutable;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {

        [Theory]
        [InlineData("This\nis\ntest", new String[] { "This", "is", "test" })]
        public void TestSplitToLines(string test, string[] result)
        {
            Assert.Equal(test.SplitToLines(), result);
        }

        [Theory]
        [InlineData("THIS is\nDifferent!words", new String[] { "THIS", "is", "Different", "words" })]
        public void TestSplitToWords(string test, string[] result)
        {
            Assert.Equal(test.SplitToWords(), result);
        }

        [Theory]
        [InlineData("Even", "Ev")]
        [InlineData("Ooodd", "Oo")]
        public void TestGetLeftHalf(string original, string target)
        {
            Assert.Equal(original.GetLeftHalf(), target);
        }

        [Theory]
        [InlineData("Even", "en")]
        [InlineData("Ooodd", "odd")]
        public void TestGetRightHalf(string original, string target)
        {
            Assert.Equal(original.GetRightHalf(), target);
        }

        [Theory]
        [InlineData("Was this", "is", "ere", "Was there")]
        [InlineData("AAAbbbbCCC", "bb", "BB", "AAABBBBCCC")]
        [InlineData("abcabc", "a", "d", "dbcdbc")]
        public void TestReplace(string original, string old, string @new, string target)
        {

        }

        [Theory]
        [InlineData("Λ", @"\u039B")]
        [InlineData("\u010A\u3C44", @"\u010A\u3C44")]
        public void TestCharsToCodes(string original, string target)
        {
            Assert.Equal(original.CharsToCodes(), target);
        }

        [Theory]
        [InlineData("abcd", "dcba")]
        public void TestGetReversed(string original, string reversed)
        {
            Assert.Equal(original.GetReversed(), reversed);
        }

        [Theory]
        [InlineData("AAA", "aaa")]
        [InlineData("aAaA", "AaAa")]
        public void TestInverseCase(string original, string inversed)
        {
            Assert.Equal(original.InverseCase(), inversed);
        }

        [Theory]
        [InlineData("\u1234\uabcd", "\u1235\uabce")]
        [InlineData("\u9998", "\u9999")]
        public void TestShiftInc(string original, string shifted)
        {
            Assert.Equal(original.ShiftInc(), shifted);
        }

        [Theory]
        [InlineData("//Comment\n/*comment 00000000:00000000*/, 00000000:00000001, 00000000:00000001 , aaaa:aaa", new long[] {1L})]
        [InlineData(@"//Com 0000:0000\n00000000:0000000K", new long[] { })]
        [InlineData(@"01111111:01111111  00000000:0000000a", new long[] { 0x0111111101111111, 10L  })]
        public void TestGetUsedObjects(string original, long[] target)
        {
            Assert.Equal(original.GetUsedObjects(), target);
        }

    }
}
