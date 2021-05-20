using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Current time:", Time.WhatTimeIsIt());
            Console.WriteLine("Current UTC time:", Time.WhatTimeIsItInUtc());

            DateTime time_now = Time.WhatTimeIsIt();
            Console.WriteLine("Current time:", time_now);
            Console.WriteLine("Current round-parsed time:", Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(time_now)));
            
            Console.WriteLine("Add ten seconds:", Time.AddTenSeconds(time_now));
            Console.WriteLine("Add ten seconds v2:", Time.AddTenSeconds(time_now));
            Console.WriteLine("Dumb", Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine("Dumb gender swapped", Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            
            Console.WriteLine("Rocket science", Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine("Rocket science gender swapped", Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            
            Console.WriteLine(Time.AreEqualBirthdays(new DateTime(2010, 3, 28, 2, 15, 0), new DateTime(2012, 3, 28, 2, 15, 0)));
            Console.WriteLine(Time.AreEqualBirthdays(new DateTime(2010, 3, 27, 2, 15, 0), new DateTime(2012, 3, 28, 2, 15, 0)));
        }
    }
}
