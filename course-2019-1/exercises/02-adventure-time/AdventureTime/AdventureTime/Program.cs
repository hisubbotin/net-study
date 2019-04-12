using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            DateTime nowLocal = Time.WhatTimeIsIt();
            DateTime nowUtc = Time.WhatTimeIsItInUtc();
            Console.WriteLine($"nowLocal:\t\t\t{nowLocal}");
            Console.WriteLine($"nowUtc:\t\t\t\t{nowUtc}\n");

            string localConverted = Time.ToRoundTripFormatString(nowLocal);
            Console.WriteLine($"localConverted:\t\t\t{localConverted}");
            string utcConverted = Time.ToRoundTripFormatString(Time.SpecifyKind(nowLocal, DateTimeKind.Utc));
            Console.WriteLine($"utcConverted:\t\t\t{utcConverted}");
            string unspecifiedConverted = Time.ToRoundTripFormatString(Time.SpecifyKind(nowLocal, DateTimeKind.Unspecified));
            Console.WriteLine($"unspecifiedConverted:\t\t{unspecifiedConverted}\n");

            Console.WriteLine($"parsed localConverted:\t\t{Time.ParseFromRoundTripFormat(localConverted)}");
            Console.WriteLine($"parsed utcConverted:\t\t{Time.ParseFromRoundTripFormat(utcConverted)}");
            Console.WriteLine($"parsed unspecifiedConverted:\t{Time.ParseFromRoundTripFormat(unspecifiedConverted)}\n");

            Console.WriteLine($"nowLocal to utc:\t\t{Time.ToUtc(nowLocal)}");
            Console.WriteLine($"unspecified nowLocal to utc:\t{Time.ToUtc(Time.SpecifyKind(nowLocal, DateTimeKind.Unspecified))}\n");

            Console.WriteLine($"add 10 seconds:\t\t\t{Time.AddTenSeconds(nowLocal)}");
            Console.WriteLine($"add 10 seconds v2:\t\t{Time.AddTenSecondsV2(nowLocal)}\n");

            DateTime futureLocal = nowLocal.AddHours(4.6);
            Console.WriteLine($"hours from nowLocal to futureLocal:\t{Time.GetHoursBetween(nowLocal, futureLocal)}");
            Console.WriteLine($"hours from nowUtc to nowLocal:\t{Time.GetHoursBetween(nowUtc, nowLocal)}");
            Console.WriteLine($"hours from nowLocal to unspecified futureLocal:\t" +
                $"{Time.GetHoursBetween(nowLocal, Time.SpecifyKind(futureLocal, DateTimeKind.Unspecified))}");
            Console.WriteLine($"hours from nowLocal to utc futureLocal:\t" +
                $"{Time.GetHoursBetween(nowLocal, Time.SpecifyKind(futureLocal, DateTimeKind.Utc))}\n");

            Console.WriteLine($"total minutes in three months:\t{Time.GetTotalMinutesInThreeMonths()}\n");
        }
    }
}
