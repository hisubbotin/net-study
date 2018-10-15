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
    public enum Relation



    {
        GeneralCase,
        Parallel,
        Orthogonal
    }

    public class VectorExtensions 
    {

        static private readonly double EPSILON = 1e-6;

        public static bool IsZero(Vector v)
        {
            return (v.x < EPSILON) && (v.y < EPSILON);
        }

        public static Vector Normalize(Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

        public static double GetAngleBetween(Vector u, Vector v)
        {
            return Math.Atan2(u.CrossProduct(v), u.DotProduct(v));
        }

        public static Relation GetRelation(Vector u, Vector v)
        {
            if (Math.Abs(Math.Abs(GetAngleBetween(u, v)) - Math.PI / 2) < EPSILON)
            {
                return Relation.Orthogonal;
            }
            else if ((Math.Abs(Math.Abs(GetAngleBetween(u, v)) - Math.PI) < EPSILON)
              || (Math.Abs(Math.Abs(GetAngleBetween(u, v))) < EPSILON))
            {
                return Relation.Parallel;
            }
            else return Relation.GeneralCase;
        }
    }
}
