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

    /// <summary>
    /// Отношение между двумя векторами: "общий случай", параллельны, перпендикулярны.
    /// </summary>
    public enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    };

    /// <summary>
    /// Класс с методами-расширениями структуры Vector.
    /// </summary>
    internal static class VectorExtensions
    {
        private const double EPS = 1e-6;

        /// <summary>
        /// Проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности).
        /// </summary>
        /// <param name="v">Вектор <see cref="Vector"/>.</param>
        /// <returns>Результат <see cref="bool"/> вектора.</returns>
        public static bool IsZero(this Vector v)
        {
            return (Math.Abs(v.X) < EPS && Math.Abs(v.Y) < EPS);
        }

        /// <summary>
        /// Нормализует вектор.
        /// </summary>
        /// <param name="v">Вектор <see cref="Vector"/>.</param>
        /// <returns>Нормализованный вектор <see cref="Vector"/>.</returns>
        public static Vector Normalize(this Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Возвращает угол между двумя векторами в радианах.
        /// </summary>
        /// <param name="v1">Вектор <see cref="Vector"/></param>
        /// <param name="v2">Вектор <see cref="Vector"/></param>
        /// <returns>Угол между векторами. Область значений - [0, pi]<see cref="double"/>.</returns>
        public static double GetAngleBetween(this Vector v1, Vector v2)
        {
            if (!IsZero(v1) && !IsZero(v2))
            {
                return Math.Acos(v2.DotProduct(v1) / (Math.Sqrt(v1.SquareLength() * v2.SquareLength())));
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Возвращает значение отношения между векторами: "общий случай", параллельны, перпендикулярны. (General, Parallel, Orthogonal)
        /// </summary>
        /// <param name="v1">Вектор <see cref="Vector"/></param>
        /// <param name="v2">Вектор <see cref="Vector"/></param>
        /// <returns>Отношение между векторами <see cref="VectorRelation"/>.</returns>
        public static VectorRelation GetRelation(this Vector v1, Vector v2)
        {
            if (v1.GetAngleBetween(v2) < EPS)
            {
                return VectorRelation.Parallel;
            }
            else if (Math.Abs(v1.DotProduct(v2)) < EPS)
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
