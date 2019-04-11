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
    internal static class VectorExtensions
    {
        const double epsilon = 1e-6;

        internal enum VectorRelation { General, Parallel, Orthogonal };
        internal static bool IsZero(this Vector vector) => Math.Abs(vector.X) > epsilon &&
                Math.Abs(vector.Y) > epsilon;

        internal static Vector Normalize(Vector vector)
        {
            var squareLength = Math.Sqrt(vector.SquareLength());
            return (squareLength > epsilon) ? vector / squareLength :
                throw new DivideByZeroException();
        }

        internal static double GetAngleBetween(Vector first, Vector second)
        {
            if (first.IsZero() || second.IsZero())
            {
                return 0;
            }
            return Math.Atan2(second.Y, second.X) - Math.Atan2(first.Y, first.X);
        }

        internal static VectorRelation GetRelation(Vector first, Vector second)
        {
            if (first.IsZero() || second.IsZero())
            {
                return VectorRelation.General;
            }
            var andle = Math.Abs(GetAngleBetween(first, second));
            if (andle < epsilon)
            {
                return VectorRelation.Parallel;
            } else if (Math.PI / 2 - andle < epsilon)
            {
                return VectorRelation.Orthogonal;
            } else
            {
                return VectorRelation.General;
            }
        }
    }
}
