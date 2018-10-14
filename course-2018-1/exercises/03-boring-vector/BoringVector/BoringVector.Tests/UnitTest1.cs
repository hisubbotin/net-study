using System;
using Xunit;
using BoringVector;

namespace BoringVector.Tests
{
    public class VectorTests
    {
        [Fact]
        public void Test_SquareLength()
        {
            var vector = new Vector(1, 2);
            Assert.Equal(5, vector.SquareLength());
        }

        [Fact]
        public void Test_Add()
        {
            var vector1 = new Vector(1, 2);
            var vector2 = new Vector(3, 4);
            var vector_result = new Vector(4, 6);
            Assert.Equal(vector_result, vector1.Add(vector2));
        }

        [Fact]
        public void Test_Scale()
        {
            var vector1 = new Vector(1, 2);
            var k = 5;
            var vector_result = new Vector(5, 10);
            Assert.Equal(vector_result, vector1.Scale(k));
        }

        [Fact]
        public void Test_DotProduct()
        {
            var vector1 = new Vector(1, 2);
            var vector2 = new Vector(3, 4);
            var result = 11;
            Assert.Equal(result, vector1.DotProduct(vector2));
        }

        [Fact]
        public void Test_CrossProduct()
        {
            var vector1 = new Vector(1, 2);
            var vector2 = new Vector(3, 4);
            var result = -2;
            Assert.Equal(result, vector1.CrossProduct(vector2));
        }

        [Fact]
        public void Test_ToString()
        {
            var vector1 = new Vector(1, 3);
            var result = "(1; 3)";
            Assert.Equal(result, vector1.ToString());
        }

        [Fact]
        public void Test_Sum()
        {
            var vector1 = new Vector(1, 3);
            var vector2 = new Vector(2, 4);
            var vector_result = new Vector(3, 7);
            Assert.Equal(vector_result, vector1 + vector2);
        }

        [Fact]
        public void Test_Minus()
        {
            var vector1 = new Vector(1, 3);
            var vector2 = new Vector(2, 4);
            var vector_result = new Vector(-1, -1);
            Assert.Equal(vector_result, vector1 - vector2);
        }

        [Fact]
        public void Test_Prod()
        {
            var vector1 = new Vector(1, 3);
            var k = 5;
            var vector_result = new Vector(5, 15);
            Assert.Equal(vector_result, vector1 * k);
            Assert.Equal(vector_result, k * vector1);
        }

        [Fact]
        public void Test_Divide()
        {
            var vector1 = new Vector(1, 3);
            var k = 1;
            Assert.Equal(vector1, vector1 / k);
            Assert.Throws<DivideByZeroException>(() => vector1 / 0);
        }

        [Theory]
        [InlineData(1, 2, false)]
        [InlineData(0, 1, false)]
        [InlineData(1, 0, false)]
        [InlineData(0, 0, true)]
        public void Test_IsZero(double x, double y, bool result)
        {
            var vector = new Vector(x, y);
            Assert.Equal(result, vector.IsZero());
        }

        [Theory]
        [InlineData(0, 5, 0, 1)]
        [InlineData(0, 1, 0, 1)]
        [InlineData(0, 0, 0, 0)]
        public void Test_Normalize(double x, double y, double x1, double y1)
        {
            var vector = new Vector(x, y);
            var vector_result = new Vector(x1, y1);
            Assert.Equal(vector_result, vector.Normalize());
        }

        [Theory]
        [InlineData(1, 0, 1, 0, 0)]
        [InlineData(0, 0, 1, 1, 0)]
        [InlineData(1, 1, 0, 0, 0)]
        [InlineData(0, 0, 0, 0, 0)]
        public void Test_GetAngleBetween(double x, double y, double x1, double y1, double result)
        {
            var vector1 = new Vector(x, y);
            var vector2 = new Vector(x1, y1);
            Assert.Equal(result, vector1.GetAngleBetween(vector2));
        }

        [Theory]
        [InlineData(1, 0, 0, 1, VectorExtension.VectorRelation.Orthogonal)]
        [InlineData(1, 0, 5, 0, VectorExtension.VectorRelation.Parallel)]
        [InlineData(1, 2, 3, 1, VectorExtension.VectorRelation.General)]
        internal void Test_GetRelation(double x, double y, double x1, double y1, VectorExtension.VectorRelation result)
        {
            var vector1 = new Vector(x, y);
            var vector2 = new Vector(x1, y1);
            Assert.Equal(result, vector1.GetRelation(vector2));
        }
    }
}
