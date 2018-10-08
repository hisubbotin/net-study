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
        [InlineData(0.1, 0.1)]
        [InlineData(0.1 + 0.2, 0.3)]
        [InlineData(0.000000000000001, 0)]
        public void Test_Compare_ReturnsEqual(double number1, double number2)
        {
            Assert.Equal(FloatNumbers.Compare(number1, number2), 0);
        }
        
        [Theory]
        [InlineData(0.2, 0.3)]
        [InlineData(0.00001, 0)]
        public void Test_Compare_ReturnsLess(double number1, double number2)
        {
            Assert.Equal(FloatNumbers.Compare(number1, number2), 0);
        }
    }
}
