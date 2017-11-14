using System;
using Xunit;

namespace BoringVector.Tests
{

    public class UnitTest1
    {
        public const double EPS = 1e-6;

        private static bool equals(double a, double b, double eps=EPS)
        {
            return Math.Abs(a - b) < EPS;
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(3, 4, 5)]
        [InlineData(4, 3, 5)]
        [InlineData(5, 12, 13)]
        public void TestSquareLength(double x, double y, double squaredLength)
        {
            Assert.True(equals(new Vector(x, y).SquareLength(), squaredLength));
        }

        [Theory]
        [InlineData(0, 0, 1, 1, 1, 1)]
        [InlineData(-1, 1, 1, -1, 0, 0)]
        public void TestAdd(double x1, double y1, double x2, double y2, double x, double y)
        {
            Vector res = new Vector(x1, y1).Add(new Vector(x2, y2));
            Assert.True(equals(res.X, x));
            Assert.True(equals(res.Y, y));
        }

        [Theory]
        [InlineData(0, 0, 5, 0, 0)]
        public void TestScale(double x0, double y0, double k, double x, double y)
        {
            Vector res = new Vector(x0, y0).Scale(k);
            Assert.True(equals(res.X, x));
            Assert.True(equals(res.Y, y));
        }

        [Theory]
        [InlineData(0, 0, 5, 5, 0)]
        public void TestDotProduct(double x1, double y1, double x2, double y2, double res)
        {
            double result = new Vector(x1, y1).DotProduct(new Vector(x2, y2));
            Assert.True(equals(res, result));
        }

        [Theory]
        [InlineData(0, 0, 5, 5, 0)]
        [InlineData(1, 0, 0, 1, 1)]
        public void TestCrossProduct(double x1, double y1, double x2, double y2, double res)
        {
            double result = new Vector(x1, y1).CrossProduct(new Vector(x2, y2));
            Assert.True(equals(res, result));
        }
    }
}
