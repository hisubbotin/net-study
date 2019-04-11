using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTest
    {
        [Fact]
        public void TestVector_SquareLength()
        {
            Vector v = new Vector(0, 0);
            Assert.Equal(0, v.SquareLength());
        }

        [Theory]
        [InlineData(10, 10, 20, 30)]
        public void TestVector_Add(double X, double Y, double X1, double Y1)
        {
            Vector v = new Vector(X, Y);
            Vector u = new Vector(X1, Y1);
            Vector z = new Vector(X + X1, Y + Y1);
            Assert.Equal(u.Add(v), z);
        }

        [Theory]
        [InlineData(10, 10, 3)]
        public void TestVector_Scale(double X, double Y, double k)
        {
            Vector v = new Vector(X, Y);
            Vector z = new Vector(X * k, Y * k);
            Assert.Equal(v.Scale(k), z);
        }

        [Theory]
        [InlineData(10, 10, 20, 30)]
        public void TestVector_DotProduct(double X, double Y, double X1, double Y1)
        {
            Vector v = new Vector(X, Y);
            Vector u = new Vector(X1, Y1);
            double z = X * X1 + Y * Y1;
            Assert.Equal(u.DotProduct(v), z);
        }

        [Theory]
        [InlineData(10, 10, 20, 20)]
        public void TestVector_CrossProduct(double X, double Y, double X1, double Y1)
        {
            Vector v = new Vector(X, Y);
            Vector u = new Vector(X1, Y1);
            Assert.Equal(u.CrossProduct(v), 0);
        }
    }
}
