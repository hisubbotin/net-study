using System;
using System.Numerics;
using Xunit;

 
namespace BoringVector.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(0.0, 0.0, 0.0, 1e-6)]
        [InlineData(4.0, 3.0, 25.0, 1e-6)]
        public void TestSquareLength(double x, double y, double answer, double presicion)
        {
            Vector v = new Vector(x,y);
            Assert.True(v.SquareLength() - answer < presicion);
        }

        [Theory]
        [InlineData(0.1, 0.0, 1.0, 2.3, 1.1, 2.3, 1e-3)]
        public void TestAdd(double x_, double y_, double x, double y, double answer_x, double answer_y, double presicion)
        {
            Vector v = new Vector(x_, y_);
            Vector v2 = new Vector(x, y);
            Vector pre_ans = v.Add(v2);

            Assert.True((Math.Abs(pre_ans.X) - 1.1) < presicion);
            Assert.True((Math.Abs(pre_ans.Y) - 2.3) < presicion);
        }

        [Theory]
        [InlineData(1.0, 2.0, 2.5, 2.5, 5.0, 1e-6)]
        public void TestScale(double x_, double y_, double k, double answer_x, double answer_y, double presicion)
        {
            Vector v = new Vector(x_, y_);
            Vector pre_ans = v.Scale(k);

            Assert.True(Math.Abs(pre_ans.X - answer_x) < presicion);
            Assert.True(Math.Abs(pre_ans.Y - answer_y) < presicion);
        }
        
        [Theory]
        [InlineData(1.0, 2.0, 2.5, 3.0, 8.5, 1e-6)]
        public void TestDotProduct(double x_, double y_, double x, double y, double answer, double presicion)
        {
            Vector v = new Vector(x_, y_);
            Vector v2 = new Vector(x, y);
            Assert.True(Math.Abs(v.DotProduct(v2) - answer) < presicion);
        }

        [Theory]
        [InlineData(1.0, 2.0, 2.5, 3.0, -2.0, 1e-6)]
        public void TestCrossProduct(double x_, double y_, double x, double y, double answer, double presicion)
        {
            Vector v = new Vector(x_, y_);
            Vector v2 = new Vector(x, y);
            Assert.True(Math.Abs(v.CrossProduct(v2) - answer) < presicion);
        }
    }
}
