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
    /// Отношение между двумя векторами("общий случай", параллельны, перпендикулярны).
    /// </summary>
    public enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    }

    /// <summary>
    /// Класс с методами-расширениями структуры Vector.
    /// </summary>
    internal static class VectorExtensions
    {
        /// <summary>
        /// Проверяет, является ли вектор нулевым.
        /// </summary>
        public static bool IsZero(this Vector v) => v.SquareLength() < Vector.eps;

        /// <summary>
        /// Нормализует вектор.
        /// </summary>
        public static Vector Normalize(this Vector v)
        {
            if (IsZero(v))
            {
                throw new DivideByZeroException();
            } 
            return v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Находит угол в радианах от 0 до пи между векторами.
        /// </summary>
        // v * u = |v|*|u|*cos(v^u)
        public static double GetAngleBetween(this Vector v, Vector u) => Math.Acos(Normalize(v).DotProduct(Normalize(u)));

        /// <summary>
        /// Возвращает значение перечесления <see cref="VectorRelation"/>.
        /// </summary>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u))
            {
                return VectorRelation.Parallel;
            }

            double angle = GetAngleBetween(v, u);
            if (double.IsNaN(angle))    // Такого точно не может быть, но на всякий случай
            {
                throw new InvalidOperationException();
            }
            if (angle < Vector.eps || angle > Math.PI - Vector.eps)
            {
                return VectorRelation.Parallel;
            }
            if (angle < Math.PI / 2 + Vector.eps && angle > Math.PI / 2 - Vector.eps)
            {
                return VectorRelation.Orthogonal;
            }
            return VectorRelation.General;
        }
    }
}
