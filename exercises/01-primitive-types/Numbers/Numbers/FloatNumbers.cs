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
            // Подсказка: по аналогии с константами типа int, у типа double тоже есть свой набор констант.
            return double.IsNaN(d);
            // throw new NotImplementedException();
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
            return 0 / (double)0;
            // throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает результат сравнения двух вещественнозначных чисел.
        /// </summary>
        /// <returns>-1 - первое меньше второго, 0 - значения равны, 1 - первое больше второго.</returns>
        internal static int Compare(double first, double second, double eps)
        {
            /*
                Подумай, почему это задание дано в части про вещественнозначные числа. И почему не дана полная сигнатура метода.
                Если сходу идей нет, перестань искать подвох и просто реализуй дословно. Теперь еще раз посмотри на код и подумай в чем может быть проблема, сколько должно быть аргументов.
            */
            if (Math.Abs(first - second) < eps)
            {
                return 0;
            }
            else
            {
                if (first - second > 0)
                {
                    return 1;
                }
                return -1;
            }

            // throw new NotImplementedException();
        }

        // и все?!! О_о


        // и все... -_-
    }
}
