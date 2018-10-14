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
    /// Класс, расширяющий структуру <see cref="Vector"/>.
    /// </summary>
    internal static class VectorExtension
    {
        public static double epsilon = 10e-6;

        /// <summary>
        /// Проверяет, является ли вектор нулевым вектором.
        /// </summary>
        /// <returns>Тип <see cref="bool"/>, результат проверки.</returns>
        public static bool IsZero(this Vector v)
        {
            return Math.Abs(v._x) < epsilon && Math.Abs(v._y) < epsilon;
        }

        /// <summary>
        /// Нормализует вектор (возвращает сонаправленный вектор длины 1). Создает новый объект типа <see cref="Vector"/>. При нулевом векторе возвращает его же.
        /// </summary>
        /// <returns>Тип <see cref="Vector"/>, результат нормализации вектора.</returns>
        public static Vector Normalize(this Vector v)
        {
            if (v.IsZero())
            {
                return new Vector(0, 0);
            }
            return v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Возвращает угол в радианах между векторами. Если хотя бы один из векторов нулевой, возвращается 0 (т.е. нулевой вектор считается сонаправленным с любым).
        /// </summary>
        /// <param name="v">Тип <see cref="Vector"/></param>\
        /// <returns>Тип <see cref="double"/>, угол между векторами.</returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0;
            }
            return Math.Acos(v.DotProduct(u) / Math.Sqrt(v.SquareLength()) / Math.Sqrt(u.SquareLength()));
        }

        /// <summary>
        /// Описывает отношения между векторами.
        /// </summary>
        public enum VectorRelation
        {
            /// <summary>
            /// Общий случай отношений.
            /// </summary>
            General,
            /// <summary>
            /// Вектора параллельны.
            /// </summary>
            Parallel,
            /// <summary>
            /// Вектора ортогональны.
            /// </summary>
            Orthogonal
        }

        /// <summary>
        /// Возвращает отношение между векторами (вектора параллельны, перпендикулярны или ни то, ни другое). Описания отношений лежат в <see cref="VectorRelation"/>.
        /// </summary>
        /// <param name="u">Тип <see cref="Vector"/></param>\
        /// <returns>Тип <see cref="VectorRelation"/>, описывающий отношения.</returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (Math.Abs(v.DotProduct(u)) < epsilon)
            {
                return VectorRelation.Orthogonal;
            }
            else if (Math.Abs(v.CrossProduct(u)) < epsilon)
            {
                return VectorRelation.Parallel;
            }
            else
            {
                return VectorRelation.General;
            }
        }
    }
}