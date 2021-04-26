using System;

namespace BoringVector
{
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
            if (v.IsZero())
            {
                return v;
            }

            return v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Возвращает <see cref="double"/>, угол между двумя векторами в радианах
        /// </summary>
        /// <param name="v">Первый <see cref="Vector"/></param>
        /// <param name="u">Второй <see cref="Vector"/></param>
        /// <returns><see cref="double"/>, угол между двумя векторами в радианах</returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0;
            }

            var cos = v.DotProduct(u) / Math.Sqrt(v.SquareLength() * u.SquareLength());
            if (cos < -1)
            {
                return Math.PI;
            }

            if (cos > 1)
            {
                return 0;
            }

            return Math.Acos(cos);
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
            var angle = v.GetAngleBetween(u);
            if (angle < eps || Math.PI - angle < eps)
            {
                return VectorRelation.Parallel;
            }
            
            if (Math.Abs(angle - Math.PI / 2) < eps)
            {
                return VectorRelation.Orthogonal;
            }

            return VectorRelation.General;
        }
    }
}
