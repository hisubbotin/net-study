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
    /// Перечисление, представляющее возможные отношения между объектами <see cref="Vector"/>.
    /// </summary>
    internal enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    }

    /// <summary>
    /// Класс, предоставляющий методы-расширения для класса <see cref="Vector"/>.
    /// </summary>
    internal static class VectorExtension
    {
        /// <summary>
        /// Точность, с которой производятся вычисления.
        /// </summary>
        internal static readonly double eps = 1e-6;

        /// <summary>
        /// Проверяет объект <see cref="Vector"/> на равенство нулевому вектору.
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/></param>
        /// <returns>Вернет true, если объект равен нулевому вектору, иначе false.</returns>
        internal static bool IsZero(this Vector v)
        {
            return System.Math.Abs(v.X) < eps && System.Math.Abs(v.Y) < eps;
        }

        /// <summary>
        /// Производит нормализацию объекта <see cref="Vector"/>.
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/></param>
        /// <returns>Нормализованный объект <see cref="Vector"/></returns>
        internal static Vector Normalize(this Vector v)
        {
            return v / System.Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Возвращает величину угла между объектами <see cref="Vector"/> в радианах
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/></param>
        /// <param name="u">Объект <see cref="Vector"/></param>
        /// <returns>Величина угла в радианах</returns>
        internal static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
                return 0;
            return System.Math.Acos(v.CrossProduct(u) / System.Math.Sqrt(v.SquareLength()) / System.Math.Sqrt(u.SquareLength()));
        }

        /// <summary>
        /// Возвращает значение перечесления <see cref="VectorRelation"/> - отношение между двумя векторами("общий случай", параллельны, перпендикулярны).
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/></param>
        /// <param name="u">Объект <see cref="Vector"/></param>
        /// <returns><see cref="VectorRelation.Parallel"/>, если вектора параллельны;
        /// <see cref="VectorRelation.Orthogonal"/>, если вектора ортогональны;
        /// <see cref="VectorRelation.General"/> иначе.</returns>
        internal static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
                return VectorRelation.Parallel;
            if (System.Math.Abs(v.CrossProduct(u) / System.Math.Sqrt(v.SquareLength()) / System.Math.Sqrt(u.SquareLength())) < eps)
                return VectorRelation.Parallel;
            else
            {
                if (System.Math.Abs(v.DotProduct(u)) < eps)
                    return VectorRelation.Orthogonal;
                else
                    return VectorRelation.General;
            }
        }
    }
}
