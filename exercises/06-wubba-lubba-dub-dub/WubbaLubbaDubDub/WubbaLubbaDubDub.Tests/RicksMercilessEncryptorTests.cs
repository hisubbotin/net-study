using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Give the benefit of the doubt",
 new[] { "Give", "the", "benefit", "of", "the", "doubt" })]
         public void TestSplitToWords(string line, string[] result)
         {
             Assert.Equal(result, line.SplitToWords());
         }
         [Theory]
         [InlineData("Give the benefit of the doubt \n benefit of the doubt \n of the doubt \n doubt",
 new[] { "Give the benefit of the doubt ", " benefit of the doubt ", " of the doubt ", " doubt" })]
         public void TestSplitToLines(string line, string[] result)
         {
             Assert.Equal(result, line.SplitToLines());
         }
         [Theory]
         [InlineData("Give", "Gi")]
         [InlineData("doubt", "do")]
         public void TestGetLeftHalf(string line, string result)
         {
             Assert.Equal(result, line.GetLeftHalf());
         }
         [Theory]
         [InlineData("Give", "ve")]
         [InlineData("doubt", "ubt")]
         public void TestGetRightHalf(string line, string result)
         {
             Assert.Equal(result, line.GetRightHalf());
         }
         [Theory]
         [InlineData("Givethebenefit", "the", "eht", "Giveehtbenefit")]
         public void TestReplace(string line, string old, string @new, string result)
         {
             Assert.Equal(result, line.Replace(old, @new));
         }
         [Theory]
         [InlineData("AbbbaaaaB", "BaaaabbbA")]
         public void TestGetReversed(string line, string result)
         {
             Assert.Equal(result, line.GetReversed());
         }
         [Theory]
         [InlineData("doubT", "DOUBt")]
         public void TestInverseCase(string line, string result)
         {
             Assert.Equal(result, line.InverseCase());
         }
         [Theory]
         [InlineData("abce12", "bcdf23")]
         public void TestShiftInc(string line, string result)
         {
             Assert.Equal(result, line.ShiftInc());
         }

        [Theory]
        [InlineData("//InterestingText \n /* letters \n moreLetters KKPO:5151 \n */ BBBB:4444", new[] { 3149612100L })]
        public void TestGetUsedObject(string someText, long[] answer)
        {
            Assert.Equal(answer, someText.GetUsedObjects());
        }
    }
}
