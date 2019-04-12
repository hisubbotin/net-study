using static System.Math;

namespace BoringVector
{
    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - отношение между 
            двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */

    internal class VectorWithExtensions
    {
        public enum Relation : short
        {
            General,
            Parallel,
            Orthogonal
        }

        public const double eps = 1e-8;

        public static bool IsZero(Vector vec)
        {
            return vec.SquareLength() < eps;
        }

        public static Vector Normalize(Vector vec)
        {
            return vec / Sqrt(vec.SquareLength());
        }

        public static double GetAngleBetween(Vector vec1, Vector vec2)
        {
            if (IsZero(vec1) || IsZero(vec2))
            {
                return 0.0;
            }

            return Acos(vec1.DotProduct(vec2) / (Sqrt(vec1.SquareLength()) * Sqrt(vec2.SquareLength())));
        }

        public static Relation GetRelation(Vector vec1, Vector vec2)
        {
            double angle = GetAngleBetween(vec1, vec2);
            if (Abs(angle) < eps || (angle - PI) < eps)
            {
                return Relation.Parallel;
            }
            else if ( Abs(angle - (PI/2)) < eps )
            {
                return Relation.Orthogonal;
            }
            else
            {
                return Relation.General;
            }
        }
    }


}
