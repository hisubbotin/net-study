using NUnit.Framework;

namespace BoringVector.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SquareLength()
        {
            var v = new Vector(5, 5);
            Assert.AreEqual(v.SquareLength(), 50);
        }
        [Test]
        public void Add()
        { 
            var v = new Vector(5, 5);
            var u = new Vector(1, -1);
            Assert.AreEqual(v.Add(u), new Vector(6, 4));
        }
        [Test]
        public void Scale()
        {
            var v = new Vector(5, 5);
            Assert.AreEqual(v.Scale(10), new Vector(50, 50));
        }
        [Test]
        public void DotProduct()
        {
            var v = new Vector(5, 5);
            var u = new Vector(1, -1);
            Assert.AreEqual(v.DotProduct(u), 0);
        }
        [Test]
        public void CrossProduct()
        {
            var v = new Vector(5, 5);
            var u = new Vector(1, -1);
            Assert.AreEqual(v.CrossProduct(u), -10);
        }
    }
}