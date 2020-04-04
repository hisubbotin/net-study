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
    enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    }
    internal static class VectorExtension
    {
        public static bool IsZero(this Vector v)
        {
            return Equals(v, -v);
        }
        public static Vector Normalize(this Vector v)
        {
            return v / v.SquareLength();
        }

        public static double GetAngleBetween(this Vector v1, Vector v2)
        {
            if (v1.IsZero() || v2.IsZero()) // один из векторов равен 0
                return 0;
            if (Equals(v1.Normalize(), v2.Normalize())) // вектора сонаправлены
                return 0;
            return Math.Acos(v1.DotProduct(v2))/(v1.SquareLength()*v2.SquareLength());
        }

        public static VectorRelation GetRelation(this Vector v1, Vector v2)
        {
            const double EPSILON = 0.00001;
            double angle = v1.GetAngleBetween(v2);
            if (angle >= -EPSILON && angle <= EPSILON)
                return VectorRelation.Parallel;
            double dot_product = v1.DotProduct(v2);
            if (dot_product >= -EPSILON && dot_product <= EPSILON)
                return VectorRelation.Orthogonal;
            return VectorRelation.General;
        }
        
        
    } 
 
}
