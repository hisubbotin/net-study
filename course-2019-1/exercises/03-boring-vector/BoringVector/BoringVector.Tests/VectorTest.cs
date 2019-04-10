using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTest
    {
        static int precision = 6;
        
        [Theory]
        [InlineData(3.0, 4.0, 25.0)]
        [InlineData(5.0, 12.0, 169.0)]
        [InlineData(1.568, 3.926, 17.8721)]
        public void Test_SquareLength(double x, double y, double right_answer)
        {
            Vector vector = new Vector(x, y);
            Assert.Equal(right_answer, vector.SquareLength(), precision);
        }
        
        [Theory]
        [InlineData(29.3, 87.567, 15.234)]
        [InlineData(42.0357, 5.789, 5600)]
        [InlineData(-23.6438, 2.5478, -4.23)]
        public void Test_Scale(double x, double y, double k)
        {
            Vector init_vector = new Vector(x, y);
            Vector new_vector = init_vector.Scale(k);
            Assert.Equal(k * x, new_vector.X, precision);
            Assert.Equal(k * y, new_vector.Y, precision);
        }
        
        [Theory]
        [InlineData(29.3, 87.567, 15.234, 91.144)]
        [InlineData(42.0357, 5.789, 5600, 1.697)]
        [InlineData(-23.6438, 2.5478, -4.23, -75.369)]
        public void Test_Add(double x1, double y1, double x2, double y2)
        {
            Vector vector1 = new Vector(x1, y1);
            Vector vector2 = new Vector(x2, y2);
            Vector sum = vector1.Add(vector2);
            Assert.Equal(x1 + x2, sum.X, precision);
            Assert.Equal(y1 + y2, sum.Y, precision);
        }
        
        [Theory]
        [InlineData(29.3, 87.567, 15.234, 91.144)]
        [InlineData(42.0357, 5.789, 5600, 1.697)]
        [InlineData(-23.6438, 2.5478, -4.23, -75.369)]
        public void Test_DotProduct(double x1, double y1, double x2, double y2)
        {
            Vector vector1 = new Vector(x1, y1);
            Vector vector2 = new Vector(x2, y2);
            Assert.Equal(x1 * x2 + y1 * y2, vector1.DotProduct(vector2), precision);
        }

        [Theory]
        [InlineData(29.3, 87.567, 15.234, 91.144)]
        [InlineData(42.0357, 5.789, 5600, 1.697)]
        [InlineData(-23.6438, 2.5478, -4.23, -75.369)]
        public void Test_CrossProduct(double x1, double y1, double x2, double y2)
        {
            Vector vector1 = new Vector(x1, y1);
            Vector vector2 = new Vector(x2, y2);
            Assert.Equal(x1 * y2 - x2 * y1, vector1.CrossProduct(vector2), precision);
        }
    }
}
