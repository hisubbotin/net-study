using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            DateTime dt = Time.WhatTimeIsIt();
            DateTimeKind kind = DateTimeKind.Utc;
            // 1
            // Console.WriteLine(Time.WhatTimeIsItInUtc());
            
            // 2
            // Console.WriteLine(dt);
            // Console.WriteLine(Time.SpecifyKind(dt, kind));
            
            // 3
            //Console.WriteLine(Time.ToRoundTripFormatString(dt));
            
            // 4
            /*
            Console.WriteLine(Time.SpecifyKind(dt, DateTimeKind.Local).ToString("o")); 
            Console.WriteLine(Time.SpecifyKind(dt, DateTimeKind.Unspecified).ToString("o"));
            Console.WriteLine(Time.SpecifyKind(dt, DateTimeKind.Utc).ToString("o"));
            */
            
            // 5
            //Console.WriteLine(dt);
            //Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(dt)));
            
            // 6
            //Console.WriteLine(Time.ToUtc(dt));
            
            // 7
            //Console.WriteLine(dt);
            //Console.WriteLine(Time.AddTenSeconds(dt));
            
            // 8
            //Console.WriteLine(dt);
            //Console.WriteLine(Time.AddTenSecondsV2(dt));
            
            // 9
            DateTime test_dt = new DateTime(2021, 5, 24, 2, 15, 0);
            //Console.WriteLine(Time.GetHoursBetween(dt, Time.SpecifyKind(test_dt, DateTimeKind.Utc)));
            
            // 10
            //Console.WriteLine(Time.GetTotalMinutesInThreeMonths());
            
            // 11
            //Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            
            // 12
            //Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            
            // 13
            //Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            
            // 14
            //Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            
            // 15
            //Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            
            // ...
            
            // 16 
            //Console.WriteLine(Time.AreEqualBirthdays(dt, test_dt));
        }
    }
}
