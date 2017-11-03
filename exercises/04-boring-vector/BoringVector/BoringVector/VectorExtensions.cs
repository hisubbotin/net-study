using System;

namespace BoringVector
{
    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты 
            близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах. 
            Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления VectorRelation(General, 
            Parallel, Orthogonal) - отношение между двумя векторами("общий случай", 
            параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */

    public enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    };

    internal static class VectorPlus {

        private static readonly double epsilon = 1e-6;

        public static bool IsZero (this Vector v)
        {
            return v.Length() < epsilon;
        }

        public static Vector Normalize(this Vector v)
        {
            return v / v.Length();
        }

        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u))
            {
                return 0;
            }
            else
            {
                return Math.Acos(v.DotProduct(u) / (v.Length() * u.Length()));
            }
        }

        public static VectorRelation GetRelation (this Vector v, Vector u)
        {
            if (v.DotProduct(u) < epsilon)
            {
                return VectorRelation.Orthogonal;
            }
            if (v.CrossProduct(u) < epsilon)
            {
                return VectorRelation.Parallel;
            }

            return VectorRelation.General;
        }

    }
}
