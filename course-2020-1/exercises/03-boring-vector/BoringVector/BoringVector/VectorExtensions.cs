using System;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;

namespace BoringVector
{

    /// <summary>
    /// Отношение между двумя векторами (общий случай, параллельны, перпендикулярны)
    /// </summary>
    enum VectorRelation { General, Parallel, Orthogonal };
    
    /// <summary>
    /// Дополнительные методы структуры Vector
    /// </summary>
    static class VectorExtensions
    {
        
        /// <summary>
        /// Проверяет, является ли вектор нулевым с точностью до 1e-6.
        /// </summary>
        /// <param name="v"> Вектор <see cref="Vector"/> </param>
        /// <returns> Результат <see cref="bool"/> сравнения с нулем </returns>
        public static bool isZero(this Vector v)
        {
            const double eps = 1e-6;
            return Math.Sqrt(v.SquareLength()) < eps;
        }
    
        /// <summary>
        /// Метод, который нормализует заданный вектор
        /// </summary>
        /// <param name="v"> Заданный двумерный вектор <see cref="Vector"/> </param>
        /// <returns> Вектор <see cref="Vector"/> в изначальном направлении, единичной длины </returns>
        public static Vector Normalize(this Vector v)
        {
            if (v.isZero())
            {
                throw new DivideByZeroException();
            }
            
            var norm = Math.Sqrt(v.SquareLength());
            return v.Scale(1 / norm);
        }
        
        /// <summary>
        /// Метод, возвращающий угол между векторами <see cref="Vector"/>, если один из векторов <see cref="Vector"/> ноль,
        /// то угол <see cref="double"/> между векторами <see cref="Vector"/> по определению ноль
        /// </summary>
        /// <param name="v1"> Первый вектор <see cref="Vector"/> </param>
        /// <param name="v2"> Второй вектор <see cref="Vector"/> </param>
        /// <returns> Возвращает угол <see cref="double"/> между заданными векторами </returns>
        public static double GetAngleBetween(this Vector v1, Vector v2)
        {
            if (v1.isZero() || v2.isZero() || Math.Sqrt(v1.SquareLength() * v2.SquareLength()) < 1e-6)
            {
                return 0;
            }
            
            double cos = v1.DotProduct(v2) / Math.Sqrt(v1.SquareLength() * v2.SquareLength());
            
            if (cos < -1)
            {
                return Math.PI;
            }

            if (cos > 1)
            {
                return 0;
            }

            return Math.Acos(cos);
        }
        
        /// <summary>
        /// Метод возвращает отношение (VectorRelation) между векторами <see cref="Vector"/> : параллельны, перпенидикулярны, общий случай
        /// </summary>
        /// <param name="v1"> Первый вектор <see cref="Vector"/> </param>
        /// <param name="v2"> Второй вектор <see cref="Vector"/> </param>
        /// <returns> Отношение (VectorRelation) между векторами <see cref="Vector"/> </returns>
        public static VectorRelation GetRelation(this Vector v1, Vector v2)
        {
            const double eps = 1e-6;
            if (Math.Abs(GetAngleBetween(v1, v2)) < eps)
            {
                return VectorRelation.Parallel;
            }
            
            return Math.Abs(v1.DotProduct(v2)) < eps ? VectorRelation.Orthogonal : VectorRelation.General;
        }
        
    }
    
}
