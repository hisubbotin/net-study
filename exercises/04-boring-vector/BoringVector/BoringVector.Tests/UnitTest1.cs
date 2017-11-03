using System;
using Xunit;



namespace BoringVector.Tests
{
    public class UnitTest1
    {
        [Theory]

        [InlineData(1, 1, 2)]
        public void Test_SquareLength(double x, double y, double res)
        {
            Assert.Equal(new Vector(x, y).SquareLength(), res);
        }
 
        [Theory]
        [InlineData(1, 1, 1, 1, 2, 2)]
        public void Test_Add(double x1, double y1, double x2, double y2, double x, double y)
        {
            Assert.Equal(new Vector(x1, y1) + new Vector(x2, y2), new Vector(x, y));
        }

        [Theory]
        [InlineData(1, 1, 2, 2, 2)]
        public void Test_Scale(double x, double y, double k, double res_x, double res_y)
        {
            Assert.Equal(new Vector(x, y).Scale(k), new Vector(res_x, res_y));
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 2)]
        public void Test_DotProduct(double x1, double y1, double x2, double y2, double res)
        {
            Assert.Equal(new Vector(x1, y1).DotProduct(new Vector(x2, y2)), res);
        }

        [Theory]
        [InlineData(1, -1, -2, 2, 0)]
        public void Test_CrossProductd(double x1, double y1, double x2, double y2, double res)
        {
            Assert.Equal(new Vector(x1, x1).CrossProduct(new Vector(x2, y2)), res);
        }
    }
}