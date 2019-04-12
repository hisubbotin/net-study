using System;
using NodaTime;
using NodaTime.TimeZones;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("current time                         : ");
            Console.WriteLine(Time.WhatTimeIsIt());
            Console.Write("current time (UTC)                   : ");
            Console.WriteLine(Time.WhatTimeIsItInUtc());
            Console.Write("current time (kind UTC)              : ");
            Console.WriteLine(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc));

            Console.WriteLine();

            Console.Write("current time (kind - local)          : ");
            Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local)));

            Console.Write("current time (kind - utc)            : ");
            Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsItInUtc(), DateTimeKind.Utc)));

            Console.WriteLine();

            Console.Write("parsed time (kind - local)           : ");
            Console.WriteLine(Time.ParseFromRoundTripFormat(
                Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local))));
            Console.Write("parsed time (kind - UTC)             : ");
            Console.WriteLine(Time.ParseFromRoundTripFormat(
                Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsItInUtc(), DateTimeKind.Utc))));

            Console.WriteLine();

            Console.Write("to utc specify time (kind - local)   : ");
            Console.WriteLine(Time.ToUtc(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local)));
            Console.Write("to utc specify time (kind - utc)     : ");
            Console.WriteLine(Time.ToUtc(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc)));
            Console.Write("to utc specify time (kind - unspec)  : ");
            Console.WriteLine(Time.ToUtc(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified)));

            Console.WriteLine();

            Console.Write("add 10 seconds                       : ");
            Console.WriteLine(Time.AddTenSeconds(Time.WhatTimeIsIt()));
            Console.Write("add 10 seconds v2                    : ");
            Console.WriteLine(Time.AddTenSecondsV2(Time.WhatTimeIsIt()));

            Console.WriteLine();

            Console.Write("TotalMinutesInThreeMonths            : ");
            Console.WriteLine(Time.GetTotalMinutesInThreeMonths());

            Console.WriteLine();

            DateTime date1;
            DateTime date2;

            date1 = new DateTime(1998, 1, 11, 1, 2, 3);
            date2 = new DateTime(1998, 1, 11, 6, 5, 4);
            Console.WriteLine(Time.AreEqualBirthdays(date1, date2));

            date1 = new DateTime(1961, 11, 12, 10, 10, 10);
            date2 = new DateTime(1961, 11, 11, 11, 11, 11);
            Console.WriteLine(Time.AreEqualBirthdays(date1, date2));

            Console.ReadLine();
        }
    }
}
