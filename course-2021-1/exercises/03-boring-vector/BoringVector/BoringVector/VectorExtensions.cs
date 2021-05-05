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
        // константа для сравнения чисел с типом double
        private const double EPS = 1e-6;

        /// <summary>
        /// Отношение между двумя векторами (общий случай, параллельны, перпендикулярны)
        /// </summary>
        public enum VectorRelation
        {
            General,
            Parallel,
            Orthogonal
        }

        /// <summary>
        /// Проверка вектора на равенство нулю
        /// </summary>
        /// <param name="v">Искомый вектор</param>
        /// <returns>Результат проверки на равенство нулю</returns>
        public static bool IsZero(Vector v)
        {
            return v.SquareLength() < EPS * EPS;
        }

        /// <summary>
        /// Возвращает нормированный вектор
        /// </summary>
        /// <param name="v">Искомый вектор</param>
        /// <returns>Нормированный вектор</returns>
        public static Vector Normalize(Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Возвращает угол между двумя векторами в радианах
        /// </summary>
        /// <param name="v">Первый вектор</param>
        /// <param name="u">Второй вектор</param>
        /// <returns>Угол между векторами в радианах</returns>
        public static double GetAngleBetween(Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u))
            {
                return 0.0;
            }
            return Math.Acos(Normalize(v).DotProduct(Normalize(u)));
        }

        /// <summary>
        /// Возвращает отношение между векторами (общий случай, параллельны, перпендикулярны)
        /// </summary>
        /// <param name="v">Первый вектор</param>
        /// <param name="u">Второй вектор</param>
        /// <returns>Отношение между векторами</returns>
        public static VectorRelation GetRelation(Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u) || v.CrossProduct(u) < EPS)
            {
                return VectorRelation.Parallel;
            }
            if (v.DotProduct(u) < EPS)
            {
                return VectorRelation.Orthogonal;
            }

            return VectorRelation.General;
        }
    }
}
