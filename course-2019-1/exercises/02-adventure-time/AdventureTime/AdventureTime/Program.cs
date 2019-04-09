using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            DateTime local = Time.WhatTimeIsIt();
            DateTime utc = Time.WhatTimeIsItInUtc();
            DateTime unspec = new DateTime(2019, 4, 8, 11, 35, 12, DateTimeKind.Unspecified);
            Console.WriteLine(local);
            Console.WriteLine(utc);
            Console.WriteLine(unspec);
            Console.WriteLine();

            string localISO = Time.ToRoundTripFormatString(local);
            string utcISO = Time.ToRoundTripFormatString(utc);
            string unspecISO = Time.ToRoundTripFormatString(unspec);
            Console.WriteLine(localISO);
            Console.WriteLine(utcISO);
            Console.WriteLine(unspecISO);
            Console.WriteLine();

            DateTime localRecovery = Time.ParseFromRoundTripFormat(localISO);
            DateTime utcRecovery = Time.ParseFromRoundTripFormat(utcISO);
            DateTime unspecRecovery = Time.ParseFromRoundTripFormat(unspecISO);
            Console.WriteLine(localRecovery);
            Console.WriteLine(utcRecovery);
            Console.WriteLine(unspecRecovery);
            Console.WriteLine(localRecovery.Kind);
            Console.WriteLine(utcRecovery.Kind);
            Console.WriteLine(unspecRecovery.Kind);
            Console.WriteLine();

            Console.WriteLine(Time.ToUtc(local));
            Console.WriteLine(Time.ToUtc(utc));
            Console.WriteLine(Time.ToUtc(unspec));
            Console.WriteLine();

            Console.WriteLine(Time.AddTenSeconds(local));
            Console.WriteLine(Time.AddTenSeconds(utc));
            Console.WriteLine(Time.AddTenSeconds(unspec));
            Console.WriteLine();

            Console.WriteLine(Time.AddTenSecondsV2(local));
            Console.WriteLine(Time.AddTenSecondsV2(utc));
            Console.WriteLine(Time.AddTenSecondsV2(unspec));
            Console.WriteLine();

            Console.WriteLine(Time.GetHoursBetween(unspec, local));
            Console.WriteLine(Time.GetHoursBetween(unspec, utc));
            Console.WriteLine(Time.GetHoursBetween(utc, local));
            Console.WriteLine();

            Console.WriteLine(Time.GetTotalMinutesInThreeMonths());
            Console.WriteLine();

            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine();
        }
    }
}
