using System;
using Xunit;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Immutable;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("You are the sun,\nYou are the only one,\nMy heart is blue,\nMy heart is blue for you",
            new[] { "You are the sun,", "You are the only one,", "My heart is blue,", "My heart is blue for you" })]
        public void TestSplitToLines(string line, string[] result)
        {
            Assert.Equal(result, line.SplitToLines());
        }
        
        [Theory]
        [InlineData("Be my, be my, be my little queen!",
            new[] { "Be", "my", "be", "my", "be", "my", "little", "queen" })]
        public void TestSplitToWords(string line, string[] result)
        {
            Assert.Equal(result, line.SplitToWords());
        }

        [Theory]
        [InlineData("little", "lit")]
        [InlineData("litttle", "lit")]
        public void TestGetLeftHalf(string line, string result)
        {
            Assert.Equal(result, line.GetLeftHalf());
        }

        [Theory]
        [InlineData("little", "tle")]
        [InlineData("litttle", "ttle")]
        public void TestGetRightHalf(string line, string result)
        {
            Assert.Equal(result, line.GetRightHalf());
        }
        
        [Theory]
        [InlineData("Thesun", "sun", "one", "Theone")]
        public void TestReplace(string line, string old, string @new, string result)
        {
            Assert.Equal(result, line.Replace(old, @new));
        }

        [Theory]
        [InlineData("HI", "\\u0048\\u0049")]
        public void TestCharsToCodes(string s, string result)
        {
            Assert.Equal(result, s.CharsToCodes());
        }

        [Theory]
        [InlineData("cool", "looc")]
        public void TestGetReversed(string line, string result)
        {
            Assert.Equal(result, line.GetReversed());
        }
        [Theory]
        [InlineData("Thesun", "tHESUN")]
        public void TestInverseCase(string line, string result)
        {
            Assert.Equal(result, line.InverseCase());
        }
        [Theory]
        [InlineData("ABC", "BCD")]
        public void TestShiftInc(string line, string result)
        {
            Assert.Equal(result, line.ShiftInc());
        }
        
        [Theory]
        [InlineData("Be my, be my, be my little Rock'n'Roll queen! \n /* СССС:5555 */ BBBB:4444", new[] { 3149612100L })]
        public void TestGetUsedObject(string line, long[] result)
        {
            Assert.Equal(result, line.GetUsedObjects());
        }
    }
}
