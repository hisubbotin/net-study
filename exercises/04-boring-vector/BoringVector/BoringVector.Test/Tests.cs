using Xunit;

namespace BoringVector.Tests
{
    public class Tests
    {
        [Theory]

        [InlineData(1, 2, 5)]
        public void Test_SquareLength(double X, double Y, double result)
        {
            Assert.Equal(new Vector(X, Y).SquareLength(), result);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 4, 6)]
        [InlineData(-1, 1, -2, 2, -3, 3)]
        public void Test_Add(double X1, double Y1, double X2, double Y2, double X, double Y)
        {
            Assert.Equal(new Vector(X1, Y1) + new Vector(X2, Y2), new Vector(X, Y));
        }

        [Theory]
        [InlineData(1, 2, 3, 3, 6)]
        [InlineData(1, 2, -3, -3, -6)]
        public void Test_Scale(double X1, double Y1, double k, double X, double Y)
        {
            Assert.Equal(new Vector(X1, Y1).Scale(k), new Vector(X, Y));
        }

        [Theory]
        [InlineData(1, 0, 1, 0, 1)]
        [InlineData(1, 0, 0, -1, 0)]
        public void Test_DotProduct(double X1, double Y1, double X2, double Y2, double result)
        {
            Assert.Equal(new Vector(X1, Y1).DotProduct(new Vector(X2, Y2)), result);
        }

        [Theory]
        [InlineData(1, -1, -2, 2, 0)]
        [InlineData(1, 0, 0, 1, 1)]
        public void Test_CrossProductd(double X1, double Y1, double X2, double Y2, double result)
        {
            Assert.Equal(new Vector(X1, Y1).CrossProduct(new Vector(X2, Y2)), result);
        }
    }
}
