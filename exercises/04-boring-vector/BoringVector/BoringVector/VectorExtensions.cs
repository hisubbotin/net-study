using System;

namespace BoringVector
{
    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */

    internal enum VectorRelation
    {
        Parallel,
        Orthogonal,
        General
    }

    internal static class VectorExtensions
    {

        private const double epsilon = 1e-6;

        public static bool IsZero(this Vector v)
        {
            return v.SquareLength() < epsilon * epsilon;
        }

        public static Vector Normalize(this Vector v)
        {
            return v.Scale(1 / Math.Sqrt(v.SquareLength()));
        }

        public static double GetAngleBetween(this Vector a, Vector b)
        {
            if (a.IsZero() || b.IsZero())
            {
                return 0;
            }
            return Math.Acos(a.DotProduct(b) / (Math.Sqrt(a.SquareLength() * b.SquareLength())));
        }

        public static VectorRelation GetRelation(this Vector a, Vector b)
        {
            if (a.CrossProduct(b) < epsilon)
            {
                return VectorRelation.Parallel;
            }
            if (a.DotProduct(b) < epsilon)
            {
                return VectorRelation.Orthogonal;
            }
            return VectorRelation.General;
        }
    }
}
