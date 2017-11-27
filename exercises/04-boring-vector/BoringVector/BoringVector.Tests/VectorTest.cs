using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTest
    {
        private static readonly double TOLERANCE = 1e-6;

        [Theory]
        [InlineData(3, 4, 5)]
        [InlineData(5, 12, 13)]
        [InlineData(33, 56, 65)]
        [InlineData(65, 72, 97)]
        [InlineData(115, 252, 277)]
        [InlineData(161, 240, 289)]
        [InlineData(68, 285, 293)]
        public void Test_SquareLength(double x, double y, double length)
        {
            Assert.True(Math.Abs(Math.Abs(new Vector(x, y).SquareLength() - length * length)) < TOLERANCE);
        }

        [Fact]
        public void Test_Add()
        {
            var a = new Vector(1, 2);
            var b = new Vector(3, 4);
            var c = a.Add(b);
            Assert.True(Math.Abs(c.X - 4) < TOLERANCE && Math.Abs(c.Y - 6) < TOLERANCE);
        }

        [Fact]
        public void Test_Scale()
        {
            var b = new Vector(3, 4);
            var c = b.Scale(1.5);
            Assert.True(Math.Abs(c.X - 4.5) < TOLERANCE && Math.Abs(c.Y - 6) < TOLERANCE);
        }

        [Fact]
        public void Test_DotProduct()
        {
            var a = new Vector(1, 2);
            var b = new Vector(3, 4);
            var c = a.DotProduct(b);
            Assert.True(Math.Abs(c - 11) < TOLERANCE);
        }

        [Fact]
        public void Test_CrossProduct()
        {
            var a = new Vector(1, 2);
            var b = new Vector(3, 4);
            var c = a.CrossProduct(b);
            Assert.True(Math.Abs(c - (-2)) < TOLERANCE);
        }
    }
}