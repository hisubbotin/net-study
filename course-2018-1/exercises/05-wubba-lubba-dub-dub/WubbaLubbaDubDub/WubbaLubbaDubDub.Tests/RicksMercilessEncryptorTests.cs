using System;
using System.Collections.Immutable;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Hi\r\nThis is one\r\nBla bla bla\r\naaaaaaaaaa", 
            new [] {"Hi", "This is one", "Bla bla bla", "aaaaaaaaaa" })]
        public void TestSplitToLines(string text, string[] res)
        {
            Assert.Equal(text.SplitToLines(), res);
        }

        [Theory]
        [InlineData("Hi This, is!! one\r\nBla bla bla\r\naaaaaaaaaa",
            new[] { "Hi", "This", "is", "one", "Bla", "bla", "bla", "aaaaaaaaaa" })]
        public void TestSplitToWords(string line, string[] res)
        {
            Assert.Equal(line.SplitToWords(), res);
        }

        [Theory]
        [InlineData("Hi, my name is tru-la-la", "Hi, my name ")]
        [InlineData("Hi, my name is tru-la-laa", "Hi, my name ")]
        public void TestGetLeftHalf(string s, string res)
        {
            Assert.Equal(s.GetLeftHalf(), res);
        }

        [Theory]
        [InlineData("Hi, my name is tru-la-la", "is tru-la-la")]
        [InlineData("Hi, my name is tru-la-laa", "is tru-la-laa")]
        public void TestGetRightHalf(string s, string res)
        {
            Assert.Equal(s.GetRightHalf(), res);
        }

        [Theory]
        [InlineData("Hi, my name is tru-la-la", "la", "lu", "Hi, my name is tru-lu-lu")]
        public void TestReplace(string s, string old, string @new, string res)
        {
            Assert.Equal(s.Replace(old, @new), res);
        }

        [Theory]
        [InlineData("ABC", "\\u0041\\u0042\\u0043")]
        public void TestCharsToCodes(string s, string res)
        {
            Assert.Equal(s.CharsToCodes(), res);
        }

        [Theory]
        [InlineData("ABC", "CBA")]
        [InlineData("What is it?", "?ti si tahW")]
        public void TestGetReversed(string s, string res)
        {
            Assert.Equal(s.GetReversed(), res);
        }

        [Theory]
        [InlineData("ABC", "abc")]
        [InlineData("What is it?", "wHAT IS IT?")]
        public void TestInverseCase(string s, string res)
        {
            Assert.Equal(s.InverseCase(), res);
        }

        [Theory]
        [InlineData("ABCa", "BCDb")]
        public void TestShiftInc(string s, string res)
        {
            Assert.Equal(s.ShiftInc(), res);
        }

        [Theory]
        [InlineData("This is some text without comments and id", new long[0] {})]
        [InlineData("This is another text without comments but with id: ABCD:1234",
            new[] { 2882343476L })]
        [InlineData("This is text with id: ABCD:1234 and comment: //bla bla AFFF:1010\ndgf",
            new[] { 2882343476L })]
        [InlineData("This is text with id: ABCD:1234 and comment: //bla bla AFFF:1010",
            new[] { 2882343476L })]
        [InlineData("Text with comment: /*b*/ and ids: FFFF:0000, ABCD:1234",
            new[] { 4294901760L, 2882343476L })]
        [InlineData("Text with comment: /*Comment with id\n FFFF:0000 bla bla*/ and ids: FFFF:0000, ABCD:1234", 
            new[] { 4294901760L, 2882343476L })]
        public void TestGetUsedObjects(string s, long[] res)
        {
            Assert.Equal(s.GetUsedObjects(), res.ToImmutableList());
        }
    }
}
