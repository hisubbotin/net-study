using System;
using Xunit;

namespace BoringVector.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void AddTest()
        {
            Vector vector = new Vector(1, -1);
            Assert.True(vector.Add(-vector).IsZero());
        }

        [Theory]
        [InlineData(1, -1, 2)]
        [InlineData(2, 2, 8)]
        [InlineData(2, -2, 8)]
        public void SquareLengthTest(double x, double y, double res)
        {
            Assert.Equal(res, new Vector(x, y).SquareLength());
        }

        [Fact]
        public void ScaleTest()
        {
            Vector vector = new Vector(1, -1);
            Assert.Equal(200, vector.Scale(10).SquareLength());
        }

        [Fact]
        public void DotProductTest()
        {
            Vector vector1 = new Vector(1, -1);
            Vector vector2 = new Vector(-1, -1);
            Assert.Equal(0, vector1.DotProduct(vector2));
        }

        [Fact]
        public void CrossProductTest()
        {
            Vector vector1 = new Vector(1, -1);
            Vector vector2 = new Vector(1, 1);
            Assert.Equal(2, vector1.CrossProduct(vector2));
        }
    }
}
