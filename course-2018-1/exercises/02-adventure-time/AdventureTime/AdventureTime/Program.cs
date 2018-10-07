using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            DateTime now = DateTime.Now;

            Console.WriteLine("Local Now -- {0}", Time.WhatTimeIsIt());
            Console.WriteLine("Utc Now   -- {0}", Time.WhatTimeIsItInUtc());
            Console.WriteLine();

            Console.WriteLine("Utc kind of data -- {0}", Time.SpecifyKind(now, DateTimeKind.Utc).Kind);
            Console.WriteLine("Local kind of data -- {0}", Time.SpecifyKind(now, DateTimeKind.Local).Kind);
            Console.WriteLine("Unspecified kind of data -- {0}", Time.SpecifyKind(now, DateTimeKind.Unspecified).Kind);
            Console.WriteLine();

            Console.WriteLine("Data/time to string");
            Console.WriteLine("Utc -- {0}", Time.ToRoundTripFormatString(Time.SpecifyKind(now, DateTimeKind.Utc)));
            Console.WriteLine("Local -- {0}", Time.ToRoundTripFormatString(Time.SpecifyKind(now, DateTimeKind.Local)));
            Console.WriteLine("Unspecified -- {0}", Time.ToRoundTripFormatString(Time.SpecifyKind(now, DateTimeKind.Unspecified)));
            Console.WriteLine();

            Console.WriteLine("Data/time to string and back");
            if (Time.SpecifyKind(now, DateTimeKind.Utc) == Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.SpecifyKind(now, DateTimeKind.Utc))))
            {
                Console.WriteLine("Utc Ok");
            }
            if (Time.SpecifyKind(now, DateTimeKind.Local) == Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.SpecifyKind(now, DateTimeKind.Local))))
            {
                Console.WriteLine("Local Ok");
            }
            if (Time.SpecifyKind(now, DateTimeKind.Unspecified) == Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.SpecifyKind(now, DateTimeKind.Unspecified))))
            {
                Console.WriteLine("Unspecified Ok");
            }
            Console.WriteLine();

            Console.WriteLine("Data/time to Utc");
            Console.WriteLine(Time.ToUtc(Time.SpecifyKind(now, DateTimeKind.Local)));
            Console.WriteLine(Time.ToUtc(Time.SpecifyKind(now, DateTimeKind.Utc)));
            Console.WriteLine(Time.ToUtc(Time.SpecifyKind(now, DateTimeKind.Unspecified)));
            Console.WriteLine();

            Console.WriteLine("Add 10 sec");
            Console.WriteLine(now);
            Console.WriteLine(Time.AddTenSeconds(now));
            Console.WriteLine();

            Console.WriteLine(now);
            Console.WriteLine(Time.AddTenSecondsV2(now));
            Console.WriteLine();

            Console.WriteLine("Count of hours");
            Console.WriteLine(Time.GetHoursBetween(new DateTime(1900, 1, 1, 15, 21, 12), new DateTime(1900, 1,1,15, 32, 12))); // 0
            Console.WriteLine(Time.GetHoursBetween(new DateTime(1900, 1, 1, 15, 21, 12), new DateTime(1900, 1, 1, 16, 20, 12))); // 0
            Console.WriteLine(Time.GetHoursBetween(new DateTime(1900, 1, 1, 15, 21, 12), new DateTime(1900, 1, 1, 16, 21, 11))); // 0
            Console.WriteLine(Time.GetHoursBetween(new DateTime(1900, 1, 1, 15, 21, 12), new DateTime(1900, 1, 1, 16, 32, 12))); // 1
            Console.WriteLine(Time.GetHoursBetween(new DateTime(1900, 1, 1, 15, 21, 12), new DateTime(1900, 1, 2, 16, 32, 12))); // 25
            Console.WriteLine(Time.GetHoursBetween(new DateTime(1900, 1, 1, 15, 21, 12, DateTimeKind.Local), new DateTime(1900, 1, 1, 16, 32, 12, DateTimeKind.Utc))); // :(
            Console.WriteLine(Time.GetHoursBetween(new DateTime(1900, 1, 1, 15, 21, 12, DateTimeKind.Utc), new DateTime(1900, 1, 2, 16, 32, 12, DateTimeKind.Local))); // :(
            Console.WriteLine();

            Console.WriteLine("Count of minutes between Moscow and London");
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            if (Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience() ==
                Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience() && 
                Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime() == 
                Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience())
            {
                Console.WriteLine("Ok");
            }
            Console.WriteLine();

        }
    }
}
