/*
    Здесь все то же самое.
*/

using System;

namespace Numbers
{
    public static class FloatNumbers
    {
        /// <summary>
        /// Возвращает вещественнозначное число со значением "не число" (Not a number).
        /// </summary>
        internal static double GetNaN() => 0.0 / 0.0;

        /// <summary>
        /// Возвращает результат проверки, имеет ли указанное вещественнозначное число значение "не число" (Not a number).
        /// </summary>
        /// <param name="d">Проверяемое вещественнозначное число.</param>
        /// <returns>True, если число имеет значение "не число", иначе false.</returns>
        internal static bool IsNaN(double d) => double.IsNaN(d);

        /// <summary>
        /// Возвращает результат сравнения двух вещественнозначных чисел.
        /// </summary>
        /// <param name="eps">Точность, с которой сраниваются числа.</param>
        /// <returns>-1 - первое меньше второго, 0 - значения равны, 1 - первое больше второго.</returns>
        internal static int Compare(double first, double second, double eps = 1e-7)
        {
            if (first - second < eps && first - second > -eps)
            {
                return 0;
            } else if (first <= second - eps)
            {
                return -1;
            } else if (first >= second + eps)
            {
                return 1;
            }

            throw new InvalidOperationException();
        }
    }
}
