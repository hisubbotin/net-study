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
    public enum VectorRelation : int {
        General = 0,
        Parallel = 1,
        Orthogonal = 2
    }
    internal static class VectorExtensions {

        const double epsilon = 1e-6;

        /// <summary>
        /// If the both components of the vector less than <see cref = "VectorExtensions.epsilon"/>, returns True.
        /// Othervise returns False
        /// </summary>
        /// <param name="v">Object of <see cref="Vector"/> class checking for Zero</param>
        /// <returns>Object of <see cref="bool"/>.</returns>
        public static bool IsZero(this Vector v) {
            if(Math.Abs(v._X) < epsilon && Math.Abs(v._Y) < epsilon) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// If the vector is not IsZero, normalizes vector.
        /// Othervise exception throwed
        /// </summary>
        /// <param name="v">Object of <see cref="Vector"/> class to normalize</param>
        /// <returns>Object of <see cref="Vector"/> class, normalized vector</returns>
        public static Vector Normalize(this Vector v) {
            if (v.IsZero()) {
                throw new System.ArgumentException("Normalized vector should not be Zero");
            }
            var length = Math.Sqrt(v.SquareLength());
            return new Vector(v._X/length, v._Y/length);
        }

        /// <summary>
        /// If the both vectors are not IsZero, returns angle between them.
        /// Othervise returns 0
        /// </summary>
        /// <param name="v">Object of <see cref="Vector"/> class</param>
        /// <param name="other_v">Object of <see cref="Vector"/> class</param>
        /// <returns>Variable of <see cref="doubdle"/> type, angle between the vectors</returns>
        public static double GetAngleBetween(this Vector v, Vector other_v) {
            if (v.IsZero()) {
                return 0.0;
            } 
            if (other_v.IsZero()) {
                return 0.0;
            }
            var dot_product = v.DotProduct(other_v);
            Console.WriteLine(dot_product);
            var v_length = Math.Sqrt(v.SquareLength());
            var other_v_length = Math.Sqrt(other_v.SquareLength());
            var angle_cos = dot_product/(v_length * other_v_length);
            return Math.Acos(angle_cos);
        }

        /// <summary>
        /// Makes sense if both of the vectors are not IsZero.
        /// Defines relations among the vectors.
        /// <relation cathegory="Orthogonal">
        /// If abs of DotProduct of the vectors less then <see cref = "VectorExtensions.epsilon"/> 
        /// </relation>
        /// </summary>
        /// <param name="v">Object of <see cref="Vector"/> class</param>
        /// <param name="other_v">Object of <see cref="Vector"/> class</param>
        /// <returns>Function can returns following cathegories:
        /// <list type="number">  
        /// <item>
        /// <term>Ortohonal</term>
        /// <description>Abs of DotProduct of the vectors less then <see cref = "VectorExtensions.epsilon"/> </description>  
        /// </item>  
        /// <item>
        /// <term>Parallel</term>
        /// <description>Abs of CrossProduct of the vectors less then <see cref = "VectorExtensions.epsilon"/> </description>
        /// </item>
        /// <item>
        /// <term>General</term>
        /// <description>Othervise </description>
        /// </item>
        /// </list>
        /// </returns>
        public static VectorRelation GetRelation(this Vector v, Vector other_v) {
            if(Math.Abs(v.DotProduct(other_v)) < epsilon) {
                return VectorRelation.Orthogonal;
            } else if(Math.Abs(v.CrossProduct(other_v)) < epsilon) {
                return VectorRelation.Parallel;
            } else {
                return VectorRelation.General;
            }
        }
    }
}
