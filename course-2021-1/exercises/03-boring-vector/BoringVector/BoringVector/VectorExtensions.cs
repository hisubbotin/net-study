using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BoringVector
{
    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */

    internal enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    };
    
    internal static class VectorExtensions
    {
        public static bool IsZero(this Vector v)
        {
            return v.X == 0 && v.Y == 0;
        }

        public static Vector Normalize(this Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

        public static double GetAngleBetween(this Vector v, Vector u)
        {
            return Math.Acos(v.DotProduct(u) / (Math.Sqrt(v.SquareLength()) * Math.Sqrt(u.SquareLength())));
        }

        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            switch (GetAngleBetween(v, u))
            {
                case 0:
                case Math.PI:
                    return VectorRelation.Parallel;
                case Math.PI / 2:
                    return VectorRelation.Orthogonal;
                default:
                    return VectorRelation.General;
            }
        }
    }
}
