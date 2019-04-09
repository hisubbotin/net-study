using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            DateTime n = Time.WhatTimeIsIt();
            
            Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(n, DateTimeKind.Utc)));
            Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(n, DateTimeKind.Local)));
            Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(n, DateTimeKind.Unspecified)));
            DateTime n1 = 
                Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.SpecifyKind(n, DateTimeKind.Utc)));
            DateTime n2 = 
                Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.SpecifyKind(n, DateTimeKind.Local)));
            DateTime n3 = 
                Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.SpecifyKind(n, DateTimeKind.Unspecified)));

            Console.WriteLine(n);
            Console.WriteLine(n1);            
            Console.WriteLine(n2);           
            Console.WriteLine(n3);
            Console.WriteLine(Time.AddTenSeconds(n));
            Console.WriteLine(Time.AddTenSecondsV2(n));
            Console.WriteLine(Time.GetTotalMinutesInThreeMonths());
            Console.WriteLine(Time.GetHoursBetween(Time.SpecifyKind(n, DateTimeKind.Local), Time.SpecifyKind(n, DateTimeKind.Utc)));
            Console.WriteLine(Time.GetHoursBetween(Time.WhatTimeIsItInUtc(), Time.WhatTimeIsIt()));
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine(Time.AreEqualBirthdays(n, n3));
        }
    }
}
