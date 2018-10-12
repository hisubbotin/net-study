using System;
using System.Runtime.CompilerServices;

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
    /// Допустимые отношение между 2-мя веткорами векторами
    /// </summary>
    public enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    }
    /// <summary>
    /// Класс с методами-расширениями структуры Vector
    /// </summary>
    internal static class VectorExtension
    {
        
        /// <summary>
        /// Проверяет вектор на равенство 0 по eps
        /// </summary>
        /// <param name="vec">проверяемый вектор</param>
        /// <returns>true:вектор нулевой,false:вектор не нулевой</returns>
        public static bool IsZero(this Vector vec)
        {
            double eps = 1e-6;
            return Math.Abs(vec.x) < eps && Math.Abs(vec.y) < eps ? true : false;
        }

        /// <summary>
        /// Нормирует вектор на единичную сферу
        /// </summary>
        /// <param name="vec">нормируемый вектор</param>
        public static Vector Normalize(this Vector vec)
        {
            if (vec.IsZero())
            {
                return vec;
            }
            vec /= Math.Sqrt(vec.SquareLength());
            return vec;
        }
        /// <summary>
        /// Вычисляет угол между 2-мя векторами
        /// </summary>
        /// <param name="a">1-ый вектор</param>
        /// <param name="b">2-ой вектор</param>
        /// <returns>угол в радианах</returns>
        public static double GetAngleBetween(this Vector a, Vector b)
        {
            if (a.IsZero() || b.IsZero())
            {
                return Double.NaN;
            }
            else
            {
                return Math.Acos(a.DotProduct(b) / Math.Sqrt(a.SquareLength() * b.SquareLength())) * Math.PI / 180;
            }
        }
        /// <summary>
        /// Устанавливает отношение между 2-мя векторами
        /// </summary>
        /// <param name="vec">1-ый вектор</param>
        /// <param name="comparisonVector">2-ой вектор</param>
        /// <returns>одно из полей VectorRelation: Orthogonal,Parallel,General</returns>
        public static VectorRelation GetRelation(this Vector vec, Vector comparisonVector )
        {
            double eps = 1e-6;
            if (Math.Abs(comparisonVector.DotProduct(vec)) < eps)
            {
                return VectorRelation.Orthogonal;
            } else if(Math.Abs(comparisonVector.CrossProduct(vec)) < eps)
            {
                return VectorRelation.Parallel;
            } else
            {
                return VectorRelation.General;
            }
        }
    }
}

