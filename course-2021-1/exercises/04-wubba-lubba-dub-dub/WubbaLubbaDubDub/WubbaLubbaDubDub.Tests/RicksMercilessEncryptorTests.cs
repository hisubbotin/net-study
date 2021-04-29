using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Such, a? simple* example-example!; isn't it?", new string[]{"Such", "a", "simple", "example-example", "isn't", "it"} )]
        public void TestSplitToWords(string line, string[] actual)
        {
            Assert.Equal(line.SplitToWords(), actual);
        }

        [Theory]
        [InlineData("abc", "bcd")]
        public void TestShiftInc(string word, string actual)
        {
            Assert.Equal(word.ShiftInc(), actual);
        }
        
    }
}
