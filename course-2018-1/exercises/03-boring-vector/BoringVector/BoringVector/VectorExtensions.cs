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
        General,
        Parallel,
        Orthogonal
    }
    
    internal static class VectorExtension
    {
        /// <summary>
        /// Константа, отвечающая за точность вычислений
        /// </summary>
        private const double Eps = 1e-6;
        
        /// <summary>
        /// Проверяет, является ли вектор нулевыс
        /// </summary>
        /// <param name="v">Объект типа <see cref="Vector"/></param>
        /// <returns>Объект типа <see cref="Boolean"/></returns>
        public static bool IsZero(this Vector v)
        {
            return Math.Abs(v.x) < Eps && Math.Abs(v.y) < Eps;
        }
        
        /// <summary>
        /// Нормализует вектор
        /// </summary>
        /// <param name="v">Объект типа <see cref="Vector"/></param>
        /// <returns>Объект типа <see cref="Vector"/></returns>
        public static Vector Normalize(this Vector v)
        {
            return v.IsZero() ? v : v.Scale(Math.Sqrt(v.SquareLength()));
        }
        
        /// <summary>
        /// Вычисляет угор между векторами
        /// </summary>
        /// <param name="v">Объект типа <see cref="Vector"/></param>
        /// <param name="u">Объект типа <see cref="Vector"/></param>
        /// <returns>Объект типа <see cref="Double"/></returns>
        public static double GetAngleBetween(this Vector v, Vector u)
        {
            return v.DotProduct(u) / (Math.Sqrt(v.SquareLength()) * Math.Sqrt(u.SquareLength()));
        }
        
        /// <summary>
        /// Выясняет отношение двух векторов
        /// </summary>
        /// <param name="v">Объект типа <see cref="Vector"/></param>
        /// <param name="u">Объект типа <see cref="Vector"/></param>
        /// <returns>Объект типа <see cref="Relation"/></returns>
        public static Relation GetRelation(this Vector v, Vector u)
        {
            return Math.Abs(v.CrossProduct(u)) < Eps ? Relation.Parallel :
                Math.Abs(v.DotProduct(u)) < Eps ? Relation.Orthogonal : Relation.General;
        }
    }
}
