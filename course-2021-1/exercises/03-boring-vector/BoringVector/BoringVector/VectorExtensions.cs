using System;

namespace BoringVector
{
    enum VectorRelation
    {
        General,
        Parallel,
        Orthogonal
    }
    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты
            близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее
            берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах.
            Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления
            VectorRelation(General, Parallel, Orthogonal) - отношение между
            двумя векторами("общий случай", параллельны, перпендикулярны).
            Перечисление задавать тоже тебе)
    */
    internal class ExtendedVector : Vector
    {
        const double eps = 0.000001;
        public ExtendedVector(double x, double y) : base(x, y) {}
        public bool IsZero()
        {
            return Math.Abs(x) < eps && Math.Abs(y) < eps;
        }

        public ExtendedVector Normalize()
        {
            double len = Math.Sqrt(SquareLength());
            x /= len;
            y /= len;
            return this;
        }

        static public double GetAngleBetween(ExtendedVector v, ExtendedVector u)
        {
            if (v.IsZero() || u.IsZero()) {
                return 0;
            }
            return Math.Acos(v.Normalize().DotProduct(u.Normalize()));
        }
        static public VectorRelation GetRelation(ExtendedVector v, ExtendedVector u)
        {
            if (v.CrossProduct(u) == 0) {
                return VectorRelation.Parallel;
            } else if (v.DotProduct(u) == 0) {
                return VectorRelation.Orthogonal;
            }
            return VectorRelation.General;
        }
    }
}
