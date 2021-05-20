/*
    Атрибуты [Fact] и [Theory] означают, что данный метод является тестовым, т.е. TestRunner должен его запускать. 
    Совсем обывательски - разница в том, что метод с [Theory] дает возможность тестовому методу принимать аргументы и быть запущенным с разными входными данными.
    Посмотри на два первых тестовых метода. Первый при тестовом прогоне будет запущен один раз, а второй три - каждый раз с разным набором входных данных.
*/

using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTest
    {
        [Theory]
        [InlineData(3, -4, 25)]
        [InlineData(12, 5, 169)]
        [InlineData(-0.5, -0.5, 0.5)]
        [InlineData(-1.2, 0.0, 1.44)]
        [InlineData(0, 0, 0)]
        public void Test_SquareLength(double x, double y, double val)
        {
            Assert.Equal(val, new BoringVector.Vector(x, y).SquareLength());
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 2, 2)]
        [InlineData(0, -1, -1000, 1001, -1000, 1000)]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(0.11, -0.5, 0.89, -99.5, 1, -100)]
        public void Test_Add(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Assert.Equal(x3, (new BoringVector.Vector(x1, y1).Add(new BoringVector.Vector(x2, y2))).X);
            Assert.Equal(y3, (new BoringVector.Vector(x1, y1).Add(new BoringVector.Vector(x2, y2))).Y);
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 2, 2)]
        [InlineData(0, -1, -1000, 1001, -1000, 1000)]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(0.11, -0.5, 0.89, -99.5, 1, -100)]
        public void Test_Plus(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Assert.Equal(x3, (new BoringVector.Vector(x1, y1) + new BoringVector.Vector(x2, y2)).X);
            Assert.Equal(y3, (new BoringVector.Vector(x1, y1) + new BoringVector.Vector(x2, y2)).Y);
        }

        [Theory]
        [InlineData(1, 1, 2, 2, 2)]
        [InlineData(0, -10, -100, 0, 1000)]
        [InlineData(5, 0.81, 0, 0, 0)]
        [InlineData(0.1, -0.5, 0.5, 0.05, -0.25)]
        public void Test_Scale(double x1, double y1, double k, double x3, double y3)
        {
            Assert.Equal(x3, (new BoringVector.Vector(x1, y1).Scale(k)).X);
            Assert.Equal(y3, (new BoringVector.Vector(x1, y1).Scale(k)).Y);
        }

        [Theory]
        [InlineData(1, 1, 2, 2, 2)]
        [InlineData(0, -10, -100, 0, 1000)]
        [InlineData(5, 0.81, 0, 0, 0)]
        [InlineData(0.1, -0.5, 0.5, 0.05, -0.25)]
        public void Test_Mult(double x1, double y1, double k, double x3, double y3)
        {
            Assert.Equal(x3, (new BoringVector.Vector(x1, y1) * k).X);
            Assert.Equal(y3, (new BoringVector.Vector(x1, y1) * k).Y);
        }

        [Theory]
        [InlineData(1, 1, 2, 2, 4)]
        [InlineData(10, -10, 0, -100, 1000)]
        [InlineData(0.1, 0.81, 1.9, 1, 1)]
        [InlineData(0.1, -0.5, 0.5, 0.1, 0)]
        public void Test_DotProduct(double x1, double y1, double x2, double y2, double d)
        {
            Assert.Equal(d, new BoringVector.Vector(x1, y1).DotProduct(new BoringVector.Vector(x2, y2)));
        }

        [Theory]
        [InlineData(1, 0, 2, 2, 2)]
        [InlineData(1, 0, 0, 1, 1)]
        [InlineData(1, 0, 0, -1, -1)]
        [InlineData(0.5, 0.5, 2, 0, -1)]
        public void Test_CrossProduct(double x1, double y1, double x2, double y2, double d)
        {
            Assert.Equal(d, new BoringVector.Vector(x1, y1).CrossProduct(new BoringVector.Vector(x2, y2)));
        }
    }
}
