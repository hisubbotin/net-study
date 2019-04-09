namespace BoringVector
{
    using static System.Math;
    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */

    /// <summary>
    /// Класс, расширяющий функционал класса <see cref="Vector"/>
    /// </summary>
    class VectorExtensions
    {
        /// <summary>
        /// Точность, используемая при работе с <see cref="Vector"/>
        /// </summary>
        public const double EPS = 1e-6;

        /// <summary>
        /// Enum, отражающий взаимное расположение между двумя экземплярами класса
        /// <see cref="Vector"/>
        /// </summary>
        public enum VectorRelation: byte
        {
            General,
            Parallel,
            Orthogonal
        }

        /// <summary>
        /// Проверка вектора на равенство нулевому
        /// </summary>
        /// <param name="v">Вектор</param>
        /// <returns>true, в случае, если норма v меньше <see cref="EPS"/> </returns>
        public static bool IsZero(Vector v)
        {
            return v.SquareLength() < EPS * EPS;
        }

        /// <summary>
        /// Нормализация вектора
        /// </summary>
        /// <param name="v">Нормализуемый вектор</param>
        /// <returns><see cref="Vector"/>, сонаравленный v, имеющий длину 1 </returns>
        /// <remarks>Возможен выброс исключения в случае нулевого вектора</remarks>
        public static Vector Normalize(Vector v)
        {
            return v / Sqrt(v.SquareLength());
        }

        /// <summary>
        /// Взятие угла между двумя векторами в радианах
        /// </summary>
        /// <param name="v1">Первый вектор</param>
        /// <param name="v2">Второй вектор</param>
        /// <returns>Угол между двумя векторами, выраженный в радианах</returns>
        /// <remarks>Угол между нуль-вектором и любым другим полагаем равным 0</remarks>
        public static double GetAngleBetween(Vector v1, Vector v2)
        {
            if (IsZero(v1) || IsZero(v2))
            {
                return 0.0;
            }

            return Acos(Normalize(v1).DotProduct(Normalize(v2)));
        }

        /// <summary>
        /// Определение взаимного распложения между двумя векторами (см. <see cref="VectorRelation"/>) 
        /// </summary>
        /// <param name="v1">Первый вектор</param>
        /// <param name="v2">Второй вектор</param>
        /// <returns><see cref="VectorRelation"/> для двух данных векторов</returns>
        /// <remarks>Нуль-вектор полагаем параллельным любому другому</remarks>
        public static VectorRelation GetRelation(Vector v1, Vector v2)
        {
            double angle = GetAngleBetween(v1, v2);

            if (angle < EPS || angle > PI - EPS)
            {
                return VectorRelation.Parallel;
            }
            if (Abs(angle - PI / 2) < EPS)
            {
                return VectorRelation.Orthogonal;
            }
            return VectorRelation.General;
        }
    }
}
