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
    /// класс с методами-расширениями структуры Vector
    ///</summary>
    internal static class VectorExtensions
    {
        /// <summary>
        /// перечисление отношений между векторами
        ///</summary>
        public enum VectorRelation
        {
         General,
         Parallel,
         Orthogonal
        };

        private const double Epsilon = 1e-6;

        /// <summary>
        /// проверка на равенство вектора нулю
        ///</summary>
        public static bool IsZero(this Vector v)
        {
            return Math.Sqrt(v.SquareLength()) < Epsilon;
        }

        /// <summary>
        /// нормализация вектора
        ///</summary>
        public static Vector Normalize(this Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// вычисление угла между векторами
        ///</summary>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u))
            {
                return 0.0;
            }
            
            return Math.Acos(v.DotProduct(u) / (v.Length() * u.Length()));
        }

        /// <summary>
        /// вычисление отношения между векторами
        ///</summary>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (v.GetAngleBetween(u) < Epsilon)
            {
                return VectorRelation.Parallel;
            }
            if (v.DotProduct(u) < Epsilon)
            {
                return VectorRelation.Orthogonal;
            }
            return VectorRelation.General;
        }
    }
}
