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
    /// Тип отношения между двумя векторами.
    /// </summary>
    public enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    };

    /// <summary>
    /// Класс с методами расширения.
    /// </summary>
    public static class VectorHelper
    {
        /// <summary>
        /// Проверяет, является ли вектор нулевым.
        /// </summary>
        public static bool IsZero(this Vector v)
        {
            return (v.X < 1E-6 || v.Y < 1E-6);
        }
        /// <summary>
        /// Нормализует вектор.
        /// </summary>
        public static Vector Normalize(this Vector v)
        {
            return v / v.Length();
        }
        /// <summary>
        /// Возвращает угол между двумя векторами в радианах.
        /// </summary>
        public static double GetAngleBetween(this Vector v1, Vector v2)
        {
            if (v1.SquareLength() < 1E-6 || v2.SquareLength() < 1E-6)
            {
                return 0;
            }
            else
            {
                return Math.Acos(v1.DotProduct(v2) / (v1.Length() * v2.Length()));
            }
        }
        /// <summary>
        /// Возвращает отношение между двумя векторами.
        /// </summary>
        public static VectorRelation GetRelation(this Vector v1, Vector v2)
        {
            double angle = v1.GetAngleBetween(v2);
            if (v1.CrossProduct(v2) < 1E-6)
            {
                return VectorRelation.Parallel;
            }
            else if (v1.DotProduct(v2) < 1E-6)
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
