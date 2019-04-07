using System;
using Xunit;
using BoringVector;
using static BoringVector.VectorExtensions;

namespace VectorTest
{
    public class UnitTest1
    {

        [Fact]
        public void testLen()
        {
            var v = new Vector(3, 4);
            var a = v.SquareLength();
            Assert.True(Double.Equals(v.SquareLength(), 25.0));
        }

        [Fact]
        public void testAdd()
        {
            var v = new Vector(3, 4);
            var v2 = new Vector(3, 4);
            var v3 = v.Add(v2);
            Assert.True(Double.Equals(v3.X, 6.0) && Double.Equals(v3.Y, 8.0));
        }

        [Fact]
        public void testScale()
        {
            var v = new Vector(3, 4);
            var v2 = v.Scale(2);
            Assert.True(Double.Equals(v2.X, 6.0) && Double.Equals(v2.Y, 8.0));
        }

        [Fact]
        public void testDotProduct()
        {
            var v = new Vector(3, 4);
            var v2 = new Vector(3, 4);
            Assert.True(Double.Equals(v.DotProduct(v2), 25.0));
        }

        [Fact]
        public void testScale2()
        {
            var v = new Vector(3, 4);
            var v2 =  v * 2;
            Assert.True(Double.Equals(v2.X, 6.0) && Double.Equals(v2.Y, 8.0));
        }

        [Fact]
        public void testDotCrossProduct()
        {
            var v = new Vector(3, 4);
            var v2 = new Vector(3, 4);
            Assert.True(Double.Equals(v.CrossProduct(v2), 0.0));
        }

        [Fact]
        public void testAdd2()
        {
            var v = new Vector(3, 4);
            var v2 = new Vector(3, 4);
            var v3 = v + v2;
            Assert.True(Double.Equals(v3.X, 6.0) && Double.Equals(v3.Y, 8.0));
        }

        [Fact]
        public void testunMin()
        {
            var v = new Vector(3, 4);
            var v2 = -v;
            Assert.True(Double.Equals(v2.X, -3.0) && Double.Equals(v2.Y, -4.0));
        }

        [Fact]
        public void testSub()
        {
            var v = new Vector(3, 4);
            var v2 = new Vector(3, 4);
            var v3 = v - v2;
            Assert.True(Double.Equals(v3.X, 0.0) && Double.Equals(v3.Y, 0.0));
        }

        [Fact]
        public void testscale3()
        {
            var v = new Vector(3, 4);
            var v2 = v / 0.5;
            Assert.True(Double.Equals(v2.X, 6.0) && Double.Equals(v2.Y, 8.0));
        }

        [Theory]
        [InlineData(3.0, 4.0, false)]
        [InlineData(0.0, 0.0, true)]
        public void testIsZero(double x, double y, bool isZero)
        {
            Vector v = new Vector(x, y);
            Assert.Equal(v.IsZero(), isZero);
        }

        [Fact]
        public void testNormalize()
        {
            var v = new Vector(4, 3);
            var v2 = v.Normalize(); 
            Assert.True(Double.Equals(v2.X, 0.8));
            Assert.True(Double.Equals(v2.Y, 0.6));
        }

        [Theory]
        [InlineData(3.0, 4.0, 3.0, 4.0, 0.0)]
        [InlineData(3.0, 4.0, -4.0, 3.0, Math.PI / 2)]
        [InlineData(0.0, 0.0, 3.4, 3.4, 0.0)]
        public void testGetAngle(double x, double y, double x2, double y2, double angle)
        {
            Vector v = new Vector(x, y);
            Vector v2 = new Vector(x2, y2);
            Assert.Equal(v.GetAngleBetween(v2), angle);
        }

        [Theory]
        [InlineData(3.0, 4.0, 3.0, 4.0, VectorRelation.Parallel)]
        [InlineData(3.0, 4.0, -4.0, 3.0, VectorRelation.Orthogonal)]
        [InlineData(1.0, 0.0, 3.4, 3.4, VectorRelation.General)]
        internal void testRelation(double x, double y, double x2, double y2, VectorRelation relation)
        {
            Vector v = new Vector(x, y);
            Vector v2 = new Vector(x2, y2);
            var r = v.GetRelation(v2);
            Assert.Equal(r, relation);
        }
    }
}
