using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            var now = Time.WhatTimeIsIt();
            var nowUtc = Time.WhatTimeIsItInUtc();
            
            Console.WriteLine($"WhatTimeIsIt: {now}");
            Console.WriteLine($"WhatTimeIsItInUtc: {nowUtc}");
            
            Console.WriteLine();

            foreach (DateTimeKind kind in Enum.GetValues(typeof(DateTimeKind)))
            {
                Console.WriteLine($"SpecifyKind {kind}: {Time.SpecifyKind(now, kind)}");
            }
            
            Console.WriteLine();

            foreach (DateTimeKind kind in Enum.GetValues(typeof(DateTimeKind)))
            {
                Console.WriteLine($"{kind}:");
                var time = Time.SpecifyKind(now, kind);
                var strTime = Time.ToRoundTripFormatString(time);
                var parsedTime = Time.ParseFromRoundTripFormat(strTime);
                Console.WriteLine($"\tToRoundTripFormatString: {strTime}");
                Console.WriteLine($"\tParseFromRoundTripFormat: {parsedTime}");
                Console.WriteLine($"\tT == ParseFromRoundTripFormat(ToRoundTripFormatString(T)): {Time.ToUtc(time) == Time.ToUtc(parsedTime)}");
            }
            
            Console.WriteLine();
            
            foreach (DateTimeKind kind in Enum.GetValues(typeof(DateTimeKind)))
            {
                Console.WriteLine($"ToUtc {kind}: {Time.ToUtc(now)}");
            }
            
            Console.WriteLine();
            
            Console.WriteLine($"AddTenSeconds: {Time.AddTenSeconds(now)}");
            Console.WriteLine($"AddTenSecondsV2: {Time.AddTenSecondsV2(now)}");
            
            Console.WriteLine();
            
            foreach (DateTimeKind kind1 in Enum.GetValues(typeof(DateTimeKind)))
            {
                foreach (DateTimeKind kind2 in Enum.GetValues(typeof(DateTimeKind)))
                {
                    var dt1 = Time.SpecifyKind(now, kind1);
                    var dt2 = Time.SpecifyKind(now.AddHours(3), kind2);
                    Console.WriteLine($"GetHoursBetween {kind1} {kind2}: {Time.GetHoursBetween(dt1, dt2)}");
                }
            }
            
            Console.WriteLine();
            
            Console.WriteLine($"GetTotalMinutesInThreeMonths: {Time.GetTotalMinutesInThreeMonths()}");
            
            Console.WriteLine();
            
            Console.WriteLine($"GetAdventureTimeDurationInMinutes_ver0_Dumb: {Time.GetAdventureTimeDurationInMinutes_ver0_Dumb()}");
            Console.WriteLine($"GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb: {Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb()}");
            Console.WriteLine($"GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter: {Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter()}");
            Console.WriteLine($"GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience: {Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()}");
            Console.WriteLine($"GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience: {Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()}");
            Console.WriteLine($"GetAdventureTimeDurationInMinutes_ver3_NodaTime: {Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime()}");

            Console.WriteLine();

            var bd1 = Time.ToUtc(now);
            var bd2 = Time.ToUtc(now.AddYears(3));
            var bd3 = Time.ToUtc(now.AddMonths(3));
            Console.WriteLine($"AreEqualBirthdays {bd1:d} == {bd2:d}: {Time.AreEqualBirthdays(bd1, bd2)}");
            Console.WriteLine($"AreEqualBirthdays {bd2:d} == {bd3:d}: {Time.AreEqualBirthdays(bd2, bd3)}");
        }
    }
}
