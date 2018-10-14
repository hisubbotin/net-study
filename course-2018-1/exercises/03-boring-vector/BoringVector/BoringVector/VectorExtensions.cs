using System;

namespace BoringVector
{
    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - 
            отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */

    internal static class VectorExtension
    {
        /// <summary>
        /// Заданная точность проверок типа double
        /// </summary>
        internal static double EPSILON = 1e-6;

        /// <summary>
        /// Отношение между двумя <see cref="Vector"/> - <see cref="Vector"/>ы общего положения, <see cref="Vector"/>ы параллельны, <see cref="Vector"/>ы перепендикулярны
        /// </summary>
        internal enum VectorRelation
        {
            General,
            Parallel,
            Orthogonal
        }

        /// <summary>
        /// Проверка, что <see cref="Vector"/> является нулевым
        /// </summary>
        /// <param name="v">Данный <see cref="Vector"/></param>
        /// <returns>bool - результат проверки</returns>
        public static bool IsZero(this Vector v)
        {
            return Math.Abs(v.X) <= EPSILON && Math.Abs(v.Y) <= EPSILON;
        }

        /// <summary>
        /// Нормализация <see cref="Vector"/>
        /// </summary>
        /// <param name="v">Данный <see cref="Vector"/></param>
        /// <returns>Нормализованный объект типа <see cref="Vector"/></returns>
        public static Vector Normalize(this Vector v)
        {
            return v / v.Length();
        }

        /// <summary>
        /// Угол между двумя <see cref="Vector"/>
        /// </summary>
        /// <param name="v">Первый <see cref="Vector"/></param>
        /// <param name="u">Второй <see cref="Vector"/></param>
        /// <returns>Угол в радианах типа double</returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0;
            }

            return Math.Acos(v.DotProduct(u) / v.Length() / u.Length());
        }

        /// <summary>
        /// Отношение между двумя <see cref="Vector"/>
        /// </summary>
        /// <param name="v">Первый <see cref="Vector"/></param>
        /// <param name="u">Второй <see cref="Vector"/></param>
        /// <returns>Объект перечисления <see cref="VectorRelation"/></returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (Math.Abs(GetAngleBetween(v, u)) < EPSILON)
            {
                return VectorRelation.Parallel;
            }

            if (Math.Abs(v.DotProduct(u)) < EPSILON)
            {
                return VectorRelation.Orthogonal;
            }

            return VectorRelation.General;
        }
    }
}
