using System;
using Xunit;
using static BoringVector.VectorExtensions;

namespace BoringVector.Tests
{
    public class SquareTests
    {
        [Fact]
        public void Test1()
        {
            Assert.True(new Vector(0, 0).SquareLength < EPS);
        }

        [Fact]
        public void Test2()
        {
            Assert.True(Math.Abs(new Vector(4, 0).SquareLength() - 16) < EPS);
        }

        [Fact]
        public void Test3()
        {
            Assert.True(Math.Abs(new Vector(0, 4).SquareLength() - 16) < EPS);
        }

        [Fact]
        public void Test4()
        {
            Assert.True(Math.Abs(new Vector(2, 1).SquareLength() - 5) < EPS);
        }
    }
}

    public class AddTests
    {
        [Fact]
        public void Test1()
        {
            Vector v1 = new Vector(-5, 4);
            Vector v2 = new Vector(3, 0);
            Vector sum = v1.add(v2);
            Assert.True(Math.Abs(sum.x + 2) < EPS);
            Assert.True(Math.Abs(sum.y - 4) < EPS);
        }
    }   
    
    public class ClassTests
    {
        [Fact]
        public void Test1()
        {
            Vector v1 = new Vector(6, 7);
            Vector multi = v1.Scale(6);
            Assert.True(Math.Abs(multi.x - 36) < EPS);
            Assert.True(Math.Abs(multi.y - 42) < EPS);
        }
        [Fact]
        public void Test2()
        {
            Vector v1 = new Vector(0, 0);
            Vector multi = v1.Scale(6);
            Assert.True(Math.Abs(multi.x - 0) < EPS);
            Assert.True(Math.Abs(multi.y - 0) < EPS);
        }
        [Fact]
        public void Test3()
        {
            Vector v1 = new Vector(3, 5);
            Vector multi = v1.Scale(0);
            Assert.True(Math.Abs(multi.x - 0) < EPS);
            Assert.True(Math.Abs(multi.y - 0) < EPS);
        }

    public class DotProductTests
    {
        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(0, 5, 5, 0, 0)]
        [InlineData(2, 0, 0, 2, 0)]
        [InlineData(2, 5, 2, 5, 29)]
        public void Test1(double x11, double x21, double x12, double x22, double res)
        {
            double v = (new Vector(x11, x21)).DotProduct(new Vector(x12, x22));
            Assert.True(Math.Abs(v - res) < EPS);
        }

    }
    public class CrossProductTests
    {
        [Theory]
        [InlineData(1, 1, 1, 1, 0)]
        [InlineData(1, 0, 0, 1, 1)]
        [InlineData(4, 3, 3, 4, 7)]
        public void TestCrossProduct(double x11, double x21, double x12, double x22, double res)
        {
            Double V = (new Vector(x11, x21)).CrossProduct(new Vector(x12, x22));
            Assert.True(Abs(V - res) < EPS);
        }
    }
}
      




 