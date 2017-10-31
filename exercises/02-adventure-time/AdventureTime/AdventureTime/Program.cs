using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            var now = Time.WhatTimeIsIt();
            var nowUtc = Time.WhatTimeIsItInUtc();
            Console.WriteLine("Now: " + now);
            Console.WriteLine("Now UTC: " + nowUtc);

            Console.WriteLine(nowUtc.Date == Time.ToUtc(now).Date);
            Console.WriteLine(now == Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(now)));
            Console.WriteLine("");

            Console.WriteLine("We are in " + Time.GetHoursBetween(nowUtc, Time.AddTenSeconds(now)) +
                              " hours ahead of UTC");
            Console.WriteLine("Minutes in 3 months: " + Time.GetTotalMinutesInThreeMonths());

            Console.WriteLine("");
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine("");

            var time1 = new DateTime(2011, 3, 28, 3, 15, 0);
            var time2 = new DateTime(2011, 4, 28, 3, 15, 0);
            var time3 = new DateTime(1970, 3, 28, 17, 45, 0);
            Console.WriteLine(Time.AreEqualBirthdays(time1, time2));
            Console.WriteLine(Time.AreEqualBirthdays(time1, time3));

            Console.ReadKey();
        }
    }
}