using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Time now is " + Time.WhatTimeIsIt());
            Console.WriteLine("Time in UTC now is " + Time.WhatTimeIsItInUtc());

            DateTime testTime = new DateTime(2000, 03, 23, 14, 45, 31);
            DateTime testTimeLocal = Time.SpecifyKind(testTime, DateTimeKind.Local);
            DateTime testTimeUtc = Time.SpecifyKind(testTime, DateTimeKind.Utc);
            DateTime testTimeUnspecified = Time.SpecifyKind(testTime, DateTimeKind.Unspecified);
            Console.WriteLine("\nSpecifying DateTime " + testTime);
            Console.WriteLine(testTimeLocal + ", kind - " + testTimeLocal.Kind);
            Console.WriteLine(testTimeUtc + ", kind - " + testTimeUtc.Kind);
            Console.WriteLine(testTimeUnspecified + ", kind - " + testTimeUnspecified.Kind);


            Console.WriteLine("Converting to string (ISO 8601) different kinds:");
            Console.WriteLine(Time.ToRoundTripFormatString(testTimeLocal) + ", kind - " + testTimeLocal.Kind);
            Console.WriteLine(Time.ToRoundTripFormatString(testTimeUtc) + ", kind - " + testTimeUtc.Kind);
            Console.WriteLine(
                Time.ToRoundTripFormatString(testTimeUnspecified) + ", kind - " + testTimeUnspecified.Kind);

            Console.WriteLine("\nConverting from string (ISO 8601) different kinds:");
            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(testTimeLocal)));
            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(testTimeUtc)));
            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(testTimeUnspecified)));

            Console.WriteLine("\nAdding 10 seconds:");
            Console.WriteLine("Built-in method " + Time.AddTenSeconds(testTime));
            Console.WriteLine("TimeSpan method " + Time.AddTenSecondsV2(testTime));

            Console.WriteLine("\nGetting hours between");
            DateTime hourTestTimeUtc = testTimeUtc.AddHours(21);
            DateTime hourTestTimeLocal = testTimeLocal.AddHours(21);
            Console.WriteLine("Between " + testTimeUtc + " and " + hourTestTimeUtc + " there are " +
                              Time.GetHoursBetween(testTimeUtc, hourTestTimeUtc) + " hours, kinds are " +
                              testTimeUtc.Kind + " and " + hourTestTimeUtc.Kind);
            Console.WriteLine("Between " + hourTestTimeLocal + " and " + testTimeLocal + " there are " +
                              Time.GetHoursBetween(hourTestTimeLocal, testTimeLocal) + " hours, kinds are " +
                              hourTestTimeLocal.Kind + " and " + testTimeLocal.Kind);
            Console.WriteLine("Between " + testTimeLocal + " and " + hourTestTimeUtc + " there are " +
                              Time.GetHoursBetween(testTimeLocal, hourTestTimeUtc) + " hours, kinds are " +
                              testTimeLocal.Kind + " and " + hourTestTimeUtc.Kind);

            Console.WriteLine("\nThere are " + Time.GetTotalMinutesInThreeMonths() + " minutes in 3 months");

            Console.WriteLine("\n Adventure time:");
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            
            Console.WriteLine("\nChecking equality of Birthdays");
            Console.WriteLine("Are " + testTimeLocal + " and " + testTimeUtc + " equal? " +
                              Time.AreEqualBirthdays(testTimeLocal, testTimeUtc));
            DateTime secondTestTime = new DateTime(2001, 01, 21, 04, 30, 12);
            Console.WriteLine("Are " + testTime + " and " + secondTestTime + " equal? " +
                              Time.AreEqualBirthdays(testTime, secondTestTime));
        }
    }
}