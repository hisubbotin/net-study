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
    internal static class VectorExt
    {
        internal const double eps = Vector.eps;

        /// <summary>
        /// Перечисление представляет возможные способы взаимного расположения векторов
        /// </summary>
        internal enum VectorRelation { General, Parallel, Orthogonal }

        /// <summary>
        /// Возвращает объект типа <see cref="bool"/> - результат проверки на равенство объекта типа <see cref="Vector"/> нулевому вектору
        /// </summary>
        /// <param name="v">Объект типа <see cref="Vector"/></param>
        /// <returns>Объект типа <see cref="bool"/></returns>
        public static bool IsZero(this Vector v)
        {
            return v.SquareLength() < eps * eps;
        }

        /// <summary>
        /// Возвращает объект типа <see cref="Vector"/> - нормализованную версию исходного ненулевого вектора.
        /// </summary>
        /// <param name="v">Объект типа <see cref="Vector"/></param>
        /// <returns>Объект типа <see cref="Vector"/></returns>
        public static Vector Normalize(this Vector v)
        {
            if( !v.IsZero() )
            {
                return v / Math.Sqrt(v.SquareLength());
            } else {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Возвращает объект типа <see cref="double"/> - угол между входными векторами u и v.
        /// Считается, что нулевой вектор параллелен любому другому.
        /// </summary>
        /// <param name="u">Объект типа <see cref="Vector"/></param>
        /// <param name="v">Объект типа <see cref="Vector"/></param>
        /// <returns>Объект типа <see cref="double"/></returns>
        public static double GetAngleBetween(this Vector u, Vector v)
        {
            if( u.IsZero() || v.IsZero() ) {
                return 0.0;
            } else {
                Vector uNorm = u.Normalize();
                Vector vNorm = v.Normalize();
                double cosBetweenUV = u.DotProduct(v);
                double sinBetweenUV = u.CrossProduct(v);
                return Math.Atan2(cosBetweenUV, sinBetweenUV);
            }
            
        }

        /// <summary>
        /// Возвращает объект типа <see cref="VectorRelation"/> - тип взаимного расположения векторов u и v
        /// </summary>
        /// <param name="u">Объект типа <see cref="Vector"/></param>
        /// <param name="v">Объект типа <see cref="Vector"/></param>
        /// <returns>Объект типа <see cref="VectorRelation"/> - тип взаимного расположения векторов u и v</returns>
        public static VectorRelation GetRelation(this Vector u, Vector v)
        {
            double absAngle = Math.Abs(u.GetAngleBetween(v));
            if( absAngle < eps ) {
                return VectorRelation.Parallel;
            } else if( Math.Abs(absAngle - Math.PI / 2) < eps ) {
                return VectorRelation.Orthogonal;
            } else {
                return VectorRelation.General;
            }
        }
    }
}
