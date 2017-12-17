using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Lets pretend we are dancing in the street in Barselona",
            new[] { "Lets", "pretend", "we", "are", "dancing", "in", "the",  "street", "in", "Barselona" })]
        public void TestSplitToWords(string line, string[] result)
        {
            Assert.Equal(result, line.SplitToWords());
        }
        [Theory]
        [InlineData("Lets pretend we are dancing in the street \n in Barselona \n Barseloona \n Barseloona",
            new[] { "Lets pretend we are dancing in the street ", " in Barselona ", " Barseloona ", " Barseloona" })]
        public void TestSplitToLines(string line, string[] result)
        {
            Assert.Equal(result, line.SplitToLines());
        }
        [Theory]
        [InlineData("Barseloona", "Barse")]
        [InlineData("Barselooona", "Barse")]
        public void TestGetLeftHalf(string line, string result)
        {
            Assert.Equal(result, line.GetLeftHalf());
        }
        [Theory]
        [InlineData("Barseloona", "loona")]
        [InlineData("Barselooona", "looona")]
        public void TestGetRightHalf(string line, string result)
        {
            Assert.Equal(result, line.GetRightHalf());
        }
        [Theory]
        [InlineData("Barseloona", "sel", "les", "Barlesoona")]
        public void TestReplace(string line, string old, string @new, string result)
        {
            Assert.Equal(result, line.Replace(old, @new));
        }
        [Theory]
        [InlineData("Barseloona", "anoolesraB")]
        public void TestGetReversed(string line, string result)
        {
            Assert.Equal(result, line.GetReversed());
        }
        [Theory]
        [InlineData("Barseloona", "bARSELOONA")]
        public void TestInverseCase(string line, string result)
        {
            Assert.Equal(result, line.InverseCase());
        }
        [Theory]
        [InlineData("Barseloona", "Cbstfmppob")]
        public void TestShiftInc(string line, string result)
        {
            Assert.Equal(result, line.ShiftInc());
        }
        [Theory]
        [InlineData("//Barselooona \n /* dfjhdk \n skjfhk AAAA:5555 \n */ BBBB:4444", new[] { 3149612100L })]
        public void TestGetUsedObject(string line, long[] result)
        {
            Assert.Equal(result, line.GetUsedObjects());
        }
    }
}
