using System;
using Xunit;

namespace BoringVector.Test
{
    public class VectorTest
    {
        [Fact]
        public void Test_add()
        {
            Vector v = new Vector { X = 1.0, Y = 3.2 };
            Vector u = new Vector { X = -2.0, Y = 1.0 };
            Vector res = new Vector { X = -1.0, Y = 4.2 };
            Assert.True(v + u == res);
        }

        [Fact]
        public void Test_sub()
        {
            Vector v = new Vector { X = 3.0, Y = -100000 };
            Vector u = new Vector { X = 1.0, Y = -1.0};
            Vector res = new Vector { X = 2.0, Y = -99999 };
            Assert.True(v - u == res);
        }

        [Fact]
        public void Test_scale()
        {
            Vector v = new Vector { X = 2, Y = 5 };
            double k = -0.7;
            Vector res = new Vector { X = -1.4, Y = -3.5 };
            Assert.True(v * k == res);
            Assert.True(k * v == res);
        }

        [Fact]
        public void Test_div()
        {
            Vector v = new Vector { X = 2, Y = 5 };
            double k = 2;
            Vector res = new Vector { X = 1, Y = 2.5 };
            Assert.True(v / k == res);
        }

        private static bool Cmp(double first, double second)
        {
            return Math.Abs(first - second) < Vector.eps;
        }

        [Fact]
        public void Test_Dot()
        {
            Vector v = new Vector { X = 3, Y = 4 };
            Vector u = new Vector { X = -1.2, Y = 2.5 };
            double res = 6.4;
            Assert.True(Cmp(v.DotProduct(u), res));
        }

        [Fact]
        public void Test_Cross()
        {
            Vector v = new Vector { X = 1, Y = 2 };
            Vector u = new Vector { X = 3, Y = 4 };
            double res = -2.0;
            Assert.True(Cmp(v.CrossProduct(u), res));
        }
    }

    public class Test_Extensions
    {
        [Theory]
        [InlineData(0, 0, 0, 0, VectorRelation.General)]
        [InlineData(0, 0, 1, 1, VectorRelation.General)]
        [InlineData(1, 0, 0, 1, VectorRelation.Orthogonal)]
        [InlineData(-3, 2, 1.5, -1, VectorRelation.Parallel)]
        [InlineData(1, 2, -2, -1, VectorRelation.General)]
        [InlineData(1, 2, -2, 1, VectorRelation.Orthogonal)]
        public void Test_Relation(double x1, double y1, double x2, double y2, VectorRelation relation)
        {
            Vector v = new Vector { X = x1, Y = y1 };
            Vector u = new Vector { X = x2, Y = y2 };
            Assert.Equal(relation, VectorExtensions.GetRelation(v, u));
        }
    }
}