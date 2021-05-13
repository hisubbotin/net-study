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
    /// Класс, расширяющий функциональность двумерного вектора <see cref="Vector"/>
    /// </summary>
    internal static class VectorHelper
    {
        /// <summary>
        /// Константа для сравнения вещественных чисел
        /// </summary>
        private const double eps = 1e-6;

        /// <summary>
        /// Перечисление, определяющая взаимное расположение векторов в пространстве
        /// </summary>
        public enum VectorRelation
        {
            General,
            Parallel,
            Orthogonal
        }

        /// <summary>
        /// Проверяет, является ли вектор нулевым (с точностью до eps)
        /// </summary>
        /// <param name="v"> Вектор <see cref="Vector"/> </param>
        /// <returns> <see cref="double"/> Равен ли вектор нулевому </returns>
        public static bool IsZero(this Vector v)
        {
            double absX = Math.Abs(v.X);
            double absY = Math.Abs(v.Y);
            return absX < eps && absY < eps;
        }

        /// <summary>
        /// Нормализует вектор (приводит к длине 1, если он ненулевой)
        /// </summary>
        /// <param name="v"> Вектор <see cref="Vector"/> </param>
        /// <returns> <see cref="double"/> v / |v| </returns>
        public static Vector Normalize(this Vector v)
        {
            return v.IsZero() ? v : v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Считает угол между v и u в радианах
        /// </summary>
        /// <param name="v"> Первый <see cref="Vector"/> вектор </param>
        /// <param name="u"> Второй <see cref="Vector"/> вектор </param>
        /// <returns> <see cref="double"/> Угол между v и u </returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0;
            }

            return Math.Acos(v.Normalize().DotProduct(u.Normalize()));
        }


        /// <summary>
        /// Определяет взаимное расположение между векторами
        /// </summary>
        /// <param name="v"> Первый <see cref="Vector"/> вектор </param>
        /// <param name="u"> Второй <see cref="Vector"/> вектор </param>
        /// <returns> Взаимное расположение <see cref="VectorRelation"/> между v и u </returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            v = v.Normalize();
            u = u.Normalize();

            if (v.IsZero() || u.IsZero())
            {
                return VectorRelation.Parallel;
            }

            if (Math.Abs(Math.Abs(v.DotProduct(u)) - 1) < eps)
            {
                return VectorRelation.Parallel;
            }

            if (Math.Abs(v.DotProduct(u)) < eps)
            {
                return VectorRelation.Orthogonal;
            }

            return VectorRelation.General;
        }
    }
}
