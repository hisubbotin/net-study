using System;
using NodaTime;
using NodaTime.TimeZones;
namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {

            DateTime a = Time.WhatTimeIsIt();
            Console.WriteLine(a.ToString());
            DateTime q = Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(a));
            if (a==q)
            {
                Console.WriteLine("True");
            }
            Console.WriteLine(a);
            Console.WriteLine(Time.ParseFromRoundTripFormat("01.02.1999"));
            Console.WriteLine(Time.AreEqualBirthdays(a, Time.ParseFromRoundTripFormat("01.02.1999")));
            Console.WriteLine(Time.GetTotalMinutesInThreeMonths(a));
            DateTime b = Time.SpecifyKind(a, DateTimeKind.Utc);
            DateTime c = Time.SpecifyKind(a, DateTimeKind.Local);
            Console.WriteLine(Time.GetHoursBetween(b, c));
            Console.ReadLine();
        }
    }
}
