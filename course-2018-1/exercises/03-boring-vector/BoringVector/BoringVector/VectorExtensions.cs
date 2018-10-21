using System;
using System.Net;
using System.Security.Cryptography;

namespace BoringVector
{
    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */
    /// <summary>
    /// Класс-расширение для структуры Vector
    /// </summary>
    internal static class VectorExtention
    {
        /// <summary>
        /// Эпсилон - значение погрешности
        /// </summary>
        private static double epsilon = 1e-6;
        /// <summary>
        /// Перечисление отношений между двумя векторами
        /// </summary>
        private enum VectorRelation
        {
            General,
            Parallel,
            Orthogonal
        }
        
        /// <summary>
        /// Проверяет является ли векторнулевым
        /// </summary>
        /// <param name="v">вектор</param>
        /// <returns>True - если вектор нулевой в пределах погрешности, False - иначе</returns>
        public static bool IsZero(this Vector v)
        {
            return v.Lenght() < epsilon;
        }

        /// <summary>
        /// Нормализует вектор
        /// </summary>
        /// <param name="v">вектор</param>
        /// <returns>Нормализованный вектор</returns>
        public static Vector Normalize(this Vector v)
        {
            return v / v.Lenght();
        }

        /// <summary>
        /// Возвращает угол между двумя векторами
        /// </summary>
        /// <param name="v1">первый вектор</param>
        /// <param name="v2">второй вектор</param>
        /// <returns>Значение угла между двумя векторами в радианах</returns>
        public static double GetAngleBetween(this Vector v1, Vector v2)
        {
            
            return v1.IsZero() || v2.IsZero() ? 0 : Math.Acos(v1.DotProduct(v2) / v1.Lenght() / v2.Lenght());
        }

        /// <summary>
        /// Возвращает отношение двух векторов друг к другу
        /// </summary>
        /// <param name="v1">первый вектор</param>
        /// <param name="v2">второй вектор</param>
        /// <returns>2 - если векторы перпендикулярны, 1 - если параллельны, 0 - общий случай</returns>
        public static int GetRelation(this Vector v1, Vector v2)
        {
            if (v1.GetAngleBetween(v2) < epsilon)
            {
                return (int) VectorRelation.Parallel;
            }

            if (v1.GetAngleBetween(v2) - Math.PI < epsilon)
            {
                return (int) VectorRelation.Orthogonal;
            }

            return (int) VectorRelation.General;
        }
    }
}
