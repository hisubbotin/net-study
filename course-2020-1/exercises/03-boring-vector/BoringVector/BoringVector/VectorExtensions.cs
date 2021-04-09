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
    /// Relation between two vectors (general case, parallel, perpendicular)
    /// </summary>
    enum VectorRelation { General, Parallel, Orthogonal };
    /// <summary>
    /// Extension methods of the Vector structure
    /// </summary>
    static class VectorExtensions
    {
        /// <summary>
        /// Checks if the vector is null with an error in length of 1e-6.
        /// </summary>
        /// <param name = "v"> Object <see cref = "Vector" /> </param>
        /// <returns> <see cref = "bool" /> whether the vector is null </returns>
        public static bool IsZero(this Vector v)
        {
            return v.SquareLength() < 1e-12;
        }
        /// <summary>
        /// Returns <see cref = "Vector" />, normalized to its length
        /// </summary>
        /// <param name = "v"> </param>
        /// <returns> <see cref = "Vector" /> normalized to its length </returns>
        public static Vector Normalize(this Vector v)
        {
            return v.Scale(1 / Math.Sqrt(v.SquareLength()));
        }
        /// <summary>
        /// Returns <see cref = "double" />, the angle between two vectors in radians
        /// </summary>
        /// <param name = "v"> First <see cref = "Vector" /> </param>
        /// <param name = "u"> Second <see cref = "Vector" /> </param>
        /// <returns> <see cref = "double" />, the angle between two vectors in radians </returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            return Math.Acos(v.DotProduct(u) / Math.Sqrt(v.SquareLength() * u.SquareLength()));
        }
        /// <summary>
        /// Returns the relation (VectorRelation) between two vectors
        /// </summary>
        /// <param name = "v"> First <see cref = "Vector" /> </param>
        /// <param name = "u"> Second <see cref = "Vector" /> </param>
        /// <returns> The relationship (VectorRelation) between two vectors </returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (-1e-6 < v.CrossProduct(u) && v.CrossProduct(u) < 1e-6)
            {
                return VectorRelation.Parallel;
            }
            else
            {
                if (-1e-6 < v.DotProduct(u) && v.DotProduct(u) < 1e-6)
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
}
