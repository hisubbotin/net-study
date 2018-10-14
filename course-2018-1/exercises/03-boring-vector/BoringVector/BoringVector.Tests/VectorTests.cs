using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTests
    {
        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(0, 0, 0)]
        [InlineData(3, 4, 25)]
        public void Test_SquareLength(double X, double Y, double len)
        {
            Vector v = new Vector { X = X, Y = Y };
            Assert.Equal(v.SquareLength(), len);
        }

        [Theory]
        [InlineData(3, 2, -3, -2, 0, 0)]
        public void Test_Add(double X1, double Y1, double X2, double Y2, double X3, double Y3)
        {
            Vector u = new Vector { X = X1, Y = Y1 };
            Vector v = new Vector { X = X2, Y = Y2 };
            Vector w = new Vector { X = X3, Y = Y3 };
            Vector sum = u + v;
            Assert.Equal(sum.X, w.X);
            Assert.Equal(sum.Y, w.Y);
        }

        [Theory]
        [InlineData(1, 2, -2, -2, -4)]
        [InlineData(1, 2, 0, 0, 0)]
        [InlineData(0, 0, 10, 0, 0)]
        public void Test_Scale_1(double X1, double Y1, double k, double X2, double Y2)
        {
            Vector u = new Vector { X = X1, Y = Y1 };
            Vector v = new Vector { X = X2, Y = Y2 };
            u = u.Scale(k);
            Assert.Equal(u.X, v.X);
            Assert.Equal(u.Y, v.Y);
        }

        [Theory]
        [InlineData(double.NaN)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        public void Test_Scale_2(double k)
        {
            Vector u = new Vector { X = 1, Y = 1 };
            try {
                u = u.Scale(k);
            } catch( NotFiniteNumberException ) {
                Assert.True(true);
                return;
            } catch {
            }
            Assert.True(false);
        }

        [Theory]
        [InlineData(1, 1, 2, 2, 4)]
        [InlineData(1, 1, -1, 1, 0)]
        public void Test_DotProduct(double X1, double Y1, double X2, double Y2, double product)
        {
            Vector u = new Vector { X = X1, Y = Y1 };
            Vector v = new Vector { X = X2, Y = Y2 };
            double result = u.DotProduct(v);
            Assert.Equal(result, product);
        }

        [Theory]
        [InlineData(1, 1, 2, 2, 0)]
        [InlineData(1, 1, -1, 1, 2)]
        public void Test_CrossProduct(double X1, double Y1, double X2, double Y2, double product)
        {
            Vector u = new Vector { X = X1, Y = Y1 };
            Vector v = new Vector { X = X2, Y = Y2 };
            double result = u.CrossProduct(v);
            Assert.Equal(result, product);
        }
    }
}
