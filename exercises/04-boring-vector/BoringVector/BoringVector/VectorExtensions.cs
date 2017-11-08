using System;

namespace BoringVector
{
    /// <summary>
    /// Взаимное расположение векторов в просранстве.
    /// </summary>
    internal enum VectorRelation
    {
        General = 0,
        Parallel = 1,
        Orthogonal = 2
    }

    /// <summary>
    /// Расширение функционалности класса <see cref="Vector"/>.
    /// </summary>
    internal static class VectorExtenstions
    {
        private const double EPS = 1e-6;

        /// <summary>
        /// Проверяет, является ли вектор нулевым с точностью 1e-6.
        /// </summary>
        /// <param name="v">Объект типа <see cref="Vector"/>.</param>
        /// <returns>True, если вектор имеет нулевые координаты, false иначе.</returns>
        public static bool IsZero(this Vector v) => Math.Abs(v.X) < EPS && Math.Abs(v.Y) < EPS;

        /// <summary>
        /// Возвращает норму вектора.
        /// </summary>
        /// <param name="v">Объект типа <see cref="Vector"/>.</param>
        /// <returns>Норма вектора.</returns>
        public static double Length(this Vector v) => Math.Sqrt(v.SquareLength());

        /// <summary>
        /// Нормализует вектор <paramref name="v"/>.
        /// </summary>
        /// <param name="v">Объект типа <see cref="Vector"/>.</param>
        public static void Normalize(this Vector v)
        {
            v = v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Возвращает угол между двумя векторами в радианах.
        /// </summary>
        /// <param name="v">Объект типа <see cref="Vector"/>.</param>
        /// <param name="v">Ещё объект типа <see cref="Vector"/>.</param>
        /// <returns></returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0;
            }

            return Math.Acos(v.DotProduct(u) / (v.Length() * u.Length()));
        }

        /// <summary>
        /// Возвращает значение типа <see cref="VectorRelation"/> - отношение между векторами <paramref name="v"/> и <paramref name="u"/>.
        /// </summary>
        /// <param name="v">Объект типа <see cref="Vector"/>.</param>
        /// <param name="v">Ещё объект типа <see cref="Vector"/>.</param>
        /// <returns>Значение типа <see cref="VectorRelation"/> - отношение между двумя векторами.</returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (v.DotProduct(u) < EPS)
            {
                return VectorRelation.Orthogonal;
            }
            else if (v.CrossProduct(u) < EPS)
            {
                return VectorRelation.Parallel;
            }

            return VectorRelation.General;
        }
    }
}
