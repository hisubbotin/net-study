using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Xunit;
using BoringVector;
using Microsoft.VisualBasic.CompilerServices;

namespace BoringVector.Tests
{
    public class VectorTest
    {
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(-1, 1, 2)]
        [InlineData(0, 0, 0)]
        public void Test_SquareLength_ReturnsCorrectValue(double x, double y, double squaredLength)
        {
            var new_vector = new Vector(x, y);
            Assert.Equal(new_vector.SquareLength(), squaredLength);
        }

        [Theory]
        [InlineData(1, 1, 2, 2, 3, 3)]
        [InlineData(1, 1, 0, 0, 1, 1)]
        [InlineData(-1, 1, 1, -1, 0, 0)]
        public void Test_Add_ReturnsCorrectValue(double leftX, double leftY, double rightX, double rightY, double sumX, double sumY)
        {
            var v = new Vector(leftX, leftY);
            var u = new Vector(rightX, rightY);
            var sum = v.Add(u);
            Assert.Equal(sum.X, sumX);
            Assert.Equal(sum.Y, sumY);

        }

        [Theory]
        [InlineData(1, 1, 2, 2, 2)]
        [InlineData(-1, 1, 0, 0, 0)]
        [InlineData(0.5, 1.0, 3.0, 1.5, 3.0)]
        public void Test_Scale_ReturnsCorrectValue(double x, double y, double k, double scaledX, double scaledY)
        {
            var v = new Vector(x, y);
            var scaledVector = v.Scale(k);
            Assert.Equal(scaledVector.X, scaledX);
            Assert.Equal(scaledVector.Y, scaledY);
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 2)]
        [InlineData(1, 1, -1, 1, 0)]
        [InlineData(0, -1, 2, -3, 3)]
        public void Test_DotProduct_ReturnsCorrectValue(double leftX, double leftY, double rightX, double rightY, double dotProduct)
        {
            var v = new Vector(leftX, leftY);
            var u = new Vector(rightX, rightY);
            Assert.Equal(v.DotProduct(u), dotProduct);
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 0)]
        [InlineData(1, 1, -1, 1, 2)]
        [InlineData(0, -1, 2, -3, 2)]
        public void Test_CrossProduct_ReturnsCorrectValue(double leftX, double leftY, double rightX, double rightY, double crossProduct)
        {
            var v = new Vector(leftX, leftY);
            var u = new Vector(rightX, rightY);
            Assert.Equal(v.CrossProduct(u), crossProduct);
        }
    }
}