using System;
using System.Collections.Immutable;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("new test string", new[] { "new test string" })]
        [InlineData("just\ntesting\n\n\nthis\nmethod", new[] { "just", "testing", "" ,"", "this", "method" })]
        public void SplitToLines(string before, string[] expected)
        {
            Assert.Equal(expected, before.SplitToLines());
        }

        [Theory]
        [InlineData("new test string", new[] { "new", "test", "string" })]
        [InlineData("just\ntesting, another\n\n\nthis\nmethod.", new[] { "just", "testing", "another", "this", "method" })]
        public void SplitToWords(string before, string[] expected)
        {
            //Assert.Equal(expected, before.SplitToLines());
        }

        [Theory]
        [InlineData("abcdef", "abc")]
        [InlineData("abcdefg", "abc")]
        [InlineData("", "")]
        public void GetLeftHalf(string before, string expected)
        {
            Assert.Equal(expected, before.GetLeftHalf());
        }

        [Theory]
        [InlineData("abcdef", "def")]
        [InlineData("abcdefg", "defg")]
        [InlineData("", "")]
        public void GetRightHalf(string before, string expected)
        {
            Assert.Equal(expected, before.GetRightHalf());
        }

        [Theory]
        [InlineData(new[] { "new test string is new", "new", "old"},  "old test string is old" )]
        public void Replace(string[] before, string expected)
        {
            Assert.Equal(expected, before[0].Replace(before[1], before[2]));
        }

        [Theory]
        [InlineData("alloky1234", @"\u0061\u006C\u006C\u006F\u006B\u0079\u0031\u0032\u0033\u0034")]
        public void CharsToCodes(string before, string expected)
        {
            var test = before.CharsToCodes();
            Assert.Equal(expected, before.CharsToCodes());
        }

        [Theory]
        [InlineData("abcdef", "fedcba")]
        [InlineData("abcdefg", "gfedcba")]
        [InlineData("", "")]
        public void Reversed(string before, string expected)
        {
            Assert.Equal(expected, before.GetReversed());
        }

        [Theory]
        [InlineData("aBc1$", "AbC1$")]
        [InlineData("abc D,ef?", "ABC d,EF?")]
        [InlineData("", "")]
        public void InverseCase(string before, string expected)
        {
            Assert.Equal(expected, before.InverseCase());
        }

        [Theory]
        [InlineData("abc", "bcd")]
        public void ShiftInc(string before, string expected)
        {
            Assert.Equal(expected, before.ShiftInc());
        }


        [Theory]
        [InlineData("¶0:2¶//¶100:200¶\n/** ¶0:13¶ **/ ¶0:12¶ ¶0:20¶", new[] { 2L, 18L, 32L })]
        public void GetUsedObjects(string before, long[] expected)
        {
            Assert.Equal(expected, before.GetUsedObjects());
        }
    }
}
