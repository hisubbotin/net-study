using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(Time.WhatTimeIsIt());
            Console.WriteLine(Time.WhatTimeIsItInUtc());

            Console.WriteLine(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local));
            Console.WriteLine(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc));
            Console.WriteLine(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified));

            Console.WriteLine(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local).ToLocalTime());
            Console.WriteLine(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc).ToLocalTime());
            Console.WriteLine(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified).ToLocalTime());

            Console.WriteLine(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local).ToUniversalTime());
            Console.WriteLine(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc).ToUniversalTime());
            Console.WriteLine(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified).ToUniversalTime());

            Console.WriteLine(Time.ToRoundTripFormatString(Time.WhatTimeIsIt()));
            Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local)));
            Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc)));
            Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified)));

            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.WhatTimeIsIt())));
            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local))));
            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc))));
            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified))));

            Console.WriteLine(Time.ToUtc(Time.WhatTimeIsIt()));
            Console.WriteLine(Time.ToUtc(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local)));
            Console.WriteLine(Time.ToUtc(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc)));
            Console.WriteLine(Time.ToUtc(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified)));

            Console.WriteLine(Time.AddTenSeconds(Time.WhatTimeIsIt()));
            Console.WriteLine(Time.AddTenSeconds(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local)));
            Console.WriteLine(Time.AddTenSeconds(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc)));
            Console.WriteLine(Time.AddTenSeconds(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified)));

            Console.WriteLine(Time.AddTenSecondsV2(Time.WhatTimeIsIt()));
            Console.WriteLine(Time.AddTenSecondsV2(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local)));
            Console.WriteLine(Time.AddTenSecondsV2(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc)));
            Console.WriteLine(Time.AddTenSecondsV2(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified)));

            Console.WriteLine(Time.GetHoursBetween(Time.WhatTimeIsIt(), new DateTime(2021, 5, 8, 10, 0, 0)));
            Console.WriteLine(Time.GetHoursBetween(new DateTime(2021, 5, 8, 10, 0, 0), Time.WhatTimeIsIt()));
            Console.WriteLine(Time.GetHoursBetween(Time.WhatTimeIsIt(), Time.WhatTimeIsIt()));
            Console.WriteLine(Time.GetHoursBetween(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local), Time.SpecifyKind(new DateTime(2021, 5, 8, 10, 0, 0), DateTimeKind.Local)));
            Console.WriteLine(Time.GetHoursBetween(Time.SpecifyKind(new DateTime(2021, 5, 8, 10, 0, 0), DateTimeKind.Local), Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local)));
            Console.WriteLine(Time.GetHoursBetween(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local), Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local)));
            Console.WriteLine(Time.GetHoursBetween(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc), Time.SpecifyKind(new DateTime(2021, 5, 8, 10, 0, 0), DateTimeKind.Utc)));
            Console.WriteLine(Time.GetHoursBetween(Time.SpecifyKind(new DateTime(2021, 5, 8, 10, 0, 0), DateTimeKind.Utc), Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc)));
            Console.WriteLine(Time.GetHoursBetween(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc), Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc)));
            Console.WriteLine(Time.GetHoursBetween(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified), Time.SpecifyKind(new DateTime(2021, 5, 8, 10, 0, 0), DateTimeKind.Unspecified)));
            Console.WriteLine(Time.GetHoursBetween(Time.SpecifyKind(new DateTime(2021, 5, 8, 10, 0, 0), DateTimeKind.Unspecified), Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified)));
            Console.WriteLine(Time.GetHoursBetween(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified), Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified)));

            Console.WriteLine(Time.GetTotalMinutesInThreeMonths());

            Console.WriteLine(Time.AreEqualBirthdays(new DateTime(2000, 6, 7), new DateTime(1995, 3, 5)));
            Console.WriteLine(Time.AreEqualBirthdays(new DateTime(1995, 3, 5), new DateTime(1995, 3, 5)));

            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
        }
    }
}
