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

    internal enum Relations
    {
        GeneralCase,
        Parallel,
        Orthogonal
    }

    internal static class VectorHelper
    {
        /// <summary>
        /// Эпсилон погрешность
        /// </summary>
        private const double eps_ = 1e-6;

        /// <summary>
        /// Отношения между двумя векторами("общий случай", параллельны, перпендикулярны)
        /// </summary>

        /// <summary>
        /// Проверяет, является ли вектор нулевым с точностью <see cref="eps_"/>
        /// </summary>
        /// <param name="v">Проверяемый <see cref="Vector"/></param>
        /// <returns> true, если вектор нулевой с точнотью <see cref="eps_"/>, иначе false </returns>
        public static bool IsZero(this Vector v)
        {
            return Math.Abs(v.X) < eps_ && Math.Abs(v.Y) < eps_;
        }

        /// <summary>
        /// Нормализует вектор
        /// </summary>
        /// <param name="v"> Нормализуемый <see cref="Vector"/></param>
        /// <returns> Объект <see cref="Vector"/>, являющийся нормализованным вектором</returns>
        public static Vector Normalize(this Vector v)
        {
            return v.IsZero() ? v : v.Scale(Math.Sqrt(v.SquareLength()));
        }

        /// <summary>
        /// Возвращает угол между векторами в радианах
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/></param>
        /// <param name="u">Объект <see cref="Vector"/></param>
        /// <returns>Угол между векторами <paramref name="v"/> и <paramref name="u"/></returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            return v.IsZero() || u.IsZero() ? 0 : Math.Atan2(v.DotProduct(u), v.CrossProduct(u));
        }

        /// <summary>
        /// Возвращает отношение между двумя векторами
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/></param>
        /// <param name="u">Объект <see cref="Vector"/></param>
        /// <returns>Объект отношения <see cref="VectorRelation"/> между векторами</returns>
        public static Relations GetRelation(this Vector v, Vector u)
        {
            return v.DotProduct(u) < eps_ ? Relations.Orthogonal : v.CrossProduct(u) < eps_ ? Relations.Parallel : Relations.GeneralCase;
        }
    }
}
