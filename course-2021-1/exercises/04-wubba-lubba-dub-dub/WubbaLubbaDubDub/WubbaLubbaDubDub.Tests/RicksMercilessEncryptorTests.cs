using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("fffff\nffff", new string[] { "fffff", "ffff" })]
        public void TestSplitToLines(string line, string[] actual)
        {
            Assert.Equal(line.SplitToLines(), actual);
        }

        [Theory]
        [InlineData("Such, a? simple* example-example!; isn't it?", new string[]{"Such", "a", "simple", "example-example", "isn't", "it"} )]
        public void TestSplitToWords(string line, string[] actual)
        {
            Assert.Equal(line.SplitToWords(), actual);
        }

        [Theory]
        [InlineData("ab", "a")]
        [InlineData("aab", "a")]
        public void TestGetLeftHalf(string line, string actual)
        {
            Assert.Equal(line.GetLeftHalf(), actual);
        }

        [Theory]
        [InlineData("ab", "b")]
        [InlineData("aab", "ab")]
        public void TestGetRightHalf(string line, string actual)
        {
            Assert.Equal(line.GetRightHalf(), actual);
        }

        [Theory]
        [InlineData("aaaacaaaaa", "aaaa", "bb", "bbcbba")]
        public void TestReplace(string line, string old, string @new, string actual)
        {
            Assert.Equal(line.Replace(old, @new), actual);
        }


        [Theory]
        [InlineData("a", @"\u0061")]
        public void TestCharsToCodes(string line, string actual)
        {
            Assert.Equal(line.CharsToCodes(), actual);
        }
        
        [Theory]
        [InlineData("ab", "ba")]
        public void TestGetReversed(string line, string actual)
        {
            Assert.Equal(line.GetReversed(), actual);
        }
        
        [Theory]
        [InlineData("Ab", "aB")]
        public void TestInverseCase(string line, string actual)
        {
            Assert.Equal(line.InverseCase(), actual);
        }

        [Theory]
        [InlineData("abc", "bcd")]
        public void TestShiftInc(string word, string actual)
        {
            Assert.Equal(word.ShiftInc(), actual);
        }

        [Theory]
        [InlineData(
            @"Wow, is this an example?
               // even with comments
               /* and block comments */
               some id here: ¶0000:0001¶
               /* another block comment, with id in it:
                    ¶0000:0002¶ */
               another id here: ¶0000:0003¶
               // comment with id ¶0000:0004¶       
               ", new long[] { 0x00000001, 0x00000003 }
        )]
        public void TestGetUsedObjects(string text, long[] actual)
        {
            Assert.Equal(text.GetUsedObjects(), actual);
        }
    }
}
