using System;
using System.Diagnostics;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            /* ToRoundTripFormatString */
            Console.WriteLine(Time.ToRoundTripFormatString(
                Time.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
                ));
            Console.WriteLine(Time.ToRoundTripFormatString(
                Time.SpecifyKind(DateTime.Now, DateTimeKind.Local)
                ));

            /* ParseFromRoundTripFormat */
            var dt = DateTime.Now;
            var dtStr = Time.ToRoundTripFormatString(dt);
            Debug.Assert(dt == Time.ParseFromRoundTripFormat(dtStr));

            /* AddTenSeconds */
            Console.WriteLine(dt);
            Console.WriteLine(Time.AddTenSeconds(dt));
            Console.WriteLine(Time.AddTenSecondsV2(dt));

            /* GetHoursBetween */
            Console.WriteLine(Time.GetHoursBetween(dt, dt + TimeSpan.FromHours(4)));

            var testDt = new DateTime(2010, 1, 1, 0, 0, 0);
            Console.WriteLine(Time.GetHoursBetween(
                Time.SpecifyKind(testDt, DateTimeKind.Local),
                Time.SpecifyKind(dt, DateTimeKind.Local)
                ));
            Console.WriteLine(Time.GetHoursBetween(
                Time.SpecifyKind(new DateTime(2010, 1, 1, 0, 0, 0), DateTimeKind.Utc),
                Time.SpecifyKind(dt, DateTimeKind.Local)
                ));
            // Returns the same value

            /* GetTotalMinutesInThreeMonths */
            Console.WriteLine(Time.GetTotalMinutesInThreeMonths());

            /* Adventure Time Saga */
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Debug.Assert(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
                == Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());

            /* AreEqualBirthdays */
            Console.WriteLine(Time.AreEqualBirthdays(
                DateTime.Now, new DateTime(2015, 10, 29, 0, 0, 0)
                ));
        }
    }
}
