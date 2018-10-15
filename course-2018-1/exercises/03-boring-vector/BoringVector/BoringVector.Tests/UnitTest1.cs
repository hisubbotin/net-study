using System;
using System.Reflection.Metadata.Ecma335;
using Xunit;

namespace BoringVector.Tests
{
    public class UnitTestsPart1
    {
        [Fact]
        public void TestSquareLength1()
        {
            Assert.Equal(25, new Vector(3, 4).SquareLength());
        }
        
        [Fact]
        public void TestSquareLength2()
        {
            Assert.Equal(101, new Vector(10, 1).SquareLength());
        }
        
        [Fact]
        public void TestAdd()
        {
            Assert.Equal(new Vector(11, 11), new Vector(10, 1).Add(new Vector(1, 10)));
        }
        
        [Fact]
        public void TestScale()
        {
            Assert.Equal(new Vector(20, 2), new Vector(10, 1).Scale(2));
        }
        
        [Fact]
        public void TestDotProduct()
        {
            Assert.Equal(20, new Vector(10, 1).DotProduct(new Vector(1, 10)));
        }
        
        [Fact]
        public void TestCrossProduct()
        {
            Assert.Equal(99, new Vector(10, 1).CrossProduct(new Vector(1, 10)));
        }
       
        [Fact]
        public void TestToString()
        {
            Assert.Equal("(10; 1)", new Vector(10, 1).ToString());
        }
    }

    public class UnitTestsPart2
    {
        [Fact]
        public void TestIsZero()
        {
            Assert.Equal(true, VectorExtension.IsZero(new Vector(0, 0)));
        }
        
        [Fact]
        public void TestNormalize()
        {
            Assert.True(VectorExtension.IsZero(new Vector(0.707106781186547, 0.707106781186547) - 
                                               VectorExtension.Normalize(new Vector(2, 2))));
        }
        
        [Fact]
        public void TestGetAngleBetween()
        {
            Assert.True(0.8 - VectorExtension.GetAngleBetween(new Vector(2, 1), new Vector(1, 2)) < 1e-6);
        }
        
        [Fact]
        public void TestGetRelation()
        {
            Assert.Equal(Relation.Parallel, VectorExtension.GetRelation(new Vector(0, 0), new Vector(10, 3)));
        }
    }
}