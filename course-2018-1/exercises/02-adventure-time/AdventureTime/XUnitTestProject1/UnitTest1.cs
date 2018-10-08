using System;
using Xunit;

namespace Time.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void SpecifyTimeTest()
        {
            DateTime dt1 = DateTime.UtcNow;
            DateTime dt2 = AdventureTime.Time.WhatTimeIsItInUtc();
            
            dt1 = AdventureTime.Time.SpecifyKind(dt1, DateTimeKind.Utc);
            var delta = (dt2 - dt1).TotalSeconds;
            Assert.InRange(delta, -1, 1);
        }

        [Fact]
        public void SpecifyTimeMistakeTest()
        {
            DateTime dt1 = DateTime.UtcNow;
            DateTime dt2 = AdventureTime.Time.WhatTimeIsItInUtc();

            dt1 = AdventureTime.Time.SpecifyKind(dt1, DateTimeKind.Local);
            dt2 = dt2.ToLocalTime();
            var delta = (dt2 - dt1).TotalSeconds;
            Assert.NotInRange(delta, -1, 1);
        }

        [Fact]
        public void RoundTripUTCTest()
        {
            DateTime dt1 = DateTime.UtcNow;
            Assert.Equal(DateTimeKind.Utc, dt1.Kind);
            string str = AdventureTime.Time.ToRoundTripFormatString(dt1);
            DateTime dt2 = AdventureTime.Time.ParseFromRoundTripFormat(str);
            Assert.Equal(dt1, dt2.ToUniversalTime());
        }

        [Fact]
        public void RoundTripLocalTest()
        {
            DateTime dt1 = DateTime.UtcNow.ToLocalTime();
            Assert.Equal(DateTimeKind.Local, dt1.Kind);
            string str = AdventureTime.Time.ToRoundTripFormatString(dt1);
            DateTime dt2 = AdventureTime.Time.ParseFromRoundTripFormat(str);
            Assert.Equal(dt1, dt2);
        }

        [Fact]
        public void ToLondonTripTest()
        {
            int delta = AdventureTime.Time.GetAdventureTimeDurationInMinutes_ver0_Dumb();
            Assert.Equal(180, actual: delta);
        }

        [Fact]
        public void ToMoscowTripTest()
        {
            int delta = AdventureTime.Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb();
            Assert.Equal(60, actual: delta);
        }

        [Fact]
        public void ToLondonTrip2Test()
        {
            int delta = AdventureTime.Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter();
            Assert.Equal(180, actual: delta);
        }

        [Fact]
        public void ToLondonTrip3Test()
        {
            int delta = AdventureTime.Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience();
            Assert.Equal(120, actual: delta);
        }

        [Fact]
        public void ToLondonTrip4Test()
        {
            int delta = AdventureTime.Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime();
            Assert.Equal(120, actual: delta);
        }

        [Fact]
        public void ToMoscowTrip2Test()
        {
            int delta = AdventureTime.Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience();
            Assert.Equal(120, actual: delta);
        }

        [Fact]
        public void HoursBetweenTest()
        {
            DateTime dt = DateTime.UtcNow;
            Assert.Equal(0, actual: AdventureTime.Time.GetHoursBetween(dt, dt));
        }

        [Fact]
        public void HoursBetweenLocalTest()
        {
            DateTime dt = DateTime.UtcNow;
            Assert.Equal(3, actual: AdventureTime.Time.GetHoursBetween(dt.ToLocalTime(), dt));
        }

    }
}
