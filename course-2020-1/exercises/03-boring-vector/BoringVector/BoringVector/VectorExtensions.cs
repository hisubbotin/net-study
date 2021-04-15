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
    /// перечисление различных вариантов расположения векторов(относительно друг друга)
    /// </summary>
    internal enum VectorRelation
    {
        General = 0,
        Parallel = 1,
        Orthogonal = 2
    }

    internal static class VectorExtensions
    {
        /// <summary>
        /// радиус эпсилон окрестности
        /// </summary>
        public static double e = 1e-6;
        /// <summary>
        /// Проверяет, является ли вектор нулевым.
        /// </summary>
        /// <param name="v">Принимаемый <see cref="Vector"/>.</param>
        /// <returns><c>true</c>, если его кооридинаты близки к нулю, <c>false</c> в остальных случаях.</returns>
        public static bool IsZero(this Vector v)
        {
            return v.SquareLength() <= e * e;
        }
        /// <summary>
        /// Нормализует вектор
        /// </summary>
        /// <param name="v"><see cref="Vector"/></param>
        /// <returns>Нормализованный вектор</returns>
        public static Vector Normalize(this Vector v)
        {
            if (v.IsZero())
            {
                throw new DivideByZeroException();
            }
            return v.Scale(1 / Math.Sqrt(v.SquareLength()));
        }
        /// <summary>
        /// Вычисляет величину угла между двумя векторами
        /// </summary>
        /// <param name="v">Первый <see cref="Vector"/></param>
        /// <param name="u">Второй <see cref="Vector"/></param>
        /// <returns>Величина угла в радианах</returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0.0;
            }
            else
            {
                Vector vNormal = v.Normalize();
                Vector uNormal = u.Normalize();
                return Math.Acos(vNormal.DotProduct(uNormal));
            }
        }
        /// <summary>
        /// Проверяет положения двух векторов относительно друг друга 
        /// </summary>
        /// <param name="v">Первый <see cref="Vector"/></param>
        /// <param name="u">Второй <see cref="Vector"/></param>
        /// <returns>Объект <see cref="VectorRelaion"/>, задающий отношение между векторами</returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            {
                var angle = GetAngleBetween(v, u);
                if (Math.Abs(angle - Math.PI / 2) < e)
                {
                    return VectorRelation.Orthogonal;
                }
                if (angle < e || angle > Math.PI - e)
                {
                    return VectorRelation.Parallel;
                }
                return VectorRelation.General;
            }
        }
    }

}
