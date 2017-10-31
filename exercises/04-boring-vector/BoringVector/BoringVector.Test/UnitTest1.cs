using System;
using System.Collections.Generic;
using Xunit;

namespace BoringVector.Test
{
    public class UnitTest1
    {
        internal static bool Equals(double one, double other)
        {
            // �������� � ���� ������ ��������� Infinity
            if (one == other)
                return true;

            return Math.Abs(one - other) < VectorExtentions.Eps;
        }

        internal static bool Equals(Vector one, Vector other)
        {
            var xEqual = Equals(one.X, other.X);
            var yEqual = Equals(one.Y, other.Y);

            return xEqual && yEqual;
        }

        [Theory]
        [InlineData(0, 0, "(0; 0)")]
        [InlineData(-1, 567.4, "(-1; 567,4)")]
        public void TestToString(double X, double Y, string result)
        {
            Assert.Equal(result, new Vector(X, Y).ToString());
        }

        internal static IEnumerable<object[]> VectorAriphmetics()
        {
            yield return new object[] { new Vector(0, 0), new Vector(0, 0), new Vector(0, 0) };
            yield return new object[] { new Vector(1, 2), new Vector(3, 4), new Vector(4, 6) };
            yield return new object[] { new Vector(0.123, -0.123), new Vector(0.123, -0.123), new Vector(0.246, -0.246) };
            yield return new object[] { new Vector(42, -100500), new Vector(-42, 100500), new Vector(0, 0) };
        }


        [Theory]
        [MemberData(nameof(VectorAriphmetics))]
        internal void TestAdd(Vector one, Vector other, Vector sum)
        {
            Assert.True(Equals(one + other, sum));
        }

        [Theory]
        [MemberData(nameof(VectorAriphmetics))]
        internal void TestMinus(Vector difference, Vector subtrahend, Vector minuend)
        {
            Assert.True(Equals(minuend - subtrahend, difference));
        }


        [Theory]
        [InlineData(0, 0, 10, 0, 0)]
        [InlineData(10, 10, 1, 10, 10)]
        [InlineData(10, 10, 0, double.PositiveInfinity, double.PositiveInfinity)]
        public void TestDivision(double X, double Y, double k, double XExpect, double YExpect)
        {
            Assert.True(Equals(new Vector(XExpect, YExpect), new Vector(X, Y) / k));
        }

        [Theory]
        [InlineData(10, 1, 0, 10)]
        public void TestAngle(double X1, double Y1, double X2, double Y2)
        {
            Vector v1 = new Vector(X1, Y1);
            Vector v2 = new Vector(X2, Y2);
            Assert.True(Equals(v1.GetAngleBetween(v2), v2.GetAngleBetween(v1)));
        }

        [Fact]
        public void TestNothingDoingOperator()
        {
            var v = new Vector(1.2345, 2.34567);
            Assert.True(Equals(v, +v));
        }

    }
}