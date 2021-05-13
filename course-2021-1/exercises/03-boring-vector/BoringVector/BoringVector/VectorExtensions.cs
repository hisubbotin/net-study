using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

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
    /// Класс с методами-расширениями структуры Vector
    /// </summary>
    internal static class VectorExtensions
    {
        /// <summary>
        /// Тип перечисления, описывающий виды отношений между двумя векторами
        /// </summary>
        internal enum VectorRelation
        {
            General,
            Parallel,
            Orthogonal
        };

        private const double Eps = 1e-6;

        /// <summary>
        /// Проверяет, является ли вектор нулевым (0; 0) или нет
        /// </summary>
        /// <param name="v">Вектор, который надо проверить</param>
        /// <returns>Булево значение true, если вектор нулевой и false, если ненулевой</returns>
        public static bool IsZero(this Vector v)
        {
            return v.SquareLength() < Eps;
        }

        /// <summary>
        /// Нормализует вектор, т.е. сохраняет направление и делает длину равной 1
        /// </summary>
        /// <param name="v">Вектор, который надо нормализовать</param>
        public static Vector Normalize(this Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Вычисляет угол между двумя векторами
        /// </summary>
        /// <param name="v">1-ый вектор</param>
        /// <param name="u">2-ой вектор</param>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            return Math.Acos(v.DotProduct(u) / (Math.Sqrt(v.SquareLength()) * Math.Sqrt(u.SquareLength())));
        }

        /// <summary>
        /// Возвращает тип отношения между векторами, т.е. "общий случай", параллельны или перпендикулярны
        /// </summary>
        /// <param name="v">1-ый вектор</param>
        /// <param name="u">2-ой вектор</param>
        /// <returns><c>General</c> в "общем случае"; <c>Parallel</c> если параллельны; <c>Orthogonal</c> если перпендикулярны</returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (v.DotProduct(u) < Eps)
            {
                return VectorRelation.Orthogonal;
            }

            if (v.CrossProduct(u) < Eps)
            {
                return VectorRelation.Parallel;
            }

            return VectorRelation.General;
        }
    }
}
