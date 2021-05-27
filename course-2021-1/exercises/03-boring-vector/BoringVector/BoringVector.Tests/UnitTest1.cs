using System;
using Xunit;

namespace BoringVector.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(3, 4, 25)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 1, 2)]
        public void Test_SquareLength(double x, double y, double z)
        {
            Assert.Equal(new Vector(x, y).SquareLength(), z);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(3, 4, 25, 123)]
        [InlineData(0, 1, 1, 10)]
        [InlineData(1, 5, 1, 2)]
        public void Test_Add(double x, double y, double a, double b)
        {
            var tmp = new Vector(x, y).Add(new Vector(a, b));
            Assert.Equal(x + a, tmp.X);
            Assert.Equal(y + b, tmp.Y);
        }

        [Theory]
        [InlineData(0, 5, 0)]
        [InlineData(4, 25, 123)]
        [InlineData(1, 1, 10)]
        [InlineData(5, 1, 2)]
        public void Test_Scale(double x, double y, double k)
        {
            var tmp = new Vector(x, y).Scale(k);
            Assert.Equal(x * k, tmp.X);
            Assert.Equal(y * k, tmp.Y);
        }
    }
}
