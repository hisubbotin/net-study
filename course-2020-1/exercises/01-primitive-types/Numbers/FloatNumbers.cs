/*
    Здесь все то же самое.
*/

using System;

namespace Numbers
{
    public static class FloatNumbers
    {

        internal static double GetNaN()
        {
            return 0.0 / 0.0;
        }
        
        internal static bool IsNaN(double d)
        {
            return d.Equals(Double.NaN);
        }
        
        internal static int Compare(double firstNum, double secondNum, double epsilon = double.Epsilon)
        {
            var result = 0;
            if (Math.Abs(firstNum - secondNum) < epsilon) return result;
            result = 1;
            if (firstNum < secondNum)
            {
                result = -1;
            }

            return result;
        }
    }
}
