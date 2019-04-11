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
    internal static class VectorExtensions
    {

        /// <summary>
        /// Эпсилон окрестность
        /// </summary>
        public static double Epsilon = 1e-6;

        

        /// <summary>
        /// Проверяет, является ли вектор нулевым.
        /// </summary>
        /// <returns>True, если его координаты близки к нулю (в эпсилон окрестности), False иначе</returns>
        /// <param name="v">Принимаемый вектор.</param>
        public static bool IsZero(this Vector v)
        {
            return (Math.Abs(v.X) <= Epsilon && Math.Abs(v.Y) <= Epsilon);
        }

        /// <summary>
        /// Нормализует вектор
        /// </summary>
        /// <param name="v">Вектор для нормировки</param>
        /// <returns>Нормализованный вектор</returns>
        public static Vector Normalize(this Vector v)
        {
            if (v.IsZero())
            {
                return new Vector(0, 0);
            }
            Vector u = new Vector(v.X, v.Y);
            return u / Math.Sqrt(u.SquareLength());
        }

        /// <summary>
        /// Вычисляет угол между двумя векторами, если один из векторов нулевой - угол нулевой
        /// </summary>
        /// <param name="v">Вектор 1</param>
        /// <param name="u">Вектор 2</param>
        /// <returns>Угол между векторами в радианах</returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0;
            }
            else
            {
                Vector vNormal = v.Normalize();
                Vector uNormal = u.Normalize();
                return Math.Acos(vNormal.DotProduct(uNormal));
            }
        }

        /// <summary>
        /// возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal)
        /// - отношение между двумя векторами("общий случай", параллельны, перпендикулярны).
        /// </summary>
        /// <param name="v">Вектор1</param>
        /// <param name="u">Вектор2</param>
        /// <returns>Одно из отношений в  <see cref="VectorRelation"/></returns>
        internal static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (Math.Abs(v.GetAngleBetween(u)) < Epsilon)
            {
                return VectorRelation.Parallel;
            }

            if (Math.Abs(v.DotProduct(u)) < Epsilon)
            {
                return VectorRelation.Orthogonal;
            }

            return VectorRelation.General;
        }

        /// <summary>
        /// Перечисление с возможными положениями двух векторов относительно друг друга.
        /// </summary>
        internal enum VectorRelation
        {
            General = 0,
            Parallel = 1,
            Orthogonal = 2
        }
    }
}
