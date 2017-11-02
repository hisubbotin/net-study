using Xunit;

namespace BoringVector.Tests
{
    public class VecorUnitTest
    {
        [Fact]
        public void SqureLengthTest()
        {
            Vector v = new Vector(3, 4);
            Assert.Equal(5 * 5, v.SquareLength() );
        }
        
        [Fact]
        public void AddTest()
        {
            Vector v = new Vector(2, 3);
            Vector u = new Vector(5, 1);
            Vector result = v.Add(u);
            Assert.Equal(result.X, 7);
            Assert.Equal(result.Y, 4);
        }
        
        [Fact]
        public void AddOperatorTest()
        {
            Vector v = new Vector(2, 3);
            Vector u = new Vector(5, 1);
            Vector result = v + u;
            Assert.Equal(result.X, 7);
            Assert.Equal(result.Y, 4);
        }
        
        [Fact]
        public void ScaleTest()
        {
            Vector v = new Vector(2, 3);
            double s = -5; 
            Vector result = v.Scale(s);
            Assert.Equal(result.X, -10);
            Assert.Equal(result.Y, -15);
        }
        
        [Fact]
        public void DotProductTest()
        {
            Vector v = new Vector(2, 3);
            Vector u = new Vector(5, 1);
            double result = v.DotProduct(u);
            Assert.Equal(result, 13);
            Assert.Equal(result, u.DotProduct(v));
        }
        
        [Fact]
        public void CrossProductTest()
        {
            Vector v = new Vector(2, 3);
            Vector u = new Vector(5, 1);
            double result = v.CrossProduct(u);
            Assert.Equal(result, 13);
            Assert.Equal(result, u.CrossProduct(v));
        }
    }
}