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
    /// Расширяющий класс Vector.
    /// </summary>
    internal static class VectorExtensions
    {
        /// <summary>
        /// Эпсилон.
        /// </summary>
        private const double eps = 1e-6;
        /// <summary>
        /// Перечисления - отношение между двумя векторами("общий случай", параллельны, перпендикулярны).
        /// </summary>
        internal enum VectorRelation
        {
            General, Parallel, Orthogonal
        }
        /// <summary>
        /// Проверяет, является ли вектор нулевым.
        /// </summary>
        /// <param name="v">Исходный вектор.</param>
        /// <returns>True, если вектор нулевой, иначе False</returns>
        public static bool IsZero(this Vector v)
        {
            return Math.Abs(v.X) < eps && Math.Abs(v.Y) < eps;
        }
        /// <summary>
        /// Нормализует вектор (если он не нулевой).
        /// </summary>
        /// <param name="v">Исходный вектор.</param>
        /// <returns>Нормализованный вектор.</returns>
        public static Vector Normalize(this Vector v)
        {
            if (IsZero(v))
                return v;
            return v / Math.Sqrt(v.SquareLength());
        }
        /// <summary>
        /// Вычисление угла между векторами.
        /// </summary>
        /// <param name="v">Первый вектор.</param>
        /// <param name="u">Второй.</param>
        /// <returns>Угол между векторами в радианах от 0 до PI.</returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u))
            {
                return 0;
            }

            return Math.Acos(Normalize(v).DotProduct(Normalize(u)));
        }
        /// <summary>
        /// Вычисление отношения между двумя заданными векторами.
        /// </summary>
        /// <param name="v">Первый вектор.</param>
        /// <param name="u">Второй вектор.</param>
        /// <returns>Отношение между двумя векторами("общий случай", параллельны, перпендикулярны).</returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            var ang = GetAngleBetween(v, u);

            if (ang < eps || Math.PI - ang < eps)
            {
                return VectorRelation.Parallel;
            }
            if (Math.Abs(Math.PI / 2 - ang) < eps)
            {
                return VectorRelation.Orthogonal;
            }
            return VectorRelation.General;
        }
    }
}
