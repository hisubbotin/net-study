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
        [InlineData(1.0, 1.0000000001, 0)]
        [InlineData(1.0, 2.0, -1)]
        [InlineData(2.0, 1.0, 1)]
        public void Test_Compare(double a, double b, int result)
        {
            Assert.Equal(FloatNumbers.Compare(a, b), result);
        }
    }
}
