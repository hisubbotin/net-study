/*
    Здесь все то же самое.
*/

using System;

namespace Numbers
{
    public static class FloatNumbers
    {
        /// <summary>
        /// </summary>
        internal static double GetNaN()
        {
            return double.NaN;

        }

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
        /// Возвращает результат сравнения двух вещественнозначных чисел.
        /// </summary>
        /// <returns>-1 - первое меньше второго, 0 - значения равны, 1 - первое больше второго.</returns>
        internal static int Compare(double val_1, double val_2)
        {
            //Как сравнивать NaN и числа?
            if (val_1 < val_2)
            {
                return -1;
            }
            else if (val_1 > val_2)
            {
                return 1;
            }
            else return 0;
            /*
                Подумай, почему это задание дано в части про вещественнозначные числа. И почему не дана полная сигнатура метода.
                Если сходу идей нет, перестань искать подвох и просто реализуй дословно. Теперь еще раз посмотри на код и подумай в чем может быть проблема, сколько должно быть аргументов.
            */
        }
    }
}
