using System;
using Xunit;

namespace BoringVector.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(2, 3, 13)]
        [InlineData(0, 7, 49)]
        public void SquareLengthTest(double x, double y, double length)
        {
            var vect = new Vector {X = x, Y = y};
            Assert.Equal(vect.SquareLength(), length);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 4, 6)]
        [InlineData(-1, -2, 3, 4, 2, 2)]
        public void AdditionTest(double x1, double y1, double x2, double y2,
            double x3, double y3)
        {
            var vect1 = new Vector {X = x1, Y = y1};
            var vect2 = new Vector {X = x2, Y = y2};
            var vect3 = new Vector {X = x3, Y = y3};
            Assert.Equal(vect1.Add(vect2), vect3);
        }
        
        [Theory]
        [InlineData(1, 2, 2, 2, 4)]
        [InlineData(0, 10, 0.2, 0, 2)]
        public void ScaleTest(double x1, double y1, double k, double x2, double y2)
        {
            var vect1 = new Vector {X = x1, Y = y1};
            var vect2 = new Vector {X = x2, Y = y2};
            Assert.Equal(vect1.Scale(k), vect2);
        }

        [Theory]
        [InlineData(1, 10, 4, 4, 44)]
        [InlineData(5, 4, 2, -1, 6)]
        public void DotProductTest(double x1, double y1, double x2, double y2, double ans)
        {
            var vect1 = new Vector {X = x1, Y = y1};
            var vect2 = new Vector {X = x2, Y = y2};
            Assert.Equal(vect1.DotProduct(vect2), ans);
        }

        [Theory]
        [InlineData(1, 5, 7, -2, -37)]
        [InlineData(3, -4, 7, 2, 34)]
        public void CrossProductTest(double x1, double y1, double x2, double y2, double ans)
        {
            var vect1 = new Vector {X = x1, Y = y1};
            var vect2 = new Vector {X = x2, Y = y2};
            Assert.Equal(vect1.CrossProduct(vect2), ans);
        }
    }
}