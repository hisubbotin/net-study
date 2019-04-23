using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            DateTime now = Time.WhatTimeIsIt();

            // протестим работу всех функций
            // ToRoundTripFormatString
            Console.WriteLine(now);
            Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(now, DateTimeKind.Utc)));

            // ParseFromRoundTripFormat
            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.SpecifyKind(now, DateTimeKind.Local))));

            // AddTenSeconds
            Console.WriteLine(Time.AddTenSeconds(Time.ParseFromRoundTripFormat("27.10.1998")));
            Console.WriteLine(Time.AddTenSecondsV2(Time.ParseFromRoundTripFormat("27.10.1998")));

            // GetTotalMinutesInThreeMonths
            //Console.WriteLine(Time.GetTotalMinutesInThreeMonths());

            // GetHoursBetween
            Console.WriteLine(Time.GetHoursBetween(Time.ParseFromRoundTripFormat("20.10.1998"), Time.ParseFromRoundTripFormat("27.10.1998")));

            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());

            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());

            Console.WriteLine(Time.AreEqualBirthdays(Time.ParseFromRoundTripFormat("27.10.1998"), Time.ParseFromRoundTripFormat("20.10.1998")));
            Console.WriteLine(Time.AreEqualBirthdays(Time.ParseFromRoundTripFormat("27.10.1998"), Time.ParseFromRoundTripFormat("27.10.2000")));
            var x = Console.ReadLine();
        }
    }
}
