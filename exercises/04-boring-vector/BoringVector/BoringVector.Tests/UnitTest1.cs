using System;
using Xunit;
using System.Collections.Generic;

namespace BoringVector.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(2, 2, 8)]
        public void SquareLength_PositeveCoordinates_Returns_PositiveValue(double x, double y, double result)
        {
            Assert.Equal(new Vector(x, y).SquareLength(), result);
        }

        [Theory]
        [InlineData(-2, -2, 8)]
        public void SquareLength_NegativeCoordinates_Returns_PositiveValue(double x, double y, double result)
        {
            Assert.Equal(new Vector(x, y).SquareLength(), result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        public void SquareLength_ZeroVector_Returns_ZeroValue(double x, double y, double result)
        {
            Assert.Equal(new Vector(x, y).SquareLength(), result);
        }


        [Theory]
        [InlineData(2, 2, 1, 1, 3, 3)]
        public void Add_WithPositeveCoordinates_Returns_NewVector(double x1, double y1, double x2, double y2, double x, double y)
        {
            Assert.Equal(new Vector(x1, y1) + new Vector(x2, y2), new Vector(x, y));
        }

        [Theory]
        [InlineData(-1, 0, 0, -1, -1, -1)]
        public void Add_WithNegativeAndZeroCoordinates_Returns_NewVector(double x1, double y1, double x2, double y2, double x, double y)
        {
            Assert.Equal(new Vector(x1, y1) + new Vector(x2, y2), new Vector(x, y));
        }

        [Theory]
        [InlineData(2, 2, 2, 4, 4)]
        public void Scale_VectorByPositiveNumber_Returns_NewVector(double x1, double y1, double k, double x, double y)
        {
            Assert.Equal(new Vector(x1, y1).Scale(k), new Vector(x, y));
        }

        [Theory]
        [InlineData(2, 2, -2, -4, -4)]
        public void Scale_VectorByNegativeNumber_Returns_NewVector(double x1, double y1, double k, double x, double y)
        {
            Assert.Equal(new Vector(x1, y1).Scale(k), new Vector(x, y));
        }

        [Theory]
        [InlineData(2, 3, 2, 1, 7)]
        public void DotProduct_WithPositeveCoordinates_Returns_PositiveValue(double x1, double y1, double x2, double y2, double result)
        {
            Assert.Equal(new Vector(x1, y1).DotProduct(new Vector(x2, y2)), result);
        }

        [Theory]
        [InlineData(1, -1, -1, -1, 0)]
        public void DotProduct_WithNegativeAndPositiveCoordinates_Returns_ZeroValue(double x1, double y1, double x2, double y2, double result)
        {
            Assert.Equal(new Vector(x1, y1).DotProduct(new Vector(x2, y2)), result);
        }

        [Theory]
        [InlineData(1, 1, 2, 5, 3)]
        public void CrossProductd_WithPositeveCoordinates_Returns_PositiveValue(double x1, double y1, double x2, double y2, double result)
        {
            Assert.Equal(new Vector(x1, y1).CrossProduct(new Vector(x2, y2)), result);
        }
        
        [Theory]
        [InlineData(1, 1, 5, 2, -3)]
        public void CrossProductd_WithPositeveCoordinates_Returns_NegativeValue(double x1, double y1, double x2, double y2, double result)
        {
            Assert.Equal(new Vector(x1, y1).CrossProduct(new Vector(x2, y2)), result);
        }

        [Theory]
        [InlineData(-1, 1, 5, 2, -7)]
        public void CrossProductd_WithNegativeAndPositiveCoordinates_Returns_NegativeValue(double x1, double y1, double x2, double y2, double result)
        {
            Assert.Equal(new Vector(x1, y1).CrossProduct(new Vector(x2, y2)), result);
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 0)]
        public void CrossProductd_WithPositeveCoordinates_Returns_ZeroValue(double x1, double y1, double x2, double y2, double result)
        {
            Assert.Equal(new Vector(x1, y1).CrossProduct(new Vector(x2, y2)), result);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        public void CrossProductd_WithZeroCoordinates_Returns_ZeroValue(double x1, double y1, double x2, double y2, double result)
        {
            Assert.Equal(new Vector(x1, y1).CrossProduct(new Vector(x2, y2)), result);
        }
    }
}
