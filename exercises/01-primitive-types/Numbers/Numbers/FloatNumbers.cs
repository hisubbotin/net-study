﻿/*
    Здесь все то же самое.
*/

using System;

namespace Numbers
{
    public static class FloatNumbers
    {

        static double zero; // для метода GetNaN

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
        /// </summary>
        internal static double GetNaN()
        {
            /*
                Необходимо вернуть значение, не используя непосредственно саму константу.
                Для этого подумай, какой смысл в себе несет эта константа и где бы она могла стать результатом операции или вычисления функции.
            */
            return 0 / zero;
        }

        /// <summary>
        /// Возвращает результат сравнения двух вещественнозначных чисел.
        /// </summary>
        /// <returns>-1 - первое меньше второго, 0 - значения равны, 1 - первое больше второго.</returns>
        internal static int Compare(double first, double second, double precision = 0.0001)
        {
            if (Math.Abs(first - second) < precision)
            {
                return 0;
            }
            else if (first > second)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

    }
}
