using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace BoringVector.Tests
{
    public class TestDataGeneratorSquareLength: IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new Vector(1.5, 1), 3.25},
            new object[] {new Vector(-1, 1), 2},
            new object[] {new Vector(10, -11), 221},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorAdd: IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new Vector(1.5, 1), new Vector(-1.5, 0), new Vector(0, 1)},
            new object[] {new Vector(-1.2, 2), new Vector(2.4, 2), new Vector(1.2, 4)},
            new object[] {new Vector(0, 4.1), new Vector(7, 2), new Vector(7, 6.1)},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorScale: IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new Vector(10.0, 1), 2.2, new Vector(22.0, 2.2)},
            new object[] {new Vector(-1, 2), 1, new Vector(-1, 2)},
            new object[] {new Vector(0, 4.1), -4, new Vector(0, -16.4)},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorDotProduct: IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new Vector(10.0, 1.0), new Vector(22.0, 2.2), 222.2},
            new object[] {new Vector(-1, 2), new Vector(-1, 2), 5},
            new object[] {new Vector(0, 4.1), new Vector(0, -16.4), -67.24},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorCrossProduct: IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new Vector(10.0, 1.0), new Vector(22.0, 2.2), 0},
            new object[] {new Vector(-1, 2), new Vector(-1, 2), 0},
            new object[] {new Vector(1, 2), new Vector(3.5, 3), -4},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorToString: IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new Vector(10.0, 1.9), "(10, 1.9)"},
            new object[] {new Vector(-1, 2), "(-1, 2)"},
            new object[] {new Vector(1, 2), "(1, 2)"},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorOperatorPlus: IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new Vector(1.5, 1), new Vector(-1.5, 0), new Vector(0, 1)},
            new object[] {new Vector(-1.2, 2), new Vector(2.4, 2), new Vector(1.2, 4)},
            new object[] {new Vector(0, 4.1), new Vector(7, 2), new Vector(7, 6.1)},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorOperatorMinus: IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new Vector(1.5, 1), new Vector(1.5, 0), new Vector(0, 1)},
            new object[] {new Vector(-1.2, 2), new Vector(-2.4, -2), new Vector(1.2, 4)},
            new object[] {new Vector(0, 4.1), new Vector(-7, -2), new Vector(7, 6.1)},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorOperatorMultiply: IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new Vector(1.5, 1), 1, new Vector(1.5, 1)},
            new object[] {new Vector(-1.2, 2), 2.5, new Vector(-3, 5)},
            new object[] {new Vector(0, 4.1), -10, new Vector(0, -41)},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorOperatorDivision: IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new Vector(1.5, 1), 1, new Vector(1.5, 1)},
            new object[] {new Vector(-1.2, 2), 2, new Vector(-0.6, 1)},
            new object[] {new Vector(0, 4.1), -0.5, new Vector(0, -8.2)},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorOperatorUnaryPlus: IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new Vector(1.5, 1), new Vector(1.5, 1)},
            new object[] {new Vector(-1.2, 2), new Vector(-1.2, 2)},
            new object[] {new Vector(0, 4.1), new Vector(0, 4.1)},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorOperatorUnaryMinus: IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new Vector(1.5, 1), new Vector(-1.5, -1)},
            new object[] {new Vector(-1.2, 2), new Vector(1.2, -2)},
            new object[] {new Vector(0, 4.1), new Vector(0, -4.1)},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorExtensionIsZero: IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new Vector(1.5, 1), false},
            new object[] {new Vector(-1.2, 1e-10), false},
            new object[] {new Vector(1e-10, -1e-10), true},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorExtensionNormalize: IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new Vector(3, 4), new Vector(0.6, 0.8)},
            new object[] {new Vector(-6, 8), new Vector(-0.6, 0.8)},
            new object[] {new Vector(1e-10, -1e-10), new Vector(0, 0)},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorExtensionGetAngleBetween: IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new Vector(3, 4), new Vector(0.6, 0.8), 0},
            new object[] {new Vector(-6, 8), new Vector(0.8, 0.6), Math.PI / 2},
            new object[] {new Vector(1e-10, -1e-10), new Vector(10, -11), 0},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestDataGeneratorExtensionGetRelation: IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {new Vector(3, 4), new Vector(0.6, 0.8), BoringVectorExtensions.VectorRelation.Parallel},
            new object[] {new Vector(-6, 8), new Vector(0.8, 0.6), BoringVectorExtensions.VectorRelation.Orthogonal},
            new object[] {new Vector(1, -7), new Vector(10, -11), BoringVectorExtensions.VectorRelation.General},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class SquareLengthTest
    {
        [Theory]
        [ClassData(typeof(TestDataGeneratorSquareLength))]
        internal void TestSquareLength(Vector v, double length)
        {
            Assert.Equal(v.SquareLength(), length);
        }
    }
    
    public class ScaleTest
    {
        [Theory]
        [ClassData(typeof(TestDataGeneratorScale))]
        internal void TestScale(Vector v, double k, Vector x)
        {
            Assert.Equal(v.Scale(k).X, x.X);
            Assert.Equal(v.Scale(k).Y, x.Y);
        }
    }
    
    public class AddTest
    {
        [Theory]
        [ClassData(typeof(TestDataGeneratorAdd))]
        internal void TestAdd(Vector v, Vector u, Vector x)
        {
            Assert.Equal(v.Add(u).X, x.X);
            Assert.Equal(v.Add(u).Y, x.Y);
        }
    }
    
    public class DotProductTest
    {
        [Theory]
        [ClassData(typeof(TestDataGeneratorDotProduct))]
        internal void TestDotProduct(Vector v, Vector u, double dp)
        {
            Assert.Equal(v.DotProduct(u), dp);
        }
    }
    
    public class CrossProductTest
    {
        [Theory]
        [ClassData(typeof(TestDataGeneratorCrossProduct))]
        internal void TestCrossProduct(Vector v, Vector u, double dp)
        {
            Assert.Equal(v.CrossProduct(u), dp);
        }
    }
    
    public class ToStringTest
    {
        [Theory]
        [ClassData(typeof(TestDataGeneratorToString))]
        internal void TestCrossProduct(Vector v, string str)
        {
            Assert.Equal(v.ToString(), str);
        }
    }
    
    public class OperatorPlusTest
    {
        [Theory]
        [ClassData(typeof(TestDataGeneratorOperatorPlus))]
        internal void TestOperatorPlus(Vector v, Vector u, Vector x)
        {
            Assert.Equal((v + u).X, x.X);
            Assert.Equal((v + u).Y, x.Y);
        }
    }
    
    public class OperatorMinusTest
    {
        [Theory]
        [ClassData(typeof(TestDataGeneratorOperatorMinus))]
        internal void TestOperatorMinus(Vector v, Vector u, Vector x)
        {
            Assert.Equal((v - u).X, x.X);
            Assert.Equal((v - u).Y, x.Y);
        }
    }
    
    public class OperatorMultiplyTest
    {
        [Theory]
        [ClassData(typeof(TestDataGeneratorOperatorMultiply))]
        internal void TestOperatorMultiply(Vector v, double k, Vector u)
        {
            Assert.Equal((v * k).X, u.X);
            Assert.Equal((v * k).Y, u.Y);
        }
    }
    
    public class OperatorMultiplyTestV2
    {
        [Theory]
        [ClassData(typeof(TestDataGeneratorOperatorMultiply))]
        internal void TestOperatorMultiply(Vector v, double k, Vector u)
        {
            Assert.Equal((k * v).X, u.X);
            Assert.Equal((k * v).Y, u.Y);
        }
    }
    
    public class OperatorDivisionTest
    {
        [Theory]
        [ClassData(typeof(TestDataGeneratorOperatorDivision))]
        internal void TestOperatorDivision(Vector v, double k, Vector u)
        {
            Assert.Equal((v / k).X, u.X);
            Assert.Equal((v / k).Y, u.Y);
        }
    }
    
    public class OperatorUnaryPlusTest
    {
        [Theory]
        [ClassData(typeof(TestDataGeneratorOperatorUnaryPlus))]
        internal void TestOperatorDivision(Vector v, Vector u)
        {
            Assert.Equal((+v).X, u.X);
            Assert.Equal((+v).Y, u.Y);
        }
    }
    
    public class OperatorUnaryMinusTest
    {
        [Theory]
        [ClassData(typeof(TestDataGeneratorOperatorUnaryMinus))]
        internal void TestOperatorDivision(Vector v, Vector u)
        {
            Assert.Equal((-v).X, u.X);
            Assert.Equal((-v).Y, u.Y);
        }
    }

    public class ExtensionIsZeroTest
    {
        [Theory]
        [ClassData(typeof(TestDataGeneratorExtensionIsZero))]
        internal void TestExtensionIsZero(Vector v, bool flag)
        {
            Assert.Equal(v.IsZero(), flag);
        }
    }
    
    public class ExtensionNormalizeTest
    {
        [Theory]
        [ClassData(typeof(TestDataGeneratorExtensionNormalize))]
        internal void TestExtensionNormalize(Vector v, Vector u)
        {
            Assert.Equal(v.Normalize().X, u.X);
            Assert.Equal(v.Normalize().Y, u.Y);
        }
    }
    
    public class ExtensionGetAngleBetweenTest
    {
        [Theory]
        [ClassData(typeof(TestDataGeneratorExtensionGetAngleBetween))]
        internal void TestExtensionGetAngleBetween(Vector v, Vector u, double angle)
        {
            Assert.Equal(v.GetAngleBetween(u), angle);
        }
    }
    
    public class ExtensionGetRelationTest
    {
        [Theory]
        [ClassData(typeof(TestDataGeneratorExtensionGetRelation))]
        internal void TestExtensionGetRelation(Vector v, Vector u, BoringVectorExtensions.VectorRelation relation)
        {
            Assert.Equal(v.GetRelation(u), relation);
        }
    }
}
