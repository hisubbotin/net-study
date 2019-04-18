using System;
using Xunit;
using AdventureTime.Implementation;

namespace AdventureTime.Tests
{
    public class TimeUnitTests
    {
        [Fact]
        public void Test_RoundTrip1()
        {
            DateTime dt = Time.WhatTimeIsIt();
            string str = Time.ToRoundTripFormatString(dt);
            Assert.Equal(dt, Time.ParseFromRoundTripFormat(str));
        }

        [Fact]
        public void Test_ToUtc() {
            DateTime dt = Time.WhatTimeIsItInUtc();
            var dt_unspec = Time.SpecifyKind(dt, DateTimeKind.Unspecified);
            var dt_local = Time.SpecifyKind(dt, DateTimeKind.Local);
            Assert.NotEqual(
                Time.ToRoundTripFormatString(dt_unspec), 
                Time.ToRoundTripFormatString(dt_local));
            Assert.Equal(Time.ToUtc(dt_local), Time.ToUtc(dt_unspec));
        }

        [Fact]
        public void Test_GetAdventureTimeDurationInMinutes_ver0_Dumb() {
            int journey_time = (int) TimeSpan.FromHours(3).TotalMinutes;
            Assert.Equal(journey_time, Time.GetAdventureTimeDurationInMinutes_ver0_Dumb());
        }

        [Fact]
        public void Test_GetAdventureTimeDurationInMinutes_ver1() {
            int wrong_offset = Time.GetAdventureTimeDurationInMinutes_ver0_Dumb();
            int right_offset = Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter();
            Assert.Equal(wrong_offset, right_offset);
        }

        [Fact]

        public void Test_Like_a_boss_in_rocket_science() {
            int gender_normal_offset = Time. GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience();
            int getnder_swapped_offset = Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience();
            Assert.Equal(gender_normal_offset, getnder_swapped_offset);
        }
    }
}
