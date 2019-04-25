using System;
using Xunit;

namespace BoringVector.Test
{
    public class VectorTest
    {
        [Fact]
        public void Test_Add()
        {
            Vector v = new Vector(3, -5);
            Vector u = new Vector(-3.5, 6.23);
            Vector res = new Vector(-0.5, 1.23);
            Assert.True(v + u == res);
        }

        [Fact]
        public void Test_Sub()
        {
            Vector v = new Vector(3, -5);
            Vector u = new Vector(-3.5, 6.23);
            Vector res = new Vector(6.5, -11.23);
            Assert.True(v - u == res);
        }

        [Fact]
        public void Test_Scale()
        {
            Vector v = new Vector(1.2, -2.0);
            double k = 5.0;
            Vector resMult = new Vector(6.0, -10.0);
            Assert.True(v * k == resMult);
            Assert.True(k * v == resMult);
            Vector resDiv = new Vector(0.24, -0.4);
            Assert.True(v / k == resDiv);
        }

        [Fact]
        public void Test_Unary()
        {
            Vector v = new Vector(-1234.3172, 849.123516);
            Vector u = new Vector(1234.3172, -849.123516);
            Assert.True(v == +v);
            Assert.True(v == -u);
        }

        private static bool DoubleEqual(double first, double second) => first - second < Vector.eps && first - second > -Vector.eps;

        [Fact]
        public void Test_Dot()
        {
            Vector v = new Vector(5.3, 7.8);
            Vector u = new Vector(-3.6, 2.9);
            double res = 3.54;
            Assert.True(DoubleEqual(v.DotProduct(u), res));
        }

        [Fact]
        public void Test_Cross()
        {
            Vector v = new Vector(5.3, 7.8);
            Vector u = new Vector(-3.6, 2.9);
            double res = 43.45;
            Assert.True(DoubleEqual(v.CrossProduct(u), res));
        }
    }

    public class VectorExtensionsTest
    {
        [Theory]
        [InlineData(1, 0, 0, 1, VectorRelation.Orthogonal)]
        [InlineData(0, 0, 5, -4, VectorRelation.Parallel)]
        [InlineData(0, 0.1, 5, -4, VectorRelation.General)]
        [InlineData(-5, 4, 5, -4, VectorRelation.Parallel)]
        [InlineData(-2, -3, 3, 2, VectorRelation.General)]
        [InlineData(5.00001, -4, 5, -4, VectorRelation.Parallel)]
        public void Test_Relation(double vx, double vy, double ux, double uy, VectorRelation relation)
        {
            Vector a = new Vector(1, 1);
            Assert.Equal(1, a.X);
            Vector v = new Vector(vx, vy);
            Vector u = new Vector(ux, uy);
            Assert.Equal(relation, v.GetRelation(u));
        }
    }
}
