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
    }
}
