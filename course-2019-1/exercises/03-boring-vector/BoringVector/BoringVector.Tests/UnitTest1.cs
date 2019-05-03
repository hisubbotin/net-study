using System;
using Xunit;
using static BoringVector.VectorExtenstions;

namespace BoringVector.Tests
{
    public class VectorTest
    {
        [Fact]
        public void Test_Add()
        {
            Vector v = new Vector(-2.8, -9.8);
            Vector u = new Vector(-17.5, 8.2);
            Assert.True(v + u == new Vector(-20.3, -1.6));
        }

        [Fact]
        public void Test_Sub()
        {
            Vector v = new Vector(-2.8, -9.8);
            Vector u = new Vector(-17.5, 8.2);
            Assert.True(v - u == new Vector(14.7, -18));
        }

        [Fact]
        public void Test_Scale()
        {
            Vector v = new Vector(-2.8, -9.8);
            double k = 6.1;
            Assert.True(v * k == new Vector(-17.08, -59.78));

            Assert.True(k * v == new Vector(-17.08, -59.78));

            double l = -4;
            Assert.True(v / l == new Vector(0.7, 2.45));
        }

        [Fact]
        public void Test_Unary()
        {
            Vector v = new Vector(-3.12, 0.03);
            Vector u = new Vector(3.12, -0.03);
            Assert.True(v.x == (+v).x);
            Assert.True(v.y == (+v).y);

            Assert.True(v.x == (-u).x);
            Assert.True(v.y == (-u).y);
        }

        [Theory]
        [InlineData(9.0, 7.0, 1.0, -9.0, -54.0)]
        [InlineData(-6.0, 2.0, -8.0, -3.0, 42.0)]
        [InlineData(-9.0, 5.0, 10.0, -4.0, -110.0)]
        [InlineData(5.2, -1.3, -4.6, -2.2, -21.06)]
        [InlineData(-3.4, 9.5, 8.4, -2.6, -53.26)]
        [InlineData(-5.5, 1.6, -4.0, -1.2, 20.08)]
        public void Test_Dot(double vx, double vy, double ux, double uy, double result)
        {
            Vector v = new Vector(vx, vy);
            Vector u = new Vector(ux, uy);
            //Assert.True(Double.Equals(v.DotProduct(u), result));
            Assert.True(Math.Abs(v.DotProduct(u) - result) < 1e-6);
        }

        [Theory]
        [InlineData(1.0, 10.0, -3.0, 10.0, 40.0)]
        [InlineData(3.0, -4.0, 4.0, 9.0, 43.0)]
        [InlineData(-7.0, 4.0, -9.0, 10.0, -34.0)]
        [InlineData(6.6, -0.1, -3.8, 5.2, 33.94)]
        [InlineData(-1.9, 7.6, 6.7, -8.9, -34.01)]
        [InlineData(0.8, 5.4, 9.4, -8.2, -57.32)]
        public void Test_Cross(double vx, double vy, double ux, double uy, double result)
        {
            Vector v = new Vector(vx, vy);
            Vector u = new Vector(ux, uy);
            var cross = v.CrossProduct(u);
            //Assert.True(Double.Equals(cross, result));
            Assert.True(Math.Abs(cross - result) < 1e-6);
        }
    }
}
