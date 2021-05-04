using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("WhatTimeIsIt test");
            Console.WriteLine(Time.WhatTimeIsIt());
            Console.WriteLine(Time.WhatTimeIsItInUtc());

            Console.WriteLine();

            Console.WriteLine("SpecifyKind test");
            DateTime curr_time = Time.WhatTimeIsIt();
            DateTime curr_time_local = Time.SpecifyKind(curr_time, DateTimeKind.Local);
            DateTime curr_time_utc = Time.SpecifyKind(curr_time, DateTimeKind.Utc);
            DateTime curr_time_unspecified = Time.SpecifyKind(curr_time, DateTimeKind.Unspecified);
            Console.WriteLine(curr_time_local);
            Console.WriteLine(curr_time_utc);
            Console.WriteLine(curr_time_unspecified);

            Console.WriteLine();

            Console.WriteLine("ParseFromRoundTripFormat test");
            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(curr_time_local)));
            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(curr_time_utc)));
            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(curr_time_unspecified)));

            Console.WriteLine();

            Console.WriteLine("ToRoundTripFormatString test");
            Console.WriteLine(Time.ToRoundTripFormatString(curr_time_local));
            Console.WriteLine(Time.ToRoundTripFormatString(curr_time_utc));
            Console.WriteLine(Time.ToRoundTripFormatString(curr_time_unspecified));

            Console.WriteLine();

            Console.WriteLine("AddTenSeconds test");
            Console.WriteLine(Time.AddTenSeconds(curr_time_local));
            Console.WriteLine(Time.AddTenSeconds(curr_time_utc));
            Console.WriteLine(Time.AddTenSeconds(curr_time_unspecified));

            Console.WriteLine();

            Console.WriteLine("AddTenSecondsV2 test");
            Console.WriteLine(Time.AddTenSecondsV2(curr_time_local));
            Console.WriteLine(Time.AddTenSecondsV2(curr_time_utc));
            Console.WriteLine(Time.AddTenSecondsV2(curr_time_unspecified));

            Console.WriteLine();

            Console.WriteLine("GetHoursBetween test");
            DateTime curr_time_utc_3_hours = curr_time_utc.AddHours(3);
            Console.WriteLine(Time.GetHoursBetween(curr_time_utc, curr_time_utc_3_hours));
            Console.WriteLine(Time.GetHoursBetween(curr_time_utc_3_hours, curr_time_utc));
            Console.WriteLine(Time.GetHoursBetween(curr_time_local, curr_time_utc));

            Console.WriteLine();

            Console.WriteLine("GetTotalMinutesInThreeMonths test");
            Console.WriteLine(Time.GetTotalMinutesInThreeMonths());

            Console.WriteLine();

            Console.WriteLine("GetAdventureTimeDurationInMinutes_ver0_Dumb test");
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());

            Console.WriteLine();

            Console.WriteLine("GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb test");
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());

            Console.WriteLine();

            Console.WriteLine("GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter test");
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());

            Console.WriteLine();

            Console.WriteLine("GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience test");
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());

            Console.WriteLine();

            Console.WriteLine("GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience test");
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());

            Console.WriteLine();

            Console.WriteLine("AreEqualBirthdays test");
            Console.WriteLine(Time.AreEqualBirthdays(curr_time, curr_time_utc));
            Console.WriteLine(Time.AreEqualBirthdays(curr_time, curr_time.AddYears(-3)));
        }
    }
}
