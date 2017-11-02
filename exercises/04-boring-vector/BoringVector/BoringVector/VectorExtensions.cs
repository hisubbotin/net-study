namespace BoringVector
{
    using System;
    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */

    /// <summary>
    /// Виды взаиморасположения двух векторов: общее, параллельное, перпендикулярное 
    /// </summary>
    public enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    }

    internal static class VectorExtentions
    {
        /// <summary>
        /// Погрешность, используется для сравнения <see cref="double"/> по умолчанию в этом классе 
        /// </summary>
        public const double Eps = 1e-6;

        /// <summary>
        /// Является ли вектор нулевым
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/>, который нужно сравнить с нулевым</param>
        /// <param name="eps">Погрешность сравнения, по умолчанию <see cref="Eps"/></param>
        /// <returns><see cref="bool"/>, да или нет</returns>
        internal static bool IsZero(this Vector v, double eps = Eps)
        {
            return Math.Abs(v.X) < eps && Math.Abs(v.Y) < eps;
        }

        /// <summary>
        /// Нормировка вектора
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/>, который нужно нормировать (растянуть так, чтобы длина стала равной 1)</param>
        /// <returns>Новый объект <see cref="Vector"/>, равный нормированному старому</returns>
        internal static Vector Normalize(this Vector v)
        {
            var length = Math.Sqrt(v.SquareLength());
            return v / length;
        } 

        /// <summary>
        /// Угол между векторами
        /// </summary>
        /// <param name="one"></param>
        /// <param name="other"></param>
        /// <returns>Число <see cref="double"/>, равное углу (в радианах) между двумя векторами.
        /// Углом называется кратчайший из двух вертикальных углов, образуемых прямыми, построенными на продолжении векторов.
        /// Нулевой вектор сонаправлен любому.</returns>
        internal static double GetAngleBetween(this Vector one, Vector other)
        {
            if (one.IsZero() || other.IsZero())
                return 0;

            return Math.Acos(one.DotProduct(other) / Math.Sqrt(one.SquareLength() * other.SquareLength()));
        }

        /// <summary>
        /// Взаимное положение векторов (параллельны, перпендикулярны, в общем положении)
        /// </summary>
        /// <param name="one">Объект <see cref="Vector"/></param>
        /// <param name="other">Объект <see cref="Vector"/></param>
        /// <param name="eps">Погрешность сравнения double, по умолчанию <see cref="Eps"/></param>
        /// <returns>Объект перечисления <see cref="VectorRelation"/>, соответствующий взаиморасположению векторов</returns>
        internal static VectorRelation GetRelation(this Vector one, Vector other, double eps = Eps)
        {
            if (Math.Abs(one.GetAngleBetween(other)) < eps)
                return VectorRelation.Parallel;

            if (Math.Abs(one.DotProduct(other)) < eps)
                return VectorRelation.Orthogonal;

            return VectorRelation.General;
        }
    }
}
