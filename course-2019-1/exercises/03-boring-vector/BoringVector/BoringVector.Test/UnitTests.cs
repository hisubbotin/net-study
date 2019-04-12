using System;
using Xunit;

namespace BoringVector.Test
{
    public class VectorTest
    {
        [Fact]
        public void Test_Add()
        {
            Vector v = new Vector { X = 3, Y = -5 };
            Vector u = new Vector { X = -3.5, Y = 6.23 };
            Vector res = new Vector { X = -0.5, Y = 1.23 };
            Assert.True(v + u == res);
        }

        [Fact]
        public void Test_Sub()
        {
            Vector v = new Vector { X = 3, Y = -5 };
            Vector u = new Vector { X = -3.5, Y = 6.23 };
            Vector res = new Vector { X = 6.5, Y = -11.23 };
            Assert.True(v - u == res);
        }

        [Fact]
        public void Test_Scale()
        {
            Vector v = new Vector { X = 1.2, Y = -2.0 };
            double k = 5.0;
            Vector resMult = new Vector { X = 6.0, Y = -10.0 };
            Assert.True(v * k == resMult);
            Assert.True(k * v == resMult);
            Vector resDiv = new Vector { X = 0.24, Y = -0.4 };
            Assert.True(v / k == resDiv);
        }

        [Fact]
        public void Test_Unary()
        {
            Vector v = new Vector { X = -1234.3172, Y = 849.123516 };
            Vector u = new Vector { X = 1234.3172, Y = -849.123516 };
            Assert.True(v == +v);
            Assert.True(v == -u);
        }

        private static bool DoubleEqual(double first, double second) => first - second < Vector.eps && first - second > -Vector.eps;

        [Fact]
        public void Test_Dot()
        {
            Vector v = new Vector { X = 5.3, Y = 7.8 };
            Vector u = new Vector { X = -3.6, Y = 2.9 };
            double res = 3.54;
            Assert.True(DoubleEqual(v.DotProduct(u), res));
        }

        [Fact]
        public void Test_Cross()
        {
            Vector v = new Vector { X = 5.3, Y = 7.8 };
            Vector u = new Vector { X = -3.6, Y = 2.9 };
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
            Vector v = new Vector { X = vx, Y = vy };
            Vector u = new Vector { X = ux, Y = uy };
            Assert.Equal(relation, VectorExtensions.GetRelation(v, u));
        }
    }
}
