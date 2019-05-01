using System;
using Xunit;

namespace WubbaLubbaDubDub.Tests
{
    public class RicksMercilessEncryptorTests
    {
        [Theory]
        [InlineData("first 2\nthird 3\n", new [] {"first 2", "third 3", ""})]
        public void SplitToLinesTest(string test, string[] result)
        {
            Assert.Equal(result, test.SplitToLines());
        }
        
        [Theory]
        [InlineData("1 223 344iu4o           jhjkggfsr", new [] {"1", "223", "344iu4o", "jhjkggfsr"})]
        public void SplitToWordsTest(string test, string[] result)
        {
            Assert.Equal(result, test.SplitToWords());
        }
        
        [Theory]
        [InlineData("1234", "12")]
        [InlineData("12345", "12")]
        public void GetLeftHalfTest(string test, string result)
        {
            Assert.Equal(result, test.GetLeftHalf());
        }
        
        [Theory]
        [InlineData("1234", "34")]
        [InlineData("12345", "345")]
        public void GetRightHalfTest(string test, string result)
        {
            Assert.Equal(result, test.GetRightHalf());
        }
        
        [Theory]
        [InlineData("223", "1", "0", "223")]
        [InlineData("224", "4", "5", "225")]
        [InlineData("123", "123", "", "")]
        public void ReplaceTest(string test, string old, string @new, string result)
        {
            Assert.Equal(result, test.Replace(old, @new));
        }
        
        [Theory]
        [InlineData("c# is good", @"\u0063\u0023\u0020\u0069\u0073\u0020\u0067\u006F\u006F\u0064")]
        public void CharsToCodesTest(string test, string result)
        {
            Assert.Equal(result, test.CharsToCodes());
        }
        
        [Theory]
        [InlineData("1234 5 \n 7 \n", "\n 7 \n 5 4321")]
        public void GetReversedTest(string test, string result)
        {
            Assert.Equal(result, test.GetReversed());
        }
        
        [Theory]
        [InlineData("1", "1")]
        [InlineData("abc ABC", "ABC abc")]
        public void InverseCaseTest(string test, string result)
        {
            Assert.Equal(result, test.InverseCase());
        }
        
        [Theory]
        [InlineData("1", "2")]
        [InlineData("abcABC123", "bcdBCD234")]
        public void ShiftIncTest(string test, string result)
        {
            Assert.Equal(result, test.ShiftInc());
        }
        
        [Theory]
        [InlineData("", new long[]{})]
        [InlineData("00000000:0000000D ffe 10010001:10000001", new[]{13L, 0x1001000110000001L})]
        [InlineData("/* 00000000:00000000 \n skfjfkj */  00000000:0000000A", new[]{10L})]
        [InlineData("// 00000000:00000000 \n 00000000:00000001", new[]{1L})]
        public void GetUsedObjectsTest(string test, long[] result)
        {
            Assert.Equal(result, test.GetUsedObjects());
        }
    }
}
