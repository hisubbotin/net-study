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
    /// Перечисление, задающее отношение между двумя векторами.
    /// </summary>
    internal enum VectorRelation
    {
        General = 0, // "общий случай"
        Parallel = 1, // параллельны
        Orthogonal = 2 // ортогональны
    }
    
    internal static class BoringVector
    {
        private const double Eps = 1e-6; // константа, задающая эпсилон окрестность

        /// <summary>
        /// Проверяет вектор на равенство 0.
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/>, задающий вектор.</param>
        /// <returns>True, если вектор равен 0, и False - иначе.</returns>
        public static bool IsZero(Vector v)
        {
            return Math.Abs(v.X) < Eps && Math.Abs(v.Y) < Eps;
        }

        /// <summary>
        /// Нормализует заданный вектор.
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/>, задающий вектор.</param>
        /// <returns>Объект <see cref="Vector"/>, нормализованный вектор.</returns>
        public static Vector Normalize(Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Вычисляет угол между двумя векторами.
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/>, задающий первый вектор.</param>
        /// <param name="u">Объект <see cref="Vector"/>, задающий второй вектор.</param>
        /// <returns>Угол между заданными векторами.</returns>
        public static double GetAngleBetween(Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u))
            {
                return 0.0;
            }
            return Math.Acos(v.DotProduct(u) / Math.Sqrt(v.SquareLength()) / Math.Sqrt(u.SquareLength()));
        }

        /// <summary>
        /// Находит отношение между векторами.
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/>, задающий первый вектор.</param>
        /// <param name="u">Объект <see cref="Vector"/>, задающий второй вектор.</param>
        /// <returns>Значение перечисления <see cref="VectorRelation"/>, задающее отношение между векторами.</returns>
        public static VectorRelation GetRelation(Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u) || v.CrossProduct(u) < Eps)
            {
                return VectorRelation.Parallel;
            }
            return v.DotProduct(u) < Eps ? VectorRelation.Orthogonal : VectorRelation.General;
        }
    }
}
