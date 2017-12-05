using System;
using Xunit;
using System.Collections.Immutable;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("This is one phrase.\r\nThis is another phrase.\r\nAnd this is one more.",
            new[] { "This is one phrase.", "This is another phrase.", "And this is one more." })]
        public void Test_SplitToLines(string text, string[] result)
        {
            Assert.Equal(result, text.SplitToLines());
        }

        [Theory]
        [InlineData("some words in phrase", new[] { "some", "words", "in", "phrase" })]
        [InlineData("one phrase,\r\nanother phrase", new[] { "one", "phrase", "another", "phrase" })]
        public void Test_SplitToWords(string line, string[] result)
        {
            Assert.Equal(result, line.SplitToWords());
        }

        [Theory]
        [InlineData("Merry Xmas", "Merry")]
        [InlineData("Vruchtel Serafima", "Vruchtel")]
        public void Test_GetLeftHalf(string s, string result)
        {
            Assert.Equal(result, s.GetLeftHalf());
        }

        [Theory]
        [InlineData("Yellow submarine", "ubmarine")]
        [InlineData("Vruchtel Serafima", " Serafima")]
        public void Test_GetRightHalf(string s, string result)
        {
            Assert.Equal(result, s.GetRightHalf());
        }

        [Theory]
        [InlineData("It was a bad day", "bad", "wonderful", "It was a wonderful day")]
        public void Test_Replace(string s, string old, string @new, string result)
        {
            Assert.Equal(result, s.Replace(old, @new));
        }

        [Theory]
        [InlineData("A", "\\u0041")]
        [InlineData("ABC", "\\u0041\\u0042\\u0043")]
        public void Test_CharsToCodes(string s, string result)
        {
            Assert.Equal(result, s.CharsToCodes());
        }

        [Theory]
        [InlineData("lalala", "alalal")]
        [InlineData("This is an important phrase!", "!esarhp tnatropmi na si sihT")]
        public void Test_GetReversed(string s, string result)
        {
            Assert.Equal(result, s.GetReversed());
        }

        [Theory]
        [InlineData("WrItE lIkE tHiS", "wRiTe LiKe ThIs")]
        [InlineData("Normal accurate phrase.", "nORMAL ACCURATE PHRASE.")]
        public void Test_InverseCase(string s, string result)
        {
            Assert.Equal(result, s.InverseCase());
        }

        [Theory]
        [InlineData("ABC", "BCD")]
        [InlineData("ZaZ", "[b[")]
        public void Test_ShiftInc(string s, string result)
        {
            Assert.Equal(result, s.ShiftInc());
        }

        [Theory]
        [InlineData("This is text with unique id like this: ABCD:1234 and comments like this // comment",
            new[] { 2882343476L })]
        [InlineData("/*Comment \n long FFFF:0000 */ and again FFFF:0000", new[] { 4294901760L })]
        public void Test_GetUsedObjects(string s, long[] result)
        {
            Assert.Equal(result.ToImmutableList(), s.GetUsedObjects());
        }
    }
}
