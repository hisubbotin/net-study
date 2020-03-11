using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            // current time test
            Console.WriteLine("Testing returning current time.....");
            DateTime curr_time = Time.WhatTimeIsIt();
            DateTime curr_time_utc = Time.WhatTimeIsItInUtc();
            Console.WriteLine("Now: {0}", 
                Time.ToRoundTripFormatString(curr_time)
                );
            Console.WriteLine("Now UTC: {0}", 
                Time.ToRoundTripFormatString(curr_time_utc)
                );

            // specifying kind test
            Console.WriteLine("\nTesting specifying.....");
            DateTime curr_time_local_kind = Time.SpecifyKind(curr_time, DateTimeKind.Local);
            DateTime curr_time_unspec_kind = Time.SpecifyKind(curr_time, DateTimeKind.Unspecified);
            DateTime curr_time_utc_kind = Time.SpecifyKind(curr_time, DateTimeKind.Utc);
            Console.WriteLine("Now Local Kind: {0}", 
                Time.ToRoundTripFormatString(curr_time_local_kind)
                );
            Console.WriteLine("Now Unspec Kind: {0}", 
                Time.ToRoundTripFormatString(curr_time_unspec_kind)
                );
            Console.WriteLine("Now Utc Kind: {0}", 
                Time.ToRoundTripFormatString(curr_time_utc_kind)
                );

            // parsing round-trip format test
            Console.WriteLine("\nTesting parsing from round-trip format string.....");
            if (curr_time_utc_kind != Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(curr_time_utc_kind)))
                Console.WriteLine("Oh no duuuude smth went wrong with utc kind");
            else
                Console.WriteLine("Yeah maaan");
            if (curr_time_local_kind != Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(curr_time_local_kind)))
                Console.WriteLine("Oh no duuuude smth went wrong with local kind");
            else
                Console.WriteLine("Yeah maaan");
            if (curr_time_unspec_kind != Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(curr_time_unspec_kind)))
                Console.WriteLine("Oh no duuuude smth went wrong with unspecified kind");
            else
                Console.WriteLine("Yeah maaan");
            
            
            // converting to utc time test
            Console.WriteLine("\nTesting converting.....");
            Console.WriteLine("Local REAL: {0}", 
                Time.ToRoundTripFormatString(curr_time_local_kind)
                );
            Console.WriteLine("Local: {0}",
                Time.ToRoundTripFormatString(Time.ToUtc(curr_time_local_kind))
                );
            Console.WriteLine("Unspec REAL: {0}", 
                Time.ToRoundTripFormatString(curr_time_unspec_kind)
                );
            Console.WriteLine("Unspec (== Local): {0}", 
                Time.ToRoundTripFormatString(Time.ToUtc(curr_time_unspec_kind))
                );
            Console.WriteLine("UTC REAL: {0}", 
                Time.ToRoundTripFormatString(curr_time_utc_kind)
                );
            Console.WriteLine("UTC: {0}", 
                Time.ToRoundTripFormatString(Time.ToUtc(curr_time_utc_kind))
                );
            
            // adding 10 seconds test
            Console.WriteLine("\nTesting adding 10 seconds.....");
            Console.WriteLine("UTC REAL: {0}", 
                Time.ToRoundTripFormatString(curr_time_utc_kind)
                );
            Console.WriteLine("UTC REAL + 10s: {0}", 
                Time.ToRoundTripFormatString(Time.AddTenSeconds(curr_time_utc_kind))
                );
            
            // adding 10 seconds test v2
            Console.WriteLine("\nTesting adding 10 seconds (v2).....");
            Console.WriteLine("UTC REAL: {0} ", 
                Time.ToRoundTripFormatString(curr_time_utc_kind)
                );
            Console.WriteLine("UTC REAL + 10s: {0}",
                Time.ToRoundTripFormatString(Time.AddTenSecondsV2(curr_time_utc_kind))
                );

            // getting hours between testing
            DateTime curr_time_utc_10_hours = curr_time_utc_kind.AddHours(10);
            Console.WriteLine("\nTesting getting hours between two dates.....");
            Console.WriteLine("10 hours, utc kind: {0}", 
                Time.GetHoursBetween(curr_time_utc_kind, curr_time_utc_10_hours)
                );
            Console.WriteLine("10 hours, utc kind, other arguments order: {0}", 
                Time.GetHoursBetween(curr_time_utc_10_hours, curr_time_utc_kind)
                );
            
            //DateTime curr_time_local_10_hours = curr_time_local_kind.AddHours(10);
            Console.WriteLine("0 hours, between utc and local kind time: {0}", 
                Time.GetHoursBetween(curr_time_local_kind, curr_time_utc_kind)
                );

            /*
            DateTime curr_time_unspec_10_hours = curr_time_unspec_kind.AddHours(10);
            Console.WriteLine("10 hours: {0}", 
                Time.GetHoursBetween(curr_time_unspec_kind, curr_time_unspec_10_hours)
                );
            */
            
            // adventure testing
            Console.WriteLine("\nTesting first adventure.....");
            Console.WriteLine("Minutes: {0}", 
                Time.GetAdventureTimeDurationInMinutes_ver0_Dumb()
                );
            
            Console.WriteLine("\nTesting second adventure.....");
            Console.WriteLine("Minutes: {0}", 
                Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb()
            );
            
            Console.WriteLine("\nTesting third adventure.....");
            Console.WriteLine("Minutes: {0}", 
                Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter()
            );
            
            Console.WriteLine("\nTesting forth adventure.....");
            Console.WriteLine("Minutes: {0}", 
                Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
            );
            
            Console.WriteLine("\nTesting fifth adventure.....");
            Console.WriteLine("Minutes: {0}", 
                Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
            );
            
            // birthday testing
            Console.WriteLine("\nTesting birthday equality.....");
            DateTime p1b = Time.WhatTimeIsIt();
            DateTime p2b = Time.ToUtc(p1b);
            Console.WriteLine("Must be true: {0}",
                Time.AreEqualBirthdays(p1b, p2b)
                );
            
            DateTime p2b3 = p2b.AddYears(-20);
            Console.WriteLine("Must be true: {0}",
                Time.AreEqualBirthdays(p1b, p2b3)
            );
            
            DateTime p2b2 = p2b + TimeSpan.FromDays(-1);
            Console.WriteLine("Must be false: {0}",
                Time.AreEqualBirthdays(p1b, p2b2)
                );
        }
        
    }
}
