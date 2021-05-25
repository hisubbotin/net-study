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
    /// Класс, расширяющий функциональность двумерного вектора <see cref="Vector"/>
    /// </summary>
    public static class VectorExtention
    {
        /// <summary>
        /// Проверяет, является ли вектор нулевым (с точностью до eps)
        /// </summary>
        /// <param name="v"> Вектор <see cref="Vector"/> </param>
        /// <returns> <see cref="double"/> Равен ли вектор нулевому </returns>
        internal static bool IsZero(Vector v)
        {
            return Math.Abs(v.X) < 1e-6 && Math.Abs(v.Y) < 1e-6;
        }

        /// <summary>
        /// Нормализует вектор (приводит к длине 1, если он ненулевой)
        /// </summary>
        /// <param name="v"> Вектор <see cref="Vector"/> </param>
        /// <returns> <see cref="double"/> v / |v| </returns>
        internal static Vector Normalize(Vector v)
        {
            return v.Scale(1/Math.Sqrt(v.SquareLength()));
        }

        /// <summary>
        /// Считает угол между v и u в радианах
        /// </summary>
        /// <param name="v"> Первый <see cref="Vector"/> вектор </param>
        /// <param name="u"> Второй <see cref="Vector"/> вектор </param>
        /// <returns> <see cref="double"/> Угол между v и u </returns>
        internal static double GetAngleBetween(Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u))
            {
                return 0;
            }
            else
            {
                return Math.Acos(Normalize(v).DotProduct(Normalize(u)));   
            }
        }

        /// <summary>
        /// Перечисление, определяющая взаимное расположение векторов в пространстве
        /// </summary>
        internal enum VectorRelation
        {
            General, 
            Parallel, 
            Orthogonal
        }

        /// <summary>
        /// Определяет взаимное расположение между векторами
        /// </summary>
        /// <param name="v"> Первый <see cref="Vector"/> вектор </param>
        /// <param name="u"> Второй <see cref="Vector"/> вектор </param>
        /// <returns> Взаимное расположение <see cref="VectorRelation"/> между v и u </returns>
        internal static VectorRelation GetRelation(Vector v, Vector u)
        {
            if (GetAngleBetween(u, v) == 0)
            {
                return VectorRelation.Parallel;
            }

            if (u.DotProduct(v) == 0)
            {
                return VectorRelation.Orthogonal;
            }

            return VectorRelation.General;
        }
    }
}
