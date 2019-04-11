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

    public static class BoringVectorExtension
    {
        /// <summary>
        /// если число принадлежит [-eps, eps] => равно нулю
        /// </summary>
        private static double eps = 1e-6;

        /// <summary>
        /// отношение векторов
        /// </summary>
        public enum VectorRelation
        {
            /// <summary>
            /// все остальное
            /// </summary>
            General, 
            /// <summary>
            /// параллельно
            /// </summary>
            Parallel, 
           /// <summary>
           /// ортогонально
           /// </summary>
            Orthogonal 
        };

        /// <summary>
        /// если компоненты веткора нули, возвращаем тру
        /// </summary>
        /// <param name="v">вектор</param>
        /// <returns>равен ли веткор нулю</returns>
        internal static bool isZero(this Vector v)
        {
            return Math.Abs(v.X) <= eps && Math.Abs(v.Y) <= eps;
        }

        /// <summary>
        /// Новый нормализованный вектор
        /// </summary>
        /// <param name="v">вектор</param>
        /// <returns>нормализованный вектор</returns>
        internal static Vector Normalize(this Vector v)
        {
            if (v.isZero())
            {
                return +v;
            }
            return v.Scale(1 / Math.Sqrt(v.SquareLength()));
        }

        /// <summary>
        /// возвращает угол между векторами
        /// </summary>
        /// <param name="v1">вектор 1</param>
        /// <param name="v2">вектор 2</param>
        /// <returns>угол в радианах</returns>
        internal static double GetAngleBetween(this Vector v1, Vector v2)
        {
            if (v1.isZero() || v2.isZero())
            {
                return 0.0;
            }

            return Math.Acos(v1.DotProduct(v2) / (v1.SquareLength() * v2.SquareLength()));
        }

        
        /// <summary>
        /// возвращает отношенеи векторов
        /// </summary>
        /// <param name="v1">первый вектор</param>
        /// <param name="v2">второй вектор</param>
        /// <returns>возвращает отношение векторв в простастранстве</returns>
        internal static VectorRelation GetRelation(this Vector v1, Vector v2)
        {
            if (v1.isZero() || v2.isZero() || v1.CrossProduct(v2) <= eps)
            {
                return VectorRelation.Parallel;
            } else if (v1.DotProduct(v2) <= eps)
            {
                return VectorRelation.Orthogonal;
            }
            else
            {
                return VectorRelation.General;
            }
        }
    }
}
