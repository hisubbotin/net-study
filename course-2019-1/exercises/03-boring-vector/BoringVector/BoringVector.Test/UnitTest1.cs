using System;
using Xunit;
using BoringVector;


namespace BoringVector.Tests
{
    public class UnitTest1  
    {
        [Fact]
        public void SquareLength_test()
        {
            double x = 1;
            double y = 1; // =>
            double length_squared = 2;

            var v = new Vector(x, y);
            Assert.Equal(v.SquareLength(), length_squared, 6);
        }

        [Fact]
        public void Add_test()
        {
            double x1 = 3;
            double y1 = 3;
            double x2 = 3;
            double y2 = 3;
            double x3 = 6;
            double y3 = 6;
            var v = new Vector(x1, y1);
            var u = new Vector(x2, y2);
            Assert.Equal(v.Add(u), new Vector(x3, y3));
        }

        [Theory]
        [InlineData(-9, 12, -3)]
        [InlineData(0, 0, 0)]
        public void Scale_test(int x, int y, int factor)
        {
            var vec = new Vector(3, -4);
            Assert.Equal(new Vector(x, y), vec.Scale(factor));
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 2)]
        public void DotProduct_test(double x1, double y1, double x2, double y2, double res)
        {
            var v = new Vector(x1, y1);
            var u = new Vector(x2, y2);
            Assert.Equal(v.DotProduct(u), res);
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 0)]
        public void CrossProduct_test(double x1, double y1, double x2, double y2, double res)
        {
            var v = new Vector(x1, y1);
            var u = new Vector(x2, y2);
            Assert.Equal(v.CrossProduct(u), res);
        }
    }
}