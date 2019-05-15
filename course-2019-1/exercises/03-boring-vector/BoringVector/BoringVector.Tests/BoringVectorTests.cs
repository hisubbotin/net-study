using System;
using Xunit;
using static BoringVector.VectorExtensions;

namespace BoringVector.Tests
{
    public class SquareLength_tests
    {

        [Fact]
        public void Test1()
        {
            Assert.True(new Vector(0, 0).SquareLength() < EPS);
        }

        [Fact]
        public void Test2()
        {
            Assert.True(Math.Abs(new Vector(3, 4).SquareLength() - 25) < EPS);
        }

        [Fact]
        public void Test3()
        {
            Assert.True(Math.Abs(new Vector(0, -1).SquareLength() - 1) < EPS);
        }
    }

    public class Add_tests
    {
        [Fact]
        public void Test1()
        {
            Vector v1 = new Vector(-1, -1);
            Vector v2 = new Vector(1, 1);
            Vector sum = v1.Add(v2);
            Assert.True(Math.Abs(sum.GetX() - 0) < EPS);
            Assert.True(Math.Abs(sum.GetY() - 0) < EPS);
        }

        [Fact]
        public void Test2()
        {
            Vector v1 = new Vector(10, 20);
            Vector v2 = new Vector(30, 40);
            Vector sum = v1.Add(v2);
            Assert.True(Math.Abs(sum.GetX() - 40) < EPS);
            Assert.True(Math.Abs(sum.GetY() - 60) < EPS);
        }
    }

    public class Scale_tests
    {
        [Theory]
        [InlineData(-1, 5, 3, -3, 15)]
        [InlineData(0, 10.5, -2, 0, -21)]
        public void Test1(double x, double y, double k, double resx, double resy)
        {
            Vector v = new Vector(x, y);
            Vector computedRes = v.Scale(k);
            Assert.True(Math.Abs(computedRes.GetX() - resx) < EPS);
            Assert.True(Math.Abs(computedRes.GetY() - resy) < EPS);
        }
    }

    public class DotProduct_tests
    {
        [Theory]
        [InlineData(-1, 5, 2, 3, 13)]
        [InlineData(0, 100, 10, 0, 0)]
        public void Test1(double x1, double y1, double x2, double y2, double res)
        {
            Vector v1 = new Vector(x1, y1);
            Vector v2 = new Vector(x2, y2);
            double dp = v1.DotProduct(v2);
            Assert.True(Math.Abs(dp - res) < EPS);
        }
    }

    public class CrossProduct_tests
    {
        [Theory]
        [InlineData(1, 0, 0, 1, 1)]
        [InlineData(0, 1, 1, 0, -1)]
        public void Test1(double x1, double y1, double x2, double y2, double res)
        {
            Vector v1 = new Vector(x1, y1);
            Vector v2 = new Vector(x2, y2);
            double cp = v1.CrossProduct(v2);
            Assert.True(Math.Abs(cp - res) < EPS);
        }
    }
}
