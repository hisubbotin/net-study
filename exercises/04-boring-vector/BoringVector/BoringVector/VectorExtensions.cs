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

    public enum VectorRelation
    {
        General, 
        Parallel, 
        Orthogonal
    }

    internal static class VectorExtentions
    {
        /// <summary>
        /// Определяет допустимую разность между двумя вещественными числами, которые считаются равными.
        /// </summary>
        private const double DefaultPrecision = 1e-6;
        
        /// <summary>
        /// Проверяет, что вектор <see cref="v"/> является вектором (0, 0).
        /// </summary>
        /// <param name="v">Проверяемый вектор.</param>
        /// <param name="precision">Допустимую разность между двумя вещественными числами, которые считаются равными.</param>
        /// <returns></returns>
        internal static bool IsZero(this Vector v, double precision = DefaultPrecision)
        {
            return Math.Abs(v.X) < precision && Math.Abs(v.Y) < precision;
        }
        
        /// <summary>
        /// Кто бы мог подумать, возвращает длину вектора <see cref="v"/>.
        /// </summary>
        internal static double Length(this Vector v)
        {
            return Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Возвращает нормализованный вектор <see cref="v"/>
        /// </summary>
        internal static Vector Normalize(this Vector v)
        {
            return v / v.Length();
        }

        /// <summary>
        /// Возвращает угол между векторами <see cref="v"/> и <see cref="u"/>.
        /// </summary>
        internal static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0;
            }
            return Math.Acos( v.DotProduct(u) / ( v.Length() * u.Length() ) );
        }

        /// <summary>
        /// Проверяет как взаимно расположены векторы <see cref="v"/> и <see cref="u"/>.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="u"></param>
        /// <param name="precision">Допустимую разность между двумя вещественными числами, которые считаются равными.</param>
        /// <returns><see cref="VectorRelation"/> описывающий взаимное расположение</returns>
        internal static VectorRelation GetRelation(this Vector v, Vector u, double precision = DefaultPrecision)
        {
            if (Math.Abs(v.DotProduct(u)) < precision)
            {
                return VectorRelation.Orthogonal;
            }
            
            if ( Math.Abs( v.GetAngleBetween(u) ) < precision )
            {
                return VectorRelation.Parallel;
            }
            return VectorRelation.General;
        }
    }
}
