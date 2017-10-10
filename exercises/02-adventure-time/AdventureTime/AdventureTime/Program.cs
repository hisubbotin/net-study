using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            // first_check

            DateTime first_local = Time.WhatTimeIsIt();
            DateTime first_utc = Time.WhatTimeIsItInUtc();

            string second_str = Time.ToRoundTripFormatString(first_local);
            string third_str = Time.ToRoundTripFormatString(first_utc);

            Console.WriteLine(String.Format("second_str = {0}", second_str));
            Console.WriteLine(String.Format("third_str = {0}", third_str));

            DateTime second = Time.ParseFromRoundTripFormat(second_str);
            Console.WriteLine(String.Format("second == first_local is {0}", second == first_local));

            DateTime third = Time.ParseFromRoundTripFormat(third_str);
            Console.WriteLine(String.Format("third == first_utc is {0}", second == first_local));

            // second_check
            Console.WriteLine(" --------------- ");
            DateTime first_added = first_local.AddHours(5.5);
            int hours_first = Time.GetHoursBetween(first_added, first_local);
            Console.WriteLine(String.Format("hours_first == {0}", hours_first));
            int hours_second = Time.GetHoursBetween(first_added, first_utc);
            Console.WriteLine(String.Format("hours_second == {0}", hours_second));

            Console.WriteLine(" --------------- ");
            Console.WriteLine(String.Format("GetAdventureTimeDurationInMinutes_ver0_Dumb - {0}", Time.GetAdventureTimeDurationInMinutes_ver0_Dumb()));
            Console.WriteLine(String.Format("GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb - {0}", Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb()));
            Console.WriteLine(String.Format("GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter - {0}", Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter()));
            Console.WriteLine(String.Format("GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience - {0}", Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()));
            Console.WriteLine(String.Format("GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience - {0}", Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()));
            Console.ReadKey();
        }
    }
}
