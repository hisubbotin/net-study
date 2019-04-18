using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            var now = Time.WhatTimeIsIt();
            
            Console.WriteLine(now);
            Console.WriteLine(Time.WhatTimeIsItInUtc());
            var local = Time.SpecifyKind(now, DateTimeKind.Local);
            Console.WriteLine(local);

            var nowUtc = Time.SpecifyKind(now, DateTimeKind.Utc);
            
            Console.WriteLine(Time.ToRoundTripFormatString(now));
            var rtf = Time.ToRoundTripFormatString(nowUtc);
            Console.WriteLine(rtf);
            var parsed = Time.ParseFromRoundTripFormat(rtf);
            Console.WriteLine("To RTT and back:");
            Console.WriteLine(nowUtc == parsed);
            
            Console.WriteLine(Time.ToUtc(local));
            Console.WriteLine(Time.AddTenSeconds(now));
            Console.WriteLine(Time.AddTenSecondsV2(now));
            Console.WriteLine(Time.GetHoursBetween(DateTime.Today, now));
            var dt0 = new DateTime(2000, 1, 12);
            var dt1 = new DateTime(2020, 1, 12);
            Console.WriteLine(Time.AreEqualBirthdays(dt0, dt1));
            
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            
        }
    }
}
