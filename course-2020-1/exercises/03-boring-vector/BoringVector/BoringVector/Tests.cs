using Xunit;
using BoringVector;
namespace Tests
{
    public class Tests
    {
        [Fact]
        public void AddingTests()
        {
            Vector v = new Vector(1.1, 0.9);
            Vector v2 = new Vector(0.5, 2.5);
            Assert.True(Equals(v.Add(v2), new Vector(1.6, 3.4)));
        }
        
        [Fact]
        public void ScalingTest()
        {
            Vector v = new Vector(1.1, 0.9);
            Assert.True(Equals(v.Scale(3), 3*v));
            Assert.True(Equals(v.Scale(-7), v*(-7)));
        }
        
        [Fact]
        public void ToStringTest()
        {
            Vector v = new Vector(1.1, 0.9);
            Assert.True(Equals(v.ToString(), "(1.1;0.9)"));
        }
        [Fact]
        public void DotProductTest()
        {
            Vector v = new Vector(1.1, 0.9);
            Vector v2 = new Vector(1.3, 3);
            Assert.Equal(v.DotProduct(v2), 1.1*1.3+0.9*3);
        }
        
        [Fact]
        public void CrossProductTest()
        {
            Vector v = new Vector(1.1, 0.9);
            Vector v2 = new Vector(1.3, 3);
            Assert.Equal(v.CrossProduct(v2), 1.1*3-0.9*1.3);
        }

    }
}
