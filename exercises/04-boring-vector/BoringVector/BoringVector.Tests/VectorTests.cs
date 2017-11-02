using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTests
    {
        [Fact]
        public void Test_ZeroVector()
        {
            Assert.True(new Vector(0.0, 0.0).IsZero());
            Assert.False(new Vector(0.0, 0.2).IsZero());
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 0, 5)]
        [InlineData(0, 1, 2)]
        [InlineData(0.3, -4.6, 0.7)]
        public void Test_VectorScale(double x, double y, double mul)
        {
            Vector first = new Vector(x, y);
            Assert.Equal(first.SquareLength(), x * x + y * y, 10);
            Vector result = first.Scale(mul);
            Assert.Equal(first.SquareLength() * mul * mul, result.SquareLength(), 10);
            Assert.Equal(result.X, x * mul, 10);
            Assert.Equal(result.Y, y * mul, 10);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(0, 0, 1, 0)]
        [InlineData(0.3, 0.6, 1.2, -0.2)]
        [InlineData(0, 0, -2, 4)]
        public void Test_VectorBinary(double x1, double x2, double y1, double y2)
        {
            Vector a = new Vector(x1, y1);
            Vector b = new Vector(x2, y2);
            Assert.True(a.Add(a.Scale(-1)).IsZero());
            Vector sum = a.Add(b);
            Assert.Equal(sum.X, a.X + b.X, 10);
            Assert.Equal(sum.Y, a.Y + b.Y, 10);
            Assert.Equal(a.DotProduct(b), a.X * b.X + a.Y * b.Y, 10);
            Assert.Equal(a.CrossProduct(b), a.X * b.Y - a.Y * b.X, 10);
        }
    }
}
