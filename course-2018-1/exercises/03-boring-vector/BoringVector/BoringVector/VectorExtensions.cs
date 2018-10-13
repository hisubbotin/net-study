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
    /// Enum c вариантами взаимного расположения векторов
    /// General вектора общего положения
    /// Parallel параллельные вектора
    /// Orthogonal перпендикулярные вектора
    /// </summary>
    public enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    }

    public static class VectorExt
    {
        /// <summary>
        /// Провектора вектора на 0
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool IsZero(this Vector v)
        {
            const double eps = 1e-6;
            return Math.Sqrt(v.SquareLength()) < eps;
        }

        /// <summary>
        /// Нормализация вектора
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Вектор единичной нормы</returns>
        public static Vector Normalize(this Vector v)
        {
            double length = Math.Sqrt(v.SquareLength());
            return v / length;
        }

        /// <summary>
        /// Косинус угла между векторами
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>Косинус</returns>
        private static double GetCosAngleBetween(this Vector first, Vector second)
        {
            return first.Normalize().DotProduct(second.Normalize());
        }

        /// <summary>
        /// Угол между векторами
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>Угол в радианах</returns>
        public static double GetAngleBetween(this Vector first, Vector second)
        {
            if (first.IsZero() || second.IsZero())
            {
                return 0;
            }

            return Math.Acos(first.GetCosAngleBetween(second));
        }

        /// <summary>
        /// Получить взаимное расположение векторов
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>Положение векторов</returns>
        public static VectorRelation GetRelation(this Vector first, Vector second)
        {
            double cosine = Math.Abs(first.GetCosAngleBetween(second));

            if (cosine < 1e-6)
            {
                return VectorRelation.Orthogonal;
            }
            if (cosine  > 1 - 1e-6)
            {
                return VectorRelation.Parallel;
            }

            return VectorRelation.General;
        }
    }

}
