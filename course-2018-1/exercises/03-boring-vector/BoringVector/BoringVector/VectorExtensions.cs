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
    internal static class VectorExtensions
    {
        /// <summary>
        /// Задаем точность.
        /// </summary>
        private const double Eps = 1e-6;
        
        /// <summary>
        /// Проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности).
        /// </summary>
        /// <param name="v"> </param>
        /// <returns></returns>
        public static bool IsZero(this Vector v)
        {
            return Math.Sqrt(v.SquareLength()) < Eps;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Vector Normalize(this Vector v)
        {
            if (v.IsZero())
            {
                throw new ArgumentException("Vector is zero");
            } 
          
            return v / Math.Sqrt(v.SquareLength());
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        private static double GetCosAngleBetween(this Vector v, Vector u)
        {
            return v.Normalize().DotProduct(u.Normalize());
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0;
            }

            return Math.Acos(v.Normalize().DotProduct(u.Normalize()));
        }
        
        /// <summary>
        /// Возможные взаимоположения векторов
        /// </summary>
        public enum Relation
        {
            General,
            Parallel,
            Orthogonal
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public static Relation GetRelation(this Vector v, Vector u)
        {
            double cosine = GetCosAngleBetween(v, u);
            
            if (cosine < Eps)
            {
                return Relation.Orthogonal;
            }

            return cosine < 1.0 - Eps ? Relation.Parallel : Relation.General;
        }
    }
}
