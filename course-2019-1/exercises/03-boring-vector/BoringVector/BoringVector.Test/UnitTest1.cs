using System;
using Xunit;
using BoringVector;


namespace BoringVector.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(1, 0, 1)]
        public void SquareLengthTest(double x, double y, double sqrLen)
        {
            var v = new Vector(x, y);
            Assert.Equal(v.SquareLength(), sqrLen, 6);
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 2, 2)]
        public void AddTest(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            var v = new Vector(x1, y1);
            var u = new Vector(x2, y2);
            Assert.Equal(v.Add(u), new Vector(x3, y3));
        }

        [Theory]
        [InlineData(1, 1, 3, 3, 3)]
        public void ScaleTest(double x1, double y1, double k, double x3, double y3)
        {
            var v = new Vector(x1, y1);
            Assert.Equal(v.Scale(k), new Vector(x3, y3));
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 2)]
        public void DotProductTest(double x1, double y1, double x2, double y2, double res)
        {
            var v = new Vector(x1, y1);
            var u = new Vector(x2, y2);
            Assert.Equal(v.DotProduct(u), res);
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 0)]
        public void CrossProductTest(double x1, double y1, double x2, double y2, double res)
        {
            var v = new Vector(x1, y1);
            var u = new Vector(x2, y2);
            Assert.Equal(v.CrossProduct(u), res);
        }
    }
}