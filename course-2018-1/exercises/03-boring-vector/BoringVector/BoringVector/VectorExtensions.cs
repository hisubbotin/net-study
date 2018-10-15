using System;

namespace BoringVector
{
    internal static class VectorExtensions
    {
        /*
            Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
                - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
                - Normalize: нормализует вектор
                - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
                - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
        */
        
        private const double Epsilon = 1e-6;

        internal enum VectorRelation
        {
            General,
            Parallel,
            Orthogonal
        }
        
        public static bool IsZero(this Vector v)
        {
            return Math.Abs(v.X) < Epsilon && Math.Abs(v.Y) < Epsilon;
        }
        
        public static Vector Normalize(this Vector v) {
            if (v.IsZero())
            {
                return (v);
            }
            return v / Math.Sqrt(v.SquareLength());
        }
        
        public static double GetAngleBetween(this Vector u, Vector v) {
            if (u.IsZero() || v.IsZero())
            {
                return 0;
            }
            var uLength = Math.Sqrt(u.SquareLength());
            var vLength = Math.Sqrt(v.SquareLength());
            return Math.Acos(u.DotProduct(v) / (uLength * vLength));
        }
        
        public static VectorRelation GetRelation(this Vector u, Vector v)
        {
            if (u.IsZero() || v.IsZero()) {
                return VectorRelation.Parallel;
            }
            if (Math.Abs(v.DotProduct(u)) < Epsilon)
            {
                return VectorRelation.Orthogonal;
            }
            if (Math.Abs(v.GetAngleBetween(u)) < Epsilon)
            {
                return VectorRelation.Parallel;
            }
            return VectorRelation.General;
        }
    }
}
