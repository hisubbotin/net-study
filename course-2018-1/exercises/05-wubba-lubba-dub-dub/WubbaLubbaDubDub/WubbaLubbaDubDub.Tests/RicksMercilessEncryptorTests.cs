using System;
using Xunit;
using WubbaLubbaDubDub;
using System.Collections.Immutable;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("aaaa\naaaaa", new[] {"aaaa", "aaaaa"})]
        [InlineData("", new[]{""})]
        [InlineData("aaaa\naaaa\nnnnn\neee", new[] {"aaaa", "aaaa", "nnnn", "eee"})]
        public void TestSplitToLines(string text, string[] result)
        {
            Assert.Equal(result, text.SplitToLines());
        }
        
        [Theory]
        [InlineData("aaaa aaaaa", new[] {"aaaa", "aaaaa"})]
        [InlineData("", new[]{""})]
        [InlineData("aaaa aaaa nnnn eee", new[] {"aaaa", "aaaa", "nnnn", "eee"})]
        public void TestSplitToWords(string text, string[] result)
        {
            Assert.Equal(result, text.SplitToWords());
        }
        
        [Theory]
        [InlineData("aaaaaaaaa", "aaaa")]
        [InlineData("", "")]
        [InlineData("aaaa aaaa nnnn eee", "aaaa aaaa")]
        public void TestGetLeftHalf(string text, string result)
        {
            Assert.Equal(result, text.GetLeftHalf());
        }
        
        [Theory]
        [InlineData("aaaaaaaaa", "aaaaa")]
        [InlineData("", "")]
        [InlineData("aaaa aaaa nnnn eee", " nnnn eee")]
        public void TestGetRightHalf(string text, string result)
        {
            Assert.Equal(result, text.GetRightHalf());
        }
        
        [Theory]
        [InlineData("aaaaaaaaa", "a", "rf", "rfrfrfrfrfrfrfrfrf")]
        [InlineData("", "a", "b", "")]
        [InlineData("aaaa aaaa nnnn eee", " ", "b", "aaaabaaaabnnnnbeee")]
        public void TestGetReplace(string text, string old, string @new, string result)
        {
            Assert.Equal(result, text.Replace(old, @new));
        }
        
        [Theory]
        [InlineData("abcdef", "\\u0061\\u0062\\u0063\\u0064\\u0065\\u0066")]
        [InlineData("", "")]
        [InlineData("  t", "\\u0020\\u0020\\u0074")]
        public void TestCharsToCodes(string text, string result)
        {
            Assert.Equal(result, text.CharsToCodes());
        }
        
        [Theory]
        [InlineData("a12345bcd", "dcb54321a")]
        [InlineData("", "")]
        [InlineData("   ert r r", "r r tre   ")]
        public void TestGetReversed(string text, string result)
        {
            Assert.Equal(result, text.GetReversed());
        }
        
        [Theory]
        [InlineData("A12345bCD", "a12345Bcd")]
        [InlineData("", "")]
        [InlineData("aaaaaaaaaa", "AAAAAAAAAA")]
        public void TestInverseCase(string text, string result)
        {
            Assert.Equal(result, text.InverseCase());
        }
        
        [Theory]
        [InlineData("A12345bCD", "B23456cDE")]
        [InlineData("", "")]
        [InlineData("aaaaaaaaaa", "bbbbbbbbbb")]
        public void TestShiftInc(string text, string result)
        {
            Assert.Equal(result, text.ShiftInc());
        }
        
        [Fact]
        public void TestGetUsedObjects()
        {
            var text = "00:000010 dfgds0000:0000gdfsg /*\ndgdg\ndfgdg\ndfgdg\n*/ // 0000:0100\n 0000:0001";
            var result = (new long[] {0, 1}).ToImmutableList();
            Assert.Equal(result, text.GetUsedObjects());
        }
    }
}
