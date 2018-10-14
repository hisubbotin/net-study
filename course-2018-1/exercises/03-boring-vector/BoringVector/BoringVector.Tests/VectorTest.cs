using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTest
    {
        [Theory]
        [InlineData(1.0, 1.0, 2.0)]
        [InlineData(3.0, 4.0, 25.0)]
        [InlineData(2.5, 1.5, 8.5)]
        public void Test_SquareLength(double x, double y, double result)
        {
            var v = new Vector(x, y);
            Assert.Equal(result, v.SquareLength());
        }

        [Theory]
        [InlineData(1.0, 1.0, 2.0, 2.0, 3.0, 3.0)]
        [InlineData(1.1, 2.9, 1.9, 0.1, 3.0, 3.0)]
        public void Test_Addition(double x1, double y1, double x2, double y2, double xRes, double yRes)
        {
            var v = new Vector(x1, y1);
            var u = new Vector(x2, y2);
            var result = new Vector(xRes, yRes);
            Assert.Equal(result, v.Add(u));
            Assert.Equal(result, v + u);
        }

        [Theory]
        [InlineData(1.0, 1.0, 5.0, 5.0, 5.0)]
        [InlineData(2.5, 2.5, 2.0, 5.0, 5.0)]
        public void Test_Scale(double x1, double y1, double k, double xRes, double yRes)
        {
            var v = new Vector(x1, y1);
            var result = new Vector(xRes, yRes);
            Assert.Equal(result, v.Scale(k));
        }

        [Theory]
        [InlineData(1.0, 1.0, 2.0, 2.0, 4.0)]
        [InlineData(0.1, 0.1, 10, 10, 2.0)]
        public void Test_DotProduct(double x1, double y1, double x2, double y2, double result)
        {
            var v = new Vector(x1, y1);
            var u = new Vector(x2, y2);
            Assert.Equal(result, v.DotProduct(u));
        }

        [Theory]
        [InlineData(1.0, 1.0, 2.0, 3.0, 1.0)]
        [InlineData(2.0, 5.0, 1.0, 1.0, 3.0)]
        public void Test_CrossProduct(double x1, double y1, double x2, double y2, double result)
        {
            var v = new Vector(x1, y1);
            var u = new Vector(x2, y2);
            Assert.Equal(result, v.CrossProduct(u));
        }
    }
}
