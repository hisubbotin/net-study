using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace BoringVector
{
    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */

    public static class VectorNextGen
    {
        private static double eps = 1e-6;
        public static bool isZero(this Vector v)
        {
            return Math.Sqrt(v.SquareLength()) < eps;
        }

        public static Vector Nornalize(this Vector v)
        {
            if (v.isZero()) { throw new ArgumentException("===== Can't normalize 0 vector====="); }

            return v / Math.Sqrt(v.SquareLength());
        }

        
        private static double CosDist(this Vector v1, Vector v2)
        {
            return v1.Nornalize().DotProduct(v2.Nornalize());
        }

        public static double Angle(this Vector v1, Vector v2)
        {
            if (v1.isZero() || v2.isZero()) { return 0; }

            return Math.Acos(v1.CosDist(v2));
        }

        public static double Positioning(this Vector v1, Vector v2)
        {
            double cosDist = Math.Abs(v1.CosDist(v2));
            if (cosDist < eps)
            {
                return 0;
            }

            if (cosDist >= 1.0 - eps)
            {
                return 1;
            }

            return cosDist;
        }
    }
}
