using System;
using System.Linq;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Fact]
        public void Test_SplitToLines()
        {
            const string s = "1 2\r\n3 \n4 5";
            var splitted = s.SplitToLines();
            Assert.Equal(new [] {"1 2", "3 ", "4 5"}, splitted);
        }

        [Fact]
        public void Test_SplitToWords()
        {
            const string s = " hello world,I -- love  dotnet!";
            var splitted = s.SplitToWords();
            Assert.Equal(new [] {"hello", "world", "I", "love", "dotnet"}, splitted);
        }

        [Theory]
        [InlineData("1234", "12")]
        [InlineData("1234567", "123")]
        [InlineData("", "")]
        public void Test_GetLeftHalf(string s, string half)
        {
            Assert.Equal(half, s.GetLeftHalf());
        }
        
        [Theory]
        [InlineData("1234", "34")]
        [InlineData("1234567", "4567")]
        [InlineData("", "")]
        public void Test_GetRightHalf(string s, string half)
        {
            Assert.Equal(half, s.GetRightHalf());
        }

        [Theory]
        [InlineData("12345", "34", "6", "1265")]
        [InlineData("12345", "43", "6", "12345")]
        [InlineData("123123", "12", "678", "67836783")]
        public void Test_Replace(string s, string old, string @new, string result)
        {
            // Тут тестируется не наш метод, а встроенный, но что поделать
            Assert.Equal(result, s.Replace(old, @new));
        }

        [Theory]
        [InlineData("123", @"\u0031\u0032\u0033")]
        [InlineData("ы", @"\u044B")]
        [InlineData("\uBEEF", @"\uBEEF")]
        public void Test_CharsToCodes(string s, string result)
        {
            Assert.Equal(result, s.CharsToCodes());
        }
        
        [Theory]
        [InlineData("123", "321")]
        [InlineData("вася", "ясав")]
        public void Test_GetReversed(string s, string result)
        {
            Assert.Equal(result, s.GetReversed());
        }
        
        [Theory]
        [InlineData("ВасяAbbyy123", "вАСЯaBBYY123")]
        public void Test_InverseCase(string s, string result)
        {
            Assert.Equal(result, s.InverseCase());
        }
        
        [Theory]
        [InlineData("123", "234")]
        [InlineData("Василий5", "Гбтймйк6")]
        public void Test_ShiftInc(string s, string result)
        {
            Assert.Equal(result, s.ShiftInc());
        }

        [Theory]
        [InlineData("", new long[]{})]
        [InlineData("00000000:0000000F 10000001:10000001", new[]{15L, 0x1000000110000001L})]
        [InlineData("/* 00000000:00000000 \n 00000000:00000001 */  00000000:00000002", new[]{2L})]
        [InlineData("// 00000000:00000000 \n 00000000:00000001", new[]{1L})]
        [InlineData("// /*00000000:00000000 \n 00000000:00000001*/", new[]{1L})]
        [InlineData("/* // */ 00000000:00000000", new[]{0L})]
        public void Test_GetUsedObjects(string s, long[] uids)
        {
            Assert.Equal(s.GetUsedObjects(), uids);
        }
    }
}
