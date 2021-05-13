using System;
using System.Runtime.InteropServices;
using Xunit;

namespace BoringVector.Tests
{
    /*
     SquareLength
     Add
     Scale
     DotProduct
     CrossProduct
     */
    public class BoringVectorTest
    {
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(0, 0, 0)]
        [InlineData(2, -2, 8)]
        public void SquareLengthTest(double x, double y, double length)
        {
            Vector testVec = new Vector(x, y);
            Assert.Equal(length, testVec.SquareLength());
        }

        [Theory]
        [InlineData(1, 1, 0, 0, 1, 1)]
        [InlineData(1, 1, -1, -1, 0, 0)]
        [InlineData(2, -2, 1, -1, 3, -3)]
        public void AddTest(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Vector testVec1 = new Vector(x1, y1);
            Vector testVec2 = new Vector(x2, y2);
            Vector testVec3 = testVec1.Add(testVec2);
            Assert.Equal(x3, testVec3.X);
            Assert.Equal(y3, testVec3.Y);
        }

        [Theory]
        [InlineData(1, 1, 0, 0, 0)]
        [InlineData(1, 1, -1, -1, -1)]
        [InlineData(2, -2, -0.5d, -1, 1)]
        public void ScaleTest(double x1, double y1, double k, double x2, double y2)
        {
            Vector testVec1 = new Vector(x1, y1);
            Vector testVec2 = testVec1.Scale(k);
            Assert.Equal(x2, testVec2.X);
            Assert.Equal(y2, testVec2.Y);
        }

        [Theory]
        [InlineData(1, 1, 0, 0, 0)]
        [InlineData(1, 1, -1, -1, -2)]
        [InlineData(2, -2, 1, -1, 4)]
        public void DotProductTest(double x1, double y1, double x2, double y2, double dp)
        {
            Vector testVec1 = new Vector(x1, y1);
            Vector testVec2 = new Vector(x2, y2);
            double test = testVec1.DotProduct(testVec2);
            Assert.Equal(dp, test);
        }

        [Theory]
        [InlineData(1, 1, 0, 0, 0)]
        [InlineData(1, 1, -1, -1, 0)]
        [InlineData(2, 2, 1, -1, -4)]
        public void CrossProductTest(double x1, double y1, double x2, double y2, double dp)
        {
            Vector testVec1 = new Vector(x1, y1);
            Vector testVec2 = new Vector(x2, y2);
            double test = testVec1.CrossProduct(testVec2);
            Assert.Equal(dp, test);
        }
    }
}
