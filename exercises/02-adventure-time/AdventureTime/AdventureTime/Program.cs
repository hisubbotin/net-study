using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {

            Console.WriteLine("Now: " + Time.WhatTimeIsIt());
            Console.WriteLine("Now UTC: " + Time.WhatTimeIsItInUtc());
            
            Console.WriteLine("Minutes in 3 months: " + Time.GetTotalMinutesInThreeMonths());
            
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            
            var birthday1 = new DateTime(1997, 12, 17, 12, 32, 0);
            var birthday2 = new DateTime(1996, 12, 17, 15, 19, 0);
            Console.WriteLine(Time.AreEqualBirthdays(birthday1, birthday2));
            
            Console.ReadKey();
        }
    }
}
