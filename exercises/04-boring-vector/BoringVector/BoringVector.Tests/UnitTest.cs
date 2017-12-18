using Xunit;

namespace BoringVector.Tests
{
    public class VecorUnitTest
    {
        private static int precision = 6;

        [Fact]
        public void Test_SquareLength()
        {
            Vector v = new Vector(1, 0);
            Assert.Equal(1, v.SquareLength(), precision);
        }

        [Fact]
        public void Test_Add()
        {
            Vector v = new Vector(1, 1);
            Vector u = new Vector(2, 2);
            Vector result = v.Add(u);
            Assert.Equal(result.X, 3, precision);
            Assert.Equal(result.Y, 3, precision);
        }

        [Fact]
        public void Test_Scale()
        {
            Vector v = new Vector(1, 2);
            double s = 5;
            Vector result = v.Scale(s);
            Assert.Equal(result.X, 5, precision);
            Assert.Equal(result.Y, 10, precision);
        }

        [Fact]
        public void Test_DotProduct()
        {
            Vector v = new Vector(1, 1);
            Vector u = new Vector(-1, 1);
            double result = v.DotProduct(u);
            Assert.Equal(result, 0, precision);
        }

        [Fact]
        public void Test_CrossProduct()
        {
            Vector v = new Vector(1, 1);
            Vector u = new Vector(3, 3);
            double result = v.CrossProduct(u);
            Assert.Equal(result, 0, precision);
        }
    }
}
