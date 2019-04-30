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

    /// <summary>
    /// Расширение функционала класса <see cref="Vector"/>
    /// </summary>
    internal static class VectorExtensions
    {
        
        /// <summary>
        /// Точность при работе с <see cref="Vector"/>
        /// </summary>
        public static double EPS = 1e-6;
        
        
        /// <summary>
        /// Расположение между собой двух экземпляров <see cref="Vector"/>
        /// </summary>
        public enum VectorRelation: byte
        {
            General,
            Parallel,
            Orthogonal
        }
        
        /// <summary>
        /// Проверка вектора на 0
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <returns>true, если норма вектора v меньше <see cref="EPS"/> </returns>
        public static bool IsZero(this Vector v)
        {
            return v.SquareLength() < EPS;
        }
        
        /// <summary>
        /// Нормализация
        /// </summary>
        /// <param name="v">Нормализуемый вектор</param>
        /// <returns>Возвращает <see cref="Vector"/>, сонаравленный v длины 1 </returns>
        public static Vector Normalize(this Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }
        
        /// <summary>
        /// Взятие угла между векторами
        /// </summary>
        /// <param name="a">Первый вектор</param>
        /// <param name="b">Второй вектор</param>
        /// <returns>Угол между двумя векторами; 0, если длина одного из них 0</returns>
        public static double GetAngleBetween(this Vector a, Vector b)
        {
            if (IsZero(a) || IsZero(b))
            {
                return 0;
            }
            
            return Math.Acos(Normalize(a).DotProduct(Normalize(b)));
        }
        
        /// <summary>
        /// Взаимное распложение между двумя векторами (Варианты: <see cref="VectorRelation"/>) 
        /// </summary>
        /// <param name="a">Первый вектор</param>
        /// <param name="b">Второй вектор</param>
        /// <returns><see cref="VectorRelation"/> для двух данных векторов</returns>
        public static VectorRelation GetRelation(this Vector a, Vector b)
        {
            double dot = Normalize(a).DotProduct(Normalize(b));
     
            if (dot < EPS)
            {
                return VectorRelation.Orthogonal;
            }
            if (Math.Abs(dot) > 1 - EPS)
            {
                return VectorRelation.Parallel;
            }
            
            return VectorRelation.General;
        }
    }
}
