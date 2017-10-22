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
        private const double DefaultPrecision = 1e-6;
        
        internal static bool IsZero(this Vector v, double precision = DefaultPrecision)
        {
            return Math.Abs(v.X) < precision && Math.Abs(v.Y) < precision;
        }
        
        internal static double Length(this Vector v)
        {
            return Math.Sqrt(v.SquareLength());
        }

        internal static Vector Normalize(this Vector v)
        {
            return v / v.Length();
        }

        internal static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || v.IsZero())
            {
                return 0;
            }
            return Math.Acos( v.DotProduct(u) / ( v.Length() * u.Length() ) );
        }

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
