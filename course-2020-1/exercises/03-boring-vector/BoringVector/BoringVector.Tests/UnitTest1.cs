using System;
using Xunit;
/*
    Атрибуты [Fact] и [Theory] означают, что данный метод является тестовым, т.е. TestRunner должен его запускать. 
    Совсем обывательски - разница в том, что метод с [Theory] дает возможность тестовому методу принимать аргументы
    и быть запущенным с разными входными данными.
*/
/*  SquareLength
            Add
            Scale
            DotProduct
            CrossProduct
*/
namespace BoringVector.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(5, 0, 25)]
        [InlineData(-3, 4, 25)]
        [InlineData(8, 6, 100)]
        public void TestSquareLength(double x, double y, double sqr_length)
        {
            var vec = new Vector(x, y);
            Assert.Equal(vec.SquareLength(), sqr_length);
        }

        [Theory]
        [InlineData(0, 0, 2.2, 1, 2.2, 1)]
        [InlineData(3, 0.5, -3, -1.5, 0, -1)]
        [InlineData(100, 50.5, -50, 50.5, 50, 101)]
        public void TestAdd(double x_1, double y_1, double x_2, double y_2, double x_sum, double y_sum)
        {
            var vec_1 = new Vector(x_1, y_1);
            var vec_2= new Vector(x_2, y_2);
            var vec_result = new Vector(x_sum, y_sum);
            Assert.Equal(vec_1.Add(vec_2), vec_result);
        }


        [Theory]
        [InlineData(0, 2, 2.2, 0, 4.4)]
        [InlineData(3, 2, -2, -6, -4)]
        [InlineData(100, 50.5, 0.5, 50, 25.25)]
        public void TestScale(double x_1, double y_1, double k, double x_res, double y_res)
        {
            var vec = new Vector(x_1, y_1);
            var vec_res = new Vector(x_res, y_res);
            var vec_scale_result = vec.Scale(k);
            Assert.Equal(vec_scale_result, vec_res);
        }
        [Theory]
        [InlineData(0, 2, 2.2, 0, 0)]
        [InlineData(3.1, 0.2, -1.2, -0.3, -3.78)]
        [InlineData(4, 3, 4, 3, 25)]
        public void TestDotProduct(double x_1, double y_1, double x_2, double y_2, double dp)
        {
            var vec_1 = new Vector(x_1, y_1);
            var vec_2 = new Vector(x_2, y_2);
            Assert.Equal(vec_1.DotProduct(vec_2), dp);
        }
        [Theory]
        [InlineData(0, 4, 2, 0, 8)]
        [InlineData(4.4, 1.2, 2.2, 0.6, 0)]
        [InlineData(-1, -3, 2, 4, 2)]
        public void TestCrossProduct(double x_1, double y_1, double x_2, double y_2, double cp)
        {
            var vec_1 = new Vector(x_1, y_1);
            var vec_2 = new Vector(x_2, y_2);
            Assert.Equal(vec_1.CrossProduct(vec_2), cp);
        }
        [Fact]
        public void TestToString()
        {
            var vec_1 = new Vector(0.5, -0.5);
            Assert.Equal("(0,5; -0,5)", vec_1.ToString());
        }

    }
}
