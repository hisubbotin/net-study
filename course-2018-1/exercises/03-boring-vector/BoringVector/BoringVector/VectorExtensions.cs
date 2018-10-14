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
    /// Отношения между векторами:
    /// Parallel -- вектора параллельны,
    /// Orthogonal -- вектора ортогональны,
    /// General -- иные случаи.
    /// </summary>
    internal enum VectorRelation
    {
        General = 0,
        Parallel = 1,
        Orthogonal = 2
    }

    /// <summary>
    /// Класс для методов-расширений структуры <see cref="Vector"/>.
    /// </summary>
    internal static class VectorHelper
    {
        /// <summary>
        /// Точность вычислений.
        /// </summary>
        public const double Epsilon = 1e-6;

        /// <summary>
        /// Проверить, является ли вектор нулевым с точностью <see cref="Epsilon"/>.
        /// </summary>
        /// <param name="v"><see cref="Vector"/>, который нужно проверить.</param>
        /// <returns>True, если вектор нулевой; иначе false.</returns>
        public static bool IsZero(this Vector v)
        {
            return v.Length() < Epsilon;
        }

        /// <summary>
        /// Нормализует вектор.
        /// </summary>
        /// <param name="v"><see cref="Vector"/>, который нужно нормализовать.</param>
        /// <returns>Нормализованный объект <see cref="Vector"/>.</returns>
        public static Vector Normalize(this Vector v)
        {
            if (v.IsZero()) throw new DivideByZeroException();
            return new Vector(v.X / v.Length(), v.Y / v.Length());
        }

        /// <summary>
        /// Получить угол между векторами в координатах.
        /// </summary>
        /// <param name="v">Вектор <see cref="Vector"/></param>
        /// <param name="u">Вектор <see cref="Vector"/></param>
        /// <returns><see cref="double"/> -- угол между векторами в радианах.</returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero()) return 0;
            var cos = v.DotProduct(u) / (v.Length() * u.Length());
            return Math.Acos(cos);
        }

        /// <summary>
        /// Определить отношение между векторами.
        /// </summary>
        /// <param name="v">Вектор <see cref="Vector"/></param>
        /// <param name="u">Вектор <see cref="Vector"/></param>
        /// <returns><see cref="VectorRelation"/> -- как соотносятся векторы друг с другом.</returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (v.DotProduct(u) < Epsilon) return VectorRelation.Orthogonal;
            return v.GetAngleBetween(u) < Epsilon ? VectorRelation.Parallel : VectorRelation.General;
        }
    }
}
