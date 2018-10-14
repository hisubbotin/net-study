using System;
using System.Numerics;
using Xunit;

namespace BoringVector.Tests
{
    public class BoringVectorTest
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, -0, 1)]
        [InlineData(-3, 4, 25)]
        [InlineData(5, 12, 169)]
        public void Test_SquareLenght(double x, double y, double squareLenght)
        {
            Assert.Equal(new Vector(x, y).SquareLength(), squareLenght);
        }

        [Theory]
        [InlineData(0, 0, 1, 1, 1, 1)]
        [InlineData(1, 2, 3, 4, 4, 6)]
        [InlineData(-3, 34, 643, 32.1, 640, 66.1)]
        public void Test_Add(double x1, double y1, double x2, double y2, double xRes, double yRes)
        {
            Assert.Equal(new Vector(x1, y1).Add(new Vector(x2, y2)), new Vector(xRes, yRes));
        }

        [Theory]
        [InlineData(0, 10, 0, 0, 0)]
        //[InlineData(12, 43, 0.1, 1.2, 4.3)]
        [InlineData(42, 3, -2, -84, -6)]
        public void Test_Scale(double x, double y, double k, double xRes, double yRes)
        {
            Assert.Equal(new Vector(x, y).Scale(k), new Vector(xRes, yRes));
        }

        [Theory]
        [InlineData(0, 0, 24, 2, 0)]
        [InlineData(1, 32, 54, -1, 22)]
        [InlineData(0.1, 0, 10, 1, 1)]
        public void Test_DotProduct(double x1, double y1, double x2, double y2, double res)
        {
            Assert.Equal(new Vector(x1, y1).DotProduct(new Vector(x2, y2)), res);
        }

        [Theory]
        [InlineData(0, 0, 24, 2, 0)]
        [InlineData(1, 32, -1, 54, 86)]
        [InlineData(0.1, 0, 1, 10, 1)]
        public void Test_CrossProduct(double x1, double y1, double x2, double y2, double res)
        {
            Assert.Equal(new Vector(x1, y1).CrossProduct(new Vector(x2, y2)), res);
        }
    }

}
