using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("WhatTimeIsIt: " + Time.WhatTimeIsIt());
            Console.WriteLine("WhatTimeIsItInUtc: " + Time.WhatTimeIsItInUtc());
            Console.WriteLine();

            DateTime dt1 = DateTime.Now;
            DateTime dt2 = Time.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            DateTime dt3 = Time.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            Console.WriteLine("SpecifyKind (Local -> UTC): " + dt2);
            Console.WriteLine("SpecifyKind (UTC -> Local): " + Time.SpecifyKind(DateTime.UtcNow, DateTimeKind.Local));
            Console.WriteLine("SpecifyKind (Local -> Unspecified): " + dt3);
            Console.WriteLine();

            string str1 = Time.ToRoundTripFormatString(dt1);
            string str2 = Time.ToRoundTripFormatString(dt2);
            string str3 = Time.ToRoundTripFormatString(dt3);
            Console.WriteLine("ToRoundTripFormatString (Local): " + str1);
            Console.WriteLine("ToRoundTripFormatString (UTC): " + str2);
            Console.WriteLine("ToRoundTripFormatString (Unspecified): " + str3);
            Console.WriteLine();

            dt1 = Time.ParseFromRoundTripFormat(str1);
            dt2 = Time.ParseFromRoundTripFormat(str2);
            dt3 = Time.ParseFromRoundTripFormat(str3);
            Console.WriteLine("ParseFromRoundTripFormat (Local): " + dt1 + ", " + dt1.Kind);
            Console.WriteLine("ParseFromRoundTripFormat (UTC): " + dt2 + ", " + dt2.Kind);
            Console.WriteLine("ParseFromRoundTripFormat (Unspecified): " + dt3 + ", " + dt3.Kind);
            Console.WriteLine();

            Console.WriteLine("ToUtc (Local): " + Time.ToUtc(dt1));
            Console.WriteLine("ToUtc (UTC): " + Time.ToUtc(dt2));
            Console.WriteLine("ToUtc (Unspecified): " + Time.ToUtc(dt3));
            Console.WriteLine();

            Console.WriteLine("AddTenSeconds: " + Time.AddTenSeconds(dt1));
            Console.WriteLine("AddTenSeconds: " + Time.AddTenSecondsV2(dt1));
            Console.WriteLine();

            DateTime birthday1 = new DateTime(2001, 5, 6, 8, 23, 42);
            DateTime birthday2 = new DateTime(2005, 5, 6, 8, 23, 42);
            DateTime birthday3 = new DateTime(2001, 2, 15, 8, 23, 42);
            Console.WriteLine("GetTotalMinutesInThreeMonths: " + Time.GetTotalMinutesInThreeMonths());
            Console.WriteLine($"AreEqualBirthdays({birthday1}, {birthday2}): " + Time.AreEqualBirthdays(birthday1, birthday2));
            Console.WriteLine($"AreEqualBirthdays({birthday1}, {birthday3}): " + Time.AreEqualBirthdays(birthday1, birthday3));
            Console.WriteLine();

            Console.WriteLine("GetAdventureTimeDurationInMinutes_ver0_Dumb: " + Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine("GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb: " + Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine("GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter: " + Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            Console.WriteLine();

            Console.WriteLine("GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience: " + Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine();

            Console.WriteLine("GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience: " + Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine();

            Console.WriteLine("GetAdventureTimeDurationInMinutes_ver3_NodaTime: " + Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime());
            Console.WriteLine();

            DateTime dt4 = dt1.AddMinutes(1520);
            Console.WriteLine($"GetHoursBetween({dt1}, {dt4}): {Time.GetHoursBetween(dt1, dt4)}");
            Console.WriteLine($"GetHoursBetween(Local, UTC): {Time.GetHoursBetween(dt1, Time.ToUtc(dt1))}");
            Console.WriteLine();
        }
    }
}
