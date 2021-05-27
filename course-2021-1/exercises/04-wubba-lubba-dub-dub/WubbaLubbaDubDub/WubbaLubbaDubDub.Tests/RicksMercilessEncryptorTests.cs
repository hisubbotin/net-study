using System;
using System.Collections.Immutable;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("Простой текст", new []{"Простой текст"})]
        [InlineData("Текст, разделенный\nпереводами\nстроки.", new[]{"Текст, разделенный", "переводами", "строки."})]
        public void Test_SplitToLines_ReturnsCorrectValue(string text, string[] expectedLines)
        {
            Assert.Equal(expectedLines, text.SplitToLines());
        }
        
        [Theory]
        [InlineData("Простой текст", new []{"Простой", "текст"})]
        [InlineData("  , .\r\nТекст,\t с 15:  ..разными\n\n\t\t:;' символами!?\t\t \r\n", new[]{"Текст", "с", "15", "разными", "символами"})]
        public void Test_SplitToWords_ReturnsCorrectValue(string line, string[] expectedWords)
        {
            Assert.Equal(expectedWords, line.SplitToWords());
        }
        
        [Theory]
        [InlineData("", "")]
        [InlineData("а", "")]
        [InlineData("аб", "а")]
        [InlineData("строка", "стр")]
        [InlineData("строчка", "стр")]
        public void Test_GetLeftHalf_ReturnsCorrectValue(string s, string expectedLeftHalf)
        {
            Assert.Equal(expectedLeftHalf, s.GetLeftHalf());
        }
        
        [Theory]
        [InlineData("", "")]
        [InlineData("строка", "ока")]
        [InlineData("строчка", "очка")]
        public void Test_GetRightHalf_ReturnsCorrectValue(string s, string expectedRightHalf)
        {
            Assert.Equal(expectedRightHalf, s.GetRightHalf());
        }
        
        [Theory]
        [InlineData("один одиннадцать", "один", "три", "три тринадцать")]
        [InlineData("строка как строка", "строка", "текст", "текст как текст")]
        public void Test_Replace_ReturnsCorrectValue(string s, string old, string @new, string expected)
        {
            Assert.Equal(expected, RicksMercilessEncryptor.Replace(s, old, @new));
        }

        [Theory]
        [InlineData("Слово", @"\u0421\u043B\u043E\u0432\u043E")]
        [InlineData("français", @"\u0066\u0072\u0061\u006E\u00E7\u0061\u0069\u0073")]
        public void Test_CharsToCodes_ReturnsCorrectValue(string chars, string expectedCodes)
        {
            Assert.Equal(expectedCodes, chars.CharsToCodes());
        }

        [Theory]
        [InlineData("Слово", "оволС")]
        [InlineData("français", "siaçnarf")]
        public void Test_GetReversed_ReturnsCorrectValue(string value, string expectedReversed)
        {
            Assert.Equal(expectedReversed, value.GetReversed());
        }
        
        [Theory]
        [InlineData("СлОвЕчКо", "сЛоВеЧкО")]
        [InlineData("français", "FRANÇAIS")]
        [InlineData("2021 год", "2021 ГОД")]
        public void Test_InverseCase_ReturnsCorrectValue(string value, string expectedInversed)
        {
            Assert.Equal(expectedInversed, value.InverseCase());
        }
        
        [Theory]
        [InlineData("абвгддд", "бвгдеее")]
        [InlineData("français", "gsboèbjt")]
        public void Test_ShiftInc_ReturnsCorrectValue(string value, string expectedShifted)
        {
            Assert.Equal(expectedShifted, value.ShiftInc());
        } 
        
        [Theory]
        [InlineData("траляля 0001:0000 /*12 1234:56AF*/", new []{65536L})]
        [InlineData("//1234:56AF\n 0000:0012 //AAAA:AAAA\n /* 2314:ABCD*/", new []{18L})]
        public void Test_GetUsedObjects_ReturnsCorrectValue(string value, long[] expectedObjects)
        {
            Assert.Equal(ImmutableArray.Create(expectedObjects), value.GetUsedObjects());
        } 
    }
}