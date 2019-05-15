using static System.Math;

namespace BoringVector
{
    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - отношение между 
            двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */

    static class VectorWithExtensions
    {
        /// <summary>
        /// Перечисление положений векторов относительно друг друга
        /// </summary>
        public enum Relation : short
        {
            General,
            Parallel,
            Orthogonal
        }

        /// <summary>
        /// Точность вычислений
        /// </summary>
        public const double eps = 1e-8;

        /// <summary>
        /// Проверка на нулевой вектор
        /// </summary>
        /// <param name="vec"><see cref="Vector"/></param>
        /// <returns><see cref="bool"/></returns>
        public static bool IsZero(this Vector vec)
        {
            return vec.SquareLength() < eps;
        }

        /// <summary>
        /// Нормализация вектора
        /// </summary>
        /// <param name="vec"><see cref="Vector"/></param>
        /// <returns><see cref="Vector"/></returns>
        public static Vector Normalize(this Vector vec)
        {
            return vec / Sqrt(vec.SquareLength());
        }

        /// <summary>
        /// Угол между 2мя векторами
        /// </summary>
        /// <param name="vec1"><see cref="Vector"/></param>
        /// <param name="vec2"><see cref="Vector"/></param>
        /// <returns><see cref="double"/></returns>
        public static double GetAngleBetween(this Vector vec1, Vector vec2)
        {
            if (IsZero(vec1) || IsZero(vec2))
            {
                return 0.0;
            }

            return Acos(vec1.DotProduct(vec2) / (Sqrt(vec1.SquareLength()) * Sqrt(vec2.SquareLength())));
        }

        /// <summary>
        /// Отношение положения 2х векторов в пространстве
        /// </summary>
        /// <param name="vec1"><see cref="Vector"/></param>
        /// <param name="vec2"><see cref="Vector"/></param>
        /// <returns><see cref="VectorWithExtensions.Relation"/></returns>
        public static Relation GetRelation(this Vector vec1, Vector vec2)
        {
            double angle = GetAngleBetween(vec1, vec2);
            if (Abs(angle) < eps || (angle - PI) < eps)
            {
                return Relation.Parallel;
            }
            else if ( Abs(angle - (PI/2)) < eps )
            {
                return Relation.Orthogonal;
            }
            else
            {
                return Relation.General;
            }
        }
    }


}
