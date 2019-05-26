﻿using System;
using System.Runtime.CompilerServices;



[assembly: InternalsVisibleTo("BoringVector.Tests")]

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
    /// Расширение функционала вектора
    /// </summary>
    internal static class VectorExtensions
    {
        private const double epsilon = 0.000001;

        /// <summary>
        /// Задает отношение между двумя векторами - "общий случай", параллельны, перпендикулярны)
        /// </summary>
        public enum VectorRelation : byte
        {
            General, Parallel, Orthogonal
        }

        public static bool IsZero(this Vector v)
        {
            return v.SquareLength() <= epsilon;
        }

        /// <summary>
        /// нормализует вектор
        /// </summary>
        /// <param name="v">вектор для нормировки</param>
        /// <returns>нормированный вектор</returns>
        public static Vector Normalize(this Vector v)
        {
            if (v.IsZero()) {
                return new Vector(0, 0);
            }
            return v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// возвращает угол между двумя векторами
        /// </summary>
        /// <param name="v">первый вектор</param>
        /// <param name="u">второй вектор</param>
        /// <returns>угол между данными векторами</returns>
        public static double GetAngleBetween(this Vector a, Vector b)
        {
            if (a.IsZero() || b.IsZero())
            {
                return 0;
            }
            return Math.Acos(a.DotProduct(b) / Math.Sqrt(a.SquareLength() * b.SquareLength()));
        }

        /// <summary>
        /// возвращает отношение между двумя векторами  (General - "общий случай", Parallel - параллельны, Orthogonal - перпендикулярны)
        /// </summary>
        /// <param name="a">первый вектор</param>
        /// <param name="b">второй вектор</param>
        /// <returns> (General - "общий случай", Parallel - параллельны, Orthogonal - перпендикулярны)</returns>
        public static VectorRelation GetRelation(this Vector a, Vector b)
        {
            double angle = GetAngleBetween(a, b);

            if (angle < epsilon || Math.PI - angle < epsilon)
            {
                return VectorRelation.Parallel;
            }
            if ((Math.Abs(angle - Math.PI/2)) < epsilon) // pi/2 = 90 grad
            {
                return VectorRelation.Orthogonal;
            }
            return VectorRelation.General;
        }
    }
}
