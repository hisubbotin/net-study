using System;

namespace AdventureTime
{
    internal static class Time
    {
        internal static DateTime WhatTimeIsIt()
        {
            return DateTime.Now;
            //throw new NotImplementedException();
        }

        internal static DateTime WhatTimeIsItInUtc()
        {
            return DateTime.UtcNow;
            //throw new NotImplementedException();
        }

        internal static DateTime ParseDateTime(string dtStr)
        {
            //throw new NotImplementedException();
            return DateTime.Parse(dtStr);
        }

        internal static DateTime ToUtc(DateTime dt)
        {
            //throw new NotImplementedException();
            return dt.ToUniversalTime();
        }

        internal static DateTime AddTenSeconds(DateTime dt)
        {
            //throw new NotImplementedException();
            return dt.AddSeconds(10);
        }

        internal static int GetHoursBetween(DateTime dt1, DateTime dt2)
        {
            //throw new NotImplementedException();
            TimeSpan delta = dt1 - dt2;
            return delta.Hours;
        }

        internal static int GetTotalMinutesInThreeMonths()
        {
            //throw new NotImplementedException();
            DateTime dt1 = new DateTime();
            DateTime dt2 = dt1.AddMonths(3);
            TimeSpan ts = dt2 - dt1;
            return (int)ts.TotalMinutes;
        }

        internal static int GetParticularTravelDurationInMinutes()
        {
            var fromLondon = new DateTimeOffset(2010, 3, 28, 1, 15, 0, TimeSpan.FromHours(1));
            var toMoscow = new DateTimeOffset(2010, 3, 28, 5, 0, 0, TimeSpan.FromHours(4));

            TimeSpan duration = toMoscow - fromLondon;
            return (int)duration.TotalMinutes;
            //throw new NotImplementedException();
        }

        internal static DateTime GetBirthdate()
        {
            //throw new NotImplementedException();
            return new DateTime(year: 1994, month: 10, day: 12);
        }   
    }
}
