using System;
using System.Globalization;
using Xunit;

namespace AdventureTime.Test
{
    public class UnitTest1
    {
        [Fact]
        public void CurrentIsNotUtc()
        {
            DateTime current = Time.WhatTimeIsIt();
            DateTime utc = Time.WhatTimeIsItInUtc();
            Assert.NotEqual(current, utc);
        }

        [Fact]
        public void IsConvertible()
        {
            DateTime current = Time.WhatTimeIsIt();
            String currentString = Time.ToRoundTripFormatString(current);
            Assert.Equal(current, Time.ParseFromRoundTripFormat(currentString));
        }

        [Fact]
        public void ToUTCConversion()
        {
            DateTime time = DateTime.Now;
            DateTime utc = Time.ToUtc(time);
            Assert.Equal(utc , time - TimeSpan.FromHours(3));
        }

        [Fact]
        public void TestHours()
        {
            DateTime dt1 = new DateTime(2010, 3, 5, 12, 0, 0);
            DateTime dt2 = new DateTime(2010, 3, 5, 14, 0, 0);
            Assert.Equal(0, Time.GetHoursBetween(dt1, dt1));
            Assert.Equal(2, Time.GetHoursBetween(dt1, dt2));
        }

        [Fact]
        public void AdventureTimeTest()
        {
            Assert.Equal(180, Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
            Assert.Equal(60, Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
            Assert.Equal(180, Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
            Assert.Equal(120, Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
            Assert.Equal(120, Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
        }

        [Fact]
        public void BirthdayTest()
        {
            DateTime d1 = new DateTime(2015, 1, 1, 0, 0, 0);
            DateTime d2 = new DateTime(2007, 1, 1, 12, 7, 54);
            Assert.True(Time.AreEqualBirthdays(d1, d2));
        }

        [Fact]
        public void AddingMethodsAreEqualTest()
        {
            DateTime now = DateTime.Now;
            Assert.Equal(Time.AddTenSeconds(now), Time.AddTenSecondsV2(now));
        }
    }
}
