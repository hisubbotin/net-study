using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("a\na\na\na\na\n")]
        public void Test_SplitToLines(string text)
        {
            Assert.Equal(5, text.SplitToLines().Length);
        }

        [Theory]
        [InlineData("Wubba lubba dub dub", new string[] {"Wubba", "lubba", "dub", "dub"})]
        public void Test_SplitToWords(string line, string[] res)
        {
            Assert.Equal(res, line.SplitToWords());
        }

        [Theory]
        [InlineData("Rick Sanchez", "Rick S")]
        public void Test_GetLeftHalf1(string line, string res)
        {
            Assert.Equal(res, line.GetLeftHalf());
        }

        [Theory]
        [InlineData("Pickle Rick", "Pickl")]
        public void Test_GetLeftHalf2(string line, string res)
        {
            Assert.Equal(res, line.GetLeftHalf());
        }

        [Theory]
        [InlineData("Rick Sanchez", "anchez")]
        public void Test_GetRightHalf1(string line, string res)
        {
            Assert.Equal(res, line.GetRightHalf());
        }

        [Theory]
        [InlineData("Pickle Rick", "e Rick")]
        public void Test_GetRightHalf2(string line, string res)
        {
            Assert.Equal(res, line.GetRightHalf());
        }

        [Theory]
        [InlineData("I'm Snuffles", "Snuffles", "Snowball", "I'm Snowball")]
        public void Test_Replace(string line, string old, string @new, string res)
        {
            Assert.Equal(res, line.Replace(old, @new));
        }

        [Theory]
        [InlineData("Unity", "\u0055\u006E\u0069\u0074\u0079")]
        public void Test_CharToCodes(string line, string res)
        {
            Assert.Equal(res, line.CharsToCodes());
        }

        [Theory]
        [InlineData("Summer", "remmuS")]
        public void Test_GetReversed(string line, string res)
        {
            Assert.Equal(res, line.GetReversed());
        }

        [Theory]
        [InlineData("Get Schwifty", "gET sCHWIFTY")]
        public void Test_InverseCase(string line, string res)
        {
            Assert.Equal(res, line.InverseCase());
        }

        [Theory]
        [InlineData("Mr. Meeseeks", "Ns/!Nfftfflt")]
        public void Test_ShiftInc(string line, string res)
        {
            Assert.Equal(res, line.ShiftInc());
        }

        [Theory]
        [InlineData("Dimension C-0000:0089 is one of the many universes /*in the " +
                    "multiverse*/ and the universe where the mainstream Rick and Morty " +
                    "//are often identified as coming from 0000:0089.", 
                    new long[] {137L})]
        public void Test_GetUsedObjects(string line, long[] res)
        {
            Assert.Equal(res, line.GetUsedObjects());
        }
    }
}
