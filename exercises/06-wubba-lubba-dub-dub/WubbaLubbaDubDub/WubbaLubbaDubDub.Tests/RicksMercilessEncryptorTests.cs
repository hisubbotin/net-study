using System;
using Xunit;
using WubbaLubbaDubDub;
using System.Text.RegularExpressions;
using System.Collections.Immutable;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Fact]
        public void Test_SplitToLines()
        {
            string text = "abc\r\nfoo\r\nbar";
            Assert.Equal(new string[] { "abc", "foo", "bar" }, text.SplitToLines());
        }

        [Fact]
        public void Test_SplitToWords()
        {
            string text = "abc def     foo\tbar";
            Assert.Equal(new string[] { "abc", "def", "foo", "bar" }, text.SplitToWords());
        }

        [Theory]
        [InlineData("abcd", "ab")]
        [InlineData("abcde", "ab")]
        public void Test_GetLeftHalf(string str, string half)
        {
            Assert.Equal(half, str.GetLeftHalf());
        }

        [Theory]
        [InlineData("abcd", "cd")]
        [InlineData("abcde", "cde")]
        public void Test_GetRightHalf(string str, string half)
        {
            Assert.Equal(half, str.GetRightHalf());
        }

        [Theory]
        [InlineData("abc", "cba")]
        [InlineData("1 2\t", "\t2 1")]
        public void Test_GetReversed(string str, string rev)
        {
            Assert.Equal(rev, str.GetReversed());
        }

        [Theory]
        [InlineData("abc", @"\u0061\u0062\u0063")]
        [InlineData("1 2\t", @"\u0031\u0020\u0032\u0009")]
        public void Test_CharsToCodes(string str, string coded)
        {
            Assert.Equal(coded, str.CharsToCodes());
        }

        [Theory]
        [InlineData("aBc", "AbC")]
        [InlineData("1 2\t e ^8$ T", "1 2\t E ^8$ t")]
        public void Test_GetCaseInversed(string str, string inv)
        {
            Assert.Equal(inv, str.InverseCase());
        }

        [Theory]
        [InlineData("abc", "bcd")]
        [InlineData("1 2\t e ^8$ T", "2!3\n!f!_9%!U")]
        public void Test_GetIncShifted(string str, string shifted)
        {
            Assert.Equal(shifted, str.ShiftInc());
        }

        [Theory]
        [InlineData("abc ¶0000:0000¶ def", new long[]{3472328296227680304})]
        [InlineData("abc /* ¶abcd:abcd¶ */ ¶0000:0000¶ ee", new long[]{3472328296227680304})]
        [InlineData("abc ¶0000:0000¶ // ¶abcd:abcd¶ ee\n and ¶0000:1000¶ after",
            new long[]{3472328296227680304, 3472328296227680305})]
        [InlineData("abc foo ¶ABCD:XYWZ¶ gehet\n" +
                "line with ¶1234:5678¶ and //comment of ¶6666:7777¶, yeah\n" +
                "and ¶mult:line¶ comment here: /* begin with ¶2222:2222¶ and\n" +
                "continue with ¶cccc:cccc¶ and even\n" +
                "ending with ¶eeee:eeee¶ here */ the last one ¶0000:0000¶ end.",
            new long[] {4918848066474695000, 3761405300762424885, 8389209318598011244, 3472328296227680304})]
        public void Test_GetUsedObjects(string text, long[] ids)
        {
            Assert.Equal(ImmutableList.Create(ids), text.GetUsedObjects());
        }
    }
}
