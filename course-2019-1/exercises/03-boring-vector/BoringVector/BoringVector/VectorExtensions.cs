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
    /// Отношение между векторами
    /// </summary>
    internal enum VectorRelaion
    {
        General = 0,
        Parallel = 1,
        Orthogonal = 2
    }

    /// <summary>
    /// Класс, умеющий делать полезные операции над векторами
    /// </summary>
    internal static class VectorExtensions
    {
        private const double Eps = 1e-6;
        
        /// <summary>
        /// Проверяет, является ли вектор нулевым
        /// </summary>
        /// <param name="v"><see cref="Vector"/></param>
        /// <returns>Является ли вектор нулевым</returns>
        public static bool IsZero(this Vector v)
        {
            return v.SquareLength() <= Eps * Eps;
        }

        /// <summary>
        /// Нормализует вектор
        /// </summary>
        /// <param name="v"><see cref="Vector"/></param>
        /// <returns>Нормализованный вектор</returns>
        public static Vector Normalize(this Vector v)
        {
            return IsZero(v) ? new Vector(0, 0) : v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Вычисляет неориентированный угол между векторами
        /// </summary>
        /// <param name="a">Первый <see cref="Vector"/></param>
        /// <param name="b">Второй <see cref="Vector"/></param>
        /// <returns>Угол между векторами в радианнах</returns>
        public static double GetAngleBetween(this Vector a, Vector b)
        {
            var squareLengths = Math.Sqrt(a.SquareLength() * b.SquareLength());
            return squareLengths < Eps * Eps ? 0 : Math.Acos(a.DotProduct(b) / squareLengths);
        }

        /// <summary>
        /// Вычисляет, в каком отношении находятся векторы
        /// </summary>
        /// <param name="a">Первый <see cref="Vector"/></param>
        /// <param name="b">Второй <see cref="Vector"/></param>
        /// <returns>Объект <see cref="VectorRelaion"/>, задающий отношение между векторами</returns>
        public static VectorRelaion GetRelation(this Vector a, Vector b)
        {
            var angle = GetAngleBetween(a, b);
            if (Math.Abs(angle - Math.PI / 2) < Eps)
            {
                return VectorRelaion.Orthogonal;
            }
            if (angle < Eps || angle > Math.PI - Eps)
            {
                return VectorRelaion.Parallel;
            }
            return VectorRelaion.General;
        }
        
    }
}
