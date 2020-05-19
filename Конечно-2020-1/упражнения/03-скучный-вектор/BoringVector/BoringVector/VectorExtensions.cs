using System;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("BoringVector.Test")]

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
    /// Задает тип отношений между двумя векторами
    /// </summary>
    public enum VectorRelation
    {
        General,    // общий
        Parallel,   // параллельный
        Orthogonal  // перпендикулярный
    }

    /// <summary>
    /// Класс с расширениями структуры Vector.
    /// </summary>
    internal class VectorExtensions
    {
        /// <summary>
        /// Проверяет, является ли вектор нулевым (операции с точностью <see cref="eps"/>)
        /// </summary>
        public static bool IsZero(Vector v)
        {
            return Math.Abs(v.SquareLength()) < Vector.eps;
        }

        /// <summary>
        /// Нормализует вектор.
        /// </summary>
        public static Vector Normalize(Vector v)
        {
            if (IsZero(v))
                return v;
            return v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// возвращает угол между двумя векторами в радианах в промежутке [0, \pi)
        /// </summary>
        public static double GetAngleBetween(Vector v, Vector u)
        {
            // v * u = |v| * |u| * cos((v x u))
            return Math.Acos(Normalize(v).DotProduct(Normalize(u)));
        }

        /// <summary>
        /// Возвращает значение перечесления <see cref="VectorRelation"/>.
        /// </summary>
        public static VectorRelation GetRelation(Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u))
            {
                return VectorRelation.General;
            }

            double alpha = GetAngleBetween(v, u);
            if (alpha < Vector.eps || alpha > Math.PI - Vector.eps)
            {
                return VectorRelation.Parallel;
            }
            if (alpha < Math.PI / 2 + Vector.eps && alpha > Math.PI / 2 - Vector.eps)
            {
                return VectorRelation.Orthogonal;
            }
            return VectorRelation.General;
        }
    }
}
