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

    /// <summary>
    /// Класс с методами-расширениями структуры Vector.
    /// </summary>
    internal static class VectorExtensions
    {
        private const double Epsilon = 1e-6;
        /// <summary>
        /// Проверяет, является ли вектор нулевым.
        /// </summary>
        /// <param name="v">Экземпляр вектора<see cref="Vector"/>, который проверяется.</param>
        /// <returns>Результат проверки<see cref="bool"/> вектора.</returns>
        public static bool IsZero(this Vector v)
        {
            return (Math.Abs(v.X) < Epsilon && Math.Abs(v.Y) < Epsilon);
        }

        /// <summary>
        /// Нормализует вектор.
        /// </summary>
        /// <param name="v">Экземпляр вектора<see cref="Vector"/>, который нормализуется.</param>
        /// <returns>Результат нормализации вектора, вектор<see cref="Vector"/>.</returns>
        public static Vector Normalize(this Vector v)
        {
            return v / v.Length();
        }

        /// <summary>
        /// Возвращает угол между двумя векторами в радианах.
        /// </summary>
        /// <param name="v1">Первый вектор<see cref="Vector"/></param>
        /// <param name="v2">Второй вектор<see cref="Vector"/></param>
        /// <returns>Угол между векторами в радианах, число<see cref="double"/>.</returns>
        public static double GetAngleBetween(this Vector v1, Vector v2)
        {
            if (IsZero(v1) || IsZero(v2))
            {
                return 0;
            }
            else
            {
                return Math.Acos(v1.DotProduct(v2) / (v1.Length() * v2.Length()));
            }
        }

        /// <summary>
        /// Возвращает отношение между двумя векторами.
        /// </summary>
        /// <param name="v1">Первый вектор<see cref="Vector"/></param>
        /// <param name="v2">Второй вектор<see cref="Vector"/></param>
        /// <returns>Отношение между векторами, объект перечисления<see cref="VectorRelation"/>.</returns>
        public static VectorRelation GetRelation(this Vector v1, Vector v2)
        {
            if (v1.CrossProduct(v2) < Epsilon)
            {
                return VectorRelation.Parallel;
            }
            else if (v1.DotProduct(v2) < Epsilon)
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
