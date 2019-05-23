using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            var time = DateTime.Now;
            Console.WriteLine("time: " + $"{ time }");
            var parsed = Time.ToRoundTripFormatString(time);
            Console.WriteLine("parsed: " + parsed);
            var time2 = Time.ParseFromRoundTripFormat(parsed);


            Console.WriteLine("time2: " + $"{ time2 }");
            Console.WriteLine(time == time2);

            /*
            
            Console.WriteLine("Time now: " + $"{ Time.WhatTimeIsIt() }");
            Console.WriteLine("Time now Utc: " + Time.WhatTimeIsItInUtc());

            //Console.WriteLine();

            var str_datetime_utc = Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc));
            var str_datetime_local = Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local));
            var str_datetime_unspec = Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified));

            Console.WriteLine();

            Console.WriteLine("ToRoundTripFormatString | DateTimeKind.Utc: " + str_datetime_utc);
            Console.WriteLine("ParseFromRoundTripFormat: {0}", Time.ParseFromRoundTripFormat(str_datetime_utc));

            Console.WriteLine();

            Console.WriteLine("ToRoundTripFormatString | DateTimeKind.Local: " + str_datetime_local);
            Console.WriteLine("ParseFromRoundTripFormat: {0}", Time.ParseFromRoundTripFormat(str_datetime_local));

            Console.WriteLine();

            Console.WriteLine("ToRoundTripFormatString | DateTimeKind.Unspecified: " + str_datetime_unspec);
            Console.WriteLine("ParseFromRoundTripFormat: {0}", Time.ParseFromRoundTripFormat(str_datetime_unspec));

            Console.WriteLine();

            Console.WriteLine("Time now: " + $"{ Time.WhatTimeIsIt() }");
            Console.WriteLine("Time now to Utc: " + $"{Time.ToUtc(Time.WhatTimeIsIt())}");
            Console.WriteLine("Time now Utc: " + Time.WhatTimeIsItInUtc());

            Console.WriteLine();

            Console.WriteLine("Time now: " + $"{ Time.WhatTimeIsIt() }");
            Console.WriteLine("AddTenSeconds: " + $"{ Time.AddTenSeconds(Time.WhatTimeIsIt()) }");
            Console.WriteLine("AddTenSecondsV2: " + $"{ Time.AddTenSecondsV2(Time.WhatTimeIsIt()) }");

            Console.WriteLine();

            Console.WriteLine("GetAdventureTimeDurationInMinutes_ver0_Dumb\t\t\t: " + $"{ Time.GetAdventureTimeDurationInMinutes_ver0_Dumb() }");
            Console.WriteLine("GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb\t: " + $"{ Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb() }");
            Console.WriteLine("GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter\t\t: " + $"{ Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter() }");
            */
        }
    }
}
