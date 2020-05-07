using System;
using Xunit;

namespace BoringVector.Test
{
    public class UnitTest
    {
        [Theory]
        [InlineData(3, 3, 18)]
        [InlineData(-3, 2, 13)]
        public void TestSquareLength(double x, double y, double sqr_length)
        {
            var vector = new Vector(x, y);
            Assert.Equal(vector.SquareLength(), sqr_length);
        }

        [Theory]
        [InlineData(0, 0, 4.4, 2.6, 4.4, 2.6)]
        [InlineData(6, 4, -9, -5, -3, -1)]
        [InlineData(6, 17, -6, -5, 0, 12)]
        public void TestAdd(double x1, double y1, double x2, double y2, double x_sum, double y_sum)
        {
            var vector1 = new Vector(x1, y1);
            var vector2= new Vector(x2, y2);
            var result = new Vector(x_sum, y_sum);
            Assert.Equal(vector1.Add(vector2), result);
        }


        [Theory]
        [InlineData(0, 2, 5, 0, 10)]
        [InlineData(0, 3, 1.6, 0, 4.8)]
        [InlineData(10, 160.5, 0, 0, 0)]
        public void TestScale(double x1, double y1, double k, double x_res, double y_res)
        {
            var vector = new Vector(x1, y1);
            var scale = vector.Scale(k);
            var result = new Vector(x_res, y_res);
            Assert.Equal(scale, result);
        }
        [Theory]
        [InlineData(0, -1, -33, 0, 0)]
        [InlineData(2, 5, 2, 5, 29)]
        public void TestDotProduct(double x1, double y1, double x2, double y2, double dot_product)
        {
            var vector1 = new Vector(x1, y1);
            var vector2 = new Vector(x2, y2);
            Assert.Equal(vector1.DotProduct(vector2), dot_product);
        }
        [Theory]
        [InlineData(0, 2, 4, 0, 8)]
        [InlineData(4, 2, 2, 1, 0)]
        public void TestCrossProduct(double x1, double y1, double x2, double y2, double cross_product)
        {
            var vector1 = new Vector(x1, y1);
            var vector2 = new Vector(x2, y2);
            Assert.Equal(vector1.CrossProduct(vector2), cross_product);
        }
        [Fact]
        public void TestToString()
        {
            var vec_1 = new Vector(5, -2);
            Assert.Equal("(5; -2)", vec_1.ToString());
        }

    }
}