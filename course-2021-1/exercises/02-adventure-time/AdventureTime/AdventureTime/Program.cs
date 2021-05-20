using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            // Протестируем работу основных методов без Adventure time
            System.Console.WriteLine("Base methods");
            System.Console.WriteLine(Time.WhatTimeIsIt());
            System.Console.WriteLine(Time.WhatTimeIsItInUtc());
            System.Console.WriteLine(Time.SpecifyKind(Time.WhatTimeIsItInUtc(), DateTimeKind.Local));
            System.Console.WriteLine(Time.ToRoundTripFormatString(Time.WhatTimeIsIt(), true));
            System.Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.WhatTimeIsIt())));
            System.Console.WriteLine(Time.ToUtc(Time.SpecifyKind(Time.WhatTimeIsItInUtc(), DateTimeKind.Local)));
            System.Console.WriteLine(Time.AddTenSeconds(Time.WhatTimeIsIt()));
            System.Console.WriteLine(Time.AddTenSecondsV2(Time.WhatTimeIsIt()));
            System.Console.WriteLine(Time.GetHoursBetween(
                new DateTime(2010, 3, 28, 2, 15, 0), 
                new DateTime(2010, 3, 28, 3, 45, 0))
            );
            System.Console.WriteLine(Time.GetTotalMinutesInThreeMonths());
            System.Console.WriteLine(Time.AreEqualBirthdays(
                new DateTime(2010, 3, 28), new DateTime(2000, 4, 1)));
            System.Console.WriteLine("===============================================================================");
            
            // Протестируем работу методов в Adventure time
            System.Console.WriteLine("Adventure time methods");
            System.Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            System.Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            System.Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            System.Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            System.Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            System.Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime());
            System.Console.WriteLine("===============================================================================");
        }
    }
}
