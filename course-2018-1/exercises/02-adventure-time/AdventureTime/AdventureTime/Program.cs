using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// #define print Console.WriteLine // да всмысле, почему нельзя(
// TODO что-то не так с тестами. Xunit не подключается. Скачиваемый Xunit не подходит.

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            if (Time.WhatTimeIsIt() == Time.WhatTimeIsItInUtc())
                Console.WriteLine("Say 'God bless the queen!'\n");

            //if (Time.WhatTimeIsIt() != Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.WhatTimeIsIt())))
            //    Console.WriteLine("Time was converted wrongly!");
            Console.WriteLine(Time.WhatTimeIsIt());
            Console.WriteLine(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(Time.WhatTimeIsIt())));
           
            Console.WriteLine(Time.ToUtc(DateTime.Now));
            Console.WriteLine(DateTime.Now - TimeSpan.FromHours(3));

            
            DateTime dt1 = new DateTime(2010, 10, 10, 7, 0, 0);
            DateTime dt2 = new DateTime(2010, 10, 10, 14, 0, 0);
            if (Time.GetHoursBetween(dt1, dt2) != 7)
                Console.WriteLine("\nCAPTAIN!!! LOOOOOK!!\n");

            Assert.AreEqual(180, Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Assert.AreEqual(180, Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Assert.AreEqual(180, Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            Assert.AreEqual(Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime(), Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Assert.AreEqual(Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime(), Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());


            Console.WriteLine("It's time to commit\n");
        }
        
    }
}
