namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            System.Console.WriteLine(AdventureTime.Time.WhatTimeIsIt());

            System.Console.WriteLine(AdventureTime.Time.WhatTimeIsItInUtc());

            System.Console.WriteLine(
                AdventureTime.Time.SpecifyKind(System.DateTime.Parse("12.12.12 01:01:01")  , System.DateTimeKind.Local));

            string curRoundTime;
            System.Console.WriteLine( curRoundTime =
                AdventureTime.Time.ToRoundTripFormatString(System.DateTime.Now));

            System.Console.WriteLine(AdventureTime.Time.ParseFromRoundTripFormat(curRoundTime));

            System.Console.WriteLine(AdventureTime.Time.ToUtc(System.DateTime.Now));

            System.Console.WriteLine(AdventureTime.Time.AddTenSeconds(System.DateTime.Now));

            System.Console.WriteLine(AdventureTime.Time.GetHoursBetween(System.DateTime.Now, System.DateTime.Today));

            System.Console.WriteLine(AdventureTime.Time.GetTotalMinutesInThreeMonths());

            System.Console.WriteLine(AdventureTime.Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());

            System.Console.WriteLine(AdventureTime.Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());

            System.Console.WriteLine(AdventureTime.Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());

            System.Console.WriteLine(AdventureTime.Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime());

            System.Console.WriteLine(AdventureTime.Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());

            System.Console.WriteLine(AdventureTime.Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());

            System.Console.WriteLine(AdventureTime.Time.AreEqualBirthdays(
                System.DateTime.Parse("1997-04-29"), 
                System.DateTime.Parse("29.04.1997")));
        }
    }
}
