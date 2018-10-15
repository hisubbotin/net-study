using System;
using Xunit;

namespace BoringVector.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1.1, 1.21)]
        [InlineData(1, 1, 2)]
        [InlineData(3, 4, 25)]
        public void TestSquareLength(double x, double y, double length)
        {
            Assert.True(Math.Abs(new Vector(x, y).SquareLength() - length) < 1e-6);
        }

        [Theory]
        [InlineData(1, 7, 2.3, 4.5, 3.3, 11.5)]
        [InlineData(1.31, 2, 0, 0.005, 1.31, 2.005)]
        public void TestAdd(double v_x, double v_y, double u_x, double u_y, double x, double y)
        {
            Vector b = new Vector(v_x, v_y).Add(new Vector(u_x, u_y));
            Assert.Equal(x, b.x);
            Assert.Equal(y, b.y);
        }

        [Theory]
        [InlineData(1, 1, 0, 0, 0)]
        [InlineData(1, 3, 3, 3, 9)]
        [InlineData(2, 7, 2.5, 5, 17.5)]
        public void TestScale(double v_x, double v_y, double k, double x, double y)
        {
            Vector b = new Vector(v_x, v_y).Scale(k);
            Assert.Equal(x, b.x);
            Assert.Equal(y, b.y);
        }

        [Theory]
        [InlineData(1, 0, 0, 2, 0)]
        [InlineData(2, 5, 1, 3, 17)]
        public void TestDotProduct(double v_x, double v_y, double u_x, double u_y, double dot_product)
        {
            Assert.Equal(dot_product, new Vector(v_x, v_y).DotProduct(new Vector(u_x, u_y)));
        }



        [Theory]
        [InlineData(1, 0, 0, 2, 2)]
        [InlineData(2, 3, 4, 5, -2)]
        [InlineData(2.4, 2.4, 1.1, 1.1, 0)]
        public void TestCrossProduct(double x1, double y1, double x2, double y2, double result)
        {
            Assert.Equal(result, new Vector(x1, y1).CrossProduct(new Vector(x2, y2)));
        }

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(1, 0, false)]
        public void TestIsZero(double x, double y, bool result)
        {
            Assert.Equal(result, VectorExtensions.IsZero(new Vector(x, y)));
        }

        [Theory]
        [InlineData(0,228, 0, 1)]
        public void TestNormalize(double v_x, double v_y, double x, double y)
        {
            Vector v = VectorExtensions.Normalize(new Vector(v_x, v_y));
            Assert.Equal(x, v.x);
            Assert.Equal(y, v.y);
        }

        [Theory]
        [InlineData(0, 1, 1, 0, -System.Math.PI / 2)]
        public void TestAngleBetween(double v_x, double v_y, double u_x, double u_y, double result)
        {
            Assert.Equal(result, VectorExtensions.GetAngleBetween(new Vector(v_x, v_y), new Vector(u_x, u_y)));
        }

        [Theory]
        [InlineData(0, 1, 1, 0, Relation.Orthogonal)]
        [InlineData(1, 0, 0, 228, Relation.Orthogonal)]
        [InlineData(2, 3, 4, 6, Relation.Parallel)]
        [InlineData(1, 1, -500, -500, Relation.Parallel)]
        [InlineData(11, 12, 12, 11, Relation.GeneralCase)]
        public void TestGetRelation(double v_x, double v_y, double u_x, double u_y, Relation result)
        {
            Assert.Equal(result, VectorExtensions.GetRelation(new Vector(v_x, v_y), new Vector(u_x, u_y)));
        }
    }
}

