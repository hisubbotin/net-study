using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTests
    {
        [Theory]
        [InlineData(3.0, 4.0, 25.0)]
        [InlineData(6.0, 8.0, 100.0)]
        public void Test_SquareLength(double x, double y, double expected)
        {
            Vector vec = new Vector(x, y);
            Assert.Equal(expected, vec.SquareLength(), 5);
        }

        [Fact]
        public void Test_Add()
        {
            Vector vec1 = new Vector(1.0, 0.0);
            Vector vec2 = new Vector(0.0, 1.0);
            Vector sum = vec1.Add(vec2);
            Assert.Equal(1.0, sum.X, 5);
            Assert.Equal(1.0, sum.Y, 5);
        }

        [Theory]
        [InlineData(12.3, 14.0, 4.3)]
        [InlineData(-2.4, 4.0, 1.3)]
        [InlineData(1.4, 2.1, -0.5)]
        public void Test_Scale(double x, double y, double k)
        {
            Vector vec = new Vector(x, y);
            Vector scaled = vec.Scale(k);
            Assert.Equal(x * k, scaled.X, 5);
            Assert.Equal(y * k, scaled.Y, 5);
        }

        [Fact]
        public void Test_DotProduct()
        {
            Vector vec1 = new Vector(1.0, 1.0);
            Vector vec2 = new Vector(-1.0, 1.0);
            Assert.Equal(0.0, vec1.DotProduct(vec2), 5);
        }

        [Fact]
        public void Test_CrossProduct()
        {
            Vector vec1 = new Vector(1.0, 1.0);
            Vector vec2 = new Vector(2.0, 2.0);
            Assert.Equal(0.0, vec1.CrossProduct(vec2), 5);
        }
    }
}
