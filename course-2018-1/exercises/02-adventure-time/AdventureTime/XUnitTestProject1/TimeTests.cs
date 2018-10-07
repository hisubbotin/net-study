using System;
using Xunit;

namespace AdventureTime.Tests
{
    public class TimeTests
    {
        [Fact]
        public void Test_SpecifyKind()
        {
            DateTime time = new DateTime(2010, 2, 28, 13, 34, 59, DateTimeKind.Utc);
            Assert.Equal(Time.SpecifyKind(time, DateTimeKind.Utc), time);
        }

        [Theory]
        [InlineData(DateTimeKind.Unspecified)]
        [InlineData(DateTimeKind.Utc)]
        [InlineData(DateTimeKind.Local)]
        public void Test_ParseInvariantTime(DateTimeKind kind)
        {
            DateTime time = new DateTime(2010, 2, 28, 13, 34, 59, kind);
            DateTime result = Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(time));
            Assert.Equal(time, result);
        }
        [Theory]
        [InlineData(DateTimeKind.Unspecified)]
        [InlineData(DateTimeKind.Utc)]
        [InlineData(DateTimeKind.Local)]
        public void Test_AddTenSeconds_v1(DateTimeKind kind)
        {
            DateTime time = new DateTime(2010, 2, 28, 13, 34, 59, kind);
            DateTime add10Seconds = new DateTime(2010, 2, 28, 13, 35, 09, kind);
            Assert.Equal(Time.AddTenSeconds(time), add10Seconds);
        }
        [Theory]
        [InlineData(DateTimeKind.Unspecified)]
        [InlineData(DateTimeKind.Utc)]
        [InlineData(DateTimeKind.Local)]
        public void Test_AddTenSeconds_v2(DateTimeKind kind)
        {
            DateTime time = new DateTime(2010, 2, 28, 13, 34, 59, kind);
            DateTime add10Seconds = new DateTime(2010, 2, 28, 13, 35, 09, kind);
            Assert.Equal(Time.AddTenSecondsV2(time), add10Seconds);
        }
        [Theory]
        [InlineData(DateTimeKind.Unspecified)]
        [InlineData(DateTimeKind.Utc)]
        [InlineData(DateTimeKind.Local)]
        public void Test_GetHoursBetween(DateTimeKind kind)
        {
            DateTime time1 = new DateTime(2010, 2, 28, 13, 34, 59, kind);
            DateTime time2 = new DateTime(2010, 3, 1, 3, 0, 09, kind);
            Assert.Equal(Time.GetHoursBetween(time1, time2), 13);
        }
        [Fact]
        public void Test_AdventureTimes()
        {
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb(), 180);
            Assert.Equal(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb(), 60);
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter(), 180);
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience(), 120);
            Assert.Equal(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience(), 120);
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime(), 120);
        }
        [Fact]
        public void Test_AreEqualBirthdays()
        {
            DateTime feb282008 = new DateTime(2008, 2, 28);
            DateTime feb292008 = new DateTime(2008, 2, 29);
            DateTime feb282011 = new DateTime(2011, 2, 28);
            DateTime mar012011 = new DateTime(2011, 3, 1);
            Assert.Equal(Time.AreEqualBirthdays(feb282011, feb282008), true);
            Assert.Equal(Time.AreEqualBirthdays(feb282011, feb292008), false);
            Assert.Equal(Time.AreEqualBirthdays(mar012011, feb292008), false);
        }
    }
}
