using Xunit;

namespace BoringVector.Tests
{
    public class Tests
    {
        [Theory]
        [InlineData(-3, 4, 5)]
        [InlineData(1, 0, 1)]
        public void TestVectorSquareLength(double x, double y, double result)
        {
            var v = new Vector(x, y);
            Assert.Equal(v.SquareLength(), result);
        }

        [Theory]
        [InlineData(1, -1, 3, 2, 4, 1)]
        [InlineData(0, 0, 10, -10, 10, -10)]
        public void TestVectorAdd(double x1, double y1, double x2, double y2, double xResult, double yResult)
        {
            var v1 = new Vector(x1, y1);
            var v2 = new Vector(x2, y2);
            Assert.Equal(v1.Add(v2), new Vector(xResult, yResult));
        }

        [Theory]
        [InlineData(3, 4, 2, 6, 8)]
        [InlineData(1, 1, 0, 0, 0)]
        public void TestVectorScale(double x, double y, double k, double xResult, double yResult)
        {
            var v = new Vector(x, y);
            Assert.Equal(v.Scale(k), new Vector(xResult, yResult));
        }

        [Theory]
        [InlineData(1, 1, 2, 2, 4)]
        [InlineData(-1, 2, -2, 1, 4)]
        public void TestVectorDotProduct(double x1, double y1, double x2, double y2, double result)
        {
            var v1 = new Vector(x1, y1);
            var v2 = new Vector(x2, y2);
            Assert.Equal(v1.DotProduct(v2), result);
        }

        [Theory]
        [InlineData(1, 2, 1, 3, 1)]
        [InlineData(-1, 2, 1, 3, -5)]
        public void TestVectorCrossProduct(double x1, double y1, double x2, double y2, double result)
        {
            var v1 = new Vector(x1, y1);
            var v2 = new Vector(x2, y2);
            Assert.Equal(v1.CrossProduct(v2), result);
        }
    }
}
