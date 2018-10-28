using System;
using System.Collections.Immutable;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("aaaaa\n, aaaaa\n   fsjdkbfkjsdjk", 3)]
        [InlineData("aaaaaaaaaaa", 1)]
        public void SplitTest(string text, int linesCount)
        {
            var lines = text.SplitToLines();
            Assert.Equal(linesCount, lines.Length);
        }

        [Theory]
        [InlineData("aa\taa", 2)]
        [InlineData("aa aa", 2)]
        public void SplitWordsTest(string line, int wordCount)
        {
            var words = line.SplitToWords();
            Assert.Equal(wordCount, words.Length);
        }

        [Theory]
        [InlineData("abacaba", "aba")]
        [InlineData("wubaluba", "wuba")]
        public void LeftTest(string line, string target)
        {
            Assert.Equal(target, line.GetLeftHalf());
        }

        [Theory]
        [InlineData("abacaba", "caba")]
        [InlineData("wubaluba", "luba")]
        public void RightTest(string line, string target)
        {
            Assert.Equal(target, line.GetRightHalf());
        }

        [Theory]
        [InlineData("Wubaluba", "abulabuW")]
        [InlineData("stressed desserts", "stressed desserts")]
        public void ReversedTest(string line, string target)
        {
            Assert.Equal(target, line.GetReversed());
        }

        [Theory]
        [InlineData("aabaa", "b", "c", "aacaa")]
        public void ReplaceTest(string line, string pattern, string @new, string target)
        {
            var result = line.Replace(pattern, @new);
            Assert.Equal(target, result);
        }

        [Theory]
        [InlineData("abc", "\\u0061\\u0062\\u0063")]
        public void CharToCodesTest(string line, string target)
        {
            Assert.Equal(target, line.CharsToCodes());
        }
        [Theory]
        [InlineData("AbAcAbA", "aBaCaBa")]
        public void InvertTest(string line, string target)
        {
            Assert.Equal(target, line.InverseCase());
        }

        [Theory]
        [InlineData("abc123", "bcd234")]
        public void ShiftTest(string line, string target)
        {
            Assert.Equal(target, line.ShiftInc());
        }

        [Fact]
        public void UsedObjectsTest()
        {
            string text = "0000:0001 /* hgajogsfogs 0000:0000 */ 0000:0010 // 0000:3333 \n";
            IImmutableList<long> list = text.GetUsedObjects();
            Assert.Equal(2, list.Count);
            Assert.Equal(1, list[0]);
            Assert.Equal(16, list[1]);
        }
    }
}
