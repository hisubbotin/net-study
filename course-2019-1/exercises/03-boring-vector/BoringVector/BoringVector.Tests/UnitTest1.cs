using System;
using Xunit;

namespace BoringVector.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 0, 0, 1, 1, 1)]
        public void TestAdd(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Vector v1;
            v1.x = x1;
            v1.y = y1;

            Vector v2;
            v2.x = x2;
            v2.y = y2;

            var v3 = v1.Add(v2);

            Assert.Equal(v3.x, x3);
            Assert.Equal(v3.y, y3);
        }

        [Theory]
        [InlineData(1, -1, 0.5, 0.5, -0.5)]
        public void TestScale(double x1, double y1, double coef, double x3, double y3)
        {
            Vector v1;
            v1.x = x1;
            v1.y = y1;

            var v3 = v1.Scale(coef);

            Assert.Equal(v3.x, x3);
            Assert.Equal(v3.y, y3);
        }

        [Theory]
        [InlineData(1, 2, 1, 1, 3)]
        public void TestDotProd(double x1, double y1, double x2, double y2, double dotProd)
        {
            Vector v1;
            v1.x = x1;
            v1.y = y1;

            Vector v2;
            v2.x = x2;
            v2.y = y2;

            var val = v1.DotProduct(v2);

            Assert.Equal(val, dotProd);
        }


        [Theory]
        [InlineData(1, 0, 0, 1, 1)]
        [InlineData(0, 1, 1, 0, -1)]
        public void TestCrossProd(double x1, double y1, double x2, double y2, double dotProd)
        {
            Vector v1;
            v1.x = x1;
            v1.y = y1;

            Vector v2;
            v2.x = x2;
            v2.y = y2;

            var val = v1.CrossProduct(v2);

            Assert.Equal(val, dotProd);
        }
    }
}
