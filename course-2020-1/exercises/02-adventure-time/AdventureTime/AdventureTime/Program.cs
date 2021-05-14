using System;
using NodaTime;
using NodaTime.TimeZones;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            var cur_time = DateTime.Now;
            Console.WriteLine("current time: " + cur_time.ToString());

            var cur_parsed_time = Time.ToRoundTripFormatString(cur_time);
            Console.WriteLine("parsed current time: " + cur_parsed_time);

            var result_time = Time.ParseFromRoundTripFormat(cur_parsed_time);
            Console.WriteLine("result current time: " + result_time.ToString());

        }
    }
}
