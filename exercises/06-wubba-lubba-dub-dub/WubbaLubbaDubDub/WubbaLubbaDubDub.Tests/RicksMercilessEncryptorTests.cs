using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Lorem ipsum dolor\r\n sit amet, consectetur adipiscing elit, \r\n" +
            "sed do eiusmod te\r\nmpor incididunt ut labore et dolore\r\n magna aliqua.",
            new[] { "Lorem ipsum dolor",
                " sit amet, consectetur adipiscing elit, ",
                "sed do eiusmod te",
                "mpor incididunt ut labore et dolore",
                " magna aliqua." })]
        public void Test_SplitToLines(string text, string[] expected)
        {
            var actual = text.SplitToLines();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Excepteur sint occaecat",
           new[] { "Excepteur", "sint", "occaecat" })]
        public void Test_SplitToWords(string text, string[] expected)
        {
            var actual = text.SplitToWords();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Left_half_Right_half", "Left_half_")]
        public void Test_GetLeftHalf(string text, string expected)
        {
            var actual = text.GetLeftHalf();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Left_half_Right_half", "Right_half")]
        public void Test_GetRightHalf(string text, string expected)
        {
            var actual = text.GetRightHalf();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Ut enim ad minim veniam", "ad", "kek", "Ut enim kek minim veniam")]
        public void Test_Replace(string text, string old, string @new, string expected)
        {
            var actual = text.Replace(old, @new);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Hi", "\\u0048\\u0069")]
        public void Test_CharsToCode(string text, string expected)
        {
            var actual = text.CharsToCodes();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Duis aute irure dolor in reprehenderit",
            "tiredneherper ni rolod eruri etua siuD")]
        public void Test_Reverse(string text, string expected)
        {
            var actual = text.GetReversed();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Lorem Ipsum", "lOREM iPSUM")]
        public void Test_Inverse(string text, string expected)
        {
            var actual = text.InverseCase();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("abcdef", "bcdefg")]
        public void Test_ShiftInc(string text, string expected)
        {
            var actual = text.ShiftInc();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Lorem ipsum dolor sit amet, 0000:000D consectetur adipiscing elit, sed do eiusmod tempor\r\n" +
            " //incididunt DEAD:BEAF ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud\r\n " +
            "exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure" +
            " /*dolor 1234:FFFF in repr*/ehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur." +
            " Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit" +
            " anim id est laborum.",
           new[] { 13L })]
        public void Test_GetUsedObjects(string text, long[] expected)
        {
            var actual = text.GetUsedObjects();
            Assert.Equal(expected, actual);
        }
    }
}
