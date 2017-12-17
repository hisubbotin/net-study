using System.IO;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {

        [Theory]
        [InlineData("1\n1\n1\n1\n1\n1\n1\n1\n1\n1")]
        public void Test_SplitToLines(string text)
        {
            Assert.Equal(10, text.SplitToLines().Length);
        }

        [Theory]
        [InlineData(
            "Мама давно... хотела помыть раму!",
            new string[] { "Мама", "давно", "хотела", "помыть", "раму" }
        )]
        public void Test_SplitToWords(string line, string[] result)
        {
            Assert.Equal(result, line.SplitToWords());
        }

        [Theory]
        [InlineData(
            "qwertyuiop",
            "qwert"
        )]
        public void Test_GetLeftHalf(string line, string result)
        {
            Assert.Equal(result, line.GetLeftHalf());
        }

        [Theory]
        [InlineData(
            "qwertyuiop",
            "yuiop"
        )]
        public void Test_GetRightHalf(string line, string result)
        {
            Assert.Equal(result, line.GetRightHalf());
        }

        [Theory]
        [InlineData(
            "Зуфар",
            "уф",
            "ах",
            "Захар"
        )]
        public void Test_Replace(string line, string old, string replaceWith, string result)
        {
            Assert.Equal(result, RicksMercilessEncryptor.Replace(line, old, replaceWith));
        }

        [Theory]
        [InlineData(
            "WubbaLubbaDubDub",
            "\\u0057\\u0075\\u0062\\u0062\\u0061\\u004C\\u0075\\u0062\\u0062\\u0061\\u0044\\u0075\\u0062\\u0044\\u0075\\u0062"
        )]
        public void Test_CharsToCodes(string line, string result)
        {
            Assert.Equal(result, line.CharsToCodes());
        }

        [Theory]
        [InlineData(
            "WubbaLubbaDubDub",
            "buDbuDabbuLabbuW"
        )]
        public void Test_GetReversed(string line, string result)
        {
            Assert.Equal(result, line.GetReversed());
        }

        [Theory]
        [InlineData(
            "AAaaAAbbCC",
            "aaAAaaBBcc"
        )]
        [InlineData(
            "11aaAAbbCC",
            "11AAaaBBcc"
        )]
        public void Test_InverseCase(string line, string result)
        {
            Assert.Equal(result, line.InverseCase());
        }

        [Theory]
        [InlineData(
            "abce 43",
            "bcdf!54"
        )]
        public void Test_ShiftInc(string line, string result)
        {
            Assert.Equal(result, line.ShiftInc());
        }

        [Theory]
        [InlineData(
            "F0BE:01A0 // 4038984096\nThe side bar includes a Cheatsheet, " +
            "full Reference, and Help. You can also Save & Share your \n/*expressions" + 
            " with the Community, and mark Favourites.\nF0AE:00A0\n*/"
        )]
        public void Test_GetUsedObjects(string text)
        {
            Assert.Equal(new long[] { 4038984096L }, text.GetUsedObjects());
        }
    }
}
