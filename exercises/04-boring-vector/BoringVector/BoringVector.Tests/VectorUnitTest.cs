using Xunit;

namespace BoringVector.Tests
{
    public class VecorUnitTest
    {
        private static int precision = 10;
        
        [Fact]
        public void Test_SquareLength()
        {
            Vector v = new Vector(3, 4);
            Assert.Equal(5 * 5, v.SquareLength(), precision);
        }
        
        [Fact]
        public void Test_Add()
        {
            Vector v = new Vector(2, 3);
            Vector u = new Vector(5, 1);
            Vector result = v.Add(u);
            Assert.Equal(result.X, 7, precision);
            Assert.Equal(result.Y, 4, precision);
        }
        
        [Fact]
        public void Test_AddOperator()
        {
            Vector v = new Vector(2, 3);
            Vector u = new Vector(5, 1);
            Vector result = v + u;
            Assert.Equal(result.X, 7, precision);
            Assert.Equal(result.Y, 4, precision);
        }
        
        [Fact]
        public void Test_Scale()
        {
            Vector v = new Vector(2, 3);
            double s = -5; 
            Vector result = v.Scale(s);
            Assert.Equal(result.X, -10, precision);
            Assert.Equal(result.Y, -15, precision);
        }
        
        [Fact]
        public void Test_DotProduct()
        {
            Vector v = new Vector(2, 3);
            Vector u = new Vector(5, 1);
            double result = v.DotProduct(u);
            Assert.Equal(result, 13, precision);
            Assert.Equal(result, u.DotProduct(v), precision);
        }
        
        [Fact]
        public void Test_CrossProduct()
        {
            Vector v = new Vector(2, 3);
            Vector u = new Vector(5, 1);
            double result = v.CrossProduct(u);
            Assert.Equal(result, 13, precision);
            Assert.Equal(result, u.CrossProduct(v), precision);
        }
    }
}