using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            DateTime time = DateTime.Now;
            string str = Time.ToRoundTripFormatString(time);
            Console.WriteLine(str);
            Console.WriteLine(DateTime.Parse(str));
            Console.WriteLine(time);

            Console.WriteLine(Time.AddTenSeconds(time));
            Console.WriteLine(Time.AddTenSecondsV2(time));
            Console.WriteLine(Time.GetHoursBetween(time, time.AddHours(4)));
            Console.WriteLine(Time.GetHoursBetween(time, time.AddHours(25)));

            Console.WriteLine(Time.GetHoursBetween(time, time.AddDays(2)));

            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());

            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            Console.ReadKey();

        }
    }
}
