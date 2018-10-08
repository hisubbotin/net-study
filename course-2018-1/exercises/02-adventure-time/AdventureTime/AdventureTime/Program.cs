using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            var dt = new DateTime(2008, 6, 12, 18, 45, 15);
            var dt2 = new DateTime(2008, 10, 15, 12, 0, 0);
            
            var defDt = Time.SpecifyKind(dt, DateTimeKind.Utc);
            var defDt2 = Time.SpecifyKind(dt2, DateTimeKind.Local);
            
            Console.WriteLine(Time.WhatTimeIsIt().Kind);
            Console.WriteLine(Time.WhatTimeIsItInUtc().Kind);
            Console.WriteLine(Time.SpecifyKind(dt, DateTimeKind.Local));
            Console.WriteLine(Time.ToRoundTripFormatString(defDt));
            
            Console.WriteLine(Time.ToUtc(defDt));
            Console.WriteLine(Time.ToRoundTripFormatString(Time.AddTenSeconds(defDt)));
            Console.WriteLine(Time.ToRoundTripFormatString(Time.AddTenSecondsV2(defDt)));

            Console.WriteLine(Time.GetHoursBetween(defDt2, defDt));
//            Console.WriteLine(Time.GetTotalMinutesInThreeMonths());
            
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
        }
    }
}
