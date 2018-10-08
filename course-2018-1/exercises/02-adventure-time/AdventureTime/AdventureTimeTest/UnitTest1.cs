using System;
using AdventureTime;
using Xunit;

namespace AdventureTimeTest
{
    public class TestPart1
    {
        [Theory]
        [InlineData(DateTimeKind.Utc)]
        [InlineData(DateTimeKind.Local)]
        public void TestSpecifyKind(DateTimeKind kind)
        {
            var dateTime = new DateTime(2011, 3, 21, 12, 24, 49, kind);
            Assert.Equal(Time.SpecifyKind(dateTime, kind), dateTime);
        }
        
        [Theory]
        [InlineData(DateTimeKind.Utc)]
        [InlineData(DateTimeKind.Local)]
        public void TestParseTripFormat(DateTimeKind kind)
        {
            var dateTime = new DateTime(2011, 3, 21, 12, 24, 49, kind);
            Assert.Equal(dateTime, Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(dateTime)));
        }
        
        [Theory]
        [InlineData(DateTimeKind.Utc)]
        [InlineData(DateTimeKind.Local)]
        public void TestAddTenSeconds(DateTimeKind kind)
        {
            var time1 = new DateTime(2011, 3, 21, 12, 24, 49, kind);
            var time2 = new DateTime(2011, 3, 21, 12, 24, 59, kind);
            Assert.Equal(Time.AddTenSeconds(time1), time2);
        }
        
        [Theory]
        [InlineData(DateTimeKind.Utc)]
        [InlineData(DateTimeKind.Local)]
        public void TestAddTenSecondsV2(DateTimeKind kind)
        {
            var time1 = new DateTime(2011, 3, 21, 12, 24, 49, kind);
            var time2 = new DateTime(2011, 3, 21, 12, 24, 59, kind);
            Assert.Equal(Time.AddTenSecondsV2(time1), time2);
        }

        [Theory]
        [InlineData(DateTimeKind.Utc)]
        [InlineData(DateTimeKind.Local)]
        public void TestGetHoursBetween(DateTimeKind kind)
        {
            var time1 = new DateTime(2011, 3, 21, 2, 24, 49, kind);
            var time2 = new DateTime(2011, 3, 21, 12, 24, 59, kind);
            Assert.Equal(Time.GetHoursBetween(time1, time2), 10);
        }
        
        [Theory]
        [InlineData(DateTimeKind.Utc)]
        [InlineData(DateTimeKind.Local)]
        public void TestGetTotalMinutesInThreeMonths(DateTimeKind kind)
        {
            Assert.Equal(Time.GetTotalMinutesInThreeMonths(), 129600);
        }
    }

    public class TestPart2
    {
        [Fact]
        public void TestSaga()
        {
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver0_Dumb(), 180);
            Assert.Equal(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver0_Dumb(), 60);
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver1_FeelsSmarter(), 60);
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience(), 120);
            Assert.Equal(Time.GetGenderSwappedAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience(), 120);
            Assert.Equal(Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime(), 120);
        }
    }

    public class TestPart3
    {
        [Fact]
        public void TestAreEqualBirthdays()
        {
            Assert.Equal(Time.AreEqualBirthdays(new DateTime(2018, 3, 28), new DateTime(2017, 3, 28)), true);
            Assert.Equal(Time.AreEqualBirthdays(new DateTime(2018, 3, 28), new DateTime(2018, 3, 27)), false);
        }
    }
}