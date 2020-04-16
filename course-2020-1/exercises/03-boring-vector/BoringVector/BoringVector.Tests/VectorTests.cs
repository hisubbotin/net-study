using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Xunit;
using BoringVector;
using Microsoft.VisualBasic.CompilerServices;

namespace BoringVector.Tests
{
    public class VectorTest
    {
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(0, 0, 0)]
        [InlineData(-1, 1, 2)]
        public void Test_SquaredLength(double x, double y, double sqlen)
        {
            var v = new Vector(x, y);
            Assert.Equal(v.SquareLength(), sqlen);
        }

        [Theory]
        [InlineData(1, 1, 2, 2, 3, 3)]
        [InlineData(-1, 1, 1, -1, 0, 0)]
        public void Test_Add(double vx, double vy, double ux, double uy, double ax, double ay)
        {
            var v = new Vector(vx, vy);
            var u = new Vector(ux, uy);
            var sum = v.Add(u);
            Assert.Equal(sum.X, ax);
            Assert.Equal(sum.Y, ay);
            
        }

        [Theory]
        [InlineData(1, 1, 2, 2, 2)]
        [InlineData(-1, 1, 0, 0, 0)]
        [InlineData(1, 1.2, 0.5, 0.5, 0.6)]
        public void Test_Scale(double x, double y, double k, double ax, double ay)
        {
            var v = new Vector(x, y);
            var scaled_v = v.Scale(k);
            Assert.Equal(scaled_v.X, ax);
            Assert.Equal(scaled_v.Y, ay);
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 2)]
        [InlineData(1, 1, -1, 1, 0)]
        [InlineData(1.2, 1.3, 0.5, 5.0, 7.1)]
        public void Test_DotProd(double vx, double vy, double ux, double uy, double prod)
        {
            var v = new Vector(vx, vy);
            var u = new Vector(ux, uy);
            var ans = v.DotProduct(u);
            Assert.Equal(ans, prod);
        }
        
        [Theory]
        [InlineData(1, 1, 1, 1, 0)]
        [InlineData(1, 1, -1, 1, 2)]
        [InlineData(1.2, 1.3, 0.5, 5.0, 5.35)]
        public void Test_CrossProd(double vx, double vy, double ux, double uy, double prod)
        {
            var v = new Vector(vx, vy);
            var u = new Vector(ux, uy);
            var ans = v.CrossProduct(u);
            Assert.Equal(ans, prod);
        }
    }
}