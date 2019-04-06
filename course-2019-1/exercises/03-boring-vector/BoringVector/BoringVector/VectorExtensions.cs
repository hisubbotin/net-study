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

    public static class BoringVectorExtension
    {
        private static double eps = 1e-6;

        enum VectorRealtion
        {
            General,
            Parallel,
            Orthogonal
        };
        static bool isZero(this Vector v)
        {
            return Math.Abs(v.X) <= eps && Math.Abs(v.Y) <= eps;
        }

        static Vector Normalize(this Vector v)
        {
            return v.Scale(1 / v.SquareLength());
        }

        static double GetAngleBetween(this Vector v1, Vector v2)
        {
            if (v1.isZero() || v2.isZero())
            {
                return 0.0;
            }

            return Math.Acos(v1.DotProduct(v2) / (v1.SquareLength() * v2.SquareLength()));
        }

        static VectorRealtion GetRelation(this Vector v1, Vector v2)
        {
            if (v1.isZero() || v2.isZero() || v1.CrossProduct(v2) <= eps)
            {
                return VectorRealtion.Parallel;
            } else if (v1.DotProduct(v2) <= eps)
            {
                return VectorRealtion.Orthogonal;
            }
            else
            {
                return VectorRealtion.General;
            }
        }
    }
}
