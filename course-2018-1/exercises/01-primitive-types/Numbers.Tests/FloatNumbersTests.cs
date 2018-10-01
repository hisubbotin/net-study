using System;
using Xunit;

namespace Numbers.Tests
{
    public class FloatNumbersTests
    {
        [Theory]
        [InlineData(0.0, false)]
        [InlineData(12313.0, false)]
        [InlineData(1e-12, false)]
        [InlineData(double.PositiveInfinity, false)]
        [InlineData(double.MinValue, false)]
        [InlineData(double.NaN, true)]
        public void Test_IsNaN_ReturnsCorrectValue(double x, bool isNaN)
        {
            Assert.Equal(FloatNumbers.IsNaN(x), isNaN);
        }

        [Fact]
        public void Test_GetNaN_IsNaNOfGetNaNReturnsTrue()
        {
            Assert.True(FloatNumbers.IsNaN(FloatNumbers.GetNaN()));
        }

        [Theory]
        [InlineData(0.0, 0.0, 0.01, 0)]
        [InlineData(1.0, 0.0, 0.01, 1)]
        [InlineData(0.0, 0.001, 0.01, 0)]
        [InlineData(0.0, 0.01, 0.001, -1)]
        public void Test_Compare_ComparesCorrectly(double x, double y, double tol, int result)
        {
            Assert.Equal(result, FloatNumbers.Compare(x, y, tol));
        }
    }
}
