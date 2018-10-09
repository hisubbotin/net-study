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
        public static bool IsZero(this Vector vec)
        {
            double eps = 1e-6;
            return Math.Abs(vec.x) < eps && Math.Abs(vec.y) < eps ? true : false;
        }

        public static void Normalize(this Vector vec)
        {
            vec  /= Math.Sqrt(vec.SquareLength());
        }

        public static double GetAngleBetween(this Vector vec)
        {
            
        }

        public static VectorRelation GetRelation(this Vector vec, Vector comparisonVector )
        {
            return 
        }
    }
}

