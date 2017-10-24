namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            System.Console.WriteLine(Time.WhatTimeIsItInUtc().TimeOfDay);
            System.Console.WriteLine(Time.SpecifyKind(Time.WhatTimeIsIt(), System.DateTimeKind.Utc));
            System.Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), System.DateTimeKind.Utc)));

            System.Console.WriteLine(Time.GetTotalMinutesInThreeMonths());
            System.Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            System.Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            System.Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime());
            System.Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            System.Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            System.Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
        }
    }
}
