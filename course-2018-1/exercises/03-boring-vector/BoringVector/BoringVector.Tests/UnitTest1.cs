using System;
using Xunit;

namespace BoringVector.Tests
{
    using BoringVector;
    public class VectorTests
    {
        [Fact]
        public void Test_SquareLength()
        {
            Assert.Equal(new Vector(3, 4).SquareLength(), 25);
        }

        [Fact]
        public void Test_Add()
        {
            Assert.Equal(new Vector(3, 4).Add(new Vector(1, 1)), new Vector(4, 5));
        }

        [Fact]
        public void Test_Scale()
        {
            Assert.Equal(new Vector(3, 4).Scale(3), new Vector(9, 12));
        }

        [Fact]
        public void Test_DotProduct()
        {
            Assert.Equal(new Vector(3, 4).DotProduct(new Vector(2, 2)), 14);
        }

        [Fact]
        public void Test_CrossProduct()
        {
            Assert.Equal(new Vector(2, 0).CrossProduct(new Vector(0, 6)), 12);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1e-7, 1e-7)]
        public void Test_IsZero(double x, double y)
        {
            Assert.True(new Vector(x, y).IsZero());
        }

        [Theory]
        [InlineData(3, 4)]
        [InlineData(1, 1)]
        public void Test_Normalize(double x, double y)
        {
            Assert.True(new Vector(x, y).Normalize().SquareLength() - 1 < VectorExtension.eps);
        }
    }
}
