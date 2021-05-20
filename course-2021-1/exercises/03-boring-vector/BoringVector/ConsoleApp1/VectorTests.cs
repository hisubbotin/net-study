using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTests
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 2, 5)]
        [InlineData(5, 50, 2525)]
        public void Test_SquareLength(double x, double y, double ans)
        {
            Assert.Equal(new Vector(x, y).SquareLength(), ans);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(1, 0, -1, 0, 0, 0)]
        [InlineData(3, 5, 0, 0, 3, 5)]
        [InlineData(6, 10, -11, 2, -5, 12)]
        public void Test_Add(double vX, double vY, double wX, double wY, double ansX, double ansY)
        {
            Vector ans = new Vector(vX, vY).Add(new Vector(wX, wY));
            Assert.Equal(ans.X, ansX);
            Assert.Equal(ans.Y, ansY);
        }

        [Theory]
        [InlineData(0, 0, 2, 0, 0)]
        [InlineData(0, 3, 6, 0, 18)]
        [InlineData(1, 1, 3, 3, 3)]
        [InlineData(2, -3, -1, -2, 3)]
        public void Test_Scale(double vX, double vY, double k, double ansX, double ansY)
        {
            Vector ans = new Vector(vX, vY).Scale(k);
            Assert.Equal(ans.X, ansX);
            Assert.Equal(ans.Y, ansY);
        }

        [Theory]
        [InlineData(0, 0, 1, 1, 0)]
        [InlineData(0, 4, 7, 0, 0)]
        [InlineData(1, -2, -1, 2, -5)]
        [InlineData(10, 4, -2, 3, -8)]
        public void Test_DotProduct(double vX, double vY, double wX, double wY, double ans)
        {
            Assert.Equal(new Vector(vX, vY).DotProduct(new Vector(wX, wY)), ans);
        }

        [Theory]
        [InlineData(0, 0, 1, 1, 0)]
        [InlineData(0, 4, 7, 0, 28)]
        [InlineData(1, -2, -1, 2, 0)]
        [InlineData(10, 4, -2, 3, 38)]
        internal void TestCrossProduct(double vX, double vY, double wX, double wY, double ans)
        {
            Assert.Equal(new Vector(vX, vY).CrossProduct(new Vector(wX, wY)), ans);
        }
    }
}