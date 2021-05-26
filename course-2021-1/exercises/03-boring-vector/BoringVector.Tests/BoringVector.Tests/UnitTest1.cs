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
            Assert.Equals(v.SquareLength(), 25);
        }
        [Test]
        public void Add()
        {
            Assert.Pass();
        }
        [Test]
        public void Scale()
        {
            Assert.Pass();
        }
        [Test]
        public void DotProduct()
        {
            Assert.Pass();
        }
        [Test]
        public void CrossProduct()
        {
            Assert.Pass();
        }
    }
}