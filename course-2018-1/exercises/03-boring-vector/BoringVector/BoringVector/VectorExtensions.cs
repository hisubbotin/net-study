using System;
using System.Numerics;

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
    /// Класс содержаший расширяюшие методы для векторов
    /// </summary>
    internal static class VectorExtensions
    {
        /// <summary>
        /// Метод проверяет, что координаты вектора нулевые с точностью 1е-6
        /// </summary>
        /// <param name="vector"> вектор для проверки</param>
        /// <returns>bool является ли вектор нулевым</returns>
        public static bool IsZero(this Vector vector)
        {
            return (Math.Abs(vector.X) < 1e-6) && (Math.Abs(vector.Y) < 1e-6);
        }

        /// <summary>
        /// Приводит норму вектора к 1
        /// </summary>
        /// <param name="vector">вектор для нормализации</param>
        /// <returns>новый нормализованный вектор</returns>
        public static Vector Normalize(this Vector vector)
        {
            return vector / Math.Sqrt(vector.SquareLength());
        }

        /// <summary>
        /// получает угол между векторами
        /// </summary>
        /// <param name="vector1">первый вектор</param>
        /// <param name="vector2">второй вектор</param>
        /// <returns>угол в радианах</returns>
        public static double GetAngleBetween(this Vector vector1, Vector vector2)
        {
            if (vector1.IsZero() || vector2.IsZero())
            {
                return 0;
            }

            return Math.Acos(vector1.Normalize().DotProduct(vector2.Normalize()));
        }

        /// <summary>
        /// Возвращает взаимоположение векторов
        /// </summary>
        /// <param name="vector1">первый вектор</param>
        /// <param name="vector2">второй вектор</param>
        /// <returns>Элемент <see cref="Relation"/> </returns>
        public static Relation GetRelation(this Vector vector1, Vector vector2)
        {
            double scalar = Math.Abs(vector1.Normalize().DotProduct(vector2.Normalize()));
            if (scalar < 1e-6)
            {
                return Relation.Orthogonal;
            }
            return scalar > 1 - 1e-6 ? Relation.Parallel : Relation.General;
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
    }
}
