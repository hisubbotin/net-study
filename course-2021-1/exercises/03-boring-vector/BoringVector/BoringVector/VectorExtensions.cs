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
    /// Перечисление, задающее возможные отношения между двумя векторами.
    /// </summary>
    internal enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    }

    /// <summary>
    /// Класс с методами-расширениями структуры Vector.
    /// </summary>
    internal class ExtendedVector
    {
        /// <summary>
        /// Проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю.
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/>.</param>
        /// <param name="eps">Число типа <see cref="double"/>, задающее точность.</param>
        /// <returns>Флаг типа <see cref="bool"/>, указывающий (с заданной точностью), является ли вектор нулевым.</returns>
        public static bool IsZero(Vector v, double eps = 1e-6)
        {
            return Math.Abs(v.X) < eps && Math.Abs(v.Y) < eps;
        }

        /// <summary>
        /// Нормализует вектор.
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/>.</param>
        /// <returns>Объект <see cref="Vector"/>, равный данному вектору, делённому на свою длину.</returns>
        public static Vector Normalize(Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Возвращает угол между двумя векторами в радианах.
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/>, задающий один из векторов.</param>
        /// <param name="w">Объект <see cref="Vector"/>, задающий один из векторов.</param>
        /// <returns>Число типа <see cref="bool"/>, углу между двумя заданными векторами в радианах.</returns>
        public static double GetAngleBetween(Vector v, Vector w)
        {
            return IsZero(v) || IsZero(w) ? 0 : Math.Acos(Normalize(v).DotProduct(Normalize(w)));
        }

        /// <summary>
        /// Определяет отношение между двумя векторами.
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/>, задающий один из векторов.</param>
        /// <param name="w">Объект <see cref="Vector"/>, задающий один из векторов.</param>
        /// <param name="eps">Число типа <see cref="double"/>, задающее точность.</param>
        /// <returns>Значение перечисления <see cref="VectorRelation"/>, указывающее (с заданной точностью) отношение между двумя данными векторами.</returns>
        public static VectorRelation GetRelation(Vector v, Vector w, double eps = 1e-6)
        {
            if (IsZero(v) || IsZero(w) || v.CrossProduct(w) < eps)
            {
                return VectorRelation.Parallel;
            }
            return Math.Abs(v.DotProduct(w)) < eps ? VectorRelation.Orthogonal : VectorRelation.General;
        }
    }
}
