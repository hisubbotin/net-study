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
    /// Класс расширения структуры <see cref="Vector"/>, реализует дополнительные операции
    /// </summary>
    class VectorExtensions
    {
        /// <summary>
        /// Проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности)
        /// </summary>
        /// <param name="v">Вектор, <see cref="Vector"/></param>
        /// <param name="eps">Допустимый радиус эпсилон-окрестности нуля, <see cref="double"/></param>
        /// <returns>Является ли вектор нулевым, <see cref="bool"/></returns>
        public static bool IsZero(Vector v, double eps = 1e-6)
        {
            return Math.Abs(v.X) < eps && Math.Abs(v.Y) < eps;
        }

        /// <summary>
        /// Нормализует вектор
        /// </summary>
        /// <param name="v">Исходный вектор, <see cref="Vector"/></param>
        /// <returns>Нормированный вектор, <see cref="Vector"/></returns>
        public static Vector Normalize(Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Возвращает угол между двумя векторами в радианах в отрезке [0, pi]
        /// </summary>
        /// <param name="v1">Первый вектор, <see cref="Vector"/></param>
        /// <param name="v2">Второй вектор, <see cref="Vector"/></param>
        /// <returns>Угол между двумя векторами в радианах в отрезке [0, pi], <see cref="double"/></returns>
        public static double GetAngleBetween(Vector v1, Vector v2)
        {
            return Math.Acos(v1.CrossProduct(v2));
        }

        /// <summary>
        /// Возможные отношения между двумя векторами
        /// </summary>
        public enum VectorRelation
        {
            /// <summary>
            /// "Общий случай"
            /// </summary>
            General,
            /// <summary>
            /// Векторы параллельны
            /// </summary>
            Parallel,
            /// <summary>
            /// Векторы перпендикулярны
            /// </summary>
            Orthogonal
        }

        /// <summary>
        /// Возвращает отношение между двумя векторами ("общий случай", параллельны, перпендикулярны)
        /// </summary>
        /// <param name="v1">Первый вектор, <see cref="Vector"/></param>
        /// <param name="v2">Второй вектор, <see cref="Vector"/></param>
        /// <param name="eps">Допустимый радиус эпсилон-окрестности, <see cref="double"/></param>
        /// <returns>Значение перечесления <see cref="VectorRelation"/></returns>
        public static VectorRelation GetRelation(Vector v1, Vector v2, double eps = 1e-6)
        {
            if (GetAngleBetween(v1, v2) < eps)
            {
                return VectorRelation.Parallel;
            }
            if (Math.Abs(GetAngleBetween(v1, v2) - Math.PI / 2) < eps)
            {
                return VectorRelation.Orthogonal;
            }
            return VectorRelation.General;
        }
    }
}
