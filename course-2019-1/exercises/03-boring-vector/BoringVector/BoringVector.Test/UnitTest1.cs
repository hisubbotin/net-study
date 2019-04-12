using System;
using Xunit;

using static BoringVector.VectorWithExtensions;
using static System.Math;

namespace BoringVector.Test
{
    public class SquareLength
    {

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(5, 5, 50)]
        [InlineData(1, 1, 2)]
        [InlineData(10, 10, 200)]
        public void TestSquareLength(double x1, double x2, double res)
        {
            Assert.True(Abs(new Vector(x1, x2).SquareLength() - res)< eps);
        }
    }

    public class Add
    {

        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(1, 1, 1, 1, 8)]
        [InlineData(3, 4, 4, 3, 98)]
        public void TestAdd(double x1_1, double x2_1, double x1_2, double x2_2, double res)
        {
            Vector resVec = (new Vector(x1_1, x2_1).Add(new Vector(x1_2, x2_2)));
            Console.WriteLine(resVec.X + " " + resVec.Y);
            Assert.True(Abs(resVec.SquareLength() - res)< eps);
        }
    }

    public class Scale
    {
        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(1, 2, 2, 4, 2)]
        [InlineData(5, 1, 15, 3, 3)]
        public void TestScale(double x1, double x2, double resx1, double resx2, double koef)
        {
            Vector resVec = new Vector(resx1, resx2);
            Vector vec = (new Vector(x1, x2)).Scale(koef);
            Assert.True(Abs((resVec - vec).SquareLength()) < eps);
        }
}

    public class DotProduct
    {
        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(0, 1, 1, 0, 0)]
        [InlineData(1, 0, 0, 1, 0)]
        [InlineData(3, 4, 3, 4, 25)]
        public void TestDotProduct(double x1_1, double x2_1, double x1_2, double x2_2, double res)
        {
            double scalar = (new Vector(x1_1, x2_1)).DotProduct(new Vector(x1_2, x2_2));
            Assert.True(Math.Abs(scalar - res) < eps);
        }
    }

    public class CrossProduct
    {
        [Theory]
        [InlineData(1, 1, 1, 1, 0)]
        [InlineData(1, 0, 0, 1, 1)]
        [InlineData(4, 3, 3, 4, 7)]
        public void TestCrossProduct(double x1_1, double x2_1, double x1_2, double x2_2, double res)
        {
            Double S = (new Vector(x1_1, x2_1)).CrossProduct(new Vector(x1_2, x2_2));
            Assert.True(Abs(S - res) < eps);
        }
    }
}
