using System;

namespace BoringVector
{
    /// <summary>
    /// Класс, расширяющий методы класса Vector
    /// </summary>
    internal static class UpdateVector
    {
        private const double eps = 1e-9;
        
        /// <summary>
        /// Проверяет равенство вектора нулевому вектору.
        /// </summary>
        /// <param name="v">Входной вектор</param>
        /// <returns>True, если вектор нулевой, False иначе</returns>
        public static bool IsZero(this Vector v)
        {
            return v.SquareLength() < eps;
        }

        /// <summary>
        /// Нормализует вектор
        /// </summary>
        /// <param name="v">Входной вектор</param>
        /// <returns>Нормализованный вектор</returns>
        public static Vector Normalize(this Vector v)
        {
            var lenght = Math.Sqrt(v.SquareLength());
            return new Vector {X = v.X / lenght, Y = v.Y / lenght};
        }

        /// <summary>
        /// Находит угол между двумя векторами
        /// </summary>
        /// <param name="v">Первый вектор</param>
        /// <param name="u">Второй вектор</param>
        /// <returns>Угол между векторами, в радианах</returns>
        public static double GetAngleBetween(Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0;
            }

            var cos_alpha = (v.Normalize()).DotProduct(u.Normalize());
            return Math.Acos(cos_alpha);
        }
        
        
        internal enum VectorRelation
        {
            General, 
            Parallel, 
            Orthogonal
        }

        /// <summary>
        /// Возвращает тип отношения между двумя векторами
        /// </summary>
        /// <param name="v">Первый вектор</param>
        /// <param name="u">Второй вектор</param>
        /// <returns>Тип отношения</returns>
        public static VectorRelation GetRelation(Vector v, Vector u)
        {
            var dot_product = v.DotProduct(u);
            if (Math.Abs(dot_product) < eps)
            {
                return VectorRelation.Orthogonal;
            }

            var cross_product = v.CrossProduct(u);
            if (Math.Abs(cross_product) < eps)
            {
                return VectorRelation.Parallel;
            }

            return VectorRelation.General;
        }
    }
    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */
}
