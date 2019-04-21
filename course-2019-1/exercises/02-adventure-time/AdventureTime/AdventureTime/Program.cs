using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            DateTime time_now = Time.WhatTimeIsIt();

            // протестим работу всех функций
            // ToRoundTripFormatString
            Console.WriteLine(time_now);
            Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(time_now, DateTimeKind.Utc)));

            // ParseFromRoundTripFormat
            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.SpecifyKind(time_now, DateTimeKind.Local))));

            // AddTenSeconds
            Console.WriteLine(Time.AddTenSeconds(Time.ParseFromRoundTripFormat("18.11.1998")));
            Console.WriteLine(Time.AddTenSecondsV2(Time.ParseFromRoundTripFormat("18.11.1998")));

            // GetTotalMinutesInThreeMonths
            //Console.WriteLine(Time.GetTotalMinutesInThreeMonths());

            // GetHoursBetween
            Console.WriteLine(Time.GetHoursBetween(Time.ParseFromRoundTripFormat("18.11.1998"), Time.ParseFromRoundTripFormat("18.12.1998")));

            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());

            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());

            Console.WriteLine(Time.AreEqualBirthdays(Time.ParseFromRoundTripFormat("18.11.2001"), Time.ParseFromRoundTripFormat("13.12.1998")));
            Console.WriteLine(Time.AreEqualBirthdays(Time.ParseFromRoundTripFormat("06.04.2001"), Time.ParseFromRoundTripFormat("06.04.1998")));
        }
    }
}
