using System;

namespace BoringVector
{
    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). 
            За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - 
            отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */
    /// <summary>
    /// Класс, расширяющий функционал стандартного <see cref="BoringVector.Vector"/> некоторыми полезными функциями.
    /// </summary>
    internal class ExtendedVector:BoringVector.Vector
    {
        /// <summary>
        /// Точность, с которой проверяется равенство нулю координат.
        /// </summary>
        private const double Eps = 1e-6;
        /// <summary>
        /// Возможные взаимоотношения между векторами: параллельны, перпендикулярны, нет определённого отношения.
        /// </summary>
        public enum VectorsRelation
        {
            Parallel,
            Orthogonal,
            General,
        }
        
        internal ExtendedVector(double X, double Y) : base(X, Y) {}
        
        /// <summary>
        /// Проверяет, является ли вектор нулевым.
        /// </summary>
        /// <returns>True, если является, False иначе.</returns>
        internal bool IsZero()
        {
            return (Math.Abs(X) < Eps & Math.Abs(Y) < Eps);
        }

        /// <summary>
        /// Нормализует вектор, вычитая среднее и деля на дисперсию.
        /// </summary>
        /// <returns>Новый <see cref="BoringVector.Vector"/> с преобразованными координатами. </returns>
        internal Vector Normilize()
        {
            double mean = (X + Y) / 2;
            double std = Math.Sqrt((X - mean) * (X - mean) + (Y - mean) * (Y - mean));

            if (std < Eps)
            {
                std = Eps;
            }

            return new Vector((X - mean) / std, (Y - mean) / std);
        }
        
        /// <summary>
        /// Считает угол между векторами.
        /// </summary>
        /// <param name="v"> Объект класса <see cref="BoringVector.Vector"/>, угол с которым надо посчитать.</param>
        /// <returns>Угол между веткорами.</returns>
        internal double GetAngleBetween(ExtendedVector v)
        {
            if (IsZero() | v.IsZero())
            {
                return 0;
            }

            return DotProduct(v) / Math.Sqrt(SquareLength() * v.SquareLength());
        }

        /// <summary>
        /// Определяет, являются ли векторы перпендикулярными, параллельными, или нет.
        /// </summary>
        /// <param name="v">Объект класса <see cref="BoringVector.Vector"/>, с которым нужно установить отношение.</param>
        /// <returns>Одно из трёх значений в <see cref="BoringVector.ExtendedVector.VectorsRelation"/>.</returns>
        internal VectorsRelation GetRelation(Vector v)
        {
            if (Math.Abs(CrossProduct(v)) < Eps)
            {
                return VectorsRelation.Parallel;
            }

            if (Math.Abs(DotProduct(v)) < Eps)
            {
                return VectorsRelation.Orthogonal;
            }

            return VectorsRelation.General;
        }
    }
}
