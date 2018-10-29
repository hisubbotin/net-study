using System;
using Xunit;
namespace BoringVector.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void AddTest()
        {
            Vector vector = new Vector(1, -1);
            Assert.True(vector.Add(-vector).IsZero());
        }

        [Theory]
        [InlineData(1, -1, 2)]
        [InlineData(2, 2, 8)]
        [InlineData(2, -2, 8)]
        public void SquareLengthTest(double x, double y, double res)
        {
            Assert.Equal(res, new Vector(x, y).SquareLength());
        }

        [Theory]
        [InlineData(1, -1)]
        [InlineData(2, 2)]
        [InlineData(2, -2)]
        public void NormalizeLengthTest(double x, double y)
        {
            Assert.InRange<Double>( new Vector(x, y).Normalize().SquareLength(), 1.0 - 1e-6, 1.0 + 1e-6);
        }

        [Theory]
        [InlineData(1, 0, 0, 1, VectorExtensions.Relation.Orthogonal)]
        [InlineData(2, 2, 4, 4, VectorExtensions.Relation.Parallel)]
        [InlineData(1, 1, 1, 2, VectorExtensions.Relation.General)]
        internal void GetRelationTest(double x, double y, double x2, double y2, VectorExtensions.Relation relation)
        {
            Assert.Equal(relation, new Vector(x, y).GetRelation(new Vector(x2, y2)));
        }

        [Fact]
        public void ScaleTest()
        {
            Vector vector = new Vector(1, -1);
            Assert.Equal(200, vector.Scale(10).SquareLength());
        }

        [Fact]
        public void DotProductTest()
        {
            Vector vector1 = new Vector(1, -1);
            Vector vector2 = new Vector(-1, -1);
            Assert.Equal(0, vector1.DotProduct(vector2));
        }

        [Fact]
        public void CrossProductTest()
        {
            Vector vector1 = new Vector(1, -1);
            Vector vector2 = new Vector(1, 1);
            Assert.Equal(2, vector1.CrossProduct(vector2));
        }
    }
}
