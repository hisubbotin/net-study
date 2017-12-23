using System;
using Xunit;

namespace BoringVector.Test
{
    public class Tests
    {
        [Fact]
        [InlineData(3, 4, 25)]
        [InlineData(10, 10, 200)]
        public void SquareLengthTest(double x, double y, double res)
        {
            Assert.Equal(new Vector(x, y).SquareLength(), res);
        }

        [Fact]
        [InlineData(1,2,3,4,4,7)]
        [InlineData(4,5,3,6,7,11)]
        public void AddTest(double x1, double y1, double x2, double y2, double X, double Y)
        {
            Assert.True(new Vector(X,Y).Equals(new Vector(x1, y1).Add(new Vector(x2,y2))));
        }
        [Fact]
        [InlineData(3,5,2,6,10)]
        [InlineData(4,7,3,12,21)]
        public void ScaleTest(double x, double y, double k, double X, double Y)
        {
            Assert.True(new Vector(x, y).Scale(k).Equals(new Vector(X,Y)));
        }

        [Fact]
        [InlineData(1,2,3,4,14)]
        [InlineData(1,1,1,1,2)]
        public void DotProductTest(double x1, double y1, double x2, double y2, double res)
        {
            Assert.True(new Vector(x1, y2).DotProduct(new Vector(x2, y2)) == res);
        }

        [Fact]
        [InlineData(1,-1,-2,2,-1)]
        public void CrossProductTest(double x1, double y1,double x2, double y2, double res)
        {
            Assert.True(new Vector(x1, y1).CrossProduct(new Vector(x2, y2)) == res);
        }



    }
}
