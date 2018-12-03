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
    internal static class VectorExtensions
    {
        /// <summary>
        /// Указывает точность вычислений.
        /// </summary>
        public static double EPS = 1e-6;

        /// <summary>
        /// Проверяет, является ли вектор нулевым.
        /// </summary>
        /// <returns><c>true</c>, если его кооридинаты близки к нулю, <c>false</c> в остальных случаях.</returns>
        /// <param name="v">Принимаемый вектор.</param>
        public static bool IsZero(this Vector v)
        {
            return (Math.Abs(v.X) <= EPS && Math.Abs(v.Y) <= EPS);
        }

        /// <summary>
        /// Вычисляет нормализованную копию исходного вектора.
        /// </summary>
        /// <returns>Нормализованный вектор.</returns>
        /// <param name="v">Принимаемый вектор.</param>
        public static Vector Normalize(this Vector v)
        {
            if (v.IsZero())
            {
                throw new DivideByZeroException();
            }
            return v.Scale(1 / Math.Sqrt(v.SquareLength()));
        }

        /// <summary>
        /// Вычисляет величину угла между двумя углами.
        /// </summary>
        /// <returns>Величина угла в радианах.</returns>
        /// <param name="v">Первый вектор.</param>
        /// <param name="u">Второй вектор.</param>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0.0;
            }
            else
            {
                Vector vNormal = v.Normalize();
                Vector uNormal = u.Normalize();
                return Math.Acos(vNormal.DotProduct(uNormal));
            }
        }



        /// <summary>
        /// Проверяет положения двух векторов относительно друг друга. 
        /// </summary>
        /// <returns>Элемент перечисления VectorRelation.</returns>
        /// <param name="v">Первый вектор.</param>
        /// <param name="u">Второй вектор.</param>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            double angle = v.GetAngleBetween(u);
            if (Math.Abs(angle) <= EPS)
            {
                return VectorRelation.Parallel;
            }
            else
            {
                if (Math.Abs(Math.Abs(angle) - Math.PI / 2) <= EPS)
                {
                    return VectorRelation.Ortogonal;
                }
                else
                {
                    return VectorRelation.General;
                }
            }
        }
    }

    /// <summary>
    /// Перечисление с возможными положениями двух векторов относительно друг друга.
    /// </summary>
    internal enum VectorRelation
    {
        General = 0,
        Parallel = 1,
        Ortogonal = 2
    }
}