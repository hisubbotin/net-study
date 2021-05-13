using System;
using System.Collections.Specialized;

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
        private const double epsilon = 1e6;

        /// <summary>
        /// Checks if the <see cref="Vector"/> is Zero <see cref="Vector"/>.
        /// </summary>
        /// <param name="v"> <see cref="Vector"/> to be checked. </param>
        /// <returns> <see cref="bool"/> of if <see cref="Vector"/> is zero <see cref="Vector"/>. </returns>
        public static bool IsZero(this Vector v)
        {
            return Math.Abs(v.X) < epsilon && Math.Abs(v.Y) < epsilon;
        }

        /// <summary>
        /// Returns the scaled <see cref="Vector"/> with the Length equal to 1.
        /// </summary>
        /// <param name="v"> <see cref="Vector"/> to be normalized. </param>
        /// <returns> Normalized <see cref="Vector"/>. </returns>
        public static Vector Normalize(this Vector v)
        {
            return v.Scale(Math.Sqrt(v.SquareLength()));
        }

        /// <summary>
        /// Calculates the angle between two object of <see cref="Vector"/> type in radians (<see cref="double"/>).
        /// </summary>
        /// <param name="v"> First <see cref="Vector"/>. </param>
        /// <param name="u"> Second <see cref="Vector"/>. </param>
        /// <returns> Angle between two objects of <see cref="Vector"/> type in radians (<see cref="double"/>). </returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
                return 0d;
            return Math.Acos(v.Normalize().DotProduct(u.Normalize()));
        }


        /// <summary>
        /// Enum with possible <see cref="Vector"/> relations.
        /// </summary>
        public enum VectorRelation
        {
            General, Parallel, Orthogonal
        }

        /// <summary>
        /// Returns <see cref="VectorRelation"/> between two objects of <see cref="Vector"/> type.
        /// </summary>
        /// <param name="v"> First <see cref="Vector"/>. </param>
        /// <param name="u"> Second <see cref="Vector"/>. </param>
        /// <returns> <see cref="VectorRelation"/> as the relation between two objects of <see cref="Vector"/> type. </returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
                return VectorRelation.Parallel;
            Vector vNorm = v.Normalize();
            Vector uNorm = u.Normalize();

            if (vNorm.DotProduct(uNorm) < epsilon)
                return VectorRelation.Orthogonal;

            if (vNorm.CrossProduct(uNorm) < epsilon)
                return VectorRelation.Parallel;

            return VectorRelation.General;
        }

    }

}
