
using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(Time.WhatTimeIsIt().ToString());
            Console.WriteLine();

            Console.WriteLine(Time.WhatTimeIsItInUtc().ToString());
            Console.WriteLine();

            var dt = Time.WhatTimeIsIt();
            Console.WriteLine(dt.Kind.ToString());
            dt = Time.SpecifyKind(dt, DateTimeKind.Utc);
            Console.WriteLine(dt.Kind.ToString());
            Console.WriteLine();

            String str = Time.ToRoundTripFormatString(dt);
            Console.WriteLine(str);
            var dt1 = Time.ParseFromRoundTripFormat(str);
            Console.WriteLine(dt1.ToString());
            Console.WriteLine();

            Console.WriteLine(Time.ToUtc(dt).ToString());
            dt = Time.SpecifyKind(dt, DateTimeKind.Local);
            Console.WriteLine(Time.ToUtc(dt).ToString());
            Console.WriteLine();

            Console.WriteLine(Time.AddTenSeconds(dt).ToString());
            Console.WriteLine();

            Console.WriteLine(Time.AddTenSecondsV2(dt).ToString());
            Console.WriteLine();

            dt1 = dt.Add(new TimeSpan(14, 60, 10));
            dt1 = Time.SpecifyKind(dt1, DateTimeKind.Utc);
            Console.WriteLine(Time.GetHoursBetween(dt1, dt));
            Console.WriteLine();

            Console.WriteLine(Time.GetTotalMinutesInThreeMonths());
            Console.WriteLine();

            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine();

            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine();

            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine();

            var birthDate1 = new DateTime(2010, 3, 28);
            var birthDate2 = new DateTime(1999, 3, 27);
            Console.WriteLine(Time.AreEqualBirthdays(birthDate1, birthDate2));
        }
    }
}
