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
    public static class VectorExtensions
    {
        public static double precision = 1e-6;

        public enum VectorRelation
        {
            General,
            Parallel,
            Orthogonal
        }


        public static bool IsZero(this Vector v)
        {
            return Math.Abs(v.X) < precision && Math.Abs(v.Y) < precision;
        }

        public static Vector Normalize(this Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0;
            }
            return Math.Asin(v.CrossProduct(u) / (Math.Sqrt(v.SquareLength()) * Math.Sqrt(u.SquareLength())));
        }

        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (Math.Abs(v.GetAngleBetween(u)) < precision)
            {
                return VectorRelation.Parallel;
            }

            if (Math.Abs(v.DotProduct(u)) < precision)
            {
                return VectorRelation.Orthogonal;
            }

            return VectorRelation.General;
        }
    }
}
