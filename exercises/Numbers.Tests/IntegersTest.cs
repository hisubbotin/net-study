using System;
using Xunit;

namespace Numbers.Tests
{
    public class IntegersTest
    {
        [Fact]
        public void Test_HalfIntMaxValue()
        {
            var x = Integers.HalfIntMaxValue();
            Assert.Equal(x, int.MaxValue / 2);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-10)]
        [InlineData(-1)]
        public void Test_Cube(int x)
        {
            Assert.Equal(Integers.Cube(x), x * x * x);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-10)]
        [InlineData(-1)]
        public void Test_CubeWithOverflowCheck_WithoutOverflow(int x)
        {
            Assert.Equal(Integers.CubeWithOverflowCheck(x), x * x * x);
        }

        [Theory]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue/2)]
        public void Test_CubeWithOverflowCheck_WithOverflowReturnArithmeticOverflowException(int x)
        {
            Assert.Throws<OverflowException>(() => Integers.CubeWithOverflowCheck(x));
        }
        
        [Theory]
        [InlineData(10)]
        [InlineData(-10)]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue / 2)]
        public void Test_CubeWithoutOverflowCheck_ShouldNotThrow(int x)
        {
            Assert.Equal(Integers.CubeWithoutOverflowCheck(x), x * x * x);
        }
    }
}
