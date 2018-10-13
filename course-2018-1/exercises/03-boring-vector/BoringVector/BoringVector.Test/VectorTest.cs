using System;
using Xunit;

namespace BoringVector.Test
{

    public class VectorTest
    {
        private const double Eps = 1e-6;

        /// <summary>
        /// Тест на вычисление квадрата длины вектора
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="squareLength"></param>
        [Theory]
        [InlineData(0.0, 0.0, 0.0)]
        [InlineData(5.0, 0.0, 25.0)]
        [InlineData(0.0, 2.0, 4.0)]
        [InlineData(1.0, 1.0, 2.0)]
        public void SquareLengthTest(double x, double y, double squareLength)
        {
            Vector v = new Vector(x, y);
            var delta = Math.Abs(v.SquareLength() - squareLength);
            Assert.True(delta < Eps);
        }

        /// <summary>
        /// Тесты на домножение на скаляр
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="k"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        [Theory]
        [InlineData(0.0, 0.0, 0.0, 0.0, 0.0)]
        [InlineData(1.0, 2.0, 3.0, 3.0, 6.0)]
        [InlineData(5.0, 0.6, 0.0, 0.0, 0.0)]
        [InlineData(5.0, 2.0, -1.0, -5.0, -2.0)]
        public void ScaleTest(double x1, double y1, double k, double x2, double y2)
        {
            var target = new Vector(x2, y2);
            Vector result = new Vector(x1, y1) * k;
            Assert.True(Math.Abs(result.X - target.X) < Eps);
            Assert.True(Math.Abs(result.Y - target.Y) < Eps);
        }

        /// <summary>
        /// Тесты на арифметические опреации над векторами
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        [Theory]
        [InlineData(0.0, 0.0, 0.0, 0.0, 0.0, 0.0)]
        [InlineData(0.0, 1.0, 1.0, 0.0, 1.0, 1.0)]
        [InlineData(0.5, -0.5, -0.5, 0.5, 0.0, 0.0)]
        public void ArithmeticTest(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            var v1 = new Vector(x1, y1);
            var v2 = new Vector(x2, y2);
            var v3 = new Vector(x3, y3);
            var result = v3 - (v1 + v2);
            Assert.True(result.IsZero());
        }

        /// <summary>
        /// Тест скалярного произведения
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="target"></param>
        [Theory]
        [InlineData(0.0, 0.0, 0.0, 0.0, 0.0)]
        [InlineData(0.0, 1.0, 1.0, 0.0, 0.0)]
        [InlineData(0.5, -0.5, -0.5, 0.5, -0.5)]
        [InlineData(1.0, 1.0, 1.0, 1.0, 2.0)]
        public void DotProductTest(double x1, double y1, double x2, double y2, double target)
        {
            var v1 = new Vector(x1, y1);
            var v2 = new Vector(x2, y2);
            var result = v1.DotProduct(v2);
            Console.WriteLine(result);
            Assert.True(Math.Abs(result - target) < Eps);
        }

        /// <summary>
        /// Тест векторного произведения
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="target"></param>
        [Theory]
        [InlineData(0.0, 0.0, 0.0, 0.0, 0.0)]
        [InlineData(0.0, 1.0, 1.0, 0.0, -1.0)]
        [InlineData(1.0, 0.0, 0.0, 1.0, 1.0)]
        [InlineData(1.0, 1.0, 1.0, 1.0, 0.0)]
        public void CrossProductTest(double x1, double y1, double x2, double y2, double target)
        {
            var v1 = new Vector(x1, y1);
            var v2 = new Vector(x2, y2);
            var result = v1.CrossProduct(v2);
            Assert.True(Math.Abs(result - target) < Eps);
        }

        /// <summary>
        /// Вектора на 0
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="target"></param>
        [Theory]
        [InlineData(0.0, 0.0, true)]
        [InlineData(0.0, 1e-5, false)]
        [InlineData(1e-7, 1e-8, true)]
        public void IsZeroTest(double x1, double y1, bool target)
        {
            Assert.Equal(new Vector(x1, y1).IsZero(), target);
        }

        /// <summary>
        /// Тест на нормализацию
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [Theory]
        [InlineData(0.0, 0.1)]
        [InlineData(0.0, 1e-5)]
        [InlineData(1e-7, 5.0)]
        public void NormalizeTest(double x, double y)
        {
            var v = new Vector(x, y);
            Assert.True(Math.Abs(v.Normalize().SquareLength() - 1.0) < Eps);
        }

        /// <summary>
        /// Тест углов между векторами
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="target"></param>
        [Theory]
        [InlineData(0.0, 0.0, 1.0, 0.0, 0.0)]
        [InlineData(0.0, 0.0, 0.0, 1.0, 0.0)]
        [InlineData(1.0, 0.0, 1.0, 0.0, 0.0)]
        [InlineData(0.0, 1.0, 1.0, 0.0, Math.PI / 2)]
        [InlineData(1.0, 0.0, 0.0, 1.0, Math.PI / 2)]
        public void AngleTest(double x1, double y1, double x2, double y2, double target)
        {
            var v1 = new Vector(x1, y1);
            var v2 = new Vector(x2, y2);
            Assert.Equal(target, v1.GetAngleBetween(v2));
        }

        /// <summary>
        /// Тест на положение векторов
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="target"></param>
        [Theory]
        [InlineData(2.0, 1.0, 4.0, 2.0, VectorRelation.Parallel)]
        [InlineData(0.0, 1.0, 1.0, 0.0, VectorRelation.Orthogonal)]
        [InlineData(1.0, 0.0, 7.0, 16.0, VectorRelation.General)]
        public void RelationTest(double x1, double y1, double x2, double y2, VectorRelation target)
        {
            var v1 = new Vector(x1, y1);
            var v2 = new Vector(x2, y2);
            
            Assert.Equal(target, v1.GetRelation(v2));
        }
    }
}
