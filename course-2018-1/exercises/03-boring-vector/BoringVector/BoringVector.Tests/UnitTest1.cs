using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTests
    {
        
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 8)]
        internal void Test_SquareLength(double x, double y, double result)
        {
            Assert.Equal(result, new Vector(x, y).SquareLength());
        }
        
        [Fact]
        internal void Test_Add()
        {
            var v = new Vector(1, -1);
            Assert.True(v.Add(-v).IsZero());
        }
    

        [Fact]
        internal void Test_Scale()
        {
            var v= new Vector(1, 1);
            Assert.Equal(200, v.Scale(10).SquareLength());
        }
    
        [Fact]
        internal void Test_DotProduct()
        {
            var v = new Vector(1, -1);
            var u = new Vector(-1, -1);
            Assert.Equal(0, v.DotProduct(u));
        }

        [Fact]
        internal void Test_CrossProduct()
        {
            var v = new Vector(1, -1);
            var u = new Vector(-1, -1);
            Assert.Equal(-2, v.CrossProduct(u));
        }
    }
}
