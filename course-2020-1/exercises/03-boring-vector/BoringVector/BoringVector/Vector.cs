using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BoringVector.Tests")]

namespace BoringVector
{
    #region 1. Структура Vector
    
    /// <summary>
    /// Класс для работы с двумерными векторами
    /// </summary>
    internal struct Vector
    {

        public readonly double X { get; }
        public readonly double Y { get; }
    
        /// <summary>
        /// Конструктор двумерного вектора по двум координатам
        /// </summary>
        /// <param name="x">Координата <see cref="double"/> по оси x</param>
        /// <param name="y">Координата <see cref="double"/> по оси y</param>
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        
        /// <summary>
        /// Метод, который возвращает <see cref="double"/>, квадрат нормы двумерного вектора
        /// </summary>
        /// <returns><see cref="double"/>, квадрат нормы двумерного вектора </returns>
        public double SquareLength()
        {
            return Math.Pow(X, 2) + Math.Pow(Y, 2); 
        }
        
        /// <summary>
        /// Метод, скающий переданный ветор <see cref="Vector"/> с собственным вектором и возвращает <see cref="Vector"/> сумму
        /// </summary>
        /// <param name="v"> Прибавляемый вектор <see cref="Vector"/></param>
        /// <returns><see cref="Vector"/> Сумма векторов </returns>
        public Vector Add(Vector v)
        {
            return new Vector(X + v.X, Y + v.Y);
        }
        
        /// <summary>
        /// Метод возвращает собственный <see cref="Vector"/> вектор, умноженный на число <see cref="double"/>
        /// </summary>
        /// <param name="k"><see cref="double"/> Коэффициент умножения </param>
        /// <returns><see cref="Vector"/> Вектор, умноженный на число <see cref="double"/></returns>
        public Vector Scale(double k)
        {
            return new Vector(X * k, Y * k);
        }
        
        /// <summary>
        /// Метод возвращает <see cref="double"/> скалярное произведение с заданным вектором <see cref="Vector"/> 
        /// </summary>
        /// <param name="v"><see cref="Vector"/> Вектор, на который умножается собственный </param>
        /// <returns><see cref="double"/> Скалярное произведение с заданным вектором <see cref="Vector"/></returns>
        public double DotProduct(Vector v)
        {
            return X * v.X + Y * v.Y;
        }
        
        /// <summary>
        /// Метод возвращает <see cref="double"/> модуль векторного произведения с заданным вектором <see cref="Vector"/> 
        /// </summary>
        /// <param name="v"><see cref="Vector"/> Вектор, на который умножается собственный </param>
        /// <returns><see cref="double"/> Модуль векторного произведения с заданным вектором <see cref="Vector"/></returns>
        public double CrossProduct(Vector v)
        {
            return X * v.Y - Y * v.X;
        }
        
        /// <summary>
        /// Возвращает <see cref="string"/> строковое представление собственного вектора <see cref="Vector"/>
        /// </summary>
        /// <returns> Строковое представление <see cref="Vector"/></returns> собственного вектора
        public override string ToString() => $"({X}; {Y})";

        #region operators
        
        /// <summary>
        /// Оператор возвращает <see cref="Vector"/> этот же вектор с положительными координатами 
        /// </summary>
        /// <param name="v"> Вектор <see cref="Vector"/> </param>
        /// <returns> Вектор <see cref="Vector"/> с такими же координатами, как заданный </returns>
        public static Vector operator +(Vector v) => v;
        
        /// <summary>
        /// Оператор возвращает <see cref="Vector"/> заданный вектор с противоположными координатами 
        /// </summary>
        /// <param name="v"> Вектор <see cref="Vector"/> </param>
        /// <returns> Вектор <see cref="Vector"/> с противоположными координатами </returns>
        public static Vector operator -(Vector v) => new Vector(-v.X, v.Y);
    
        /// <summary>
        /// Оператор складывает два вектора <see cref="Vector"/> и возвращает новый вектор, результат суммы <see cref="Vector"/>
        /// </summary>
        /// <param name="v1"> Левый вектор <see cref="Vector"/> </param>
        /// <param name="v2"> Правый вектор <see cref="Vector"/> </param>
        /// <returns> Результат суммы векторов <see cref="Vector"/> </returns>
        public static Vector operator +(Vector v1, Vector v2)
            => new Vector(v1.X + v2.X, v1.Y + v2.Y);
        
        /// <summary>
        /// Оператор вычитает один вектор из другого <see cref="Vector"/> и возвращает новый вектор, результат разности <see cref="Vector"/>
        /// </summary>
        /// <param name="v1"> Левый вектор <see cref="Vector"/> </param>
        /// <param name="v2"> Правый вектор <see cref="Vector"/> </param>
        /// <returns> Результат <see cref="Vector"/> вычитания правого векторая из левого </returns>
        public static Vector operator -(Vector v1, Vector v2)
            => v1 + (-v2);
        
        /// <summary>
        /// Оператор умножает вектор <see cref="Vector"/> на число <see cref="double"/>
        /// </summary>
        /// <param name="k"> Множитель <see cref="double"/> </param>
        /// <param name="v"> Исходный вектор </param>
        /// <returns> Вектор <see cref="Vector"/>, умноженный на число <see cref="double"/> </returns>
        public static Vector operator *(double k, Vector v)
            => new Vector(k * v.X, k * v.Y);
        
        /// <summary>
        /// Оператор умножает вектор <see cref="Vector"/> на число <see cref="double"/>
        /// </summary>
        /// <param name="v"> Исходный вектор </param>
        /// <param name="k"> Множитель <see cref="double"/> </paramЮ
        /// <returns> Вектор <see cref="Vector"/>, умноженный на число <see cref="double"/> </returns>
        public static Vector operator *(Vector v, double k)
            => k * v;
        
        /// <summary>
        /// Оператор делит вектор <see cref="Vector"/> на число, в случае, если число не равно нулю <see cref="double"/>
        /// </summary>
        /// <param name="v"> Исходный вектор </param>
        /// <param name="k"> Множитель <see cref="double"/> </paramЮ
        /// <returns> Вектор <see cref="Vector"/>, деленный на число <see cref="double"/> </returns>
        public static Vector operator /(Vector v, double k)
        {
            if (Math.Abs(k) <= 1e-6)
            {
                throw new DivideByZeroException();
            }

            return v * (1 / k);
        }

        #endregion
    }

    #endregion

    #region 4. Тесты

    /*
        Прости еще раз, но на этом твои мучения еще не кончаются. Проблема в том, что у котика все еще лапки, поэтому очень важно
        покрыть тестами хотя бы базовые методы структуры Vector:
            SquareLength
            Add
            Scale
            DotProduct
            CrossProduct

        Для этого создай в этом же солюшене (если ты не в студии, то можешь и не в солюшене) проект BoringVector.Tests,
        который будет содержать класс с набором тестов. Используй Xunit (в принципе можешь воспользоваться и другим фреймворком для тестирования).

        Особо не заморачивайся с тем, чтобы оттестировать все возможные специальные случаи - в данном задании важно, чтобы
        ты просто разобрался(-ась), как писать автотесты и как их запускать. Это задание НЕ на то, как писать хорошие тесты.

        Примечание: структура Vector описана как internal структура, поэтому по умолчанию сборке BoringVector.Tests она не видна.
        Чтобы она была видна, существует специальная директива компилятору:
            [assembly: InternalsVisibleTo("XXX")]
        , где XXX - название проекта, которому ты хочешь сделать видимыми свои internal'ы.

        Можешь посмотреть, в задании [01-primitive-types] эта директива есть в файле Program.cs проекта Numbers.

        Итак, создай проект с тестами и добейся того, чтобы базовые методы структуры Vector их проходили.
    */

    #endregion
}
