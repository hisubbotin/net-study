using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("abc\ncsa\n4534\n354534")]
        public void Test_SplitToLines(string text)
        {
            Assert.Equal("4534", text.SplitToLines()[2]);
        }

        [Theory]
        [InlineData(
            "ask mask ilon!",
            new string[] { "ask", "mask", "ilon" }
        )]
        public void Test_SplitToWords(string line, string[] result)
        {
            Assert.Equal(result, line.SplitToWords());
        }

        [Theory]
        [InlineData(
            "aaabb",
            "aa"
        )]
        public void Test_GetLeftHalf(string line, string result)
        {
            Assert.Equal(result, line.GetLeftHalf());
        }

        [Theory]
        [InlineData(
            "aabbb",
            "bbb"
        )]
        public void Test_GetRightHalf(string line, string result)
        {
            Assert.Equal(result, line.GetRightHalf());
        }

        [Theory]
        [InlineData(
            "kakadu",
            "ka",
            "du-",
            "du-du-du"
        )]
        public void Test_Replace(string line, string old, string replaceWith, string result)
        {
            Assert.Equal(result, RicksMercilessEncryptor.Replace(line, old, replaceWith));
        }

        [Theory]
        [InlineData(
            "DuDu",
            "\\u0044\\u0075\\u0044\\u0075"
        )]
        public void Test_CharsToCodes(string line, string result)
        {
            Assert.Equal(result, line.CharsToCodes());
        }

        [Theory]
        [InlineData(
            "du-du-du",
            "ud-ud-ud"
        )]
        public void Test_GetReversed(string line, string result)
        {
            Assert.Equal(result, line.GetReversed());
        }

        [Theory]
        [InlineData(
            "AAzzBv",
            "aaZZbV"
        )]
        public void Test_InverseCase(string line, string result)
        {
            Assert.Equal(result, line.InverseCase());
        }

        [Theory]
        [InlineData(
            "abcde",
            "bcdef"
        )]
        public void Test_ShiftInc(string line, string result)
        {
            Assert.Equal(result, line.ShiftWord());
        }

        [Theory]
        [InlineData("//fdsfdsfdsfds \n /* yyyyyyyyyyy \n ggggggggggggg AAAA:5555 \n */ F0BE:01A0",
            new[] { 4038984096L })]
        public void Test_GetUsedObjects(string text, long[] result)
        {
            Assert.Equal(result, text.GetUsedObjects());
        }

    }
}
