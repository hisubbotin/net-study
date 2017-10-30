using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTests
    {
        [Theory]
        [InlineData(2, 3, 13)]
        [InlineData(0, -10, 100)]
        [InlineData(4E-10, -10, 100)]
        public void Test_SquareLength(double X, double Y, double result)
        {
            Assert.Equal(new Vector(X, Y).SquareLength(), result);
        }

        [Theory]
        [InlineData(1, -1, -2, 3,  -1, 2)]
        public void Test_Add(double X1, double Y1, double X2, double Y2, double X, double Y)
        {
            Assert.Equal(new Vector(X1, Y1) + new Vector(X2, Y2), new Vector(X, Y));
        }

        [Theory]
        [InlineData(1, -1, 3, 3, -3)]
        public void Test_Scale(double X1, double Y1, double k, double X, double Y)
        {
            Assert.Equal(new Vector(X1, Y1).Scale(k), new Vector(X, Y));
        }

        [Theory]
        [InlineData(1, 1, 1, -1, 0)]
        public void Test_DotProduct(double X1, double Y1, double X2, double Y2, double result)
        {
            Assert.Equal(new Vector(X1, Y1).DotProduct(new Vector(X2, Y2)), result);
        }

        [Theory]
        [InlineData(1, 1, -2, -2, 0)]
        public void Test_CrossProductd(double X1, double Y1, double X2, double Y2, double result)
        {
            Assert.Equal(new Vector(X1, Y1).CrossProduct(new Vector(X2, Y2)), result);
        }
    }
}