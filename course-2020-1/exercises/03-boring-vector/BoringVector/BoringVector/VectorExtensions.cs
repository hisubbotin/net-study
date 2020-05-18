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
    
    enum Relation : int
    {
        General = 0,
        Parallel = 1,
        Orthogonal = 2
    }
    
    internal struct VectorExtension : Vector {
        internal VectorExtension(double x, double y) : base(x, y) { }

        /// <summary>
        /// Проверяет, является ли данный объект <see cref="Vector"/> близким к нулю с точночтью 1е-6.
        /// </summary>
        public bool IsZero()
        {
            return Math.Abs(X) < 1e-6 && Math.Abs(Y) < 1e-6;
            throw new NotImplementedException();
        }
        /// <summary>
        /// Нормализует объект <see cref="Vector"/> по длине.
        /// </summary>
        /// <returns>Вектор с направлением, идентичным данному, и длиной 1</returns>
        public VectorExtension Normalize()
        {
            return this / Math.Sqrt(this.SquareLength());
            throw new NotImplementedException();
        }
        /// <summary>
        /// Возвращает угол между двумя <see cref="Vector"/>.
        /// </summary>
        /// <param name="v"> <see cref="Vector"/>, угол с которым будет найден.</param>
        /// <returns>Угол между векторами в радианах от 0 до pi.</returns>
        public double GetAngleBetween(Vector v)
        {
            return Math.Acos(this.DotProduct(v) / Math.Sqrt(this.SquareLength() * tv.SquareLength()));
            throw new NotImplementedException();
        }
        /// <summary>
        /// Возвращает отношение между двумя <see cref="Vector"/>.
        /// </summary>
        /// <param name="v">Объект <see cref="Vector"/>, положение относительно которого данного вектора будет возвращено.</param>
        /// <returns>Отношение между двумя векторами: параллельны, ортогональны или общее положение</returns>
        public Relation GetRelation(Vector v)
        {
            if (this.GetAngleBetween(v) < 1e-6)
            {
                return Relation.Parallel;
            }
            if (this.GetAngleBetween(v) - Math.PI / 2.0 < 1e-6)
            {
                return Relation.Orthogonal;
            }

            return Relation.General;
            throw new NotImplementedException();
        }
    }
}
