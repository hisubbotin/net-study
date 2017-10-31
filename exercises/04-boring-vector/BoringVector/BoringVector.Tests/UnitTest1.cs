using System;
using Xunit;

namespace BoringVector.Tests
{
    public class Tests
    {
        [Theory]
        [InlineData(1, 2, 5)]
        [InlineData(0, 6, 36)]
        [InlineData(2, 2, 8)]
        public void Test_SquareLength(double x, double y, double result)
        {
            Assert.Equal(new Vector(x, y).SquareLength(), result);
        }

        [Theory]
        [InlineData(1, 2, 2, 3, 3, 5)]
        [InlineData(0, 0, 2, 2, 2, 2)]
        public void Test_Add(double x1, double y1, double x2, double y2, double x, double y)
        {
            Assert.Equal(new Vector(x1, y1) + new Vector(x2, y2), new Vector(x, y));
        }

        [Theory]
        [InlineData(2, 2, 2, 4, 4)]
        [InlineData(2, 2, -1, -2, -2)]
        public void Test_Scale(double x1, double y1, double k, double x, double y)
        {
            Assert.Equal(new Vector(x1, y1).Scale(k), new Vector(x, y));
        }

        [Theory]
        [InlineData(2, 2, 2, 2, 8)]
        [InlineData(1, 2, 2, -1, 0)]
        public void Test_DotProduct(double x1, double y1, double x2, double y2, double result)
        {
            Assert.Equal(new Vector(x1, y1).DotProduct(new Vector(x2, y2)), result);
        }

        [Theory]
        [InlineData(1, 4, 3, 5, -7)]
        [InlineData(-5, 1, -2, 3, -13)]
        public void Test_CrossProductd(double x1, double y1, double x2, double y2, double result)
        {
            Assert.Equal(new Vector(x1, y1).CrossProduct(new Vector(x2, y2)), result);
        }
    }
}

