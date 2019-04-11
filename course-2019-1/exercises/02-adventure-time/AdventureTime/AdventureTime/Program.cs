namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            const int offset = -60;
            var localTime = Time.WhatTimeIsIt();
            var utsTime = Time.WhatTimeIsItInUtc();

            System.Console.WriteLine($"{"WhatTimeIsIt:",offset} {localTime}");

            System.Console.WriteLine($"{"WhatTimeIsItInUtc:",offset} {utsTime}");

            System.Console.WriteLine($"{"ToRoundTripFormatStringLocal:",offset} " +
                $"{Time.ToRoundTripFormatString(localTime)}");

            System.Console.WriteLine($"{"ToRoundTripFormatStringUts:",offset} " +
                $"{Time.ToRoundTripFormatString(utsTime)}");

            
            System.Console.WriteLine($"{"ParseFromRoundTripFormatLocal:",offset} " +
                $"{Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.SpecifyKind(utsTime, System.DateTimeKind.Local)))}");
            System.Console.WriteLine($"{"ParseFromRoundTripFormatUnspecified:",offset} " +
                $"{Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.SpecifyKind(utsTime, System.DateTimeKind.Unspecified)))}");
            System.Console.WriteLine($"{"ParseFromRoundTripFormatUtc:",offset} " +
                $"{Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.SpecifyKind(utsTime, System.DateTimeKind.Utc)))}");

            System.Console.WriteLine($"{"ParseLocalFromRoundTripFormatLocal:",offset} " +
                $"{Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.SpecifyKind(localTime, System.DateTimeKind.Local)))}");
            System.Console.WriteLine($"{"ParseLocalFromRoundTripFormatUnspecified:",offset} " +
                $"{Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.SpecifyKind(localTime, System.DateTimeKind.Unspecified)))}");
            System.Console.WriteLine($"{"ParseLocalFromRoundTripFormatUtc:",offset} " +
                $"{Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.SpecifyKind(localTime, System.DateTimeKind.Utc)))}");

            System.Console.WriteLine($"{"UtcToUtc:",offset} {Time.ToUtc(utsTime)}");
            System.Console.WriteLine($"{"localToUtc:",offset} {Time.ToUtc(localTime)}");

            System.Console.WriteLine($"{"AddTenSeconds:",offset} {Time.AddTenSeconds(utsTime)}");
            System.Console.WriteLine($"{"AddTenSecondsV2:",offset} {Time.AddTenSecondsV2(utsTime)}");

            System.Console.WriteLine($"{"GetHoursBetween:",offset} {Time.GetHoursBetween(localTime, utsTime)}");
            System.Console.WriteLine($"{"GetTotalMinutesInThreeMonths:",offset} {Time.GetTotalMinutesInThreeMonths()}");

            System.Console.WriteLine($"{"GetAdventureTimeDurationInMinutes_ver0_Dumb:",offset}" +
                $" {Time.GetAdventureTimeDurationInMinutes_ver0_Dumb()}");
            System.Console.WriteLine($"{"GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb:",offset} " +
                $"{Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb()}");
            System.Console.WriteLine($"{"GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter:",offset}" +
                $" {Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter()}");
            System.Console.WriteLine($"{"GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience:",offset}" +
                $" {Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()}");

            System.Console.WriteLine($"{"GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience:",offset}" +
                $" {Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()}");

            System.Console.WriteLine($"{"AreEqualBirthdays:",offset}" +
                $" {Time.AreEqualBirthdays(new System.DateTime(2010, 3, 28, 3, 15, 0), new System.DateTime(2010, 3, 28, 1, 15, 0))}");
            System.Console.WriteLine($"{"AreEqualBirthdays:",offset}" +
                $" {Time.AreEqualBirthdays(new System.DateTime(2010, 3, 28, 3, 15, 0), new System.DateTime(2010, 3, 29, 1, 15, 0))}");
        }
    }
}
