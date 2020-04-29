using System;
using Xunit;

namespace BoringVector.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 2, 5)]
        public void TestSquareLength(double x, double y, double sqrLen)
        {
            var v = new Vector(x, y);
            Assert.Equal(v.SquareLength(), sqrLen, 6);
        }

        [Theory]
        [InlineData(10, 10, 1, 1, 11, 11)]
        public void TestAdd(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            var v = new Vector(x1, y1);
            var u = new Vector(x2, y2);
            Assert.Equal(v.Add(u), new Vector(x3, y3));
        }

        [Theory]
        [InlineData(1, 1, 10, 10, 10)]
        public void TestScale(double x1, double y1, double k, double x3, double y3)
        {
            var v = new Vector(x1, y1);
            Assert.Equal(v.Scale(k), new Vector(x3, y3));
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 11)]
        public void TestDotProduct(double x1, double y1, double x2, double y2, double res)
        {
            var v = new Vector(x1, y1);
            var u = new Vector(x2, y2);
            Assert.Equal(v.DotProduct(u), res);
        }

        [Theory]
        [InlineData(1, 2, -3, 4, 10)]
        public void TestCrossProduct(double x1, double y1, double x2, double y2, double res)
        {
            var v = new Vector(x1, y1);
            var u = new Vector(x2, y2);
            Assert.Equal(v.CrossProduct(u), res);
        }
    }
}