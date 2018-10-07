using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            DateTime dt = Time.WhatTimeIsIt();

            dt = Time.SpecifyKind(dt, DateTimeKind.Unspecified);
            System.Console.WriteLine("dt = Time.SpecifyKind(dt, DateTimeKind.Unspecified);");
            Test(dt);
            System.Console.WriteLine();

            dt = Time.SpecifyKind(dt, DateTimeKind.Local);
            System.Console.WriteLine("dt = Time.SpecifyKind(dt, DateTimeKind.Local);");
            Test(dt);
            System.Console.WriteLine();

            dt = Time.SpecifyKind(dt, DateTimeKind.Utc);
            System.Console.WriteLine("dt = Time.SpecifyKind(dt, DateTimeKind.Utc);");
            Test(dt);
            System.Console.WriteLine();

            System.Console.Write("Add 10 s to ");
            System.Console.WriteLine(dt);
            System.Console.WriteLine(Time.AddTenSeconds(dt));
            System.Console.WriteLine(Time.AddTenSecondsV2(dt));
            System.Console.WriteLine();

            System.Console.Write("Time.GetAdventureTimeDurationInMinutes_ver0_Dumb(): ");
            System.Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());

            System.Console.Write("Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb(): ");
            System.Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());

            System.Console.Write("Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter(): ");
            System.Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());

            System.Console.WriteLine("Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience(): ");
            System.Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());

            System.Console.WriteLine("Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience(): ");
            System.Console.WriteLine(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());

            System.Console.Write("Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime(): ");
            System.Console.WriteLine(Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime());
        }

        private static void Test(DateTime dt)
        {
            string dtStr = Time.ToRoundTripFormatString(dt);

            System.Console.Write("To round-trip: ");
            System.Console.WriteLine(dtStr);

            System.Console.Write("Round-trip test: ");
            System.Console.WriteLine(dt == Time.ParseFromRoundTripFormat(dtStr));

            System.Console.Write("ToUtc: ");
            System.Console.WriteLine(Time.ToUtc(dt));
        }
    }
}
