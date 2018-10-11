using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BoringVector.Tests")]
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
	/// Расширение структуры <see cref="Vector"/>
	/// </summary>
    internal static class VectorExtensions
    {
        public static double epsilon = 1e-6;
	    public static int epsilonDecimalPlaces = 6;

        public static bool EqualEps(this double d, double other)
        {
            return Math.Abs(d - other) < epsilon;
        }

		/// <summary>
		/// Проверяет равенство вектора нулевому
		/// </summary>
		/// <param name="v">Вектор</param>
		/// <returns><see langword="true"/>, если вектор равен нулевому, иначе <see langword="false"/></returns>
		public static bool IsZero(this Vector v)
        {
            return v.X.EqualEps(0) && v.Y.EqualEps(0);
        }

		/// <summary>
		/// Нормализует вектор, то есть преобразует его в вектор единичной длины.
		/// </summary>
		/// <param name="v">Вектор</param>
		/// <returns>Нормализованный вектор</returns>
        public static Vector Normalize(this Vector v)
        {
            return v / Math.Sqrt(v.SquareLength());
        }

		/// <summary>
		/// Возвращает угол между двумя векторами в радианах.
		/// </summary>
		/// <param name="v">Вектор 1</param>
		/// <param name="u">Вектор 2</param>
		/// <returns>Угол в радианах</returns>
		public static double GetAngleBetween(Vector v, Vector u)
        {
            if (v.IsZero() || u.IsZero())
            {
                return 0;
            }
            return v.DotProduct(u);
        }

		/// <summary>
		/// Отношение между двумя векторами("общий случай", параллельны, перпендикулярны). 
		/// </summary>
		public enum VectorRelation
        {
            General, Parallel, Orthogonal
        }

		/// <summary>
		/// Проверяет взаимное расположение векторов на плоскости
		/// </summary>
		/// <param name="v">Вектор 1</param>
		/// <param name="u">Вектор 2</param>
		/// <returns><see cref="VectorRelation"/>, соответствующий взаимному расположению векторов на плоскости</returns>
		public static VectorRelation GetRelation(Vector v, Vector u)
        {
            double angle = GetAngleBetween(v, u);
            if (angle.EqualEps(0) || angle.EqualEps(Math.PI))
            {
                return VectorRelation.Parallel;
            }
            else if (Math.Abs(angle).EqualEps(Math.PI / 2))
            {
                return VectorRelation.Orthogonal;
            }
            else
            {
                return VectorRelation.General;
            }
        }
    }
}
