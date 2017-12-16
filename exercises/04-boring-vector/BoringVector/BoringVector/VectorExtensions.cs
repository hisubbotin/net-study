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

    public enum VectorRelation
    {
        General = 0,
        Parallel = 1,
        Ortogonal = 2
    }

    /// <summary>
    /// Класс с методами-расширениями структуры Vector
    /// </summary>
    internal static class VectorExtenstions
    {
        /// <summary>
        /// Проверяет, является ли вектор v нулевым
        /// </summary>
        /// <returns>true - если координаты v близки к нулю, false иначе</returns>
        public static bool IsZero(Vector v)
        {
            return (v.X < 1e-6 && v.X > -1e-6) && (v.Y < 1e-6 && v.Y > -1e-6);
        }

        /// <summary>
        /// Нормализует вектор v
        /// </summary>
        public static Vector Normalize(Vector v)
        {
            return v / v.Length();
        }

        /// <summary>
        /// Возвращает угол между двумя векторами в радианах
        /// </summary>
        public static double GetAngleBetween(Vector v1, Vector v2)
        {
            if(IsZero(v1) || IsZero(v2))
            {
                return 0;
            }
            return Math.Acos(v1.DotProduct(v2) / (v1.Length() * v2.Length()));
        }

        /// <summary>
        /// Возвращает значение перечисления VectorRelation - общий случай, параллельны или перпендикулярны
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static VectorRelation GetRelation(Vector v1, Vector v2)
        {
            double angle = GetAngleBetween(v1, v2);
            if(angle < 1e-6)
            {
                return VectorRelation.Parallel;
            }
            if(v1.DotProduct(v2) < 1e-6)
            {
                return VectorRelation.Ortogonal;
            }

            return VectorRelation.General;
        }
    }
}
