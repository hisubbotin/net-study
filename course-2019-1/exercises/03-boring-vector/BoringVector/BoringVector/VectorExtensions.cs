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

    internal static class VectorExpressions
    {
        //Точность сравнений.
        private const double epsilon = 1e-6;
        
        /// <summary>
        /// Проверяет, является ли вектор нулевым.
        /// </summary>
        /// <param name="v">Вектор.</param>
        /// <returns>True, если координаты вектора близки к нулю, False иначе.</returns>
        public static bool IsZero(Vector v)
        {
            return v.X < epsilon && v.X > -epsilon && v.Y < epsilon && v.Y > -epsilon;
        }

        /// <summary>
        /// Нормализует вектор.
        /// </summary>
        /// <param name="v">Вектор.</param>
        /// <returns>Вектор, сонаправленный данному, длины 1.</returns>
        public static Vector Normalize(Vector v)
        {
            double norm = v.SquareLength();
            return v / norm;
        }

        /// <summary>
        /// Возвращает угол между двумя векторами в радианах.
        /// </summary>
        /// <param name="v">Вектор.</param>
        /// <param name="u">Вектор.</param>
        /// <returns>Угол между двумя векторами в радианах.</returns>
        public static double GetAngleBetween(Vector v, Vector u)
        {
            if (Math.Abs(v.X) < epsilon && Math.Abs(v.Y) < epsilon || Math.Abs(u.X) < epsilon && Math.Abs(u.Y) < epsilon)
            {
                return 0.0;
            }
            return Math.Atan2(v.CrossProduct(u), v.DotProduct(u));
        }
        
        //Отношение между двумя векторами("общий случай", параллельны, перпендикулярны).
        public enum VectorRelation {General, Parallel, Orthogonal};

        /// <summary>
        /// Возвращает отношение между двумя векторами.
        /// </summary>
        /// <param name="v">Вектор.</param>
        /// <param name="u">Вектор.</param>
        /// <returns>Отношение между двумя векторами.</returns>
        public static VectorRelation GetRelation(Vector v, Vector u)
        {
            if (Math.Abs(v.CrossProduct(u)) < epsilon)
            {
                return VectorRelation.Parallel;
            }
            
            if (Math.Abs(v.DotProduct(u)) < epsilon)
            {
                return VectorRelation.Orthogonal;
            }
            
            return VectorRelation.General;
        }
    }
}
