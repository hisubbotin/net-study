using System;

namespace AdventureTime
{
    internal static class Time
    {
        internal static DateTime WhatTimeIsIt()
        {
            return DateTime.Now;
        }

        internal static DateTime WhatTimeIsItInUtc()
        {
            return DateTime.UtcNow;
        }

        internal static DateTime ParseDateTime(string dtStr)
        {
            return DateTime.Parse(dtStr, System.Globalization.CultureInfo.InvariantCulture);
        }

        internal static DateTime ToUtc(DateTime dt)
        {
            return dt.ToUniversalTime();
        }

        internal static DateTime AddTenSeconds(DateTime dt)
        {
            return dt.Add(new TimeSpan(0, 0, 10));   
        }

        internal static int GetHoursBetween(DateTime dt1, DateTime dt2)
        {
            TimeSpan diff = dt1 - dt2;
            return diff.Hours;
        }

        internal static int GetTotalMinutesInThreeMonths()
        {
             return new TimeSpan (30*3 /*probably*/, 0, 0,  0).Minutes; 
        }

        internal static int GetParticularTravelDurationInMinutes()
        {
                
            var fromLondon = new DateTimeOffset(2010, 3, 28, 1, 15, 0, TimeSpan.FromHours(1));
            var toMoscow = new DateTimeOffset(2010, 3, 28, 5, 0, 0, TimeSpan.FromHours(3));
            return toMoscow.Subtract(fromLondon).Minutes;
        }

        internal static void GetBirthdate()
        {
            //C# First appeared: 2000; 17 years ago
            return;
        }
    }
}
