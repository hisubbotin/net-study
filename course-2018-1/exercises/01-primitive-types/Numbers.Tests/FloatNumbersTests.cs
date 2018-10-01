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

        
        [Theory]
        [InlineData(3.1, 3.15, 0.1, 0)]
        [InlineData(3.1, 3.15, 0.01, -1)]
        [InlineData(3.15, 3.10, 0.01, 1)]
        [InlineData(-3.1, -3.15, 0.01, 1)]
        public void Test_Compare_ReturnsCorrectValue(double d1, double d2, double eps, int compRes)
        {
            Assert.Equal(FloatNumbers.Compare(d1, d2, eps), compRes);
        }
        
        
        [Fact]
        public void Test_GetNaN_IsNaNOfGetNaNReturnsTrue()
        {
            Assert.True(FloatNumbers.IsNaN(FloatNumbers.GetNaN()));
        }
    }
}
