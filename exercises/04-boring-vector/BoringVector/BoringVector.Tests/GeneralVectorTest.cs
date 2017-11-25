using System;
using System.Collections.Generic;
using Xunit;

namespace BoringVector.Tests
{
    public class GeneralVectorTest
    {
        private static void AssertDoubleAreEqual(double a, double b)
        {
            Assert.True(Math.Abs(a - b) < 1e-6);
        }

        private static void AssertVectorsAreEqual(Vector v, Vector u)
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
        
        /// <summary>
        /// <see cref="Vector"/> v, 
        /// <see cref="Vector"/> u, 
        /// <see cref="Vector"/> u + v
        /// </summary>
        private static IEnumerable<object[]> GetTestDataFor_Add()
        {
            return new[]
            {
                new object[] {new Vector(1.5, -1.5), new Vector(-1.5, 1.5), new Vector(0, 0)},
                new object[] {new Vector(0, 100), new Vector(-1.5, 1.5), new Vector(-1.5, 101.5)},
                new object[] {new Vector(1, 1), new Vector(0, 0), new Vector(1, 1)}
            };
        }
        
        [Theory]
        [MemberData(nameof(GetTestDataFor_Add))]
        internal void Test_Add(Vector v, Vector u, Vector sum)
        {
             AssertVectorsAreEqual(v.Add(u), sum);   
        }
        
        /// <summary>
        /// <see cref="Vector"/> v, 
        /// <see cref="double"/> k, 
        /// <see cref="Vector"/> v * k
        /// </summary>
        private static IEnumerable<object[]> GetTestDataFor_Scale()
        {
            return new[]
            {
                new object[]
                {
                    new Vector(1.5, -1.5), 
                    2, 
                    new Vector(3, -3)
                },
                new object[]
                {
                    new Vector(42, -0.0001), 
                    0, 
                    new Vector(0, 0)
                },
                new object[]
                {
                    new Vector(9, -7), 
                    -1, 
                    new Vector(-9, 7)
                },
                new object[]
                {
                    new Vector(0, 0), 
                    9000, 
                    new Vector(0, 0)
                }
            };
        }
        
        [Theory]
        [MemberData(nameof(GetTestDataFor_Scale))]
        internal void Test_Scale(Vector v, double scale, Vector scaled)
        {
            AssertVectorsAreEqual(v.Scale(scale), scaled);
        }
        
        /// <summary>
        /// <see cref="Vector"/> v, 
        /// <see cref="Vector"/> u, 
        /// <see cref="double"/> v.DotProduct(u)
        /// </summary>
        private static IEnumerable<object[]> GetTestDataFor_DotProduct()
        {
            return new[]
            {
                new object[]
                {
                    new Vector(1.5, -1.5),
                    new Vector(2, -1),
                    4.5
                },
                new object[]
                {
                    new Vector(42, -0.0001),
                    new Vector(0, 0),
                    0
                },
                new object[]
                {
                    new Vector(2, -3),
                    new Vector(-2, 3),
                    -13
                },
                new object[]
                {
                    new Vector(0, 1),
                    new Vector(1, 0),
                    0
                }
            };
        }
        
        [Theory]
        [MemberData(nameof(GetTestDataFor_DotProduct))]
        internal void Test_DotProduct(Vector v, Vector u, double dotProduct)
        {
            AssertDoubleAreEqual(v.DotProduct(u), dotProduct);
        }
        
        /// <summary>
        /// <see cref="Vector"/> v, 
        /// <see cref="Vector"/> u, 
        /// <see cref="double"/> v.CrossProduct(u)
        /// </summary>
        private static IEnumerable<object[]> GetTestDataFor_CrossProduct()
        {
            return new[]
            {
                new object[]
                {
                    new Vector(1.5, -1.5),
                    new Vector(2, -1),
                    1.5
                },
                new object[]
                {
                    new Vector(42, -0.0001),
                    new Vector(0, 0),
                    0
                },
                new object[]
                {
                    new Vector(2, -3),
                    new Vector(2, 3),
                    12
                },
                new object[]
                {
                    new Vector(0, 1),
                    new Vector(1, 0),
                    -1
                }
            };
        }
        
        [Theory]
        [MemberData(nameof(GetTestDataFor_CrossProduct))]
        internal void Test_CrossProduct(Vector v, Vector u, double crossProduct)
        {
            AssertDoubleAreEqual(v.CrossProduct(u), crossProduct);
        }

        [Fact]
        internal void Test_DevideByZero()
        {
            var devisionResult = new Vector(7, -9) / 0;
            Assert.Equal(devisionResult.X, double.PositiveInfinity);
            Assert.Equal(devisionResult.Y, double.NegativeInfinity);
        }
    }
}