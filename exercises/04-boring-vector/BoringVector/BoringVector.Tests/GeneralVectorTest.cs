using System;
using System.Collections.Generic;
using Xunit;

namespace BoringVector.Tests
{
    public class GeneralVectorTest
    {
        static void AssertDoubleAreEqual(double a, double b)
        {
            Assert.True(Math.Abs(a - b) < 1e-6);
        }

        static void AssertVectorsAreEqual(Vector v, Vector u)
        {
            AssertDoubleAreEqual(v.X, u.X);
            AssertDoubleAreEqual(v.Y, u.Y);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 0, 4)]
        [InlineData(0, 2, 4)]
        [InlineData(-2, -2, 8)]
        [InlineData(1, 10, 101)]
        internal void Test_SquareLength(double x, double y, double squareLength)
        {
            Assert.Equal((new Vector(x, y)).SquareLength(), squareLength);
        }
        
        internal static IEnumerable<object[]> GetVectorPairs()
        {
            yield return new object[] { new Vector(1.5, -1.5), new Vector(-1.5, 1.5), new Vector(0, 0)};
            yield return new object[] { new Vector(0, 100), new Vector(-1.5, 1.5), new Vector(-1.5, 101.5)};
            yield return new object[] { new Vector(1, 1), new Vector(0, 0), new Vector(1, 1)};
        }
        
        [Theory]
        [MemberData(nameof(GetVectorPairs))]
        internal void Test_Add(Vector v, Vector u, Vector sum)
        {
             AssertVectorsAreEqual(v.Add(u), sum);   
        }
        
        internal static IEnumerable<object[]> GetVectorDouble_ScaledVector()
        {
            yield return new object[]
            {
                new Vector(1.5, -1.5),
                2,
                new Vector(3, -3)
            };
            yield return new object[]
            { 
                new Vector(42, -0.0001),
                0,
                new Vector(0, 0)
                
            };
            yield return new object[]
            {
                new Vector(9, -7),
                -1,
                new Vector(-9, 7)
            };
            yield return new object[]
            {
                new Vector(0, 0),
                9000,
                new Vector(0, 0)
            };
        }
        
        [Theory]
        [MemberData(nameof(GetVectorDouble_ScaledVector))]
        internal void Test_Scale(Vector v, double scale, Vector scaled)
        {
            AssertVectorsAreEqual(v.Scale(scale), scaled);
        }
        
        internal static IEnumerable<object[]> GetVectorVector_DotProduct()
        {
            yield return new object[]
            {
                new Vector(1.5, -1.5),
                new Vector(2, -1),
                4.5
            };
            yield return new object[]
            { 
                new Vector(42, -0.0001),
                new Vector(0, 0),
                0
            };
            yield return new object[]
            {
                new Vector(2, -3),
                new Vector(-2, 3),
                -13
            };
            yield return new object[]
            {
                new Vector(0, 1),
                new Vector(1, 0),
                0
            };
        }
        
        [Theory]
        [MemberData(nameof(GetVectorVector_DotProduct))]
        internal void Test_DotProduct(Vector v, Vector u, double dotProduct)
        {
            AssertDoubleAreEqual(v.DotProduct(u), dotProduct);
        }
        
        internal static IEnumerable<object[]> GetVectorVector_CrossProduct()
        {
            yield return new object[]
            {
                new Vector(1.5, -1.5),
                new Vector(2, -1),
                1.5
            };
            yield return new object[]
            { 
                new Vector(42, -0.0001),
                new Vector(0, 0),
                0
            };
            yield return new object[]
            {
                new Vector(2, -3),
                new Vector(2, 3),
                12
            };
            yield return new object[]
            {
                new Vector(0, 1),
                new Vector(1, 0),
                -1
            };
        }
        
        [Theory]
        [MemberData(nameof(GetVectorVector_CrossProduct))]
        internal void Test_CrossProduct(Vector v, Vector u, double crossProduct)
        {
            AssertDoubleAreEqual(v.CrossProduct(u), crossProduct);
        }

        [Fact]
        internal void Test_DevideByZero()
        {
            Vector devisionResult = new Vector(7, -9) / 0;
            Assert.Equal(devisionResult.X, double.PositiveInfinity);
            Assert.Equal(devisionResult.Y, double.NegativeInfinity);
        }
    }
}