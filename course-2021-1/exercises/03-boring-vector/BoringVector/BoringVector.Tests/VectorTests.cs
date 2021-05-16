using Xunit;

namespace BoringVector.Tests
{
    public class VectorTest
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 2)]
        public void SquareLength(double x, double y, double expected)
        {
            Assert.Equal(new Vector(x, y).SquareLength(), expected);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(1, 1, -1, -1, 0, 0)]
        [InlineData(1.2, 3.4, 5.6, 7.8, 6.8, 11.2)]
        public void Add(double firstX, double firstY, double secondX, double secondY, double expectedX,
            double expectedY)
        {
            var result = new Vector(firstX, firstY).Add(new Vector(secondX, secondY));
            Assert.Equal(result.GetX(), expectedX);
            Assert.Equal(result.GetY(), expectedY);
        }

        [Theory]
        [InlineData(1, 2, 1.1, 1.1, 2.2)]
        [InlineData(0, 1.5, -1, 0, -1.5)]
        public void Scale(double x, double y, double k, double expectedX, double expectedY)
        {
            var result = new Vector(x, y).Scale(k);
            Assert.Equal(result.GetX(), expectedX);
            Assert.Equal(result.GetY(), expectedY);
        }


        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(1, 1, 1, 1, 2)]
        [InlineData(1, 2, 3, 4, 11)]
        public void DotProduct(double firstX, double firstY, double secondX, double secondY, double expected)
        {
            var result = new Vector(firstX, firstY).DotProduct(new Vector(secondX, secondY));
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(1, 1, 1, 1, 0)]
        [InlineData(1, 2, 3, 4, -2)]
        public void CrossProduct(double firstX, double firstY, double secondX, double secondY, double expected)
        {
            var result = new Vector(firstX, firstY).CrossProduct(new Vector(secondX, secondY));
            Assert.Equal(result, expected);
        }
    }
}