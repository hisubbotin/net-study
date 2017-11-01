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
    /// Отношение между двумя векторами("общий случай", параллельны, перпендикулярны)
    /// </summary>
    internal enum EVectorRelation
    {
        General,
        Parallel,
        Orthogonal
    }
    
    /// <summary>
    /// Методы-расширения для структуры <see cref="Vector"/>
    /// </summary>
    internal static class VectorHelper
    {
        /// <summary>
        /// Константа точности
        /// </summary>
        private const double Eps = 1e-6;
        
        /// <summary>
        /// Проверяет, является ли вектор нулевым с точностью Eps
        /// </summary>
        /// <param name="v">Проверяемый объект <see cref="Vector"/></param>
        /// <returns>true, если вектор нулевой, иначе false</returns>
        public static bool IsZero(this Vector v)
        {
            return v.X < Eps && v.Y < Eps;
        }
        
        /// <summary>
        /// Нормализует вектор
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/></param>
        /// <returns>Объект <see cref="Vector"/> - нормализованный вектор</returns>
        public static Vector Normalize(this Vector v)
        {
            return v.IsZero() ? v : v.Scale(Math.Sqrt(v.SquareLength()));
        }
        
        /// <summary>
        /// Возвращает угол между векторами в радианах
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/></param>
        /// <param name="u">Объект <see cref="Vector"/></param>
        /// <returns>Угол между векторами <paramref name="v"/> и <paramref name="u"/></returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
                return 0;

            return Math.Acos(v.Normalize().DotProduct(u.Normalize()));
        }
        
        /// <summary>
        /// Возвращает отношение между двумя векторами
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/></param>
        /// <param name="u">Объект <see cref="Vector"/></param>
        /// <returns>Объект перечисления <see cref="EVectorRelation"/> - отношение между векторами</returns>
        public static EVectorRelation VectorRelation(this Vector v, Vector u)
        {
            if (v.DotProduct(u) < Eps)
                return EVectorRelation.Orthogonal;

            if (v.CrossProduct(u) < Eps)
                return EVectorRelation.Parallel;

            return EVectorRelation.General;
        }
    }
}
