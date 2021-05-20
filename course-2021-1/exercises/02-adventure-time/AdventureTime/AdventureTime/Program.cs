using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            DateTime dt = Time.WhatTimeIsIt();
            DateTime udt = Time.WhatTimeIsItInUtc();

            Console.WriteLine(dt);
            Console.WriteLine(udt);

            // all the same
            Console.WriteLine(Time.SpecifyKind(dt, DateTimeKind.Utc));
            Console.WriteLine(Time.SpecifyKind(dt, DateTimeKind.Local));
            Console.WriteLine(Time.SpecifyKind(dt, DateTimeKind.Unspecified));

            var roundtrip = Time.ToRoundTripFormatString(dt);
            Console.WriteLine(roundtrip);
            Console.WriteLine(Time.ParseFromRoundTripFormat(roundtrip));

            Console.WriteLine(Time.AddTenSeconds(dt));
            Console.WriteLine(Time.AddTenSecondsV2(dt));

            Console.WriteLine(Time.GetHoursBetween(udt, dt));
            Console.WriteLine(Time.GetTotalMinutesInThreeMonths());

            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime());

            Console.WriteLine(Time.AreEqualBirthdays(dt, udt));
            Console.WriteLine(Time.AreEqualBirthdays(dt, udt.AddDays(1)));
        }
    }
}
