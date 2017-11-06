using System;

namespace BoringVector
{
    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечисления VectorRelation(General, Parallel, Orthogonal) - отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */

    /// <summary>
    /// Перечисление, задающее положение между векторами в пространстве. </summary>
    internal enum VectorRelation
    {
        /// <summary>
        /// Свойство, отвечающее за коллинеарность векторов. Значение равно 0, так как соответствует значению векторного произведения между коллинеарными векторами. </summary>
        Parallel = 0,
        /// <summary>
        /// Свойство, отвечающее за ортогональность векторов. Значение равно 0, так как соответствует значению скалярного произведения между ортогональными векторами. </summary>
        Orthogonal = 0,
        /// <summary>
        /// Свойство, отвечающее за неопределенное положение между векторами в пространстве. </summary>
        General
    }

    /// <summary>
    /// Расширения структуры Vector. </summary>
    internal static class VectorExtensions
    // не совсем понимаю профитов невозможности объявить static struct
    // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
    {
        /// <summary>
        /// Статический конструктор атрибута точности вычислений. </summary>
        static VectorExtensions() => _precision = 1e-6;
        // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors

        /// <summary>
        /// Проверяет с некоторой точностью, является ли текущий вектор нулевым. </summary>
        /// <param name="vector"> Объект текущего вектора. </param>
        /// <returns> Возвращает true, если текущий вектор является нулевым, false иначе. </returns>
        public static bool IsZero(this Vector vector)
        {
            return (vector.SquareLength() <= _precision * _precision);
        }

        /// <summary>
        /// Нормализует вектор, то есть преобразует вектор vector в сонаправленный вектор с единичной длиной. </summary>
        /// <param name="vector"> Объект текущего вектора. </param>
        /// <returns> Возвращает объект измененного вектора. </returns>
        public static Vector Normalize(this Vector vector)
        {
            return vector / Math.Sqrt(vector.SquareLength());
        }

        /// <summary>
        /// Вычисляет значение угла между ненулевыми векторами firstVector и secondVector в радианах. Угол равен 0, если один из векторов является нулевым. </summary>
        /// <param name="firstVector"> Исследуемый вектор. </param>
        /// <param name="secondVector"> Исследуемый вектор. </param>
        /// <returns> Возвращает значение угла между векторами. </returns>
        public static double GetAngleBetween(Vector firstVector, Vector secondVector)
        {
            if (firstVector.IsZero() || secondVector.IsZero())
            {
                return 0.0;
            }
            else
            {
                return Math.Acos(firstVector.DotProduct(secondVector) /
                                 Math.Sqrt(firstVector.SquareLength() * secondVector.SquareLength()));
            }
        }

        /// <summary>
        /// Вычисляет взаимное расположению векторов firstVector и secondVector в пространстве. </summary>
        /// <param name="firstVector"> Исследуемый вектор. </param>
        /// <param name="secondVector"> Исследуемый вектор. </param>
        /// <returns> Возвращает значение из перечисления VectorRelation, соответствующее взаимному расположению векторов в пространстве. </returns>
        public static VectorRelation GetRelation(Vector firstVector, Vector secondVector)
        {
            if (Math.Abs(firstVector.DotProduct(secondVector)) <= _precision)
            {
                return VectorRelation.Orthogonal;
            }
            else if (Math.Abs(firstVector.CrossProduct(secondVector)) <= _precision)
            {
                return VectorRelation.Parallel;
            }
            else
            {
                return VectorRelation.General;
            }
        }

        /// <summary>
        /// Геттер атрибута, отвечающего за точность вычислений. </summary>
        /// <returns> Текущее значение точности вычислений. </returns>
        public static double GetPrecision() => _precision;
        /// <summary>
        /// Сеттер атрибута, отвечающего за точность вычислений. </summary>
        /// <param name="value"> Присваиваемое значение. </param>
        public static void SetPrecision(double value) => _precision = value;

        /// <summary>
        /// Атрибут, отвечающий за точность вычислений. </summary>
        private static double _precision;
    }
}
