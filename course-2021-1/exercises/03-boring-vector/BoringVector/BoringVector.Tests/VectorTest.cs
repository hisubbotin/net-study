using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTest
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 2)]
        [InlineData(100, 100, 20000)]
        [InlineData(-1, 2, 5)]
        internal void TestSquareLength(double x, double y, double correctResult)
        {
            Assert.Equal(new Vector(x, y).SquareLength(), correctResult);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(1, 1, 0, 0, 1, 1)]
        [InlineData(1, 0, -1, 0, 0, 0)]
        [InlineData(100, 234, 43, 20, 143, 254)]
        [InlineData(-1, 1, 1, -1, 0, 0)]
        internal void TestAdd(double uX, double uY, double vX, double vY, double resX, double resY)
        {
            var u = new Vector(uX, uY);
            var v = new Vector(vX, vY);
            var res = u.Add(v);
            Assert.Equal(res.X, resX);    
            Assert.Equal(res.Y, resY);    
        }

        [Theory]
        [InlineData(0, 0, 5, 0, 0)]
        [InlineData(1, 1, 5, 5, 5)]
        [InlineData(0, 1, 5, 0, 5)]
        [InlineData(1, 1, -1, -1, -1)]
        [InlineData(100, 200, 0.5, 50, 100)]
        internal void TestScale(double uX, double uY, double k, double resX, double resY)
        {
            var u = new Vector(uX, uY);
            var res = u.Scale(k);
            Assert.Equal(res.X, resX);    
            Assert.Equal(res.Y, resY);
        }
        
        [Theory]
        [InlineData(1, 1, 1, 1, 2)]
        [InlineData(0, 0, 1, 537, 0)]
        [InlineData(0, 2, 2, 0, 0)]
        [InlineData(1, -1, -1, 1, -2)]
        [InlineData(1, 1, -1, -1, -2)]
        internal void TestDotProduct(double uX, double uY, double vX, double vY, double actual)
        {
            var u = new Vector(uX, uY);
            var v = new Vector(vX, vY);
            var res = u.DotProduct(v);
            Assert.Equal(res, actual);
        }

        
        [Theory]
        [InlineData(1, 1, -1, 1, 2)]
        [InlineData(1, 2, 2, 1, -3)]
        [InlineData(10, 5, 3, 4, 25)]
        internal void TestCrossProduct(double uX, double uY, double vX, double vY, double actual)
        {
            var u = new Vector(uX, uY);
            var v = new Vector(vX, vY);
            var res = u.CrossProduct(v);
            Assert.Equal(res, actual);
        }
        
    }
}