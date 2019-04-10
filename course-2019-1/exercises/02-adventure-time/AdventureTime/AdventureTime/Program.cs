using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("WhatTimeIsIt \t\t: " + $"{ Time.WhatTimeIsIt() }");
            Console.WriteLine("WhatTimeIsItInUtc\t: " + Time.WhatTimeIsItInUtc());

            var str_datetime_utc = Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc));
            var str_datetime_local = Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local));
            var str_datetime_unspec = Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified));
            
            Console.WriteLine("ToRoundTripFormatString -- DateTimeKind: Utc\t\t: " + str_datetime_utc);
            Console.WriteLine("ParseFromRoundTripFormat\t\t\t\t: {0}", Time.ParseFromRoundTripFormat(str_datetime_utc));
            
            Console.WriteLine("ToRoundTripFormatString -- DateTimeKind: Local\t\t: " + str_datetime_local);
            Console.WriteLine("ParseFromRoundTripFormat\t\t\t\t: {0}", Time.ParseFromRoundTripFormat(str_datetime_local));
            
            Console.WriteLine("ToRoundTripFormatString -- DateTimeKind: Unspecified\t: " + str_datetime_unspec);
            Console.WriteLine("ParseFromRoundTripFormat\t\t\t\t: {0}", Time.ParseFromRoundTripFormat(str_datetime_unspec));
            
            Console.WriteLine("WhatTimeIsIt \t\t: " + $"{ Time.WhatTimeIsIt() }");
            Console.WriteLine("ToUtc \t\t\t: " + $"{Time.ToUtc(Time.WhatTimeIsIt())}");
            Console.WriteLine("WhatTimeIsItInUtc\t: " + Time.WhatTimeIsItInUtc());
            
            Console.WriteLine("WhatTimeIsIt \t\t: " + $"{ Time.WhatTimeIsIt() }");
            Console.WriteLine("AddTenSeconds \t\t: " + $"{ Time.AddTenSeconds(Time.WhatTimeIsIt()) }");
            Console.WriteLine("AddTenSecondsV2 \t: " + $"{ Time.AddTenSecondsV2(Time.WhatTimeIsIt()) }");
            
            Console.WriteLine("GetAdventureTimeDurationInMinutes_ver0_Dumb\t\t\t: " + $"{ Time.GetAdventureTimeDurationInMinutes_ver0_Dumb() }");
            Console.WriteLine("GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb\t: " + $"{ Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb() }");
            Console.WriteLine("GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter\t\t: " + $"{ Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter() }");
        }
    }
}
