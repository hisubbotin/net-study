namespace BoringVector
{
    using static System.Math;
    class VectorExtensions {
     /// <summary>
     /// Задаем точность.
     /// </summary>


    public const double EPS = 1e-6;
    /// <summary>
    /// Проверяет нулевость.
    /// </summary>
    public static bool IsZero(this Vector v)
        {
            return v.SquareLength() < EPS;
        }
    /// <summary>
    /// Нормализация.
    /// </summary>
    public static Vector Normalize(this Vector v)
        {
            return v / Sqrt(v.SquareLength());
        }
    /// <summary>
    /// Подсчёт угла.
    /// </summary>
    public static double GetAngleBetween(this Vector v1, Vector v2)
        {
            if (IsZero(v1) || IsZero(v2))
            {
                return 0.0;
            }
            return Acos(Normalize(v2).DotProduct(Normalize(v1)));
        }
    /// <summary>
    /// Типы соотношений.
    /// </summary>
    public enum VectorRelation : byte
        {
            Parallel,
            Orthogonal,
            General
        }

        public static VectorRelation GetRelation(this Vector v1, Vector v2)
        {
            double alpha = GetAngleBetween(v1, v2);
            if (Abs(alpha - PI / 2) < EPS)
            {
                return VectorRelation.Orthogonal;
            }
            else if (alpha < EPS || alpha > PI - EPS)
            {
                return VectorRelation.Parallel;
            }
            else
            {
                return VectorRelation.General;
            }
               
                    
            }
        }
      /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */
}