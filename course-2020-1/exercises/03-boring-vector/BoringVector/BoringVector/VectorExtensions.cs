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
    /// Отношение между двумя векторами (общий случай, параллельны, перпендикулярны)
    /// </summary>
    enum VectorRelation { General, Parallel, Orthogonal };
    
    /// <summary>
    /// Методы-расширения структуры Vector
    /// </summary>
    static class VectorExtensions
    {
        /// <summary>
        /// Проверяет, является ли вектор нулевым c погрешностью по длине в 1e-6.
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/></param>
        /// <returns><see cref="bool"/>, является ли вектор нулевым</returns>
        public static bool IsZero(this Vector v)
        {
            const double eps = 1e-6;
            return Math.Sqrt(v.SquareLength()) < eps;
        }
        /// <summary>
        /// Возвращает <see cref="Vector"/>, отнормированный на его длину
        /// </summary>
        /// <param name="v"></param>
        /// <returns><see cref="Vector"/>, отнормированный на его длину</returns>
        public static Vector Normalize(this Vector v)
        {
            var inverted_len = 1 / Math.Sqrt(v.SquareLength());
            return v.Scale(inverted_len);
        }
        /// <summary>
        /// Возвращает <see cref="double"/>, угол между двумя векторами в радианах
        /// </summary>
        /// <param name="v">Первый <see cref="Vector"/></param>
        /// <param name="u">Второй <see cref="Vector"/></param>
        /// <returns><see cref="double"/>, угол между двумя векторами в радианах</returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            var lengths_product = Math.Sqrt(v.SquareLength() * u.SquareLength());
            return Math.Acos(v.DotProduct(u) / lengths_product);
        }
        /// <summary>
        /// Возвращает отношение (VectorRelation) между двумя векторами 
        /// </summary>
        /// <param name="v">Первый <see cref="Vector"/></param>
        /// <param name="u">Второй <see cref="Vector"/></param>
        /// <returns>Отношение (VectorRelation) между двумя векторами</returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            const double eps = 1e-6;
            var cross_product = v.CrossProduct(u);
            if (-eps < cross_product && cross_product < eps)
            {
                return VectorRelation.Parallel;
            }
            
            var dot_product = v.DotProduct(u);
            if (-eps < dot_product && dot_product < eps)
            {
                return VectorRelation.Orthogonal;
            }

            return VectorRelation.General;
        }
    }
}
