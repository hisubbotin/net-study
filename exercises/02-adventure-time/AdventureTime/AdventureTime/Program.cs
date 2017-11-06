using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {         
            DateTime currentTime = DateTime.Now;
            Console.WriteLine(currentTime);
            string roundTrip = Time.ToRoundTripFormatString(currentTime);
            Console.WriteLine(roundTrip);
            Console.WriteLine(Time.ParseFromRoundTripFormat(roundTrip));

            Console.WriteLine(Time.GetHoursBetween(DateTime.Now, DateTime.Now +
                TimeSpan.FromHours(2) + TimeSpan.FromDays(10))); // = -2
            Console.WriteLine(Time.GetHoursBetween(DateTime.Now, DateTime.UtcNow)); // = 2
            try
            {
                Console.WriteLine(Time.GetTotalMinutesInThreeMonths());
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(Time.AreEqualBirthdays(new DateTime(1891, 5, 1, 4, 3, 0,DateTimeKind.Unspecified),
                new DateTime(1712, 5, 1, 11, 30, 0, DateTimeKind.Unspecified)));
            var someDate = new DateTime(2010, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
            Console.WriteLine(someDate.ToUniversalTime()); // 31.12.2009 21:00:00 KEK
            Console.WriteLine("ADVENTURE TIME!!!");
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb()); // 180
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb()); // 60
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter()); // 180 
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()); // 120
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()); // 120
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime()); // 120
        }
    }
}
