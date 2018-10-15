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
        public void Test_Add(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            var vec1 = new Vector(x1, y1);
            var vec2 = new Vector(x2, y2);
            var vec3 = new Vector(x3, y3);
            Assert.Equal(vec1.Add(vec2), vec3);
        }
    }
}