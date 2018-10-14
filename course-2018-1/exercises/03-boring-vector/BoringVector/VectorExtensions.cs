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
    /// Extensions for BoringVector class.
    /// </summary>
    public static class BoringVectorExtensions
    {
        /// <summary>
        /// If some value is lower than that level, then it is considered to be zero.
        /// </summary>
        private const double Tolerance = 1e-6;

        /// <summary>
        /// Possible relation between two vectors.
        /// </summary>
        internal enum VectorRelation
        {
            General = 0,
            Parallel = 7,
            Orthogonal = 13,
        }

        /// <summary>
        /// Returns True or False whether the given vector is zero or not.
        /// </summary>
        /// <param name="v">Given vector.</param>
        /// <returns>True, if it is a zero vector, False otherwise.</returns>
        internal static bool IsZero(this Vector v)
        {
            return Math.Abs(v.X) < Tolerance && Math.Abs(v.Y) < Tolerance;
        }
        
        /// <summary>
        /// Normalize the given vector.
        /// </summary>
        /// <param name="v">Given vector.</param>
        /// <returns>New vector, which size equals to 1.</returns>
        internal static Vector Normalize(this Vector v)
        {
            if (v.IsZero())
            {
                return new Vector(0, 0);
            }
            
            var length = Math.Sqrt(v.SquareLength());
            return new Vector(v.X / length, v.Y / length);
        }

        /// <summary>
        /// Computes angle between two given vectors.
        /// </summary>
        /// <param name="v">First vector.</param>
        /// <param name="u">Second vector.</param>
        /// <returns>Angle between two given vectors.</returns>
        internal static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0;
            }

            var lengthProduct = Math.Sqrt(v.SquareLength() * u.SquareLength());
            return Math.Acos(v.DotProduct(u) / lengthProduct);
        }
        
        /// <summary>
        /// There are 3 types of relationships between two vectors.
        /// This function determines which one of them is a case for the given two vectors.
        /// </summary>
        /// <param name="v">First vector.</param>
        /// <param name="u">Second vector.</param>
        /// <returns>Relation - one of the <see cref=""/></returns>
        internal static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (Math.Abs(v.DotProduct(u)) < Tolerance)
            {
                return VectorRelation.Orthogonal;
            }

            if (Math.Abs(v.GetAngleBetween(u)) < Tolerance)
            {
                return VectorRelation.Parallel;
            }
            
            return VectorRelation.General;
        }
    }
}
