using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(Time.ToRoundTripFormatString(DateTime.Now));
        }
    }
}
