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
    public enum Relation
    {
        General,
        Parallel,
        Orthogonal
    }

    internal static class VectorHelper
    {
        /// <summary>
        /// проверяет, является ли вектор нулевым
        /// </summary>
        /// <param name="v"></param>
        /// <param name="eps"></param>
        /// <returns></returns>
        public static bool IsZero(this Vector v, double eps = 1e-6)
        {
            if (Math.Abs(v.X) < eps && Math.Abs(v.Y) < eps)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// нормализует вектор
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector Normalize(this Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// возвращает угол между двумя векторами в радианах
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            return v.DotProduct(u) / (Math.Sqrt(v.SquareLength()) * Math.Sqrt(u.SquareLength()));
        }

        /// <summary>
        /// отношение между двумя векторами
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <param name="eps"></param>
        /// <returns></returns>
        public static Relation GetRelation(this Vector v, Vector u, double eps=1e-6)
        {
            if (Math.Abs(v.CrossProduct(u)) < eps)
            {
                return Relation.Parallel;
            }

            if (Math.Abs(v.DotProduct(u)) < eps)
            {
                return Relation.Orthogonal;
            }
            return Relation.General;
        }
    }
}
