using System;
using System.Collections.Concurrent;

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
    /// Класс, хранящий необходимые для некоторых вычислений константы
    /// </summary>
    internal static class Constants
    {
        public const double epsilon = 1e-6;
    }

    /// <summary>
    /// Перечисление, задающее все возможные отношения между двумя векторами("общий случай", параллельны, перпендикулярны)
    /// </summary>
    internal enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    }
    
    /// <summary>
    /// Класс, реализуующий методы-расширения структуры Vector
    /// </summary>
    internal static class VectorExtensions
    {
        /// <summary>
        /// Проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). 
        /// За эпсилон берется константа, определенная в соответствующем классе <see cref="Constants"/>
        /// </summary>
        /// <param name="v">Вектор, который проверяется</param>
        /// <returns>true, если вектор нулевой, false иначе</returns>
        public static bool IsZero(this Vector v)
        {
            return (v.X >= -Constants.epsilon && v.X <= Constants.epsilon) &&
                   (v.Y >= -Constants.epsilon && v.Y <= Constants.epsilon);
        }
        /// <summary>
        /// Нормализует вектор (т.е. маштабирует так, чтобы его длина была единичной)
        /// </summary>
        /// <param name="v">Вектор, который нормализуем</param>
        /// <returns>Вектор, получившийся в результате нормализации</returns>
        public static Vector Normalize(this Vector v)
        {
            if (v.IsZero())
                return v;
            var length = Math.Sqrt(v.SquareLength());
            return v / length;
        }
        /// <summary>
        /// Возвращает угол между двумя векторами в радианах. 
        /// Примечание: нулевой вектор сонаправлен любому другому.
        /// </summary>
        /// <param name="v">Первый вектор</param>
        /// <param name="u">Второй вектор</param>
        /// <returns>Угол меджду векторами в радианах</returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
                return 0;
            var dotProduct = v.DotProduct(u);
            var lengthV = v.SquareLength();
            var lengthU = u.SquareLength();
            return Math.Acos(Math.Sqrt(dotProduct * dotProduct / lengthU / lengthV));
        }
        /// <summary>
        ///  Возвращает отношение между двумя векторами("общий случай", параллельны, перпендикулярны).
        ///  <see cref="VectorRelation"/>
        /// </summary>
        /// <param name="v">Первый вектор</param>
        /// <param name="u">Второй вектор</param>
        /// <returns>Значение перечисления отношения между векторами</returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            var angle = v.GetAngleBetween(u);
            if (angle >= -Constants.epsilon && angle <= Constants.epsilon)
                return VectorRelation.Parallel;
            if (angle >= Math.PI / 2 - Constants.epsilon && angle <= Math.PI / 2 + Constants.epsilon)
                return VectorRelation.Orthogonal;
            return VectorRelation.General;
        }
    }
}
