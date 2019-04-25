using System;
using NodaTime;
using NodaTime.TimeZones;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(Time.WhatTimeIsIt());
            Console.WriteLine(Time.WhatTimeIsItInUtc());
            Console.WriteLine(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc));
            
            Console.WriteLine("---------------------");
            
            Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local)));
            Console.WriteLine(Time.ToRoundTripFormatString(Time.SpecifyKind(Time.WhatTimeIsItInUtc(), DateTimeKind.Utc)));
            
            Console.WriteLine("---------------------");

            DateTime now_local = Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local);
            DateTime temp = Time.ParseFromRoundTripFormat(
                Time.ToRoundTripFormatString(now_local));
            Console.WriteLine(temp);
            Console.WriteLine(now_local);
            Console.WriteLine(temp == now_local);

            DateTime now_utc = Time.SpecifyKind(Time.WhatTimeIsItInUtc(), DateTimeKind.Utc);
            temp = Time.ParseFromRoundTripFormat(
                Time.ToRoundTripFormatString(now_utc));
            Console.WriteLine(temp);
            Console.WriteLine(now_utc);
            Console.WriteLine(temp == now_utc);

            DateTime now_un = Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified);
            temp = Time.ParseFromRoundTripFormat(
                Time.ToRoundTripFormatString(now_un));
            Console.WriteLine(temp == now_un);

            Console.WriteLine("---------------------");
            
            Console.WriteLine(Time.ToUtc(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Local)));
            Console.WriteLine(Time.ToUtc(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Utc)));
            Console.WriteLine(Time.ToUtc(Time.SpecifyKind(Time.WhatTimeIsIt(), DateTimeKind.Unspecified)));
            
            Console.WriteLine("---------------------");
            
            Console.WriteLine(Time.AddTenSeconds(Time.WhatTimeIsIt()));
            Console.WriteLine(Time.AddTenSecondsV2(Time.WhatTimeIsIt()));
            
            Console.WriteLine("---------------------");
            
            DateTime date1 = new DateTime(2010, 1, 1, 8, 0, 15);
            DateTime date2 = new DateTime(2011, 8, 18, 13, 30, 30);
            Console.WriteLine(Time.GetHoursBetween(date1, date2));
            
            Console.WriteLine("---------------------");
            
            Console.WriteLine(Time.GetTotalMinutesInThreeMonths());
            
            Console.WriteLine("---------------------");

            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());

            Console.WriteLine("---------------------");
            
            date1 = new DateTime(2010, 1, 1, 8, 0, 15);
            date2 = new DateTime(2011, 8, 18, 13, 30, 30);
            Console.WriteLine(Time.AreEqualBirthdays(date1, date2));
            
            date1 = new DateTime(2011, 8, 18, 8, 0, 15);
            date2 = new DateTime(2011, 8, 18, 13, 30, 30);
            Console.WriteLine(Time.AreEqualBirthdays(date1, date2));
            
            date1 = new DateTime(2011, 8, 17, 8, 0, 15);
            date2 = new DateTime(2011, 8, 18, 13, 30, 30);
            Console.WriteLine(Time.AreEqualBirthdays(date1, date2));
            
            date1 = new DateTime(2011, 7, 18, 8, 0, 15);
            date2 = new DateTime(2011, 8, 18, 13, 30, 30);
            Console.WriteLine(Time.AreEqualBirthdays(date1, date2));
            
            date1 = new DateTime(2010, 8, 18, 8, 0, 15);
            date2 = new DateTime(2011, 8, 18, 13, 30, 30);
            Console.WriteLine(Time.AreEqualBirthdays(date1, date2));
        }
    }
}
