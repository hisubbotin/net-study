using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(Time.ToRoundTripFormatString(Time.WhatTimeIsIt()));
            Console.WriteLine(Time.WhatTimeIsIt());
            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.WhatTimeIsIt())));
            DateTime time = Time.WhatTimeIsIt();
            Console.WriteLine(time);
            Console.WriteLine(Time.AddTenSeconds(time));
            Console.WriteLine(Time.GetHoursBetween(Time.WhatTimeIsIt(), Time.WhatTimeIsItInUtc()));
            Console.WriteLine(Time.GetHoursBetween(Time.WhatTimeIsIt(), Time.WhatTimeIsItInUtc().AddDays(2)));
            Console.WriteLine(Time.GetTotalMinutesInThreeMonths(2018, 3));
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine("{0} ?= {1}", 
                Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience(),
                Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
        }
    }
}
