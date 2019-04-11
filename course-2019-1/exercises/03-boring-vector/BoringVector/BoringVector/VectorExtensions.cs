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
    /// Значения относительного положения векторов ("общий случай", параллельны, перпендикулярны) 
    /// </summary>
    enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    }
    internal static class VectorExtensions
    {
        static double epsilon = 1e-6;
        
        /// <summary>
        /// Сравнение double с нулем с tolerance == epsilon
        /// </summary>
        /// <param name="d">Число</param>
        /// <returns>Флаг, является ли double нулевым</returns>
        public static bool IsZero(double d)
        {
            return Math.Abs(d) < epsilon;
        }
        
        /// <summary>
        /// Проверка вырожденности вектора
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <returns>Флаг, является ли исходный вектор нулевым</returns>
        public static bool IsZero(this Vector v)
        {
            return IsZero(Math.Sqrt(v.SquareLength()));
        }
        
        /// <summary>
        /// Нормировка вектора
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <returns>Вектор единичной длины, коллинеарный исходному</returns>
        public static Vector Normalize(this Vector v)
        {
            double length = Math.Sqrt(v.SquareLength());
            return IsZero(length) ? new Vector(0.0, 0.0) : new Vector(v.X / length, v.Y / length);
        }
        
        /// <summary>
        /// Вычисление угла между векторами
        /// </summary>
        /// <param name="v">Первый вектор</param>
        /// <param name="u">Второй вектор</param>
        /// <returns>Угол в радианах</returns>
        public static double GetAngleBetween(Vector v, Vector u)
        {
            return (IsZero(v) || IsZero(u)) ? 0.0 : Math.Acos(v.DotProduct(u) / (Math.Sqrt(v.SquareLength()) * Math.Sqrt(u.SquareLength())));
        }
        
        /// <summary>
        /// Относительное положение двух векторов
        /// </summary>
        /// <param name="v">Первый вектор</param>
        /// <param name="u">Второй вектор</param>
        /// <returns>значение перечесления VectorRelation - отношение между векторами</returns>
        public static VectorRelation GetRelation(Vector v, Vector u)
        {
            double angle = GetAngleBetween(v, u);
            return IsZero(angle) ? VectorRelation.Parallel
                                 : IsZero(angle - Math.PI / 2) ? VectorRelation.Orthogonal
                                                                  : VectorRelation.General;
        }
    }
}
