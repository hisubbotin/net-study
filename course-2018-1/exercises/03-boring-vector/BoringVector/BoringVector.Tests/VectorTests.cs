using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTests
    {
        public static double EPS = 1e-6;

        [Theory]
        [InlineData(1, 2)]
        [InlineData(0.5, 3.2)]
        [InlineData(1.1, 2000)]
        [InlineData(432, -123)]
        public void Test_SquareLength(double X, double Y)
        {
            Vector v = new Vector(X, Y);

            Assert.True(Math.Abs(v.SquareLength() - X * X - Y * Y) <= EPS);
        }

        [Theory]
        [InlineData(1, 2, 3, 4)]
        [InlineData(14, -2, -34, 15)]
        [InlineData(0.7, 2.4, -8.5, 19)]
        [InlineData(4.25, 21, -67, -12)]
        public void Test_Add(double X1, double Y1, double X2, double Y2)
        {
            Vector v = new Vector(X1, Y1);
            Vector u = new Vector(X2, Y2);
            Vector vPlusU = v.Add(u);
            Assert.True(Math.Abs(vPlusU.X - X1 - X2) <= EPS && Math.Abs(vPlusU.Y - Y1 - Y2) <= EPS);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(14, -2, -34)]
        [InlineData(0.7, 2.4, -8.5)]
        [InlineData(4.25, 21, -67)]
        public void Test_Scale(double X, double Y, double k)
        {
            Vector v = new Vector(X, Y);
            Vector vMulK = v.Scale(k);
            Assert.True(Math.Abs(vMulK.X - X * k) <= EPS && Math.Abs(vMulK.Y - Y * k) <= EPS);
        }

        [Theory]
        [InlineData(1, 2, 3, 4)]
        [InlineData(14, -2, -34, 15)]
        [InlineData(0.7, 2.4, -8.5, 19)]
        [InlineData(4.25, 21, -67, -12)]
        public void Test_DotProduct(double X1, double Y1, double X2, double Y2)
        {
            Vector v = new Vector(X1, Y1);
            Vector u = new Vector(X2, Y2);
            double vDotU = v.DotProduct(u);
            Assert.True(Math.Abs(vDotU - X1 * X2 - Y1 * Y2) <= EPS);
        }

        [Theory]
        [InlineData(1, 2, 3, 4)]
        [InlineData(14, -2, -34, 15)]
        [InlineData(0.7, 2.4, -8.5, 19)]
        [InlineData(4.25, 21, -67, -12)]
        public void Test_CrossProduct(double X1, double Y1, double X2, double Y2)
        {
            Vector v = new Vector(X1, Y1);
            Vector u = new Vector(X2, Y2);
            double vCrossU = v.CrossProduct(u);
            Assert.True(Math.Abs(vCrossU - Math.Abs(X1 * Y2 - Y1 * X2)) <= EPS);
        }
    }
}