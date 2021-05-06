using System;
using System.Runtime.CompilerServices;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTest
    {
        private const double eps = 1e-6;
        [Theory]
        [InlineData(2, 2, 8)]
        [InlineData(3, 3, 18)]
        [InlineData(0, 5, 25)]
        public void Test_SquareLength(double x, double y, double z)
        {
            double l = new Vector(x, y).SquareLength();
            double residual = Math.Abs(l - z);
            Assert.True(residual < eps);
        }

        
        [Theory]
        [InlineData(0, 1, 2, -1, 2, 0)]
        [InlineData(1e5, 2e4, -1e4, 0, 1e5-1e4, 2e4)]
        [InlineData(7, -3, -2, 5, 5, 2)]
        public void Test_Add(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Vector v1 = new Vector(x1, y1);
            Vector v2 = new Vector(x2, y2);
            Vector v3 = v1.Add(v2);
            
            Assert.True(Math.Abs(v3.X - x3) < eps);
            Assert.True(Math.Abs(v3.Y - y3) < eps);
        }

        [Theory]
        [InlineData(2, 7, 0, 0, 0)]
        [InlineData(-1, 5, 2, -2, 10)]
        [InlineData(0, 5, 1, 0, 5)]
        public void Test_Scale(double x1, double y1, double k, double x2, double y2)
        {
            Vector v1 = new Vector(x1, y1);
            Vector v2 = v1.Scale(k);
            Assert.True(Math.Abs(v2.X - x2) < eps);
            Assert.True(Math.Abs(v2.Y - y2) < eps);
        }

        [Theory]
        [InlineData(0, 1, 2, -1, -1)]
        [InlineData(1e5, 2e4, -1e4, 0, 1e5 * (-1e4))]
        [InlineData(7, -3, -2, 5, -29)]
        public void Test_DotProduct(double x1, double y1, double x2, double y2, double res)
        {
            Vector v1 = new Vector(x1, y1);
            Vector v2 = new Vector(x2, y2);
            double prod = v1.DotProduct(v2);

            Assert.True(Math.Abs(prod - res) < eps);
        }

        [Theory]
        [InlineData(1, 0, 0, 1, 1)]
        [InlineData(0, 1, 1, 0, -1)]
        [InlineData(7, -3, -2, 5, 29)]
        public void Test_CrossProduct(double x1, double y1, double x2, double y2, double res)
        {
            Vector v1 = new Vector(x1, y1);
            Vector v2 = new Vector(x2, y2);
            double prod = v1.CrossProduct(v2);

            Assert.True(Math.Abs(prod - res) < eps);
        }
    }
}
