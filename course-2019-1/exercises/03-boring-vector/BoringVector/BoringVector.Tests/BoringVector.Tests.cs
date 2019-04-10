using System;
using Xunit;

namespace BoringVector.Tests
{
    public class TestVector
    {
        [Theory]
        [InlineData(1, 0, 1)]
        [InlineData(-5, 5, 50)]
        [InlineData(3, 4, 25)]
        public void TestLength(double x, double y, double ans)
        {
            Vector v = new Vector(x, y);
            Assert.Equal(v.SquareLength(), ans);
        }
        
        [Theory]
        [InlineData(0, 0, 1, 1, 1, 1)]
        [InlineData(-10, 120, 10, -120, 0, 0)]
        [InlineData(0, 0, 0, 0, 0, 0)]
        public void TestAdd(double a1, double b1, double a2, double b2, double x_ans, double y_ans)
        {
            Vector a = new Vector(a1, b1);
            Vector b = new Vector(a2, b2);
            Vector ans = new Vector(x_ans, y_ans);
            Assert.Equal(a.Add(b), ans);
        }
        
        [Theory]
        [InlineData(1, 1, 0, 0, 0)]
        [InlineData(5, -10, -3, -15, 30)]
        [InlineData(0, 0, 100, 0, 0)]
        public void TestScale(double x, double y, double k, double x_ans, double y_ans)
        {
            Vector v = new Vector(x, y);
            Vector ans = new Vector(x_ans, y_ans);
            Assert.Equal(v.Scale(k), ans);
        }
        
        [Theory]
        [InlineData(1, -1, 1, 1, 0)]
        [InlineData(111, 133, 0, 0, 0)]
        [InlineData(3, 4, 3, 4, 25)]
        public void TestDotProduct(double a1, double b1, double a2, double b2, double ans)
        {
            Vector a = new Vector(a1, b1);
            Vector b = new Vector(a2, b2);
            Assert.Equal(a.DotProduct(b), ans);
        }
        
        [Theory]
        [InlineData(1, 6, 1, 6, 0)]
        [InlineData(1, 1, 0, 0, 0)]
        [InlineData(3, 4, -4, 3, 25)]
        public void TestCrossProduct(double a1, double b1, double a2, double b2, double ans)
        {
            Vector a = new Vector(a1, b1);
            Vector b = new Vector(a2, b2);
            Assert.Equal(a.CrossProduct(b), ans);
        }
        
    }
}