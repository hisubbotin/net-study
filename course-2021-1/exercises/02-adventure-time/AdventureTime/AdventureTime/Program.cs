using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            // DateTimePart();
            // AdventureTimeSaga();

        }
        

        private static void AdventureTimeSaga() {
            Console.WriteLine("DurationInMinutes_ver0: {0}", Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine("GenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb: {0}", Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine("GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter: {0}", Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());

            Console.WriteLine("ver2: {0}", Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine("GenderSwapped ver2: {0}", Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine("ver3: {0}", Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime());
            
            
            
            
            Console.WriteLine("AreEqualBirthdays: {0}", Time.AreEqualBirthdays(new DateTime(2010, 3, 29, 16, 15, 0), new DateTime(2010, 3, 28, 3, 15, 0)));
            
            
            
            
            
        }
        private static void DateTimePart() {
            DateTime now = Time.WhatTimeIsIt();
            DateTime nowUtc = Time.WhatTimeIsItInUtc();
            DateTime nowUtcToUtc = Time.SpecifyKind(now, DateTimeKind.Utc);
            DateTime nowUtcToLocal = Time.SpecifyKind(now, DateTimeKind.Local);
            DateTime nowUtcToUnspecified = Time.SpecifyKind(now, DateTimeKind.Unspecified);           
            Console.WriteLine("Now: {0}", now);
            Console.WriteLine("Now Utc: {0}", nowUtc);
            Console.WriteLine("nowUtcToLocal: {0}", nowUtcToLocal);
            Console.WriteLine(); // WTF
            
            Console.WriteLine("UTC to ISO 8601: {0}", Time.ToRoundTripFormatString(nowUtcToUtc));
            Console.WriteLine("Local to ISO 8601: {0}", Time.ToRoundTripFormatString(nowUtcToLocal));
            Console.WriteLine("Unspecified to ISO 8601: {0}", Time.ToRoundTripFormatString(nowUtcToUnspecified));
            Console.WriteLine(); // WTF
            
            Console.WriteLine("ISO 8601 UTC vs UTC: {0} {1}", Time.ParseFromRoundTripFormat(
                Time.ToRoundTripFormatString(nowUtcToUtc)), nowUtcToUtc);
            Console.WriteLine("ISO 8601 UTC Equals UTC: {0} ", Time.ParseFromRoundTripFormat(
                Time.ToRoundTripFormatString(nowUtcToUtc)).Equals(nowUtcToUtc));
            Console.WriteLine(); // Not Done
            
            // Console.WriteLine("toUtc", Time.ToUtc());

            Console.WriteLine();
            Console.WriteLine("Add UTC 10: {0}", Time.AddTenSeconds(nowUtc));
            Console.WriteLine("Add UTC 10 V2: {0}", Time.AddTenSecondsV2(nowUtc));
            Console.WriteLine("GetHoursBetween UTC&nowUtcToLocal: {0}", Time.GetHoursBetween(nowUtc, Time.AddTenSeconds(nowUtc)));
            Console.WriteLine("TotalMinutesInThreeMonths: {0}", Time.GetTotalMinutesInThreeMonths());
            

        }
    }
}
