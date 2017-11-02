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

    public enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    };

    internal static class VectorExtensions
    {
        private static readonly double EPS = 1e-6;

        public static bool IsZero(this Vector v)
        {
            return (v.Length() < EPS);
        }
        public static Vector Normalize(this Vector v)
        {
            return v / v.Length();
        }
        public static double GetAngleBetween(this Vector first, Vector second)
        {
            if (IsZero(first) || IsZero(second))
            {
                return 0;
            }
            else
            {
                return Math.Acos(first.DotProduct(second) / (first.Length() * second.Length()));
            }
        }
        public static VectorRelation GetRelation(this Vector first, Vector second)
        {
            if (first.DotProduct(second) < EPS)
            {
                return VectorRelation.Orthogonal;
            }
            if (first.CrossProduct(second) < EPS)
            {
                return VectorRelation.Parallel;
            }
            return VectorRelation.General;
        }

    }
}
