using System;
using Xunit;
using BoringVector;

namespace BoringVector.Tests
{
    public class TestVector
    {
        [Fact]
        public void TestEmptyVectorLength()
        {
            Vector v = new Vector();
            Assert.Equal(0.0, v.SquareLength());
        }

        [Theory]
        [InlineData(3, 4, 25)]
        [InlineData(5, -6, 25 + 36)]
        public void TestVectorLength(double x, double y, double length)
        {
            Vector v = new Vector() { X = x, Y = y };
            Assert.Equal(length, v.SquareLength());
        }

        [Fact]
        public void TestVectorAdd()
        {
            Vector v1 = new Vector() { X = 3, Y = 4 };
            Vector v2 = new Vector() { X = 2, Y = -2 };
            Vector sum = v1.Add(v2);
            Assert.Equal(5.0, sum.X);
            Assert.Equal(2.0, sum.Y);
        }

        [Fact]
        public void TestVectorScale()
        {
            Vector v = new Vector() { X = 3, Y = -4 };
            Vector scaled = v.Scale(-2);
            Assert.Equal(-6, scaled.X);
            Assert.Equal(8.0, scaled.Y);
        }

        [Fact]
        public void TestVectorDotProduct()
        {
            Vector v1 = new Vector() { X = 3, Y = 4 };
            Vector v2 = new Vector() { X = 2, Y = -2 };
            Assert.Equal(3 * 2 - 4 * 2, v1.DotProduct(v2));
        }

        [Fact]
        public void TestVectorCrossProduct()
        {
            Vector v1 = new Vector() { X = 3, Y = 4 };
            Vector v2 = new Vector() { X = 2, Y = -2 };
            Assert.Equal(-3 * 2 - 4 * 2, v1.CrossProduct(v2));
        }
    }
}
