using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureTime.Tests
{
    public class TimeTests
    {
        [Fact]
        public static void Test_WhatTimeIsIt()
        {
            Assert.Equal(DateTimeKind.Local, Time.WhatTimeIsIt().Kind);
        }

        [Fact]
        public static void Test_WhatTimeIsItInUtc()
        {
            Assert.Equal(DateTimeKind.Utc, Time.WhatTimeIsItInUtc().Kind);
        }

        [Theory]
        [InlineData(DateTimeKind.Utc)]
        [InlineData(DateTimeKind.Local)]
        [InlineData(DateTimeKind.Unspecified)]
        public static void Test_SpecifyKind(DateTimeKind kind)
        {
            DateTime dt = new DateTime(2010, 3, 28, 1, 15, 0);
            Assert.Equal(kind, Time.SpecifyKind(dt, kind).Kind);
        }

        public static IEnumerable<object[]> DateTimeData()
        {
            yield return new object[] { new DateTime(2010, 3, 28, 1, 15, 0) };
            yield return new object[] { new DateTime(2010, 3, 28, 3, 15, 0) };
        }

        [Theory]
        [MemberData(nameof(DateTimeData))]
        public void Test_RoundTrip(DateTime dt)
        {
            Assert.Equal(dt, Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(dt)));
        }

        public static IEnumerable<object[]> GetHoursBetweenData()
        {
            yield return new object[]
            {
                new DateTime(2010, 3, 28, 1, 15, 0),
                new DateTime(2010, 3, 28, 1, 15, 0),
                0
            };
            yield return new object[]
            {
                new DateTime(2010, 3, 28, 3, 15, 0),
                new DateTime(2010, 3, 28, 1, 15, 0),
                -2
            };
            yield return new object[]
            {
                new DateTime(2010, 3, 28, 3, 15, 0, DateTimeKind.Local),
                new DateTime(2010, 3, 28, 1, 15, 0, DateTimeKind.Utc),
                -2
            };
            yield return new object[]
            {
                new DateTime(2010, 3, 28, 3, 15, 0, DateTimeKind.Unspecified),
                new DateTime(2010, 3, 28, 1, 15, 0, DateTimeKind.Utc),
                -2
            };
        }

        [Theory]
        [MemberData(nameof(GetHoursBetweenData))]
        public static void Test_GetHoursBetween(DateTime dt1, DateTime dt2, int result)
        {
            Assert.Equal(result, Time.GetHoursBetween(dt1, dt2));
        }

        public static IEnumerable<object[]> GetTotalMinutesInThreeMonthsData()
        {
            yield return new object[]
            {
                new DateTime(2016, 1, 1), (31+29+31)*24*60
            };
            yield return new object[]
            {
                new DateTime(2016, 7, 12), (31*2+30*1)*24*60
            };
        }

        [Theory]
        [MemberData(nameof(GetTotalMinutesInThreeMonthsData))]
        public static void Test_GetTotalMinutesInThreeMonths(DateTime dt, int minutes)
        {
            Assert.Equal(minutes, Time.GetTotalMinutesInThreeMonths(dt));
        }

        [Fact]
        public void Test_GetAdventureTimeDurationInMinutes_ver0_Dumb()
        {
            Assert.Equal(180, Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
        }

        [Fact]
        public void Test_GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb()
        {
            Assert.Equal(60, Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
        }

        [Fact]
        public void Test_GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter()
        {
            Assert.Equal(180, Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
        }

        [Fact]
        public void Test_GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
        {
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime(),
                         Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
        }

        [Fact]
        public void Test_GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience()
        {
            Assert.Equal(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver3_NodaTime(),
                Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
        }

        public static IEnumerable<object[]> GetBirthdayData()
        {
            yield return new object[]
            {
                new DateTime(2010, 3, 28),
                new DateTime(2010, 3, 29),
                false
            };
            yield return new object[]
            {
                new DateTime(2010, 3, 28),
                new DateTime(2010, 3, 28),
                true
            };
        }

        [Theory]
        [MemberData(nameof(GetBirthdayData))]
        public static void Test_AreEqualBirthdays(DateTime dt1, DateTime dt2, bool equal)
        {
            Assert.Equal(equal, Time.AreEqualBirthdays(dt1, dt2));
        }
    }
}
