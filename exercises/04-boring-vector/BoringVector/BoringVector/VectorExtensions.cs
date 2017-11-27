using System;

namespace BoringVector
{
    /// <summary>
    /// Виды отношения векторов
    /// </summary>
    enum VectorRelation
    {
        /// <summary>
        /// Общий случай
        /// </summary>
        General,
        /// <summary>
        /// Паралельны
        /// </summary>
        Parallel,
        /// <summary>
        /// Перпендикулярны
        /// </summary>
        Orthogonal
    }
    
    /// <summary>
    /// Класс-контейнер для методов, работающих с векторами
    /// </summary>
    internal static class VectorExtensions
    {
        /// <summary>
        /// Эпсилон для сравнения с нулем
        /// </summary>
        static double epsilon = 1e-6;

        /// <summary>
        /// Вспомогательный метод для сравнения числа с нулем
        /// </summary>
        /// <param name="val">Вещественное число</param>
        /// <returns>Является ли число близко к нулю</returns>
        private static bool IsZero(double val)
        {
            return Math.Abs(val) < epsilon;
        }

        /// <summary>
        /// Сравнивает длину вектора с нулем
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <returns>Является ли вектор нулевым</returns>
        public static bool IsZero(this Vector v)
        {
            return v.SquareLength() < epsilon;
        }

        /// <summary>
        /// Нормализация вектора
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <returns>Вектор с тем же направлением, но еденичной длины</returns>
        public static Vector Normalize(this Vector v)
        {
            double length = Math.Sqrt(v.SquareLength());
            return new Vector(v.X / length, v.Y / length);
        }

        /// <summary>
        /// Угол между векторами в радианах
        /// </summary>
        /// <param name="v">Первый вектор</param>
        /// <param name="u">Второй вектор</param>
        /// <returns>Угол в радианах</returns>
        public static double GetAngleBetween(this Vector v,  Vector u)
        {
            if (IsZero(v) || IsZero(u))
            {
                return 0.0;
            }
            else
            {
                return Math.Acos(v.DotProduct(u) / (v.Length() * u.Length()));
            }
        }

        /// <summary>
        /// Отношение между векторами
        /// </summary>
        /// <param name="v">Первый вектор</param>
        /// <param name="u">Второй вектор</param>
        /// <returns>Отношение между векторами</returns>
        public static VectorRelation GetRelation(this Vector v, Vector u)
        {
            double angleBetween = GetAngleBetween(v, u);
            if (IsZero(angleBetween))
            {
                return VectorRelation.Parallel;
            }
            else if (IsZero(angleBetween - Math.PI / 2))
            {
                return VectorRelation.Orthogonal;
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
