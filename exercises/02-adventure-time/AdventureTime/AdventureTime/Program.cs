using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            var now = Time.WhatTimeIsIt();
            var nowUtc = Time.WhatTimeIsItInUtc();
            var nowUtc2 = DateTime.SpecifyKind(nowUtc, DateTimeKind.Local);
            Environment.Exit(1);

           

            var test = now.Hour == nowUtc.Hour;
            Console.WriteLine("Now: " + nowUtc);
            Console.WriteLine("Now UTC: " + nowUtc2);

            Console.WriteLine(nowUtc.Date == Time.ToUtc(now).Date);
            Console.WriteLine(now == Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(now)));
            Console.WriteLine("");

            Console.WriteLine("We are in " + Time.GetHoursBetween(nowUtc, Time.AddTenSeconds(now)) +
                              " hours ahead of UTC");

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