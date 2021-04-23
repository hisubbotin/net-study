using Xunit;

namespace BoringVector.Tests
{
    public class VectorTests
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(3, 4, 25)]
        [InlineData(-0.5, -1.2, 1.69)]
        public void TestSquareLength(double X, double Y, double res)
        {
            Assert.Equal(new BoringVector.Vector(X, Y).SquareLength(), res);
        }

        [Theory]
        [InlineData(0, 0, 42, 1337, 42, 1337)]
        [InlineData(3, 4, -1, -6, 2, -2)]
        public void TestAdd(double X1, double Y1, double X2, double Y2, double XRes, double YRes)
        {
            var res = new Vector(X1, Y1).Add(new Vector(X2, Y2));
            Assert.Equal(res.X, XRes);
            Assert.Equal(res.Y, YRes);
        }

        [Theory]
        [InlineData(0, 1, 5, 0, 5)]
        [InlineData(-2, 3, -6, 12, -18)]
        public void TestScale(double X, double Y, double k, double kX, double kY)
        {
            var res = new Vector(X, Y).Scale(k);
        }

        [Theory]
        [InlineData(0, 0, 100, -500, 0)]
        [InlineData(7, -7, 7, 1, 42)]
        public void TestDotProduct(double X1, double Y1, double X2, double Y2, double res)
        {
            Assert.Equal(new Vector(X1, Y1).DotProduct(new Vector(X2, Y2)), res);
        }

        [Theory]
        [InlineData(0, 0, 100, -500, 0)]
        [InlineData(7, -7, 7, 1, 56)]
        public void TestCrossProduct(double X1, double Y1, double X2, double Y2, double res)
        {
            Assert.Equal(new Vector(X1, Y1).CrossProduct(new Vector(X2, Y2)), res);
        }
    }
}
