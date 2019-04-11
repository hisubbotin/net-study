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
        [InlineData(0.5, 0.6, -1)]
        [InlineData(double.MaxValue, double.MinValue, 1)]
        [InlineData(0.5, 0.5, 0)]
        [InlineData(1e-12, 2e-12, 0)]
        [InlineData(0.1, 0.1 + 5e-8, 0)]
        [InlineData(0.1, 0.1 + 1e-7, -1)]
        public void Test_Compare_WorksCorrectly(double first, double second, int result)
        {
            Assert.Equal(FloatNumbers.Compare(first, second), result);
        }
    }
}
