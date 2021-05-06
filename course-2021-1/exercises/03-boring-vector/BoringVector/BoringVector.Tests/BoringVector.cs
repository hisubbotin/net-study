using System;
using Xunit;

namespace BoringVector.Tests
{
    public class BoringVector
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(3, 4, 25)]
        [InlineData(0.5, -0.5, 0.5)]
        public void Test_SquareLength(double x, double y, double length)
        {
            Assert.Equal(new Vector(x, y).SquareLength(), length);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 4, 6)]
        [InlineData(0.5, 1.5, 2.5, -3, 3, -1.5)]
        public void Test_Add(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Vector sumVector = (new Vector(x1, y1)).Add(new Vector(x2, y2));
            Assert.Equal(sumVector.X, x3);
            Assert.Equal(sumVector.Y, y3);
        }

        [Theory]
        [InlineData(1, 2, 0, 0, 0)]
        [InlineData(0.5, 1.5, 3, 1.5, 4.5)]
        [InlineData(0.5, 1.5, -2, -1, -3)]
        public void Test_Scale(double x1, double y1, double k, double x2, double y2)
        {
            Vector scaledVector = (new Vector(x1, y1)).Scale(k);
            Assert.Equal(scaledVector.X, x2);
            Assert.Equal(scaledVector.Y, y2);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 11)]
        [InlineData(0.5, 1.5, 2, -3, -3.5)]
        public void Test_DotProduct(double x1, double y1, double x2, double y2, double product)
        {
            Assert.Equal((new Vector(x1, y1)).DotProduct(new Vector(x2, y2)), product);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, -2)]
        [InlineData(0.5, 1.5, 2, -3, -4.5)]
        public void Test_CrossProduct(double x1, double y1, double x2, double y2, double product)
        {
            Assert.Equal((new Vector(x1, y1)).CrossProduct(new Vector(x2, y2)), product);
        }
    }
}
