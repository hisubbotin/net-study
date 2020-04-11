using System;
namespace BoringVector
{

    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). 
            За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах.
            Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) -
            отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */

    internal static class VectorExtension
    {
        private const double epsilon = 1e-6;
        /// <summary>
        /// Проверка, является ли вектор нулевым
        /// </summary>
        /// <param name="v">Вектор типа <see cref="Vector"/> </param>
        public static bool IsZero(this Vector v)
        {
            return (v.X < epsilon && v.Y < epsilon);

        }
        /// <summary>
        /// Нормировка вектора
        /// </summary>
        /// <param name="v">Вектор типа <see cref="Vector"/> </param>
        public static Vector Normalize(this Vector v)
        {
            if (v.IsZero())
            {
                return v;
            }
            else return v / (Math.Sqrt(v.SquareLength()));
        }
        /// <summary>
        /// Угл между двумя векторами в радинах
        /// </summary>
        /// <param name="v">Вектор типа <see cref="Vector"/> </param>
        /// <param name="v">Вектор типа <see cref="Vector"/> </param>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0;
            }
            double cos_alpha = v.DotProduct(u) / Math.Sqrt((v.SquareLength() * u.SquareLength()));
            return Math.Acos(cos_alpha);
        }
        internal enum VectorRelation
        {
            General,
            Parallel,
            Orthogonal
        }
        /// <summary>
        /// Отношение между векторами
        /// </summary>
        /// <param name="v">Вектор типа <see cref="Vector"/> </param>
        /// <param name="v">Вектор типа <see cref="Vector"/> </param>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return VectorRelation.Parallel;
            }
            else if (Math.Abs(v.DotProduct(u)) < epsilon)
            {
                return VectorRelation.Orthogonal;
            }
            else if (Math.Abs(v.GetAngleBetween(u)) < epsilon || Math.Abs(v.GetAngleBetween(u) - 180) < epsilon)
            {
                return VectorRelation.Parallel;
            }
            else return VectorRelation.General;
        }
  
    }
  
}
