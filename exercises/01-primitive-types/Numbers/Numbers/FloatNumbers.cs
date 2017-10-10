/*
    Здесь все то же самое.
*/

using System;

namespace Numbers
{
    public static class FloatNumbers
    {
        /// <summary>
        /// Возвращает результат проверки, имеет ли указанное вещественнозначное число значение "не число" (Not a number).
        /// </summary>
        /// <param name="d">Проверяемое вещественнозначное число.</param>
        /// <returns>True, если число имеет значение "не число", иначе false.</returns>
        internal static bool IsNaN(double d)
        {
            return double.IsNaN(d);
        }

        /// <summary>
        /// Возвращает вещественнозначное число со значением "не число" (Not a number).
        /// </summary>m
        internal static double GetNaN()
        {
            return Math.Sqrt(-1);
        }

        /// <summary>
        /// Возвращает результат сравнения двух вещественнозначных чисел.
        /// </summary>
        /// <returns>-1 - первое меньше второго, 0 - значения равны, 1 - первое больше второго.</returns>
        internal static int Compare(double a, double b, double eps)
        {
            double delta = a - b;
            if (Math.Abs(delta) < eps)
            {
                return 0;
            }
            else
            {
                return delta < 0 ? -1 : 1;
            }
        }

        // и все?!! О_о


        // и все... -_-
    }
}
