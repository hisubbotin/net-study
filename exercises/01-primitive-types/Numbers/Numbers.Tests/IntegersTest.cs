using System;
using Xunit;

namespace Numbers.Tests
{
    public class IntegersTest
    {
        [Fact]
        public void Test_HalfIntMaxValue()
        {
            Assert.Equal(Integers.HalfIntMaxValue(), 1073741823);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-10)]
        [InlineData(-1)]
        public void Test_Cube_ReturnsCorrectValue(int x)
        {
            Assert.Equal(Integers.Cube(x), x * x * x);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-10)]
        [InlineData(-1)]
        public void Test_CubeWithOverflowCheck_ReturnsCorrectValue(int x)
        {
            Assert.Equal(Integers.CubeWithOverflowCheck(x), x * x * x);
        }

        [Theory]
        [InlineData(2147483646)]
        [InlineData(-1073741824)]
        public void Test_CubeWithOverflowCheck_ThrowsArithmeticOverflowException(int x)
        {
            Assert.Throws<OverflowException>(() => Integers.CubeWithOverflowCheck(x));
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-10)]
        [InlineData(-1)]
        public void Test_CubeWithoutOverflowCheck_ReturnsCorrectValue(int x)
        {
            Assert.Equal(Integers.CubeWithoutOverflowCheck(x), x * x * x);
        }

        [Theory]
        [InlineData(2147483646)]
        [InlineData(-1073741824)]
        public void Test_CubeWithoutOverflowCheck_ShouldNotThrow(int x)
        {
            Assert.Equal(Integers.CubeWithoutOverflowCheck(x), x * x * x);
        }

        [Theory]
        [InlineData(0, "0")]
        [InlineData(-123456, "-123456")]
        [InlineData(123456789, "123456789")]
        [InlineData(10.123, "10")]
        public void Test_ToString_ShouldReturnCorrectValue(int x, string xStr)
        {
            Assert.Equal(Integers.ToString(x), xStr);
        }

        [Theory]
        [InlineData("0", 0)]
        [InlineData("-123456", -123456)]
        [InlineData("123456789", 123456789)]
        public void Test_Parse_ShouldReturnCorrectValue(string xStr, int x)
        {
            Assert.Equal(Integers.Parse(xStr), x);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 10)]
        [InlineData(-5, -50)]
        public void Test_TenTimes_ShouldReturnCorrectValue(int x, int tenTimesX)
        {
            Assert.Equal(Integers.TenTimes(x), tenTimesX);
        }

        [Theory]
        [InlineData(0, "0")]
        [InlineData(1, "1")]
        [InlineData(14, "E")]
        [InlineData(12315, "301B")]
        [InlineData(-289823, "FFFB93E1")]
        public void Test_ToHexString_ShouldReturnCorrectValue(int x, string xHexStr)
        {
            Assert.Equal(Integers.ToHexString(x), xHexStr, ignoreCase: true);
        }
    }
}
