using System;
using Xunit;

namespace BoringVector.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(-1, 0, 1)]
        [InlineData(0.2, -0.3, 0.13)]
        public void SquareLength(double x, double y, double expected)
        {
            Assert.Equal(new Vector(x, y).SquareLength(), expected);
        }
        
        [Theory]
        [InlineData(0, 1, 1, 0, 1, 1)]
        [InlineData(1.2, 1.2, -1.2, -1.2, 0, 0 )]
        [InlineData(1.2, -3.4, 5.6, -7.8, 6.8, -11.2)]
        public void Add(double firstTermX, double firstTermY, double secondTermX, double secondTermY, double expectedSumX, double expectedSumY)
        {
            var actual = new Vector(firstTermX, firstTermY).Add(new Vector(secondTermX, secondTermY));
            Assert.Equal(actual.X, expectedSumX);
            Assert.Equal(actual.Y, expectedSumY);
        }
        
        [Theory]
        [InlineData(0, 0, 1, 0, 0)]
        [InlineData(1, 1, 1.5, 1.5, 1.5)]
        [InlineData(1, -1, -1, -1, 1)]
        [InlineData(1.2, -3.4, 5.6, 6.72, -19.04)]
        public void Scale(double x, double y, double scale, double expectedScaledX, double expectedScaledY)
        {
            var actual = new Vector(x, y).Scale(scale);
            Assert.Equal(actual.X, expectedScaledX);
            Assert.Equal(actual.Y, expectedScaledY);
        }
        
        [Theory]
        [InlineData(1, 2, 3, 4, 11)]
        [InlineData(0, 0, 1000, -1000, 0)]
        [InlineData(0, 1000000, 1000000, 0, 0)]
        [InlineData(1, 100, -100, 1, 0)]
        [InlineData(12.3, -45.6, 78.9,-1011.12, 47077.542)]
        public void DotProduct(double firstTermX, double firstTermY, double secondTermX, double secondTermY,
            double expected)
        {
            var actual = new Vector(firstTermX, firstTermY).DotProduct(new Vector(secondTermX, secondTermY));
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(1, 2, 3, 4, -2)]
        [InlineData(0, 0, 1000, -1000, 0)]
        [InlineData(0, 1000000, 1000000, 0, -1000000000000)]
        [InlineData(1, 100, -100, 1, 10001)]
        [InlineData(-100, 1, 1, 100, -10001)]
        [InlineData(12.3, -45.6, 78.9, -1011.12, -8838.936)]
        public void CrossProduct(double firstTermX, double firstTermY, double secondTermX, double secondTermY,
            double expected)
        {
            var actual = new Vector(firstTermX, firstTermY).CrossProduct(new Vector(secondTermX, secondTermY));
            Assert.True(Math.Abs(expected - actual) < 0.00001);
        }
    }
}