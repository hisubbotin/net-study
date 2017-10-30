using System;

namespace BoringVector
{
    #region Структура Vector
    
    /// <summary>
    /// Двумерный вектор.
    /// </summary>
    internal struct Vector
    {
        /// <summary>
        /// Координата x.
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Координата y.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Инициализирует новую структуру <see cref="Vector"/>.
        /// </summary>
        /// <param name="x">Координата x.</param>
        /// <param name="y">Координата y.</param>
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Возвращает квадрат длины.
        /// </summary>
        /// <returns>Квадрат длины.</returns>
        public double SquareLength() => DotProduct(this);

        /// <summary>
        /// Возвращает сумму векторов.
        /// </summary>
        /// <param name="v">Объект типа <see cref="Vector"/>, с которым складываем.</param>
        /// <returns>Новый объект типа <see cref="Vector"/> - результат сложения данного вектора с <paramref name="v"/></returns>
        public Vector Add(Vector v) => new Vector(X + v.X, Y + v.Y);

        /// <summary>
        /// Возвращает вектор, умноженный на коэффициент <paramref name="k"/>.
        /// </summary>
        /// <param name="k">Коэффициент, на который домножаем данный вектор.</param>
        /// <returns>Вектор, умноженный на коэффициент <paramref name="k"/>.</returns>
        public Vector Scale(double k) => new Vector(k * X, k * Y);

        /// <summary>
        /// Возвращает скалярное произведение векторов.
        /// </summary>
        /// <param name="v">Объект типа <see cref="Vector"/>, на который умножаем.</param>
        /// <returns>Величина типа <see cref="double"/> - скалярное произведение данного вектора и <paramref name="v"/>.</returns>
        public double DotProduct(Vector v) => X * v.X + Y + v.Y;

        /// <summary>
        /// Возвращает векторное произведение.
        /// </summary>
        /// <param name="v">Объект типа <see cref="Vector"/>, на который умножаем.</param>
        /// <returns>Величина типа <see cref="double"/> - площадь параллелограмма, образованного данным веткором и <paramref name="v"/>.</returns>
        public double CrossProduct(Vector v) => X * v.Y - v.X - Y;

        /// <summary>
        /// Возвращает строковое представление вектора.
        /// </summary>
        /// <returns>Строковое представление в формате (x, y).</returns>
        public override string ToString() => String.Format("({0}, {1})", X, Y);

        #region operators
   
        public static Vector operator +(Vector v, Vector u) => v.Add(u);

        public static Vector operator -(Vector v, Vector u) => v + (-u);

        public static Vector operator *(double k, Vector v) => v.Scale(k);

        public static Vector operator *(Vector v, double k) => k * v;

        public static Vector operator /(Vector v, double k) => (1 / k) * v;

        public static Vector operator +(Vector v) => 1 * v;

        public static Vector operator -(Vector v) => -1 * v;

        #endregion
    }

    #endregion

    #region Комментарии

    /// <summary>
    /// Класс, не делающий ничего.
    /// </summary>
    internal class Foo
    {
        /// <summary>
        /// Не делает ничего, как и подобает методам данного класса.
        /// </summary>
        /// <param name="something">Экземпляр <see cref="object"/> чего бы то ни было.</param>
        public static void DoNothing(object something)
        {
            // nothing to do here
        }

        public static void ThrowNotImplementedException()
        {
            throw new NotImplementedException();
        }
    }

    #endregion
}
