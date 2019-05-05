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
    /// Класс для методов-расширений для работы с вектором
    /// </summary>
    internal static class VectorExtensions
    {
        /// <summary>
        /// Перечисление, задающее отношение векторов друг к другу - параллельные вектора, ортогональные и все остальное
        /// </summary>
        public enum VectorRelation
        {
            General, Parallel, Orthogonal
        }
        
        /// <summary>
        /// Малая окрестность для <see cref="DoubleEquals"/>
        /// </summary>
        private const double Epsilon = 1e-6;
        
                
        /// <summary>
        /// Сравнение чисел в малой окрестности
        /// </summary>
        public static bool DoubleEquals(double d1, double d2)
        {
            return Math.Abs(d1 - d2) < Epsilon;
        }
      

        /// <summary>
        /// Проверка, что вектор - нулевой
        /// </summary>
        public static bool IsZero(this Vector v)
        {
            return v.SquareLength() < Epsilon;
        }

        /// <summary>
        /// Нормализует вектор
        /// </summary>
        public static Vector Normalize(this Vector v)
        {
            return v / v.SquareLength();
        }

        /// <summary>
        /// Возвращает угол между векторами
        /// </summary>
        public static double GetAngleBetween(this Vector v1, Vector v2)
        {
            if (IsZero(v1) || IsZero(v2))
            {
                return 0;
            }

            return Math.Acos(v1.DotProduct(v2) / Math.Sqrt(v1.SquareLength() * v2.SquareLength()));
        }

        /// <summary>
        /// Возвращает отношение между векторами
        /// </summary>
        public static VectorRelation GetRelation(this Vector v1, Vector v2)
        {
            var angle = GetAngleBetween(v1, v2);

            if (DoubleEquals(angle, 0) || DoubleEquals(angle, Math.PI))
            {
                return VectorRelation.Parallel;
            }

            return DoubleEquals(angle, Math.PI / 2) ? VectorRelation.Orthogonal : VectorRelation.General;
        }

        
    }
}
