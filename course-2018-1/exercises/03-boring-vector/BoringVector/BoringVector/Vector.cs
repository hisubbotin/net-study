using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BoringVector.Tests")]
namespace BoringVector {
    
    /// <summary>
    /// Структура, реализующая вектор на плоскости.
    /// </summary>
    internal struct Vector {
        
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="x">Задает первую координату вектора, по умолчанию 0.</param>
        /// <param name="y">Задает вторую координату вектора, по умолчанию 0.</param>
        public Vector(double x = 0, double y = 0) {
            X = x;
            Y = y;
        }
        
        /// <summary>
        /// Возвращает квадрат длины вектора в стандартной норме (где длина есть сумма квадратов координат).
        /// </summary>
        /// <returns>Квадрат длины вектора.</returns>
        public double SquareLength() {
            return DotProduct(new Vector(X, Y));
        }

        /// <summary>
        /// Возвращает сумму (поэлементную) сумму двух векторов.
        /// </summary>
        /// <param name="v">Другой вектор, который надо прибавить к данному.</param>
        /// <returns>Сумма двух векторов.</returns>
        public Vector Add(Vector v) {
            return new Vector(X + v.X, Y + v.Y);
        }

        /// <summary>
        /// Возвращает вектор, умноженный в заданное действительное число раз.
        /// </summary>
        /// <param name="k">Числовой множитель.</param>
        /// <returns>Умноженный вектор.</returns>
        public Vector Scale(double k) {
            return new Vector(X * k, Y * k);
        }

        /// <summary>
        /// Возвращает скалярное произведение двух векторов.
        /// </summary>
        /// <param name="v">Другой вектор, скалярное произведение с которым надо посчитать.</param>
        /// <returns>Скалярное произведение.</returns>
        public double DotProduct(Vector v) {
            return X * v.X + Y * v.Y;
        }

        /// <summary>
        /// Возвращает векторное произведение двух векторов.
        /// </summary>
        /// <param name="v">Другой вектор, векторное произведение с которым надо посчитать.</param>
        /// <returns>Векторное произведение.</returns>
        public double CrossProduct(Vector v) {
            return X * v.Y - Y * v.X;
        }

        /// <summary>
        /// Преобразует вектор в строку.
        /// </summary>
        /// <returns>Строкое представление вектора.</returns>
        public new string ToString() {
            return $"({X}, {Y})";
        }
        
        /// <summary>
        /// Оператор умножения для вектора и действительного числа.
        /// </summary>
        /// <param name="u">Вектор, который надо умножить на число.</param>
        /// <param name="k">Число, на которое надо умножить вектор.</param>
        /// <returns>Вектор, умноженный на число.</returns>
        public static Vector operator *(Vector u, double k) {
            return u.Scale(k);
        } 
       
        /// <summary>
        /// Оператор деление вектора на действительное число, не равное нулю.
        /// </summary>
        /// <param name="u">Вектор, который надо разделить на число.</param>
        /// <param name="k">Число, на которое надо разделить вектор.</param>
        /// <returns>Вектор, разделенные на число.</returns>
        /// <exception cref="ArgumentException">Происходит в случае деления на 0.</exception>
        public static Vector operator /(Vector u, double k) {
            if (k < Epsilon) {
                throw new ArgumentException("Division by zero");
            }

            return u * (1.0 / k);
        }
        
        /// <summary>
        /// Унарный плюс для вектора. Ничего не делает.
        /// </summary>
        /// <param name="u">Вектор, к которому применяется оператор.</param>
        /// <returns>Тот же вектор.</returns>
        public static Vector operator +(Vector u) {
            return u;
        }
        
        /// <summary>
        /// Унарный минус для вектора. Возвращает вектор, противоположный данному.
        /// </summary>
        /// <param name="u">Вектор, к которому надо найти противоположный.</param>
        /// <returns>Противоположный вектор.</returns>
        public static Vector operator -(Vector u) {
            return u * (-1);
        }
        
        /// <summary>
        /// Оператор сложения двух векторов.
        /// </summary>
        /// <param name="u">Левый операнд.</param>
        /// <param name="v">Правый операнд.</param>
        /// <returns>Сумма двух векторов.</returns>
        public static Vector operator +(Vector u, Vector v) {
            return u.Add(v);
        }
        
        /// <summary>
        /// Опреатор вычитания двух векторов.
        /// </summary>
        /// <param name="u">Уменьшаемое.</param>
        /// <param name="v">Вычитаемое.</param>
        /// <returns>Разность.</returns>
        public static Vector operator -(Vector u, Vector v) {
            return u + (-v);
        }

        /// <summary>
        /// Первая координата вектора.
        /// </summary>
        public double X { get; }
        
        /// <summary>
        /// Вторая координата вектора.
        /// </summary>
        public double Y { get; }
        
        /// <summary>
        /// Константа, определяющая точность, с которой выполняеются операции с вещественными числами.
        /// </summary>
        internal const double Epsilon = 1e-6;

        /// <summary>
        /// Перечисление, задающее отношение двух векторов между собой.
        /// </summary>
        internal enum VectorRelation {
            /// <summary>
            /// Общее - векторы ни параллельны, ни ортогональны.
            /// </summary>
            General,
            
            /// <summary>
            /// Параллельны - оба векторы не нулевые и параллельны.
            /// </summary>
            Parallel,
            
            /// <summary>
            /// Ортогональны - векторы ортогональны или какой-то или оба из них нули.
            /// </summary>
            Orthogonal   
        }
    }
}
