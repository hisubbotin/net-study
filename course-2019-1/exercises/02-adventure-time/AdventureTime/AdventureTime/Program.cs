using System;
using System.Diagnostics;
namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            var nowUtc = Time.WhatTimeIsItInUtc();
            var nowLocal = Time.WhatTimeIsIt();
            var utcTimeStr = Time.ToRoundTripFormatString(nowUtc);
            var localTimeStr = Time.ToRoundTripFormatString(nowLocal);
            Console.WriteLine("utc time {0}", utcTimeStr);
            Console.WriteLine("local time {0}", localTimeStr);
            var decodedUtc = Time.ParseFromRoundTripFormat(utcTimeStr);
            var decodedLocal = Time.ParseFromRoundTripFormat(localTimeStr);
            Debug.Assert(decodedUtc == nowUtc);
            Debug.Assert(decodedLocal == nowLocal);
            var diffMin = Time.GetAdventureTimeDurationInMinutes_ver0_Dumb();
            return;
        }
    }
}
