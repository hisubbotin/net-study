using System;
using System.Text;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("", 1)]
        [InlineData("OneWord", 1)]
        [InlineData("Two words", 1)]
        [InlineData("Two\nlines", 2)]
        [InlineData("Three\nlines\n.", 3)]
        public void Test_SplitToLines(string text, int size)
        {
            Assert.Equal(size, text.SplitToLines().Length);
        }

        [Theory]
        [InlineData("", 1)]
        [InlineData("OneWord", 1)]
        [InlineData("Two words", 2)]
        [InlineData(@"Two words, and three words;some/words#more", 8)]
        [InlineData("words and numbers: 123, 23", 5)]
        public void Test_SplitToWords(string line, int size)
        {
            Assert.Equal(size, line.SplitToWords().Length);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("a", "")]
        [InlineData("ab", "a")]
        [InlineData("abc", "a")]
        public void Test_GetLeftHalf(string s, string leftHalf)
        {
            Assert.Equal(leftHalf, s.GetLeftHalf());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("a", "a")]
        [InlineData("ab", "b")]
        [InlineData("abc", "bc")]
        public void Test_GetRightHalf(string s, string leftHalf)
        {
            Assert.Equal(leftHalf, s.GetRightHalf());
        }

        [Fact]
        public void Test_Replace_empty()
        {
            try
            {
                "string".Replace("", "new");
            }
            catch (System.ArgumentException e)
            {
            }
        }

        [Theory]
        [InlineData("", "a", "b", "")]
        [InlineData("a", "b", "c", "a")]
        [InlineData("a", "a", "b", "b")]
        [InlineData("abc", "bc", "de", "ade")]
        public void Test_Replace(string s, string old, string @new, string result)
        {
            Assert.Equal(result, s.Replace(old, @new));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("abacab", @"\u0061\u0062\u0061\u0063\u0061\u0062")]
        public void Test_CharsToCodes(string s, string result)
        {
            Assert.Equal(result, s.CharsToCodes());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("abacab", "bacaba")]
        public void Test_GetReversed(string s, string result)
        {
            Assert.Equal(result, s.GetReversed());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("a", "A")]
        [InlineData("A", "a")]
        [InlineData("Ab", "aB")]
        public void Test_InverseCase(string s, string result)
        {
            Assert.Equal(result, s.InverseCase());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("\u0000", "\u0001")]
        [InlineData("\u1A72\u4C91", "\u1A73\u4C92")]
        [InlineData("\uFFFF", "\u0000")]
        public void Test_ShiftInc(string s, string result)
        {
            Assert.Equal(result, s.ShiftInc());
        }

        [Fact]
        public void Test_GetUsedObjects()
        {
            string input = "// one line comment\n" +
                           "identifier ¶00000000:00000000¶ here\n" +
                           "// one line comment with ¶00000000:00000001¶ identifier\n" +
                           "one another ¶00000000:00000d02¶ id\n" +
                           "/* start\n" +
                           "of multiline comment */\n" +
                           "im ¶00000A00:00000003¶ here\n" +
                           "or here ¶00000000:00000004¶ /*but not here ¶00000000:00000005¶*/\n" +
                           "duplicate ¶00000a00:00000003¶\n";
            long[] result = new long[]
            {
                0x0000000000000000, 0x0000000000000d02, 0x00000A0000000003, 0x0000000000000004
            };
            Assert.Equal(result, input.GetUsedObjects());
        }
    }
}
