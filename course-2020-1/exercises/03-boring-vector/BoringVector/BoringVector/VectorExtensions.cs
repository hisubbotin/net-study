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
    ///<summary>
        /// Создадим enum для метода GetRelation
    ///</summary>
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
            if (v1.IsZero() || v2.IsZero()) {
                return 0;
            }
            if (Equals(v1.Normalize(), v2.Normalize())) {
                return 0;
            }
            return Math.Acos(v1.DotProduct(v2))/(v1.SquareLength()*v2.SquareLength());
        }

        public static VectorRelation GetRelation(this Vector v1, Vector v2)
        {
            const double EPSILON = 0.000001;
            if (v1.GetAngleBetween(v2) >= -EPSILON && v1.GetAngleBetween(v2) <= EPSILON){
                return VectorRelation.Parallel;
            }
            if (v1.DotProduct(v2) >= -EPSILON && v1.DotProduct(v2) <= EPSILON){
                return VectorRelation.Orthogonal;
            }
            return VectorRelation.General;
        }


    } 
}
