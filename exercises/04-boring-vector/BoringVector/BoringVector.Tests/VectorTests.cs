using Xunit;

namespace BoringVector.Tests
{
    public class VectorTests
    {
        // Tests for the following functions:
        // SquareLength,
        // Add,
        // Scale,
        // DotProduct,
        // CrossProduct.

        [Theory]
        [InlineData(45.0, 68.0, 6649.0)]
        public void Test_SquareLength_ReturnsCorrectValue(double x, double y, double squareLength)
        {
            Assert.Equal(new Vector(x, y).SquareLength(), squareLength);
        }

        [Theory]
        [InlineData(2.0, 3.0, 4.0, 5.0, 6.0, 8.0)]
        public void Test_Add_ReturnsCorrectValue(double x1, double y1, double x2, double y2, double sumX, double sumY)
        {
            Assert.Equal(new Vector(x1, y1).Add(new Vector(x2, y2)), new Vector(sumX, sumY));
        }

        [Theory]
        [InlineData(3.0, 4.0, 5.0, 15.0, 20.0)]
        public void Test_Scale_ReturnsCorrectValue(double x, double y, double k, double scaledX, double scaledY)
        {
            Assert.Equal(new Vector(x, y).Scale(k), new Vector(scaledX, scaledY));
        }

        [Theory]
        [InlineData(4.0, 5.0, 6.0, 7.0, 59.0)]
        public void Test_DotProduct_ReturnsCorrectValue(double x1, double y1, double x2, double y2, double dotProduct)
        {
            Assert.Equal(new Vector(x1, y1).DotProduct(new Vector(x2, y2)), dotProduct);
        }

        [Theory]
        [InlineData(5.0, 6.0, 7.0, 8.0, -2.0)]
        public void Test_CrossProduct_ReturnsCorrectValue(double x1, double y1, double x2, double y2,
            double crossProduct)
        {
            Assert.Equal(new Vector(x1, y1).CrossProduct(new Vector(x2, y2)), crossProduct);
        }

        //[Fact]
        //public void Test1()
        //{

        //}
    }
}
