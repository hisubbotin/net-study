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
    /// Расширяющий методов класса Vector
    /// </summary>
    internal static class VectorExtenstions
    {

        /// <summary>
        /// Отношение между двумя векторами
        /// </summary>
        public enum VectorRelation
        {
            General, Parallel, Orthogonal
        }

        private const double eps = 1e-6;

        /// <summary>
        /// Проверка равенство нулевому вектору.
        /// </summary>
        /// <param name="v">Проверяемый вектор</param>
        public static bool IsZero(this Vector v)
        {
            return v.SquareLength() < eps;
        }

        /// <summary>
        /// Нормализация вектор
        /// </summary>
        /// <param name="v">Вектор</param>
        public static Vector Normalize(this Vector v)
        {
            var len = Math.Sqrt(v.SquareLength());
            return v.Scale(1 / len);
        }

        /// <summary>
        /// Получение угла между двумя векторами
        /// </summary>
        /// <param name="v">Первый вектор</param>
        /// <param name="u">Второй вектор</param>
        public static double GetAngleBetween(Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0;
            }

            var cos = (v.Normalize()).DotProduct(u.Normalize());
            return Math.Acos(cos);
        }

        /// <summary>
        /// Отношение между двумя векторами
        /// </summary>
        /// <param name="v">Первый вектор</param>
        /// <param name="u">Второй вектор</param>
        public static VectorRelation GetRelation(Vector v, Vector u)
        {
            if (Math.Abs(v.DotProduct(u)) < eps)
            {
                return VectorRelation.Orthogonal;
            }

            if (Math.Abs(v.CrossProduct(u)) < eps)
            {
                return VectorRelation.Parallel;
            }

            return VectorRelation.General;
        }

    }
}
