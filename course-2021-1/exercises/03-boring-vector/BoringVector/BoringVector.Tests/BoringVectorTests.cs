using Xunit;
using System.Collections.Generic;
namespace BoringVector.Tests
{
    public class BoringVectorTests
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(3, 4, 25)]
        internal void Test_SquareLength(double v_x, double v_y, double square_length)
        {

            Assert.Equal(new Vector(v_x, v_y).SquareLength(), square_length);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(3, 4, 45, 16, 48, 20)]
        internal void Test_Add(double v_x, double v_y, double u_x, double u_y, double res_x, double res_y)
        {

            Assert.Equal(new Vector(v_x, v_y).Add(new Vector(u_x, u_y)), new Vector(res_x, res_y));
        }

        [Theory]
        [InlineData(0, 0, 5, 0, 0)]
        [InlineData(600, 200, 0, 0, 0)]
        [InlineData(3, 4, 10, 30, 40)]
        internal void Test_Scale(double v_x, double v_y, double k, double res_x, double res_y)
        {

            Assert.Equal(new Vector(v_x, v_y).Scale(k), new Vector(res_x, res_y));
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(0, 12, 15, 0, 0)]
        [InlineData(-12, 15, 15, 12, 0)]
        [InlineData(0, 0, 15, -12, 0)]
        [InlineData(21, 7, 1, 3, 42)]
        internal void Test_DotProduct(double v_x, double v_y, double u_x, double u_y, double res)
        {

            Assert.Equal(new Vector(v_x, v_y).DotProduct(new Vector(u_x, u_y)), res);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(0, 12, 15, 0, -180)]
        [InlineData(0, 15, 0, 0, 0)]
        [InlineData(0, 0, 15, -12, 0)]
        [InlineData(21, 7, 3, 1, 0)]
        [InlineData(21, 7, -3, 1, 42)]
        internal void Test_CrossProduct(double v_x, double v_y, double u_x, double u_y, double res)
        {

            Assert.Equal(new Vector(v_x, v_y).CrossProduct(new Vector(u_x, u_y)), res);
        }
    }
}
