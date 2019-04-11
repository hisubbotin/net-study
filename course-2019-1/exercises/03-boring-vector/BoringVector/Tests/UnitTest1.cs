using System;
using BoringVector;
using Xunit;


namespace Tests
{
    public class Test
    {
        [Fact]
        public void TestSquareLength()
        {
            var vec = new Vector(3, 4);
            Assert.Equal(25, vec.SquareLength());
        }
        
        [Fact]
        public void TestAdd()
        {
            var vec1 = new Vector(3, 4);
            var vec2 = new Vector(-1, 5);
            Assert.Equal(new Vector(2, 9), vec1.Add(vec2));
        }
        
        [Fact]
        public void TestScale()
        {
            var vec = new Vector(3, -4);
            Assert.Equal(new Vector(-9, 12), vec.Scale(-3));
        }
        
        [Fact]
        public void TestDotProduct()
        {
            var vec1 = new Vector(3, 4);
            var vec2 = new Vector(-1, 5);
            Assert.Equal(17, vec1.DotProduct(vec2));
        }
        
        [Fact]
        public void TestCrossProduct()
        {
            var vec1 = new Vector(3, 4);
            var vec2 = new Vector(-1, 5);
            Assert.Equal(19, vec1.CrossProduct(vec2));
        }
    }
}