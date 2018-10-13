using System;
using Xunit;

namespace Vector.Tests
{
    using BoringVector;
    public class VectorTests
    {
        [Fact]
        public void Test_SquareLength()
        {
            Assert.Equal(25, new Vector(3, 4).SquareLength());
        }

        [Fact]
        public void Test_Add()
        {
            Vector v = new Vector(3,4);
            Vector u = new Vector(1,1);
            Assert.Equal(v.Add(u), new Vector(4, 5));
        }

        [Fact]
        public void Test_Scale()
        {
            Vector v = new Vector(3, 4);
            double k = 5;
            Assert.Equal(v.Scale(k), new Vector(15, 20));
        }

        [Fact]
        public void Test_DotProduct()
        {
            Vector v = new Vector(3, 4);
            Vector u = new Vector(2, 3);
            Assert.Equal(18, v.DotProduct(u));
        }

        [Fact]
        public void Test_CrossProduct()
        {
            Vector v = new Vector(3, 4);
            Vector u = new Vector(2, 3);
            Assert.Equal(1, v.CrossProduct(u));
        }
    }
}
