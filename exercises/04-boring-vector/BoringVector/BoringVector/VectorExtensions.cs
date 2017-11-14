namespace BoringVector
{
    using System;
    
    /// <summary>
    /// Виды взаиморасположения векторов: 
    /// пересекающиеся, 
    /// параллельные (сонаправленные или противоположнонаправленные), 
    /// перпендикулярные
    /// </summary>
    public enum VectorRelation
    {
        General,
        Parallel,
        Ortogonal
    }
    
    internal static class VectorExtentions
    {
        /// <summary>
        /// Погрешность по умолчанию для всех операций
        /// </summary>
        public const double Eps = 1e-6;

        /// <summary>
        /// Является ли вектор нулевым
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/>, который нужно сравнить с нулевым</param>
        /// <param name="eps">Погрешность сравнения, по умолчанию <see cref="Eps"/></param>
        /// <returns>Результат проверки на 0 с учетом погрешности</returns>
        internal static bool IsZero(Vector v, double eps = Eps)
        {
            return (Math.Abs(v.X) < eps) && (Math.Abs(v.Y) < eps);
        }

        /// <summary>
        /// Возвращает нормализованный вектор
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/>, который нужно нормировать</param>
        /// <returns>Объект <see cref="Vector"/>, после нормировки</returns>
        internal static Vector Normalize(Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Возвращает угол между векторами (от 0 до Math.PI)
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Возвращает угол между векторами в радианах</returns>
        internal static double GetAngleBetween(Vector v1, Vector v2)
        {
            if (IsZero(v1) || IsZero(v2))
            {
                return 0;
            }
            double cos = v1.DotProduct(v2) / Math.Sqrt(v1.SquareLength() * v2.SquareLength());
            return Math.Acos(cos);
        }

        /// <summary>
        /// Возвращает взаимное расположение векторов
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Объект перечисления <see cref="VectorRelation"/>, соответствующий взаиморасположению векторов</returns>
        internal static VectorRelation GetRelation(Vector v1, Vector v2)
        {
            if (v1.DotProduct(v2) < Eps)
            {
                return VectorRelation.Ortogonal;
            }
            if ((GetAngleBetween(v1, v2) < Eps) || (Math.PI - GetAngleBetween(v1, v2) < Eps))
            {
                return VectorRelation.Parallel;
            }
            return VectorRelation.General;
        }
    }
}
