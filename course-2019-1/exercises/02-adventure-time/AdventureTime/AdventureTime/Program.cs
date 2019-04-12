using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Current Time " + Time.WhatTimeIsIt());
            Console.WriteLine("Current Time(UTC) " + Time.WhatTimeIsItInUtc());
            Console.WriteLine("Current Time(round-trip format) " + Time.ToRoundTripFormatString(Time.WhatTimeIsIt()));

            Console.WriteLine("------------------------------------------");

            DateTime dt = Time.WhatTimeIsIt();
            Console.WriteLine("Time " + dt);
            Console.WriteLine("Time + 10sec " + Time.AddTenSeconds(dt));
            Console.WriteLine("Time + 10sec " + Time.AddTenSecondsV2(dt));
            Console.WriteLine("Difference in Hours (must be 0)" + Time.GetHoursBetween(Time.AddTenSeconds(dt), Time.AddTenSecondsV2(dt)));
            Console.WriteLine("Minutes in 3 months " + Time.GetTotalMinutesInThreeMonths());

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Adventure Time!");

            Console.WriteLine("Dumb duration ver0 " + Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine("Dumb gender swapeped duration ver0 " + Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine("Dumb gender swapeped duration ver1 " + Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            Console.WriteLine("Dumb gender swapeped duration ver2 " + Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());

            Console.WriteLine("------------------------------------------");

            DateTime fstPersonBirthday = new DateTime(2019, 3, 3, 3, 3, 3);
            DateTime sndPersonBirthday = new DateTime(2019, 3, 3, 6, 6, 6);

            Console.WriteLine(Time.ToRoundTripFormatString(fstPersonBirthday));
            Console.WriteLine(Time.ToRoundTripFormatString(sndPersonBirthday));
            Console.WriteLine(Time.AreEqualBirthdays(fstPersonBirthday, sndPersonBirthday));

            Console.ReadLine();   
        }
    }
}
