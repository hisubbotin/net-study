using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTests
    {
        [Theory]
        [InlineData(3, 4)]
        [InlineData(0, 0)]
        public void Test_SquareLength(double x, double y)
        {
            var v = new Vector(x, y);
            Assert.Equal(v.SquareLength(), x * x + y * y);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 0e-6, 3, -4)]
        public void Test_Add(double x1, double y1, double x2, double y2)
        {
            var trueResult = new Vector(x1 + x2, y1 + y2);
            var v1 = new Vector(x1, y1);
            var v2 = new Vector(x2, y2);
            Assert.Equal(v1.Add(v2), trueResult);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(int.MaxValue, int.MinValue, 0)]
        public void Test_Scale(double x, double y, double k)
        {
            var trueResult = new Vector(x * k, y * k);
            var v = new Vector(x, y);
            v = v.Scale(k);
            Assert.Equal(v, trueResult);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 0e-6, 3, -4)]
        public void Test_DotProduct(double x1, double y1, double x2, double y2)
        {
            var v1 = new Vector(x1, y1);
            var v2 = new Vector(x2, y2);
            Assert.Equal(v1.DotProduct(v2), x1 * x2 + y1 * y2);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 0e-6, 3, -4)]
        public void Test_CrossProduct(double x1, double y1, double x2, double y2)
        {
            var v1 = new Vector(x1, y1);
            var v2 = new Vector(x2, y2);
            Assert.Equal(v1.CrossProduct(v2), x1 * y2 -  x2 * y1);
        }
    }
}