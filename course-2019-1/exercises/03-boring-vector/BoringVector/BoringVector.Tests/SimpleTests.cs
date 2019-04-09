using Xunit;

namespace BoringVector.Tests
{
    public class VectorTest
    {
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(-1, 1, 2)]
        [InlineData(1, 2, 5)]
        public void Test_SquareLength(double x, double y, double res)
        {
            Vector v = new Vector(x, y);
            Assert.Equal(v.SquareLength(), res);
        }
        
        [Theory]
        [InlineData(1, 1, 1, 1, 2, 2)]
        [InlineData(-1, 1, 1, 2, 0, 3)]
        public void Test_Add(double x1, double y1, double x2, double y2, double xRes, double yRes)
        {
            Vector v = new Vector(x1, y1);
            Vector u = new Vector(x2, y2);
            Vector res = new Vector(xRes, yRes);
            Assert.Equal(v.Add(u), res);
        }
        
        [Theory]
        [InlineData(1, 1, 0, 0, 0)]
        [InlineData(2, 3, -2, -4, -6)]
        [InlineData(1, 2, 5, 5, 10)]
        public void Test_Scale(double x, double y, double k, double xRes, double yRes)
        {
            Vector v = new Vector(x, y);
            Vector res = new Vector(xRes, yRes);
            Assert.Equal(v.Scale(k), res);
        }
        
        [Theory]
        [InlineData(1, 1, 1, 1, 2)]
        [InlineData(-1, 1, 0, 0, 0)]
        [InlineData(1, 2, 2, 1, 4)]
        public void Test_DotProduct(double x1, double y1, double x2, double y2, double res)
        {
            Vector v = new Vector(x1, y1);
            Vector u = new Vector(x2, y2);
            Assert.Equal(v.DotProduct(u), res);
        }
        
        [Theory]
        [InlineData(1, 1, 1, 1, 0)]
        [InlineData(-1, 1, 0, 0, 0)]
        [InlineData(1, 2, 2, -1, -5)]
        public void Test_CrossProduct(double x1, double y1, double x2, double y2, double res)
        {
            Vector v = new Vector(x1, y1);
            Vector u = new Vector(x2, y2);
            Assert.Equal(v.CrossProduct(u), res);
        }
    }
}