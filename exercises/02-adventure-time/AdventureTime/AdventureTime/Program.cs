using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            var now = Time.WhatTimeIsIt();

            var nowUTC = Time.WhatTimeIsItInUtc();

            /*DateTime now = Time.WhatTimeIsIt();
            String nowStr = Time.ToRoundTripFormatString(now);
            DateTime now2 = Time.ParseFromRoundTripFormat(nowStr);
            Console.WriteLine(Time.ToRoundTripFormatString(now));
            Console.WriteLine(Time.ToRoundTripFormatString(now2));*/

            /*var nowUTC = Time.ToUtc(now);
            Console.WriteLine(Time.ToRoundTripFormatString(nowUTC));*/

            //Console.WriteLine(Time.GetHoursBetween(now, nowUTC)); -> -2?

            //Console.WriteLine(Time.GetTotalMinutesInThreeMonths());

            //Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());

            /*Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());*/

            //Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()); -> 120
        }
    }
}
