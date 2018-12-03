using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTests
    {
        public static double EPS = 1e-6;

        [Theory]
        [InlineData(1, 2, 5)]
        [InlineData(0.5, 3.2, 10.49)]
        [InlineData(1.1, 2000, 4000001.21)]
        [InlineData(432, -123, 201753)]
        public void Test_SquareLength(double X, double Y, double res)
        {
            Vector v = new Vector(X, Y);

            Assert.True(Math.Abs(v.SquareLength() - res) <= EPS);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 4, 6)]
        [InlineData(14, -2, -34, 15, -20, 13)]
        [InlineData(0.7, 2.4, -8.5, 19, -7.8, 21.4)]
        [InlineData(4.25, 21, -67, -12, -62.75, 9)]
        public void Test_Add(double X1, double Y1, double X2, double Y2, double resX, double resY)
        {
            Vector v = new Vector(X1, Y1);
            Vector u = new Vector(X2, Y2);
            Vector vPlusU = v.Add(u);
            Assert.True(Math.Abs(vPlusU.X - resX) <= EPS && Math.Abs(vPlusU.Y - resY) <= EPS);
        }

        [Theory]
        [InlineData(1, 2, 3, 3, 6)]
        [InlineData(14, -2, -34, -476, 68)]
        [InlineData(0.7, 2.4, -8.5, -5.95, -20.4)]
        [InlineData(4.25, 21, -67, -284.75, -1407)]
        public void Test_Scale(double X, double Y, double k, double resX, double resY)
        {
            Vector v = new Vector(X, Y);
            Vector vMulK = v.Scale(k);
            Assert.True(Math.Abs(vMulK.X - resX) <= EPS && Math.Abs(vMulK.Y - resY) <= EPS);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 11)]
        [InlineData(14, -2, -34, 15, -506)]
        [InlineData(0.7, 2.4, -8.5, 19, 39.65)]
        [InlineData(4.25, 21, -67, -12, -536.75)]
        public void Test_DotProduct(double X1, double Y1, double X2, double Y2, double res)
        {
            Vector v = new Vector(X1, Y1);
            Vector u = new Vector(X2, Y2);
            double vDotU = v.DotProduct(u);
            Assert.True(Math.Abs(vDotU - res) <= EPS);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 2)]
        [InlineData(14, -2, -34, 15, 142)]
        [InlineData(0.7, 2.4, -8.5, 19, 33.7)]
        [InlineData(4.25, 21, -67, -12, 1356)]
        public void Test_CrossProduct(double X1, double Y1, double X2, double Y2, double res)
        {
            Vector v = new Vector(X1, Y1);
            Vector u = new Vector(X2, Y2);
            double vCrossU = v.CrossProduct(u);
            Assert.True(Math.Abs(vCrossU - res) <= EPS);
        }
    }
}