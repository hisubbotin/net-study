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
    /// Перечисление, хранящее возможные типы отношений между векторами: "общий случай", параллельны, перпендикулярны
    /// </summary>
   internal enum Relation
    {
       // общий случай
       General, 
       // параллельны
       Parallel, 
       // перпендикулярны
       Orthogonal     
    }

    /// <summary>
    /// класс, предоставляющий дополнительную функциональность для работы с векторами
    /// </summary>
    internal class BoringVector
    {
        // константа, задающая границу для сравнения чисел типа double: если числа отличаются меньше,
        // чем нак эту константу, то они считаются одинаковыми
        private const double Epsilon = 1e-6;
        
        /// <summary>
        /// Метод, проверяющий, является ли вектор нулевым, то есть лежат ли его координаты
        /// в Epsilon окрестности нуля
        /// </summary>
        /// <param name="v"> проверяемый вектор</param>
        /// <returns> true, если координаты вектора нулевые, false иначе </returns>
        public static bool IsZero(Vector v)
        {
            return Math.Abs(v.X) < Epsilon && Math.Abs(v.Y) < Epsilon;
        }

        /// <summary>
        /// Возвращает нормализованный вектор, то есть вектор, модуль которого равен единице
        /// </summary>
        /// <param name="v"> нормализуемый вектор </param>
        /// <returns> вектор, соноправленный с v и имеющиц единичный модуль </returns>
        public static Vector Normalize(Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Возвращает угол между двумя векторами
        /// Если один из векторов нулевой, то угол принимается равным нулю
        /// </summary>
        /// <param name="v"> первый вектор </param>
        /// <param name="u"> второй вектор </param>
        /// <returns> угол поворота от вектора u к вектору v против часовой стрелки </returns>
        public static double GetAngleBetween(Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u))
            {
                return 0;
            }
            return Math.Acos(Normalize(v).DotProduct(Normalize(u)));
        }

        /// <summary>
        /// Возвращает отношение между двумя векторами
        /// Векторы параллельны, если один из них нулевой или угол между ними лежит в Epsilon
        /// окрестности нуля. Векторы ортогональны, если их векторное произведение
        /// в двумерном пространстве лежит в Epsilon окрестности нуля. В остальных случаях
        /// возвращается "общий случай"
        /// </summary>
        /// <param name="v"> первый вектор </param>
        /// <param name="u"> второй вектор </param>
        /// <returns> отношение между векторами u и v </returns>
        public static Relation GetRelation(Vector v, Vector u)
        {
            if (IsZero(v) || IsZero(u))
            {
                return Relation.Parallel;
            }

            if (Math.Abs(v.DotProduct(u)) < Epsilon)
            {
                return Relation.Orthogonal;
            }

            return Math.Abs(v.CrossProduct(u)) < Epsilon ? Relation.Parallel : Relation.General;
        }
    }
}
