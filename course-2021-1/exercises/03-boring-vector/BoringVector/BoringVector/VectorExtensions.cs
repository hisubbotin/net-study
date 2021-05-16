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

    internal class VectorExtensions
    {
        public bool IsZero(Vector vec)
        {
            const double epsilon = 1e-6;
            return Math.Abs(vec.GetX()) < epsilon && Math.Abs(vec.GetY()) < epsilon;
        }
        
        public Vector Normalize(Vector vec) 
        {
            return vec / Math.Sqrt(vec.SquareLength());
        }
        
        public double GetAngleBetween(Vector first, Vector second) 
        {
            if (IsZero(first) || IsZero(second)) 
            {
                return 0;
            }
            return Math.Abs(Math.Acos(Normalize(first).DotProduct(Normalize(second))));
        }
        public enum VectorRelation
        {
            General,
            Parallel,
            Orthogonal,
        }

        public VectorRelation GetRelation(Vector first, Vector second)
        {
            if (first.DotProduct(second) == 0) 
            {
                return VectorRelation.Orthogonal;
            }
            
            return first.CrossProduct(second) == 0 ? VectorRelation.Parallel : VectorRelation.General;
        }
    }
}