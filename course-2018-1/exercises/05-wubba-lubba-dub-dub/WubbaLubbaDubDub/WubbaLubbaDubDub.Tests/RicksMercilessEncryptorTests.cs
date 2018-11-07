using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Hey\nMorty!\nLet's go to another...\nargh...\nanother Rick and Morty adventure!", new string[] { "Hey", "Morty!", "Let's go to another...", "argh...", "another Rick and Morty adventure!" })]
        [InlineData("a\nb", new string[] {"a", "b" })]
        public void SplitToLinesTest(string text, string[] correct)
        {
            string[] answer = RicksMercilessEncryptor.SplitToLines(text);
            Assert.Equal(answer, correct);
        }


        [Theory]
        [InlineData("  a    b  ", new string[] {"", "a", "b", "" })]
        public void SplitToWordsTest(string text, string[] correct)
        {
            string[] answer = RicksMercilessEncryptor.SplitToWords(text);
            Assert.Equal(answer, correct);
        }

        [Theory]
        [InlineData("VeryCool", "Very")]
        [InlineData("aaabbbb", "aaa")]
        public void GetLeftHalfTest(string text, string correct)
        {
            string answer = RicksMercilessEncryptor.GetLeftHalf(text);
            Assert.Equal(answer, correct);
        }

        [Theory]
        [InlineData("VeryCool", "Cool")]
        [InlineData("aaabbbb", "bbbb")]
        public void GetRightHalfTest(string text, string correct)
        {
            string answer = RicksMercilessEncryptor.GetRightHalf(text);
            Assert.Equal(answer, correct);
        }

        [Theory]
        [InlineData("abcabcabc", "ab", "d", "dcdcdc")]
        public void ReplaceTest(string text, string old, string @new, string correct)
        {
            string answer = RicksMercilessEncryptor.Replace(text, old, @new);
            Assert.Equal(answer, correct);
        }

        [Theory]
        [InlineData("ab", "\\u0061\\u0062")]
        public void CharToCodesTest(string text, string correct)
        {
            string answer = RicksMercilessEncryptor.CharsToCodes(text);
            Assert.Equal(answer, correct);
        }

        [Theory]
        [InlineData("abcd", "dcba")]
        public void GetReversedTest(string text, string correct)
        {
            string answer = RicksMercilessEncryptor.GetReversed(text);
            Assert.Equal(answer, correct);
        }

        [Theory]
        [InlineData("aBcD", "AbCd")]
        public void InverseCaseTest(string text, string correct)
        {
            string answer = RicksMercilessEncryptor.InverseCase(text);
            Assert.Equal(answer, correct);
        }

        [Theory]
        [InlineData("abc", "bcd")]
        public void ShiftIncTest(string text, string correct)
        {
            string answer = RicksMercilessEncryptor.ShiftInc(text);
            Assert.Equal(answer, correct);
        }
        
        [Theory]
        [InlineData("//i sit alone and AAAA:000A watch your lights\n 0000:000A my only friend /*through teenage nights" +
           " AAA4:5565*/ and every thing i had to // i've heard it on my radio\n ",
           new long[] {10})]
        public void GetUsedObjectTest(string text, long[] correct)
        {
            
            Assert.Equal(RicksMercilessEncryptor.GetUsedObjects(text), correct);
        }

    }
}
