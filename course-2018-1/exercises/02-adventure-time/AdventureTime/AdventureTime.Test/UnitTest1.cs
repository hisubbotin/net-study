using System;
using System.Globalization;
using Xunit;

namespace AdventureTime.Test
{
    public class TimeFunctionsTest
    {
        [Fact]
        public void Test_WhatTimeIsIt_Kind()
        {
            Assert.Equal(DateTimeKind.Local, Time.WhatTimeIsIt().Kind);
        }
        
        [Fact]
        public void Test_WhatTimeIsItInUtc_Kind()
        {
            Assert.Equal(DateTimeKind.Utc, Time.WhatTimeIsItInUtc().Kind);
        }
        
        [Theory]
        [InlineData(DateTimeKind.Local)]
        [InlineData(DateTimeKind.Unspecified)]
        [InlineData(DateTimeKind.Utc)]
        public void Test_SpecifyKind(DateTimeKind kind)
        {
            var dt = DateTime.Now;
            Assert.Equal(Time.SpecifyKind(dt, kind).Kind, kind);
        }
        
        [Theory]
        [InlineData(DateTimeKind.Local, "2018-10-14T00:52:01.0000000+03:00")]
        [InlineData(DateTimeKind.Unspecified, "2018-10-14T00:52:01.0000000")]
        [InlineData(DateTimeKind.Utc, "2018-10-14T00:52:01.0000000Z")]
        public void Test_ToRoundTripFormatString(DateTimeKind kind, string dtStr)
        {
            var dt = new DateTime(2018, 10, 14, 0, 52, 01);
            Assert.Equal(Time.SpecifyKind(dt, kind).ToString("O"), dtStr);
        }
        
        [Theory]
        [InlineData(DateTimeKind.Local)]
        [InlineData(DateTimeKind.Unspecified)]
        [InlineData(DateTimeKind.Utc)]
        public void Test_ParseFromRoundTripFormat(DateTimeKind kind)
        {
            var dt = DateTime.Now;
            Assert.Equal(DateTime.Parse(Time.SpecifyKind(dt, kind).ToString("O"), null, DateTimeStyles.RoundtripKind), dt);
        }
        
        [Fact]
        public void Test_AddTenSeconds_V1_V2()
        {
            var dt = DateTime.Now;
            Assert.Equal(Time.AddTenSeconds(dt), Time.AddTenSecondsV2(dt));
        }
        
        [Fact]
        public void Test_GetHoursBetween()
        {
            var dt1 = new DateTime(2018, 10, 14, 1, 52, 01, DateTimeKind.Utc);
            var dt2 = new DateTime(2018, 10, 14, 6, 52, 01, DateTimeKind.Utc);
            Assert.Equal(Time.GetHoursBetween(dt1, dt2), 6 - 1);
        }
    }

    public class AdventureTimeSagaTest
    {
        [Fact]
        public void Test_ver0_Dumb()
        {
            Assert.Equal(180, Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
        }
        
        [Fact]
        public void Test_Swap_ver0_Dumb()
        {
            Assert.Equal(300, Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb());
        }
        
        [Fact]
        public void Test_ver1_FeelsSmarter()
        {
            Assert.Equal(180, Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter());
        }
        
        [Fact]
        public void Test_ver2_FeelsLikeRocketScience()
        {
            Assert.Equal(120, Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
        }
        
        [Fact]
        public void Test_Swap_ver2_FeelsLikeRocketScience()
        {
            Assert.Equal(120, Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
        }
        
        [Fact]
        public void Test_ver_2_3()
        {
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime(), Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience());
        }        
    }

    public class EqualBirthdays
    {
        [Fact]
        public void Test_ver_1_Same_Day()
        {
            DateTime d1 = new DateTime(2018, 10, 14, 1, 0, 0);
            DateTime d2 = new DateTime(2018, 10, 13, 23, 0, 0);
            Assert.False(Time.AreEqualBirthdays_ver1(d1, d2));
        }
        
        [Fact]
        public void Test_ver_2_Same_Interval()
        {
            DateTime d1 = new DateTime(2018, 10, 14, 1, 0, 0);
            DateTime d2 = new DateTime(2018, 10, 13, 23, 0, 0);
            Assert.True(Time.AreEqualBirthdays_ver2(d1, d2));
        }
    }
}