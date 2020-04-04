using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTests
    {
        [Theory]
        [InlineData(3, 4, 25)]
        [InlineData(1, -1, 2)]
        public void Test_SquareLength_ReturnsCorrectValue(double x, double y, double squareLength)
        {
            Assert.Equal(new Vector(x, y).SquareLength(), squareLength);
        }
        [Theory]
        [InlineData(1, 2, 2, 3, 3, 5)]
        [InlineData(1, -1, -2, 2, -1, 1)]
        public void Test_Add_ReturnsCorrectValue(double leftX, double leftY, 
            double rightX, double rightY, double sumX, double sumY)
        {
            var lhs = new Vector(leftX, leftY);
            var rhs = new Vector(rightX, rightY);
            var sum = lhs.Add(rhs);
            Assert.Equal(sum.X, sumX);
            Assert.Equal(sum.Y, sumY);
        }

        [Theory]
        [InlineData(1, 2, 2, 2, 4)]
        [InlineData(1, -1, 3, 3, -3)]
        public void Test_Scale_ReturnsCorrectValue(double x, double y, double k, double scaledX, double scaledY)
        {
            var v = new Vector(x, y);
            var scaledV = v.Scale(k);
            Assert.Equal(scaledV.X, scaledX);
            Assert.Equal(scaledV.Y, scaledY);
        }
        [Theory]
        [InlineData(1, 1, -2, 3, 1)]
        [InlineData(1, 0, 2, -3, 2)]
        public void Test_DotProduct_ReturnsCorrectValue(double leftX, double leftY,
            double rightX, double rightY, double dotProduct)
        {
            var lhs = new Vector(leftX, leftY);
            var rhs = new Vector(rightX, rightY);
            Assert.Equal(lhs.DotProduct(rhs), dotProduct);
        }
        [Theory]
        [InlineData(1, 1, -2, 3, 5)]
        [InlineData(1, 0, 2, -3, 3)]
        public void Test_CrossProduct_ReturnsCorrectValue(double leftX, double leftY,
            double rightX, double rightY, double crossProduct)
        {
            var lhs = new Vector(leftX, leftY);
            var rhs = new Vector(rightX, rightY);
            Assert.Equal(lhs.CrossProduct(rhs), crossProduct);
        }
    }
}