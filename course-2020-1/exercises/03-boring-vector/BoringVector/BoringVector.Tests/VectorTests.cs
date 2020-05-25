using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTests
    {
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(1, -10, 101)]
        public void Test_SquareLength(double x, double y, double answer)
        {
            Assert.Equal(new Vector(x, y).SquareLength(), answer);
        }
        [Theory]
        [InlineData(1, 2, 2, 3, 3, 5)]
        [InlineData(1, -1, -2, 2, -1, 1)]
        public void Test_Add(double x1, double y1,double x2, double y2, double x, double y)
        {
            var sum = (new Vector(x1, y1)).Add(new Vector(x2, y2));
            Assert.Equal(sum.X, x);
            Assert.Equal(sum.Y, y);
        }

        [Theory]
        [InlineData(1, 2, 2, 2, 4)]
        [InlineData(1, -1, 3, 3, -3)]
        public void Test_Scale(double x, double y, double k, double scaledX, double scaledY)
        {
            var v = new Vector(x, y);
            var scaledV = v.Scale(k);
            Assert.Equal(scaledV.X, scaledX);
            Assert.Equal(scaledV.Y, scaledY);
        }
        [Theory]
        [InlineData(1, 1, -2, 3, 1)]
        [InlineData(1, 0, 2, -3, 2)]
        public void Test_DotProduct(double x1, double y1,
            double x2, double y2, double dotProduct)
        {
            var l = new Vector(x1, y1);
            var r = new Vector(x2, y2);
            Assert.Equal(l.DotProduct(r), dotProduct);
        }
        [Theory]
        [InlineData(1, 1, -2, 3, 5)]
        [InlineData(1, 0, 2, -3, 3)]
        public void Test_CrossProduct(double x1, double y1,
            double x2, double y2, double crossProduct)
        {
            var l = new Vector(x1, y1);
            var r = new Vector(x2, y2);
            Assert.Equal(l.CrossProduct(r), crossProduct);
        }
    }
}