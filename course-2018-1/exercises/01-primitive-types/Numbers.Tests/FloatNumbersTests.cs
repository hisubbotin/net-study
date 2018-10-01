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
        [InlineData(0.5, 0.49999, 0.001, 0)]
        [InlineData(0.5, 0.48999, 0.001, 1)]
        [InlineData(0.5, 0.51, 0.001, -1)]
        public void Test_Compare_Returns_Equal(double a, double b, double eps, int equal)
        {
            Assert.Equal(FloatNumbers.Compare(a, b, eps), equal);
        }
        
        [Fact]
        public void Test_GetNaN_IsNaNOfGetNaNReturnsTrue()
        {
            Assert.True(FloatNumbers.IsNaN(FloatNumbers.GetNaN()));
        }      
    }
}
