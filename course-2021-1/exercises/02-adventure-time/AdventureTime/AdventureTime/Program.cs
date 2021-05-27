using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(Time.WhatTimeIsIt());
            Console.WriteLine(Time.WhatTimeIsItInUtc());
            Console.WriteLine();

            var dt_utc = Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc);
            var dt_local = Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local);
            var dt_unspec = Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified);
            Console.WriteLine(dt_utc);
            Console.WriteLine(dt_local);
            Console.WriteLine(dt_unspec);
            Console.WriteLine();

            Console.WriteLine(Time.ToRoundTripFormatString(dt_utc));
            Console.WriteLine();

            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(dt_utc)));

            Console.WriteLine();

            Console.WriteLine(Time.AddTenSeconds(dt_utc));
            Console.WriteLine(Time.AddTenSecondsV2(dt_utc));

            Console.WriteLine();

            Console.WriteLine(Time.GetHoursBetween(dt_utc, dt_utc.AddHours(3)));
            Console.WriteLine(Time.GetHoursBetween(Time.WhatTimeIsItInUtc(), Time.WhatTimeIsIt()));
            Console.WriteLine();
            Console.WriteLine(Time.GetTotalMinutesInThreeMonths());
            Console.WriteLine();


            Console.WriteLine(Time.AreEqualBirthdays(dt_utc, dt_local));
        }
    }
}
