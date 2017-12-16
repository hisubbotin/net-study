using System;
using Xunit;

namespace BoringVector.Tests2
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 2, 4)]
        [InlineData(2, 3, 13)]
        public void Test_SquareLength(double X, double Y, double result)
        {
            Assert.Equal((new Vector(X, Y)).SquareLength(), result);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(1, 0, 0, 1, 1, 1)]
        [InlineData(2, 3, -2, -2, 0, 1)]
        [InlineData(18, 1, -1, 10, 17, 11)]
        public void Test_Add(double vX, double vY, double uX, double uY, double resX, double resY)
        {
            Assert.Equal((new Vector(vX, vY)).Add(new Vector(uX, uY)), new Vector(resX, resY));
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(1, 1, 5, 5, 5)]
        [InlineData(8, 4.5, 0.5, 4, 2.25)]
        [InlineData(12, -1, -2, -24, 2)]
        public void Test_Scale(double vX, double vY, double k, double resX, double resY)
        {
            Assert.Equal((new Vector(vX, vY)).Scale(k), new Vector(resX, resY));
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(2, 0, 0, 1, 0)]
        [InlineData(3, 4, 1, 5, 23)]
        [InlineData(-1, 1, -2, -5, -3)]
        public void Test_DotProduct(double vX, double vY, double uX, double uY, double res)
        {
            Assert.Equal((new Vector(vX, vY)).DotProduct(new Vector(uX, uY)), res);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(1, 1, 2, 1, -1)]
        [InlineData(15, 3, 10, -1, -45)]
        public void Test_CrossProduct(double vX, double vY, double uX, double uY, double res)
        {
            Assert.Equal((new Vector(vX, vY)).CrossProduct(new Vector(uX, uY)), res);
        }
    }
}
