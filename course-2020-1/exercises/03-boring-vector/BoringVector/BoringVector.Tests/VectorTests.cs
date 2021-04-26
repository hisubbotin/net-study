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
            const int precision = 6;
            Assert.Equal(squareLength, new Vector(x, y).SquareLength(), precision);
        }
        
        [Theory]
        [InlineData(1, 2, 2, 3, 3, 5)]
        [InlineData(1, -1, -2, 2, -1, 1)]
        public void Test_Add_ReturnsCorrectValue(double leftX, double leftY, double rightX, double rightY, double sumX, double sumY)
        {
            const int precision = 6;
            var lhs = new Vector(leftX, leftY);
            var rhs = new Vector(rightX, rightY);
            var sum = lhs.Add(rhs);
            Assert.Equal(sumX, sum.X, precision);
            Assert.Equal(leftX, lhs.X, precision);
            Assert.Equal(rightX, rhs.X, precision);
            Assert.Equal(sumY, sum.Y, precision);
            Assert.Equal(leftY, lhs.Y, precision);
            Assert.Equal(rightY, rhs.Y, precision);
        }

        [Theory]
        [InlineData(1, 2, 2, 2, 4)]
        [InlineData(1, -1, 3, 3, -3)]
        public void Test_Scale_ReturnsCorrectValue(double x, double y, double k, double scaledX, double scaledY)
        {
            const int precision = 6;
            var vector = new Vector(x, y);
            var scaledVector = vector.Scale(k);
            Assert.Equal(scaledX, scaledVector.X, precision);
            Assert.Equal(scaledY, scaledVector.Y, precision);
            Assert.Equal(x, vector.X, precision);
            Assert.Equal(y, vector.Y, precision);
        }
        
        [Theory]
        [InlineData(1, 1, -2, 3, 1)]
        [InlineData(1, 0, 2, -3, 2)]
        public void Test_DotProduct_ReturnsCorrectValue(double leftX, double leftY, double rightX, double rightY, double dotProduct)
        {
            const int precision = 6;
            var lhs = new Vector(leftX, leftY);
            var rhs = new Vector(rightX, rightY);
            Assert.Equal(dotProduct, lhs.DotProduct(rhs), precision);
        }
        
        [Theory]
        [InlineData(1, 1, -2, 3, 5)]
        [InlineData(1, 0, 2, -3, 3)]
        public void Test_CrossProduct_ReturnsCorrectValue(double leftX, double leftY, double rightX, double rightY, double crossProduct)
        {
            const int precision = 6;
            var lhs = new Vector(leftX, leftY);
            var rhs = new Vector(rightX, rightY);
            Assert.Equal(crossProduct, lhs.CrossProduct(rhs), precision) ;
        }
    }
}