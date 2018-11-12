using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("First line\nSecond Line", new[] { "First line", "Second Line" })]
        [InlineData("One\nTwo\nThree", new[] { "One", "Two", "Three" })]
        [InlineData("One\n", new[] { "One", "" })]
        public void Test_SplitToLines(string s, string[] result)
        {
            Assert.Equal(result, s.SplitToLines());
        }

        [Theory]
        [InlineData("First line, Second Line", new[] { "First", "line", "Second", "Line" })]
        [InlineData("One, two, three", new[] { "One", "two", "three" })]
        [InlineData("One: 1, two: 2, three: 3", new[] { "One", "1" , "two", "2", "three", "3" })]
        [InlineData("One: 1, two: 2, 1!2#3$4", new[] { "One", "1", "two", "2", "1", "2", "3", "4" })]
        public void Test_SplitToWords(string s, string[] result)
        {
            Assert.Equal(result, s.SplitToWords());
        }

        [Theory]
        [InlineData("First", "Fi")]
        [InlineData("Second", "Sec")]
        [InlineData("123456789", "1234")]
        public void Test_GetLeftHalf(string s, string result)
        {
            Assert.Equal(result, s.GetLeftHalf());
        }

        [Theory]
        [InlineData("First", "rst")]
        [InlineData("Second", "ond")]
        [InlineData("123456789", "56789")]
        public void Test_GetRightHalf(string s, string result)
        {
            Assert.Equal(result, s.GetRightHalf());
        }

        [Theory]
        [InlineData("First", "rst", "at", "Fiat")]
        [InlineData("Second", "ond", "OND", "SecOND")]
        [InlineData("One", "Two", "Three", "One")]
        public void Test_Replace(string s, string old, string @new, string result)
        {
            Assert.Equal(result, s.Replace(old, @new));
        }

        [Theory]
        [InlineData("a", @"\u0061")]
        [InlineData("bc", @"\u0062\u0063")]
        [InlineData("", "")]
        public void Test_CharsToCodes(string s, string result)
        {
            Assert.Equal(result, s.CharsToCodes());
        }

        [Theory]
        [InlineData("First", "tsriF")]
        [InlineData("Second", "dnoceS")]
        [InlineData("123456789", "987654321")]
        [InlineData("", "")]
        public void Test_GetReversed(string s, string result)
        {
            Assert.Equal(result, s.GetReversed());
        }

        [Theory]
        [InlineData("First", "fIRST")]
        [InlineData("Second", "sECOND")]
        [InlineData("123456789", "123456789")]
        [InlineData("", "")]
        public void Test_InverseCase(string s, string result)
        {
            Assert.Equal(result, s.InverseCase());
        }

        [Theory]
        [InlineData("a", "b")]
        [InlineData("abcd", "bcde")]
        [InlineData("\uAB04", "\uAB05")]
        [InlineData("\uAB04\uCF04\u0A04", "\uAB05\uCF05\u0A05")]
        [InlineData("\uFFFF", "\u0000")]
        [InlineData("", "")]
        public void Test_ShiftInc(string s, string result)
        {
            Assert.Equal(result, s.ShiftInc());
        }

        [Theory]
        [InlineData("0000:0000 0000:0001", new[] { 0L, 1L })]
        [InlineData("0000:0000 0000:0001 0000:0002", new[] { 0L, 1L, 2L })]
        [InlineData("0000:0000 // 0000:0001", new[] { 0L })]
        [InlineData("0000:0000 /* 0000:0001 */ 0000:0002", new[] { 0L, 2L })]
        [InlineData("0000:0000 // 0000:0001 0000:0002", new[] { 0L })]
        [InlineData("0000:0000 // 0000:0001\n0000:0002", new[] { 0L, 2L })]
        [InlineData("0000:0000 /* 0000:0001\n0000:0002 */ 0000:0003", new[] { 0L, 3L })]
        [InlineData("0000:0000 /* 0000:0001\n0000:0002 */ //0000:0003", new[] { 0L })]
        [InlineData("0000:0000 /* 0000:0001\n0000:0002 */", new[] { 0L })]
        public void TestGetUsedObjects(string s, long[] result)
        {
            Assert.Equal(s.GetUsedObjects(), result);
        }
    }
}
