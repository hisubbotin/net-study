using System;
using Xunit;

namespace BoringVector.Tests
{
    public class VectorExtensionsTests
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(0.5, 3.2)]
        [InlineData(0.00001, 0)]
        [InlineData(0.00001, 1)]
        public void Test_IsZero_False(double X, double Y)
        {
            Vector v = new Vector(X, Y);

            Assert.False(v.IsZero());
        }

        [Theory]
        [InlineData(0.0, 0.0)]
        [InlineData(0.000001, 0)]
        [InlineData(0.0000001, 0)]
        public void Test_IsZero_True(double X, double Y)
        {
            Vector v = new Vector(X, Y);

            Assert.True(v.IsZero());
        }

        [Theory]
        [InlineData(1, 2, 3, 4)]
        [InlineData(14, -2, -34, 15)]
        [InlineData(0.7, 2.4, -8.5, 19)]
        [InlineData(4.25, 21, -67, -12)]
        public void Test_GetRelation_General(double X1, double Y1, double X2, double Y2)
        {
            Vector v = new Vector(X1, Y1);
            Vector u = new Vector(X2, Y2);

            Assert.True(v.GetRelation(u) == VectorRelation.General);
        }

        [Theory]
        [InlineData(0.0, 0.0, -8.5, 19)]
        [InlineData(1, 2, 2, 4)]
        public void Test_GetRelation_Parallel(double X1, double Y1, double X2, double Y2)
        {
            Vector v = new Vector(X1, Y1);
            Vector u = new Vector(X2, Y2);

            Assert.True(v.GetRelation(u) == VectorRelation.Parallel);
        }

        [Theory]
        [InlineData(1, 1, -1, 1)]
        [InlineData(1, 0, 0, 1)]
        public void Test_GetRelation_Ortogonal(double X1, double Y1, double X2, double Y2)
        {
            Vector v = new Vector(X1, Y1);
            Vector u = new Vector(X2, Y2);

            Assert.True(v.GetRelation(u) == VectorRelation.Ortogonal);
        }
    }
}


/*
    Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
        - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
        - Normalize: нормализует вектор
        - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
        - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
*/
