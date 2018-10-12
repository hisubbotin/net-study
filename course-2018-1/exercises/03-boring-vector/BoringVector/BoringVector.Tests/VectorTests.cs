using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Transactions;
using Xunit;

namespace BoringVector.Tests
{
    
    public class VectorTest
    {  
        private double eps = 1e-6;
        private int precision = 6;
        public static IEnumerable<object[]> SquareLengthTests()
        {
            return new List<object[]>
            {
                 new object[] {new Vector(1.0,2.0), 5.0},
                new object[] {new Vector(1123.0,212.0), 1123*1123 + 212 * 212},
                 new object[] {new Vector(0.0, 0.0), 0.0},
            };
        }
        
        [Theory]
        [MemberData(nameof(SquareLengthTests))]
        public void Test_SquareLength(Vector vec, double length)
        {
            Assert.Equal(vec.SquareLength(), length, precision);
        }
        
        public static IEnumerable<object[]> AddTests()
        {
            return new List<object[]>
            {
                new object[] {new Vector(1.0,2.0), new Vector(0.0,0.0), new Vector(1.0,2.0) },
                new object[] {new Vector(0.0, 0.0), new Vector(0.0, 0.0), new Vector(0.0, 0.0) },
            };
        }
        
        [Theory]
        [MemberData(nameof(AddTests))]
        public void Test_Add(Vector first, Vector second, Vector result)
        {
            first.Add(second);
            Assert.Equal(first.x, result.x, precision);
            Assert.Equal(first.y, result.y, precision);
        }
        
        public static IEnumerable<object[]> ScaleTests()
        {
            return new List<object[]>
            {
                new object[] {new Vector(1.0,1.5), 2.0, new Vector(2.0,3.0)},
                new object[] {new Vector(2, 3), 0.0, new Vector(0,0), },
            };
        }
        
        [Theory]
        [MemberData(nameof(ScaleTests))]
        public void Test_Scale(Vector vec, double k, Vector result)
        {
            vec.Scale(k);
            Assert.Equal(vec.x, result.x, precision);
            Assert.Equal(vec.y, result.y, precision);
        }
        
        public static IEnumerable<object[]> DotProductTests()
        {
            return new List<object[]>
            {
                new object[] {new Vector(3.0, 1.0), new Vector(2.0, 4.0), 10.0},
                new object[] {new Vector(7.0, 0.5), new Vector(10.0, 12.0), 76.0},
                new object[] {new Vector(10.0, 12.0), new Vector(0.0, 0.0), 0.0},

            };
        }
        
        [Theory]
        [MemberData(nameof(DotProductTests))]
        public void Test_DotProduct(Vector a, Vector b, double product)
        {
            Assert.Equal(a.DotProduct(b), product, precision);
        }
        
        public static IEnumerable<object[]> CrossProductTests()
        {
            return new List<object[]>
            {
                new object[] {new Vector(1.0, 0.0), new Vector(0.0, 1.0), 1.0},
                new object[] {new Vector(1.0, 2.0), new Vector(3.0, 8.0), 2.0},
                new object[] {new Vector(0.0, 0.0), new Vector(12321.12, 423.1), 0.0},
            };
        }
        
        [Theory]
        [MemberData(nameof(CrossProductTests))]
        public void Test_CrossProduct(Vector a, Vector b, double crossProduct)
        {
            Assert.Equal(a.CrossProduct(b), crossProduct, precision);
        }
        
        public static IEnumerable<object[]> UnaryPlusTests()
        {
            return new List<object[]>
            {
                new object[] {new Vector(1.0,2.0), new Vector(1.0,2.0)},
                new object[] {new Vector(0.0, 0.0), new Vector(0.0, 0.0)},
            };
        }
        
        [Theory]
        [MemberData(nameof(UnaryPlusTests))]
        public void Test_Unary_Plus(Vector vec, Vector result)
        {
            vec = +vec;
            Assert.Equal(vec.x, result.x, precision);
            Assert.Equal(vec.y, result.y, precision);
        }
        
        public static IEnumerable<object[]> Unary_MinusTests()
        {
            return new List<object[]>
            {
                new object[] {new Vector(1.0,2.0), new Vector(-1.0,-2.0)},
                new object[] {new Vector(0.0, 0.0), new Vector(0.0,0.0)},
            };
        }
        
        [Theory]
        [MemberData(nameof(Unary_MinusTests))]
        public void Test_Unary_Minus(Vector vec, Vector result)
        {
            vec = -vec;
            Assert.Equal(vec.y, result.y, precision);
            Assert.Equal(vec.x, result.x, precision);
        }
        
        public static IEnumerable<object[]> IsZeroTests()
        {
            return new List<object[]>
            {
                new object[] {new Vector(1.0,2.0), false},
                new object[] {new Vector(0.0, 0.0), true},
                new object[] {new Vector(-1.0, -123.0), false},
                new object[] {new Vector(-3.0, -2.0), false},
            };
        }
        
        [Theory]
        [MemberData(nameof(IsZeroTests))]
        public void Test_IsZero(Vector vec, bool flag)
        {
            Assert.Equal(VectorExtension.IsZero(vec), flag);
        }
        
        public static IEnumerable<object[]> NormalizeTests()
        {
            return new List<object[]>
            {
                new object[] {new Vector(1123.0, 4512.0), new Vector(0.241523399, 0.0002087)},
                new object[] {new Vector(-12.0, -324.0), new Vector(-0.000114, -0.003082)},
            };
        }
        
        [Theory]
        [MemberData(nameof(NormalizeTests))]
        public void Test_Normalize(Vector vec, Vector result)
        {
            vec = vec.Normalize();
            Assert.Equal(vec.x, result.x, precision);
            Assert.Equal(vec.y, result.y, precision);
        }
        
        public static IEnumerable<object[]> GetAngleBetweenTests()
        {
            return new List<object[]>
            {
                new object[] {new Vector(1.0,2.0), new Vector(-1.0,-2.0), Math.PI},
                new object[] {new Vector(1.0, 0.0), new Vector(0,1), Math.PI / 2},
                new object[] {new Vector(1.0, 0.0), new Vector(1,1), Math.PI / 4},
            };
        }
        
        [Theory]
        [MemberData(nameof(GetAngleBetweenTests))]
        public void Test_GetAngleBetween(Vector a, Vector b, double angle)
        {
            Assert.Equal(VectorExtension.GetAngleBetween(a,b), angle);
        }
        
        public static IEnumerable<object[]> GetRelationTests()
        {
            return new List<object[]>
            {
                new object[] {new Vector(1.0,2.0), new Vector(0.0, 0.0), VectorRelation.Orthogonal},
                new object[] {new Vector(1.0, 2.0), new Vector(3.0, 6.0), VectorRelation.Parallel},
                new object[] {new Vector(-4.0, 8.0), new Vector(1.0, 2.0), VectorRelation.General},
            };
        }
        
        [Theory]
        [MemberData(nameof(GetRelationTests))]
        public void Test_GetRelation(Vector a, Vector b, VectorRelation relation)
        {
            Assert.Equal(VectorExtension.GetRelation(a,b), relation);
        }
    }
}