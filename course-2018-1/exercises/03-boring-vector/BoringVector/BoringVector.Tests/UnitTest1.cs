using System;
using Xunit;

namespace BoringVector.Tests
{
    public class BasicMethodsTests
    {
        [Theory]
        [InlineData(2, 0, 4)]
        [InlineData(3, -1, 10)]
        [InlineData(2, -2, 8)]
        public void Test_SquareLength(double x, double y, double sqr_length)
        {
            var vec = new Vector(x, y);
            Assert.Equal(vec.SquareLength(), sqr_length);
        }
        
        [Theory]
        [InlineData(1.5, 0, 2.1, -1, 3.6, -1)]
        [InlineData(2.01, -3.1, -2.01, 3.1, 0, 0)]
        [InlineData(99, -0.5, -100, 1.0, -1, 0.5)]
        public void Test_Add(double x1, double y1, double x2, double y2, double xRes, double yRes)
        {
            var vec1 = new Vector(x1, y1);
            var vec2 = new Vector(x2, y2);
            var vecRes = new Vector(xRes, yRes);
            Assert.Equal(vec1.Add(vec2), vecRes);
        }
        
        [Theory]
        [InlineData(2, 4, 3, 6, 12)]
        [InlineData(-0.1, 0, -1, 0.1, 0)]
        [InlineData(2, 1, 0.0, 0, 0)]
        public void Test_Scale(double x, double y, double k, double xRes, double yRes)
        {
            var vec = new Vector(x, y);
            var vecRes = new Vector(xRes, yRes);
            Assert.Equal(vec.Scale(k), vecRes);
        }
        
        [Theory]
        [InlineData(1, 2, 3, 4, 11)]
        [InlineData(-1, -1, 2, -2, 0)]
        [InlineData(-1, 1, 0, 0, 0)]
        public void Test_DotProduct(double x1, double y1, double x2, double y2, double res)
        {
            var vec1 = new Vector(x1, y1);
            var vec2 = new Vector(x2, y2);
            Assert.Equal(vec1.DotProduct(vec2), res);
        }
        
        [Theory]
        [InlineData(1, 3, 2, 4, 2)]
        [InlineData(-1, -3, 2, 4, 2)]
        [InlineData(-2, 4, -1, 2, 0)]
        [InlineData(0, 0, 1, 2, 0)]
        public void Test_CrossProduct(double x1, double y1, double x2, double y2, double res)
        {
            var vec1 = new Vector(x1, y1);
            var vec2 = new Vector(x2, y2);
            Assert.Equal(vec1.CrossProduct(vec2), res);
        }
        
        [Fact]
        public void Test_ToString()
        {
            var vec = new Vector(0.04, -1.0);
            Assert.Equal(vec.ToString(), "(0.04; -1)");
        }
    }
}