using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTests
    {
        [Theory]
        [InlineData(3, 4, 25)]
        [InlineData(3, -4, 25)]
        public void Test_SquareLength_ReturnsCorrectValue(double x, double y, double expected)
        {
            Assert.Equal(new Vector(x, y).SquareLength(), expected);
        }
        
        [Theory]
        [InlineData(1, 2, 3, 4, 4, 6)]
        [InlineData(-1, -2, 3, 4, 2, 2)]
        public void Test_Add_ReturnsCorrectValue(double xV, double yV, double xU, double yU, double xExpected, double yExpected)
        {
            Assert.Equal(new Vector(xV, yV) + new Vector(xU, yU), new Vector(xExpected, yExpected));
        }
        
        [Theory]
        [InlineData(1, 1, 0, 0, 0)]
        [InlineData(2, -2, -1, -2, 2)]
        [InlineData(-2, 2, 1.3, -2.6, 2.6)]
        public void Test_Scale_ReturnsCorrectValue(double x, double y, double k, double xExpected, double yExpected)
        {
            Assert.Equal(new Vector(x, y).Scale(k), new Vector(xExpected, yExpected));
        }

        [Theory]
        [InlineData(1, 0, 1, 0, 1)]
        [InlineData(1, -2, 3, -4, 11)]
        public void Test_DotProduct_ReturnsCorrectValue(double xV, double yV, double xU, double yU, double expected)
        {
            Assert.Equal(new Vector(xV, yV).DotProduct(new Vector(xU, yU)), expected);
        }

        [Theory]
        [InlineData(1, -1, -1, 1, 0)]
        [InlineData(1, 2, 3, 4, -2)]
        public void Test_CrossProduct_ReturnsCorrectValue(double xV, double yV, double xU, double yU, double expected)
        {
            Assert.Equal(new Vector(xV, yV).CrossProduct(new Vector(xU, yU)), expected);
        }
    }
}
