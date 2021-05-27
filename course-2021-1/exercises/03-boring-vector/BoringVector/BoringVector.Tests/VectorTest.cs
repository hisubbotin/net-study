using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTest
    {
        [Fact]
        public void Test_SquareLength()
        {
            Vector v = new Vector(3, 4);
            Assert.Equal(25, v.SquareLength());
        }
        [Theory]
        [InlineData(1, 5)]
        [InlineData(0, 0)]
        [InlineData(-1, 1)]
        public void Test_Add(double x, double y)
        {
            Vector v = new Vector(3, 4);
            Vector u = new Vector(x, y);
            v.Add(u);
            Assert.Equal(new Vector(3+x, 4+y).ToString(), v.ToString());
        }
        [Theory]
        [InlineData(5)]
        [InlineData(0)]
        [InlineData(-2)]
        public void Test_Scale(double scale)
        {
            Vector v = new Vector(3, 4);
            v.Scale(scale);
            Assert.Equal(new Vector(3*scale, 4*scale).ToString(), v.ToString());
        }
        [Fact]
        public void Test_DotProduct()
        {
            Vector v = new Vector(3, 4);
            Vector u = new Vector(1, -1);
            Assert.Equal(-1, v.DotProduct(u));
        }
        [Fact]
        public void Test_CrossProduct()
        {
            Vector v = new Vector(3, 4);
            Vector u = new Vector(4, -3);
            Assert.Equal(-25, v.CrossProduct(u));
        }
    }
}
