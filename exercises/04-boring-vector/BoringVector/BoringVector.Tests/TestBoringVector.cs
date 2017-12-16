using Xunit;

namespace BoringVector.Tests
{
    public class TestBoringVector
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 2)]
        [InlineData(3, 4, 25)]
        public void TestSquareLength(double x, double y, double result)
        {
            Assert.Equal(result, new Vector(x, y).SquareLength());
        }
        
        [Theory]
        [InlineData(1, 2, 3, 4, 4, 6)]
        [InlineData(1, 2, 0, 0, 1, 2)]
        public void TestAdd(double x1, double y1, double x2, double y2, double xRes, double yRes)
        {
            Assert.Equal(new Vector(xRes, yRes), new Vector(x1, y1).Add(new Vector(x2, y2)));
        }
        
        [Theory]
        [InlineData(1, 1, 1, 1, 1)]
        [InlineData(2, 1, 3, 6, 3)]
        public void TestScale(double x, double y, double k, double xRes, double yRes)
        {
            Assert.Equal(new Vector(xRes, yRes), new Vector(x, y).Scale(k));
        }

        [Theory]
        [InlineData(1, 0, 0, 1, 0)]
        [InlineData(2, 2, 1, 3, 8)]
        public void TestDotProduct(double x1, double y1, double x2, double y2, double result)
        {
            Assert.Equal(result, new Vector(x1, y1).DotProduct(new Vector(x2, y2)));
        }
        
        [Theory]
        [InlineData(1, 0, 0, 1, 1)]
        [InlineData(2, 4, 6, 8, -8)]
        [InlineData(2, 2, 1, 1, 0)]
        public void TestCrossProduct(double x1, double y1, double x2, double y2, double result)
        {
            Assert.Equal(result, new Vector(x1, y1).CrossProduct(new Vector(x2, y2)));
        }
    }
}