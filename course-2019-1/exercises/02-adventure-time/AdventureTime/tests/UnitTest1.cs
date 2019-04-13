using System;
using Xunit;
using AdventureTime;

namespace tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(DateTimeKind.Local)]
        [InlineData(DateTimeKind.Utc)]
        [InlineData(DateTimeKind.Unspecified)]
        public void TestParseAndToString(DateTimeKind kind)
        {
            var d = Time.SpecifyKind(Time.WhatTimeIsItInUtc(), kind);
            var s = Time.ToRoundTripFormatString(d);
            var dd = Time.ParseFromRoundTripFormat(s);
            Assert.True(d.Equals(dd));
        }

        [Fact]
        public void TestToUtc()
        {
            var d = Time.WhatTimeIsIt();
            var d1 = Time.WhatTimeIsItInUtc();
            var du = Time.ToUtc(d);
            Assert.True(du.Hour.Equals(du.Hour));
        }

        [Fact]
        public void TestAddSeconds()
        {
            var d = Time.WhatTimeIsIt();
            var dp = Time.AddTenSeconds(d);
            var dp2 = Time.AddTenSecondsV2(d);
            Assert.True(dp.Equals(dp2));
        }

        [Fact]
        public void TestHoursBetween()
        {
            var d = Time.WhatTimeIsIt();
            var d2 = Time.WhatTimeIsIt();
            Assert.True(Time.GetHoursBetween(d, d2).Equals(0));
        }

        [Fact]
        public void TestMinutesInThreeMonth()
        {
            try
            {
                Time.GetTotalMinutesInThreeMonths();
                Assert.False(true);
            }
            catch(Exception e)
            {
                Assert.True(e.Message.Equals("Not complete task"));
            }   
        }
        [Fact]
        public void TestAdTime1()
        {
            var d1 = Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience();
            var d2 = Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience();
            Assert.True(d1.Equals(d2));
        }
    }
}
