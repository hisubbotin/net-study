using NUnit.Framework;
using BoringVector;

namespace BoringVector.Tests
{
    public class SquareLengthTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Vector vector = new Vector(3, 4);
            Assert.IsTrue(vector.SquareLength() == 25);
        }
        
        [Test]
        public void Test2()
        {
            Vector vector = new Vector(0, 0);
            Assert.IsTrue(vector.SquareLength() == 0);
        }
        
        [Test]
        public void Test3()
        {
            Vector vector = new Vector(-1, -1);
            Assert.IsTrue(vector.SquareLength() == 2);
        }
    }
    
    public class AddTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Vector vector1 = new Vector(3, 4);
            Vector vector2 = new Vector(3, 4);
            Vector vector3 = new Vector(6, 8);
            Assert.IsTrue(vector1.Add(vector2) == vector3);
        }
        
        [Test]
        public void Test2()
        {
            Vector vector1 = new Vector(3, 4);
            Vector vector2 = new Vector(-3, -4);
            Vector vector3 = new Vector(0, 0);
            Assert.IsTrue(vector1.Add(vector2) == vector3);
        }
    }
    
    public class ScaleTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Vector vector1 = new Vector(3, 4);
            Vector vector2 = new Vector(6, 8);
            Assert.IsTrue(vector1.Scale(2) == vector2);
        }
        
        [Test]
        public void Test2()
        {
            Vector vector1 = new Vector(3, 4);
            Vector vector2 = new Vector(0, 0);
            Assert.IsTrue(vector1.Scale(0) == vector2);
        }
        
        [Test]
        public void Test3()
        {
            Vector vector1 = new Vector(3, 4);
            Vector vector2 = new Vector(-3, -4);
            Assert.IsTrue(vector1.Scale(-1) == vector2);
        }
    }
    
    public class DotProductTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Vector vector1 = new Vector(3, 4);
            Vector vector2 = new Vector(3, 4);
            Assert.IsTrue(vector1.DotProduct(vector2) == 25);
        }
        
        [Test]
        public void Test2()
        {
            Vector vector1 = new Vector(3, 4);
            Vector vector2 = new Vector(0, 0);
            Assert.IsTrue(vector1.DotProduct(vector2) == 0);
        }
        
        [Test]
        public void Test3()
        {
            Vector vector1 = new Vector(3, 4);
            Vector vector2 = new Vector(-1, -1);
            Assert.IsTrue(vector1.DotProduct(vector2) == -7);
        }
    }
    
    public class CrossProductTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Vector vector1 = new Vector(3, 4);
            Vector vector2 = new Vector(3, 4);
            Assert.IsTrue(vector1.CrossProduct(vector2) == 0);
        }
        
        [Test]
        public void Test2()
        {
            Vector vector1 = new Vector(3, 4);
            Vector vector2 = new Vector(0, 0);
            Assert.IsTrue(vector1.CrossProduct(vector2) == 0);
        }
        
        [Test]
        public void Test3()
        {
            Vector vector1 = new Vector(3, 4);
            Vector vector2 = new Vector(-1, -1);
            Assert.IsTrue(vector1.CrossProduct(vector2) == 1);
        }
    }
}