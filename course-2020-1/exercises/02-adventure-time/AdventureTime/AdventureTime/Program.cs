using System;
using NodaTime;
using NodaTime.TimeZones;


namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            var now = DateTime.Now;
            Console.WriteLine("Current time is " + now.ToString());

            var now_parsed = Time.ToRoundTripFormatString(now);
            Console.WriteLine("Parsed current time is " + now_parsed);

            var result_time = Time.ParseFromRoundTripFormat(now_parsed);
            Console.WriteLine("Result current time is " + result_time.ToString());
        }
    }
}
