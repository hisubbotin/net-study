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
    /// Класс с методами-расширениями структуры Vector
    /// </summary>
    internal static class VectorExtensions
    {
        // эпсилон-окрестность равенства двух векторов
        private const double EPS = 1e-6;

        /// <summary>
        /// Отношение между двумя векторами ("общий случай", "параллельны", "перпендикулярны")
        /// </summary>
        public enum VectorRelation
        {
            General,
            Parallel,
            Orthogonal
        }

        /// <summary>
        /// Возвращает объект <see cref="bool"/> - результат проверки вектора на равенство нулю.
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/> - проверяемый вектор</param>
        /// <returns>Объект <see cref="bool"/> - результат проверки вектора на равенство нулю.</returns>
        public static bool IsZero(Vector v)
        {
            return (v.X < EPS) && (v.Y < EPS);
        }

        /// <summary>
        /// Возвращает объект <see cref="Vector"/> - нормализованный вектор (вектор единичной длины, сонаправленный заданному)
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/> - нормализуемый вектор</param>
        /// <returns>Объект <see cref="Vector"/> - нормализованный вектор</returns>
        public static Vector Normalize(Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Возвращает объект <see cref="double"/> - угол между двумя векторами в радианах.
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/> - первый вектор.</param>
        /// <param name="u">Объект <see cref="Vector"/> - второй вектор</param>
        /// <returns>Объект <see cref="double"/> - угол между двумя векторами в радианах</returns>
        public static double GetAngleBetween(Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u))
            {
                return 0;
            }
            else
            {
                return Math.Abs(Math.Acos(Normalize(v).DotProduct(Normalize(u))));
            }
        }

        /// <summary>
        /// Возвращает объект <see cref="VectorRelation"/> - отношение между векторами (общий случай, параллельны, перпендикулярны)
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/> - первый вектор.</param>
        /// <param name="u">Объект <see cref="Vector"/> - второй вектор</param>
        /// <returns>Объект <see cref="VectorRelation"/> - отношение между векторами (общий случай, параллельны, перпендикулярны)</returns>
        public static VectorRelation GetRelation(Vector v, Vector u)
        {
            double angle = GetAngleBetween(v, u);
            if (angle < EPS || Math.Abs(angle - 180) < EPS)
            {
                return VectorRelation.Parallel;
            }
            if (Math.Abs(angle - 90) < EPS)
            {
                return VectorRelation.Orthogonal;
            }

            return VectorRelation.General;
        }
    }
}