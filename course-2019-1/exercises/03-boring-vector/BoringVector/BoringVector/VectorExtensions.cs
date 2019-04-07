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
        /// <summary>
        /// Возвращяет true, если вектор нулевой иначе false
        /// </summary>
        /// <param name="v"> вектор </param>
        /// <param name="eps"> точность измерения </param>
        public static bool IsZero(this Vector v, double eps = 1e-7)
        {
            return Math.Abs(v.X) < eps && Math.Abs(v.Y) < eps;
        }

        /// <summary>
        /// Возвращает нормализованный вектор
        /// </summary>
        /// <param name="v"> вектор </param>
        public static Vector Normalize(this Vector v)
        {
            return new Vector(v.X / Math.Sqrt(v.SquareLength()), v.Y / Math.Sqrt(v.SquareLength()));
        }

        /// <summary>
        /// Возвращает угол между векторами
        /// </summary>
        /// <param name="v1"> 1-й вектор </param>
        /// <param name="v2"> 2-й вектор </param>
        public static double GetAngleBetween(this Vector v1, Vector v2)
        {
            if (v1.IsZero() || v2.IsZero())
            {
                return 0;
            }
            return Math.Acos(v1.DotProduct(v2) / Math.Sqrt(v1.SquareLength()) / Math.Sqrt(v2.SquareLength()));
        }

        public enum VectorRelation
        {
            General, Parallel, Orthogonal
        };

        public static VectorRelation GetRelation(this Vector v1, Vector v2, double eps = 1e-7)
        {
            if (Math.Abs(GetAngleBetween(v1, v2) - Math.PI / 2) < eps)
            {
                return VectorRelation.Orthogonal;
            }

            if (GetAngleBetween(v1, v2) < eps)
            {
                return VectorRelation.Parallel;
            }

            return VectorRelation.General;
        }
    }
}