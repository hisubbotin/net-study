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
        General,
        Parallel,
        Orthogonal
    }

    internal static class VectorExtention
    {
        private const double Epsilon = 1e-6;

        internal static bool IsZero(this Vector v)
        {
            return Math.Abs(v.X) < Epsilon && Math.Abs(v.Y) < Epsilon;
        }

        internal static Vector Normalize(this Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

        internal static double GetAngleBetween(this Vector a, Vector b)
        {
            if (a.IsZero() || b.IsZero())
            {
                return 0;
            }
            return Math.Acos(a.DotProduct(b) / Math.Sqrt(a.SquareLength() * b.SquareLength()));
        }

        internal static VectorRelation GetRelation(this Vector a, Vector b)
        {
            double angle = a.GetAngleBetween(b);
            if (Math.Abs(angle - Math.PI) < Epsilon)
            {
                return VectorRelation.Orthogonal;
            }
            else
            {
                if (angle < Epsilon || angle > Math.PI + Epsilon)
                {
                    return VectorRelation.Parallel;
                }
                else
                {
                    return VectorRelation.General;
                }
            }
        }
    }

}
