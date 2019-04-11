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
    internal static class VectorExtension
    {
        const double eps = 1e-6;

        public enum VectorRelation { General, Parallel, Orthogonal };

        /// <summary>
        ///  проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool IsZero(this Vector v)
        {
            return v.SquareLength() < eps;
        }

        /// <summary>
        /// нормализует вектор
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector Normalize(this Vector v)
        {
            double coef = Math.Sqrt(v.SquareLength());
            return v.Scale(coef);
        }

        /// <summary>
        /// возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static double GetAngleBetween(this Vector v, Vector other)
        {
            if(other.IsZero() || v.IsZero())
            {
                return 0.0;
            }

            return Math.Acos(v.Normalize().DotProduct(other.Normalize()));
        }


        /// <summary>
        /// возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
        /// </summary>
        /// <param name="v"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static VectorRelation GetRelation(this Vector v, Vector other)
        {
            double angle = v.GetAngleBetween(other);
            if (angle < eps)
            {
                return VectorRelation.Parallel;
            }
            if(Math.Abs(angle - 90.0) < eps)
            {
                return VectorRelation.Orthogonal;
            }
            return VectorRelation.General;
        }
    }
}
