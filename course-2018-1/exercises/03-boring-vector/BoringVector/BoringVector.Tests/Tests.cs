using Xunit;
using System;
using System.Numerics;

namespace BoringVector.Tests
{
    public class VectorTest
    {
        [Theory]
        [InlineData(1, 2, 5)]
        [InlineData(2, -2, 8)]
        [InlineData(1, 0, 1)]
        public void Test_SquareLength(double x, double y, double result)
        {
            var vector = new Vector(x, y);
            Assert.Equal(vector.SquareLength(), result);
        }
        
        [Theory]
        [InlineData(1, 2, 2, 1, 3, 3)]
        [InlineData(2, 2, -3, 0, -1, 2)]
        [InlineData(1, 1, 0, 0, 1, 1)]
        public void Test_Add(double x1, double y1, double x2, double y2, double xr, double yr)
        {
            var v1 = new Vector(x1, y1);
            var v2 = new Vector(x2, y2);
            var vr = new Vector(xr, yr);
            Assert.Equal(v1.Add(v2), vr);
        }
        
        [Theory]
        [InlineData(1, 2, 2, 2, 4)]
        [InlineData(2, 2, -3, -6, -6)]
        [InlineData(1, 1, 0, 0, 0)]
        public void Test_Scale(double x1, double y1, double k, double xr, double yr)
        {
            var v1 = new Vector(x1, y1);
            var vr = new Vector(xr, yr);
            Assert.Equal(v1.Scale(k), vr);
        }
        
        [Theory]
        [InlineData(1, 2, 2, 1, 4)]
        [InlineData(2, 2, -3, 0, -6)]
        [InlineData(1, 1, 0, 0, 0)]
        public void Test_DotProduct(double x1, double y1, double x2, double y2, double result)
        {
            var v1 = new Vector(x1, y1);
            var v2 = new Vector(x2, y2);
            Assert.Equal(v1.DotProduct(v2), result);
        }
        
        [Theory]
        [InlineData(1, 2, 2, 1, -3)]
        [InlineData(2, 2, -3, 0, 6)]
        [InlineData(1, 1, 0, 0, 0)]
        public void Test_CrossProduct(double x1, double y1, double x2, double y2, double result)
        {
            var v1 = new Vector(x1, y1);
            var v2 = new Vector(x2, y2);
            Assert.Equal(v1.CrossProduct(v2), result);
        }
    }
}