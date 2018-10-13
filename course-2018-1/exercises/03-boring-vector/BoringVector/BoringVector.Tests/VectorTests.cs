using Xunit;

namespace BoringVector.Tests {
    
    /// <summary>
    /// Класс, содержащий тесты для методов класса BoringVector.Vector.
    /// </summary>
    public class VectorTests {


        /// <summary>
        /// Тесты на конструктор вектора.
        /// </summary>
        [Fact]
        public void VectorTest() {
            Assert.Equal(0, new Vector().X, Precision.Value);
            Assert.Equal(0, new Vector().Y, Precision.Value);
            Assert.Equal(1, new Vector(1).X, Precision.Value);
            Assert.Equal(0, new Vector(1).Y, Precision.Value);
            Assert.Equal(1, new Vector(1, 2).X, Precision.Value);
            Assert.Equal(2, new Vector(1, 2).Y, Precision.Value); 
        }
        
        /// <summary>
        /// Тесты на метод SquareLength.
        /// </summary>
        [Fact]
        public void SquareLengthTest() {
            Assert.Equal(0, new Vector().SquareLength(), Precision.Value);
            Assert.Equal(4, new Vector(2).SquareLength(), Precision.Value);
            Assert.Equal(25, new Vector(3, 4).SquareLength(), Precision.Value);
        }
        
        /// <summary>
        /// Тесты на метод Add.
        /// </summary>
        [Fact]
        public void AddTest() {
            Assert.Equal(new Vector(), new Vector().Add(new Vector()), new VectorComparer());
            Assert.Equal(new Vector(1), new Vector(2).Add(new Vector(-1)), new VectorComparer());
            Assert.Equal(new Vector(2, 3), new Vector(3, 3).Add(new Vector(-1)), new VectorComparer());
            Assert.Equal(new Vector(4, 6), new Vector(1, 3).Add(new Vector(3, 3)), new VectorComparer());
        }
        
        /// <summary>
        /// Тесты на метод Scale.
        /// </summary>
        [Fact]
        public void ScaleTest() {
            Assert.Equal(new Vector(), new Vector().Scale(4), new VectorComparer());
            Assert.Equal(new Vector(), new Vector(10).Scale(0), new VectorComparer());
            Assert.Equal(new Vector(2), new Vector(1).Scale(2), new VectorComparer());
            Assert.Equal(new Vector(-2, -4), new Vector(1, 2).Scale(-2), new VectorComparer());
        }
        
        /// <summary>
        /// Тесты на метод DotProduct.
        /// </summary>
        [Fact]
        public void TestDotProduct() {
            Assert.Equal(0, new Vector().DotProduct(new Vector()), Precision.Value);
            Assert.Equal(0, new Vector(1, 2).DotProduct(new Vector()), Precision.Value);
            Assert.Equal(0, new Vector().DotProduct(new Vector(3, -1)), Precision.Value);
            Assert.Equal(0, new Vector(1, 2).DotProduct(new Vector(-2, 1)), Precision.Value);
            Assert.Equal(8, new Vector(1, 2).DotProduct(new Vector(2, 3)), Precision.Value);
        }
        
        /// <summary>
        /// Тесты на метод CrossProduct.
        /// </summary>
        [Fact]
        public void TestCrossProduct() {
            Assert.Equal(0, new Vector().CrossProduct(new Vector()), Precision.Value);
            Assert.Equal(0, new Vector(1, 2).CrossProduct(new Vector()), Precision.Value);
            Assert.Equal(0, new Vector().CrossProduct(new Vector(3, -1)), Precision.Value);
            Assert.Equal(5, new Vector(1, 2).CrossProduct(new Vector(-2, 1)), Precision.Value);
            Assert.Equal(-1, new Vector(1, 2).CrossProduct(new Vector(2, 3)), Precision.Value);
        }
        
        /// <summary>
        /// Тесты на метод ToString.
        /// </summary>
        [Fact]
        public void TestToString() {
            Assert.Equal("(0, 0)", new Vector().ToString());
            Assert.Equal("(3, 0)", new Vector(3).ToString());
            Assert.Equal("(1, -4)", new Vector(1, -4).ToString());
        }
        
        /// <summary>
        /// Тесты на оператор *.
        /// </summary>
        [Fact]
        public void TestMultiplicationOperator() {
            Assert.Equal(new Vector(), new Vector() * 4, new VectorComparer());
            Assert.Equal(new Vector(), new Vector(10) * 0, new VectorComparer());
            Assert.Equal(new Vector(2), new Vector(1) * 2, new VectorComparer());
            Assert.Equal(new Vector(-2, -4), new Vector(1, 2) * (-2), new VectorComparer());
        }
        
        /// <summary>
        /// Тесты на оператор /.
        /// </summary>
        [Fact]
        public void TestDivisionOperator() {
            Assert.Equal(new Vector(), new Vector() / 3, new VectorComparer());
            Assert.Equal(new Vector(1, -2), new Vector(2, -4) / 2, new VectorComparer());
        }
        
        /// <summary>
        /// Тесты на оператор + (унарный).
        /// </summary>
        [Fact]
        public void TestUnaryPlusOperator() {
            Assert.Equal(new Vector(), +new Vector(), new VectorComparer());
            Assert.Equal(new Vector(1), +new Vector(1), new VectorComparer());
            Assert.Equal(new Vector(2, 3), +new Vector(2, 3), new VectorComparer());
        }
        
        /// <summary>
        /// Тесты на оператор - (унарный).
        /// </summary>
        [Fact]
        public void TestUnaryMinusOperator() {
            Assert.Equal(new Vector(), -new Vector(), new VectorComparer());
            Assert.Equal(new Vector(-1), -new Vector(1), new VectorComparer());
            Assert.Equal(new Vector(-2, -3), -new Vector(2, 3), new VectorComparer());
        }
        
        /// <summary>
        /// Тесты на оператор + (бинарный).
        /// </summary>
        [Fact]
        public void TestAdditionOperator() {
            Assert.Equal(new Vector(), new Vector() + new Vector(), new VectorComparer());
            Assert.Equal(new Vector(1), new Vector(2) + new Vector(-1), new VectorComparer());
            Assert.Equal(new Vector(2, 3), new Vector(3, 3) + new Vector(-1), new VectorComparer());
            Assert.Equal(new Vector(4, 6), new Vector(1, 3) + new Vector(3, 3), new VectorComparer());
        }
        
        /// <summary>
        /// Тесты на оператор - (бинарный).
        /// </summary>
        [Fact]
        public void TestSubtractionOperator() {
            Assert.Equal(new Vector(), new Vector() - new Vector(), new VectorComparer());
            Assert.Equal(new Vector(3), new Vector(2) - new Vector(-1), new VectorComparer());
            Assert.Equal(new Vector(4, 3), new Vector(3, 3) - new Vector(-1), new VectorComparer());
            Assert.Equal(new Vector(-2), new Vector(1, 3) - new Vector(3, 3), new VectorComparer());
        }
    }
}
