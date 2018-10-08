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
    internal static class VectorExtensions
    {
        private static double epsilon = 1e-6;

        public static bool EqualEps(this double d, double other)
        {
            return Math.Abs(d - other) < epsilon;
        }

        public static bool IsZero(this Vector v)
        {
            return Math.Abs(v.X) < epsilon && Math.Abs(v.Y) < epsilon;
        }

        public static Vector Normalize(this Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

        public static double GetAngleBetween(Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0;
            }
            return v.DotProduct(u);
        }

        public enum VectorRelation
        {
            General, Parallel, Orthogonal
        }

        public static VectorRelation GetRelation(Vector v, Vector u)
        {
            double angle = GetAngleBetween(v, u);
            if (angle.EqualEps(0) || angle.EqualEps(Math.PI))
            {
                return VectorRelation.Parallel;
            }
            else if (Math.Abs(angle).EqualEps(Math.PI / 2))
            {
                return VectorRelation.Orthogonal;
            }
            else
            {
                return VectorRelation.General;
            }
        }
    }
}
