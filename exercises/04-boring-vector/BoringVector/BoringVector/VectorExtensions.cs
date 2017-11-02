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
    /// Виды расположения двух векторов
    /// </summary>
    internal enum VectorRelation
    {
        General,
        Parrallel,
        Orthogonal
    }

    /// <summary>
    /// Класс с методами-расширениями для структуры <see cref="Vector"/>
    /// </summary>
    internal static class VectorExtensions
    {
        /// <summary>
        /// Погрешность для сравнения вещественных чисел
        /// </summary>
        public const double EPS = 1e-6;

        /// <summary>
        /// Проверяет, является ли вектор нулевым
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/>, который нужно сравнить с нулевым</param>
        /// <returns>Возвращает <see cref="bool"/> - является нулевым или нет</returns>
        public static bool IsZero(this Vector v)
        {
            return Math.Abs(v.X) < EPS && Math.Abs(v.Y) < EPS;
        }

        /// <summary>
        /// Возвращает нормализованный вектор(с длиной 1)
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/>, который нужно нормализовать</param>
        /// <returns>Возвращает объект <see cref="Vector"/>, равный нормированному вектору <paramref name="v"/></returns>
        public static Vector Normalize(this Vector v)
        {
            var length = Math.Sqrt(v.SquareLength());
            return (v.IsZero()) ? v : v / length;
        }

        /// <summary>
        /// Возвращает угол между двумя векторами в радианах
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/></param>
        /// <param name="u">Объект <see cref="Vector"/></param>
        /// <returns>Возвращает угол между векторами <paramref name="v"/> и <paramref name="u"/> в радианах</returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0.0;
            }
            return Math.Acos(v.Normalize().DotProduct(u.Normalize()));
        }

        /// <summary>
        /// Возвращает отношение между двумя векторами
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/></param>
        /// <param name="u">Объект <see cref="Vector"/></param>
        /// <returns>Возвращает отношение <see cref="VectorRelation"/> для двух векторов</returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (v.DotProduct(u) < EPS)
            {
                return VectorRelation.Orthogonal;
            }

            if (v.CrossProduct(u) < EPS)
            {
                return VectorRelation.Parrallel;
            }

            return VectorRelation.General;
        }
    }
}
