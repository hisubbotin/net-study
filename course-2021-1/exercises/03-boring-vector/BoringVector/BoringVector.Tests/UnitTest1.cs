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
        [InlineData(2, -2, 8)]
        public void SquareLengthTest(double X, double Y, double l)
        {
            Vector test = new Vector(X, Y);
            Assert.Equal(l, test.SquareLength());
        }

        [Theory]
        [InlineData(1, 1, 0, 0, 1, 1)]
        [InlineData(1, 1, -1, -1, 0, 0)]
        public void AddTest(double X1, double Y1, double X2, double Y2, double X3, double Y3)
        {
            Vector test1 = new Vector(X1, Y1);
            Vector test2 = new Vector(X2, Y2);
            Vector test3 = test1.Add(test2);
            Assert.Equal(X3, test3.X);
            Assert.Equal(Y3, test3.Y);
        }

        [Theory]
        [InlineData(1, 1, 2, 2, 2)]
        public void ScaleTest(double X1, double Y1, double k, double X2, double Y2)
        {
            Vector test1 = new Vector(X1, Y1);
            Vector test2 = test1.Scale(k);
            Assert.Equal(X2, test2.X);
            Assert.Equal(Y2, test2.Y);
        }

        [Theory]
        [InlineData(1, 2, 1, -1, -1)]
        public void DotProductTest(double X1, double Y1, double X2, double Y2, double dp)
        {
            Vector test1 = new Vector(X1, Y1);
            Vector test2 = new Vector(X2, Y2);
            double test = test1.DotProduct(test2);
            Assert.Equal(dp, test);
        }

        [Theory]
        [InlineData(2, 2, 1, -1, -4)]
        public void CrossProductTest(double X1, double Y1, double X2, double Y2, double cp)
        {
            Vector test1 = new Vector(X1, Y1);
            Vector test2 = new Vector(X2, Y2);
            double test = test1.CrossProduct(test2);
            Assert.Equal(cp, test);
        }
    }
}