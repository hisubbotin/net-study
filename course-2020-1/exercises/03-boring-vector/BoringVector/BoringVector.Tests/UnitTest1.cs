

namespace BoringVector.Tests
{
    using Xunit;

    namespace BoringVector.Tests
    {
        public class UnitTest1
        {

            private double GetX(Vector v)
            {
                return v.DotProduct(new Vector(1, 0));
            }
            private double GetY(Vector v)
            {
                return v.DotProduct(new Vector(0, 1));
            }

            [Theory]
            [InlineData(0, 0, 0)]
            [InlineData(0, 2, 4)]
            [InlineData(2, 0, 4)]
            [InlineData(3, 4, 25)]
            public void Test_SquareLength(double x, double y, double squareLen)
            {
                var v = new Vector(x, y);
                Assert.Equal(v.SquareLength(), squareLen, 6);
            }

            [Fact]
            public void Test_Add()
            {
                var va = new Vector(2, 3);
                var vb = new Vector(-1, 4);
                Assert.Equal(GetX(va.Add(vb)), 1, 6);
                Assert.Equal(GetY(va.Add(vb)), 7, 6);
            }

            [Theory]
            [InlineData(1, 2, 0, 0, 0)]
            [InlineData(1, 2, 1, 1, 2)]
            [InlineData(1, 2, -1, -1, -2)]
            [InlineData(1, 2, 0.5, 0.5, 1)]
            [InlineData(0, 0, 3, 0, 0)]
            public void Test_Scale(double x0, double y0, double k, double x1, double y1)
            {
                var v = new Vector(x0, y0);
                v = v.Scale(k);
                Assert.Equal(GetX(v), x1, 6);
                Assert.Equal(GetY(v), y1, 6);
            }

            [Theory]
            [InlineData(1, 2, 3, 4, 11)]
            [InlineData(1, -2, 3, 4, -5)]
            [InlineData(1, 0, 0, 1, 0)]
            public void Test_DotProduct(double x1, double y1, double x2, double y2, double p)
            {
                var va = new Vector(x1, y1);
                var vb = new Vector(x2, y2);
                Assert.Equal(va.DotProduct(vb), p, 6);
                Assert.Equal(vb.DotProduct(va), p, 6);
            }

            [Theory]
            [InlineData(1, 2, 3, 4, -2)]
            [InlineData(1, -2, 3, 4, 10)]
            [InlineData(1, 0, 1, 0, 0)]
            public void Test_CrossProduct(double x1, double y1, double x2, double y2, double p)
            {
                var va = new Vector(x1, y1);
                var vb = new Vector(x2, y2);
                Assert.Equal(va.CrossProduct(vb), p, 6);
                Assert.Equal(vb.CrossProduct(va), -p, 6);
            }
        }
    }
}
