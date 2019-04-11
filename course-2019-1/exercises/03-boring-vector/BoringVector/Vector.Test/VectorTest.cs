using System;
using Xunit;

namespace Vector.Test
{
    public class VectorTest
    {
        [Theory]
        [InlineData(3, 4, 25)]
        [InlineData(-10, -10, 200)]
        [InlineData(-1, 1, 2)]
        public void SquareLength(double x, double y, double result)
        {
            var vector = new BoringVector.Vector(x, y);
            Assert.Equal(vector.SquareLength(), result);
        }

        [Theory]
        [InlineData(3, 4, 5, 6, 8, 10)]
        public void Add(double x1, double y1, double x2, double y2, double rx, double ry)
        {
            var vector1 = new BoringVector.Vector(x1, y1);
            var vector2 = new BoringVector.Vector(x2, y2);
            var vectorResult = vector1.Add(vector2);
            Assert.Equal(vectorResult.X, rx);
            Assert.Equal(vectorResult.Y, ry);
        }

        [Theory]
        [InlineData(3, 4, 10, 30, 40)]
        public void Scale(double x1, double y1, double k, double rx, double ry)
        {
            var vector1 = new BoringVector.Vector(x1, y1);
            var vectorResult = vector1.Scale(k);
            Assert.Equal(vectorResult.X, rx);
            Assert.Equal(vectorResult.Y, ry);
        }

        [Theory]
        [InlineData(3, 4, 5, 6, 39)]
        public void DotProduct(double x1, double y1, double x2, double y2, double r)
        {
            var vector1 = new BoringVector.Vector(x1, y1);
            var vector2 = new BoringVector.Vector(x2, y2);
            var result = vector1.DotProduct(vector2);
            Assert.Equal(result, r);
        }

        [Theory]
        [InlineData(3, 4, 5, 6, -2)]
        public void CrossProduct(double x1, double y1, double x2, double y2, double r)
        {
            var vector1 = new BoringVector.Vector(x1, y1);
            var vector2 = new BoringVector.Vector(x2, y2);
            var result = vector1.CrossProduct(vector2);
            Assert.Equal(result, r);
        }
    }
}
