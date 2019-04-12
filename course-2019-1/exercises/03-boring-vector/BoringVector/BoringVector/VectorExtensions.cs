using System;

using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("BoringVector.Tests")]

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
    /// Расширение функционала вектора
    /// </summary>
    internal static class VectorExtensions
    {
        public const double Eps = 0.000001;
        
        /// <summary>
        /// Отношение между двумя векторами
        /// ("общий случай", параллельны, перпендикулярны)
        /// </summary>
        public enum VectorRelation: byte
        {
            General,
            Parallel,
            Orthogonal
        }

        /// <summary>
        /// проверяет, является ли вектор нулевым
        /// </summary>
        /// <param name="v">вектор для проверки</param>
        /// <returns>false - не является, true - является</returns>
        public static bool IsZero(Vector v)
        {
            return v.SquareLength() <= Eps;
        }

        /// <summary>
        /// нормализует вектор
        /// </summary>
        /// <param name="v">вектор для нормировки</param>
        /// <returns>нормированный вектор</returns>
        public static Vector Normalize(Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// возвращает угол между двумя векторами
        /// </summary>
        /// <param name="v">первый вектор</param>
        /// <param name="u">второй вектор</param>
        /// <returns>угол между данными векторами</returns>
        public static double GetAngleBetween(Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u))
            {
                return 0;
            }
            return Math.Asin(Normalize(v).CrossProduct(Normalize(u)));
        }
        
        /// <summary>
        /// возвращает отношение между двумя векторами  (General - "общий случай", Parallel - параллельны, Orthogonal - перпендикулярны)
        /// </summary>
        /// <param name="a">первый вектор</param>
        /// <param name="b">второй вектор</param>
        /// <returns> (General - "общий случай", Parallel - параллельны, Orthogonal - перпендикулярны)</returns>
        public static VectorRelation GetRelation(Vector a, Vector b)
        {
            double angle = GetAngleBetween(a, b);

            if (angle < Eps || angle > Math.PI - Eps)
            {
                return VectorRelation.Parallel;
            }
            
            if (Math.Abs(angle - Math.PI/2) < Eps)
            {
                return VectorRelation.Orthogonal;
            }

            return VectorRelation.General;
        }
    }
 }