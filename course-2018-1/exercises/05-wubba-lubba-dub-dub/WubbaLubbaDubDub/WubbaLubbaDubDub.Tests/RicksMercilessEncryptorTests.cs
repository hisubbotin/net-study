using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Rick and morty\n \\wadventure time\n\\n"
            , new[] { "Rick and morty", " \\wadventure time", "\\n" })]
        [InlineData("Rick and morty\r\nadventure\\w\r\ntime\n"
            , new[] { "Rick and morty\r", "adventure\\w\r", "time", "" })]
        public void TestSplitToLines(string text, string[] result)
        {
            Assert.Equal(result, text.SplitToLines());
        }

        [Theory]
        [InlineData("Rick and morty\nadventure\n\ntime\n\n \n"
            , new[] { "Rick", "and", "morty", "adventure", "time" })]
        [InlineData("Rick and\r\nmorty adventure\rtime\n    "
            , new[] { "Rick", "and", "morty", "adventure", "time" })]
        [InlineData("Rick! and morty? adventure, ,,,,\t time,   eeee. !!???\t\t\n"
            , new[] { "Rick", "and", "morty", "adventure", "time", "eeee" })]
        public void TestSplitToWords(string text, string[] result)
        {
            Assert.Equal(result, text.SplitToWords());
        }

        [Theory]
        [InlineData("aaaabbbbb", "aaaa")]
        [InlineData("", "")]
        [InlineData("bbbbcccc", "bbbb")]
        public void TestGetLeftHalf(string text, string result)
        {
            Assert.Equal(result, text.GetLeftHalf());
        }

        [Theory]
        [InlineData("aaaabbbbb", "bbbbb")]
        [InlineData("", "")]
        [InlineData("bbbbcccc", "cccc")]
        public void TestGetRightHalf(string text, string result)
        {
            Assert.Equal(result, text.GetRightHalf());
        }

        [Theory]
        [InlineData("Rick \nand morty\n morty time! morty", "morty", "adventure"
            , "Rick \nand adventure\n adventure time! adventure")]
        [InlineData("Rick\rand\r\nmorty \radventure\t\r\ntime", "\r", "\n"
            , "Rick\nand\n\nmorty \nadventure\t\n\ntime")]
        public void TestReplace(string text, string old, string @new, string result)
        {
            Assert.Equal(result, RicksMercilessEncryptor.Replace(text, old, @new));
        }

        [Theory]
        [InlineData("Text", @"\u0054\u0065\u0078\u0074")]
        [InlineData("", "")]
        [InlineData("123457", @"\u0031\u0032\u0033\u0034\u0035\u0037")]
        public void TestCharsToCodes(string text, string result)
        {
            Assert.Equal(result, text.CharsToCodes());
        }

        [Theory]
        [InlineData("12345", "54321")]
        [InlineData("", "")]
        [InlineData("argentina manit negra", "argen tinam anitnegra")]
        public void TestGetReversed(string text, string result)
        {
            Assert.Equal(result, text.GetReversed());
        }

        [Theory]
        [InlineData("RIck aNd\t\r \nMorTY\t adven\tURE \r\r\nTime", 
            "riCK AnD\t\r \nmORty\t ADVEN\ture \r\r\ntIME")]
        [InlineData("", "")]
        [InlineData("EYSYYSYENSnnnnnASNSNSANnnsanASNns", "eysyysyensNNNNNasnsnsanNNSANasnNS")]
        public void TestInverseCase(string text, string result)
        {
            Assert.Equal(result, text.InverseCase());
        }

        [Theory]
        [InlineData("abacaba1234", "bcbdbcb2345")]
        [InlineData("\u0000\u1111", "\u0001\u1112")]
        public void TestShiftInc(string text, string result)
        {
            Assert.Equal(result, text.ShiftInc());
        }

        [Theory]
        [InlineData("0000:0001, // comment 1111:1111\n /* another one 12AF:1AB2*/"
            , new[] { 1L })]
        [InlineData("asd bqwd asd 0001:0000 /*1123:1231\n//1234:1234\n*/"
            , new[] { 65536L })]
        public void TestGetUsedObjects(string text, long[] result)
        {
            Assert.Equal(result, text.GetUsedObjects());
        }
    }
}
