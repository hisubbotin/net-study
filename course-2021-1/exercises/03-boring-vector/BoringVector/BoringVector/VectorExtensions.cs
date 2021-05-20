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

    public static class VectorEx
    {
        internal static bool IsZero(Vector v)
        {
            return (Math.Abs(v.X) < 1e-6) && (Math.Abs(v.Y) < 1e-6);
        }

        internal static Vector Normalize(Vector v)
        {
            return v.Scale(1/Math.Sqrt(v.SquareLength()));
        }

        internal static double GetAngleBetween(Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u))
            {
                return 0;
            }

            return Math.Acos(Normalize(v).DotProduct(Normalize(u)));
        }
        
        internal enum VectorRelation
        {
            General, 
            Parallel, 
            Orthogonal
        }

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
