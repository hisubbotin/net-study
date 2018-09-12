using Xunit;
using System;

namespace BoringVector.Tests
{
    public class VectorTest
    {
        public bool IsEqual(double left, double right)
        {
            return Math.Abs(left - right) < VectorExtensions.EPS;
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(0, 0, 0)]
        [InlineData(-1, -1, 2)]
        [InlineData(-1, 1, 2)]
        [InlineData(-1.005, 2.0001, 5.01042501)]
        public void Test_SquareLength_ReturnsCorrectValue(double x, double y, double result)
        {
            Assert.True(IsEqual(result, new Vector(x, y).SquareLength()));
        }

        [Theory]
        [InlineData(1, 1, -1, -1, 0, 0)]
        [InlineData(0, 1, -1.23423, -1.234252, -1.23423, -0.234252)]
        [InlineData(0, 0, 0, 0, 0, 0)]
        public void Test_Add_ReturnsCorrectValue(double x1, double y1, double x2, double y2, double resx, double resy) 
        {
            var res = new Vector(x1, y1).Add(new Vector(x2, y2));
            Assert.True(IsEqual(res.X, resx) && IsEqual(res.Y, resy));
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 1)]
        [InlineData(1, 1, -1, -1, -1)]
        [InlineData(1, 1, 0, 0, 0)]
        public void Test_Scale_ReturnsCorrectValue(double x1, double y1, double k, double resx, double resy)
        {
            var res = new Vector(x1, y1).Scale(k);
            Assert.True(IsEqual(res.X, resx) && IsEqual(res.Y, resy));
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 2)]
        [InlineData(1, 0, 0, 1, 0)]
        public void Test_DotProduct_ReturnsCorrectValue(double x1, double y1, double x2, double y2, double res)
        {
            var dotProduct = new Vector(x1, y1).DotProduct(new Vector(x2, y2));
            Assert.True(IsEqual(res, dotProduct));
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 0)]
        [InlineData(1, 0, 0, 1, 1)]
        public void Test_CrossProduct_ReturnsCorrectValue(double x1, double y1, double x2, double y2, double res)
        {
            var crossProduct = new Vector(x1, y1).CrossProduct(new Vector(x2, y2));
            Assert.True(IsEqual(res, crossProduct));
        }
    }
}
