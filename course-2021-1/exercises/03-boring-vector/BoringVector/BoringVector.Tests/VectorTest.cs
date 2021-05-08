using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorTest
    {
        [Theory]
        [InlineData(3, 3, 18)]
        [InlineData(0.5, -0.5, 0.5)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 10, 100)]
        [InlineData(3.6, 0, 12.96)]
        public void Test_SquareLength(double x, double y, double actual)
        {
            Vector vector = new Vector(x, y);
            Assert.Equal(vector.SquareLength(), actual);
        }
        
        [Theory]
        [InlineData(1, 1, 1, 1, 2, 2)]
        [InlineData(0.5, -0.5, 0.5, -0.5, 1, -1)]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(0, 10, 1, 11, 1, 21)]
        [InlineData(3.6, 0, 12.9, -3.6, 16.5, -3.6)]
        public void Test_Add(double x1, double y1, double x2, double y2, double x_actual, double y_actual)
        {
            Vector vector1 = new Vector(x1, y1);
            Vector vector2 = new Vector(x2, y2);
            Vector result = vector1.Add(vector2);
            Vector actual = new Vector(x_actual, y_actual);
            Assert.Equal(result, actual);
        }
        [Theory]
        [InlineData(1, 1, 1, 1, 1)]
        [InlineData(0.5, -0.5, 0.5, 0.25, -0.25)]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(0, 10, 11, 0, 110)]
        [InlineData(3.6, 0, -3.6, -12.96, 0)]
        public void Test_Scale(double x1, double y1, double k, double x_actual, double y_actual)
        {
            Vector vector1 = new Vector(x1, y1);
            Vector result = vector1.Scale(k);
            Vector actual = new Vector(x_actual, y_actual);
            Assert.Equal(result, actual);
        }
        
        [Theory]
        [InlineData(1, 1, 1, 1, 2)]
        [InlineData(0.5, -0.5, 0.5, 0.5, 0)]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(0, 10, 11, 0, 0)]
        [InlineData(3.6, 0, -3.6, 12.96, -12.96)]
        public void Test_DotProduct(double x1, double y1, double x2, double y2, double actual)
        {
            Vector vector1 = new Vector(x1, y1);
            Vector vector2 = new Vector(x2, y2);
            double result = vector1.DotProduct(vector2);
            Assert.Equal(result, actual);
        }
        
        [Theory]
        [InlineData(1, 1, 1, 1, 0)]
        [InlineData(0.5, -0.5, 0.5, 0.5, 0.5)]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(0, 10, 11, 0, 110)]
        [InlineData(3.6, 0, -3.6, 1, 3.6)]
        public void Test_CrossProduct(double x1, double y1, double x2, double y2, double actual)
        {
            Vector vector1 = new Vector(x1, y1);
            Vector vector2 = new Vector(x2, y2);
            double result = vector1.CrossProduct(vector2);
            Assert.Equal(result, actual);
        }
    }
}