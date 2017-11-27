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

    public static class VectorExtentions
    {
        private static readonly double TOLERANCE = 1e-6;

        public enum VectorRelation
        {
            General,
            Parallel,
            Orthogonal
        }
        
        /// <summary>
        /// Проверяет вектор на малость.
        /// </summary>
        public static bool IsZero(this Vector v)
        {
            return v.Length() < TOLERANCE;
        }

        /// <summary>
        /// Возвращает нормализованный вектор.
        /// </summary>
        public static Vector Normalize(this Vector v)
        {
            return v / v.Length();
        }

        /// <summary>
        /// Возвращает угол между двумя векторами.
        /// </summary>
        public static double GetAngleBetween(this Vector v, Vector other)
        {
            return Math.Asin(v.CrossProduct(other) / (v.Length() * other.Length()));
        }

        /// <summary>
        /// Возвращает положение между векторами.
        /// </summary>
        public static VectorRelation GetRelation(this Vector v, Vector other)
        {
            if (Math.Abs(v.DotProduct(other)) < TOLERANCE)
            {
                return VectorRelation.Orthogonal;
            }
            if (Math.Abs(v.CrossProduct(other)) < TOLERANCE)
            {
                return VectorRelation.Parallel;
            }
            return VectorRelation.General;
        }
    }
}