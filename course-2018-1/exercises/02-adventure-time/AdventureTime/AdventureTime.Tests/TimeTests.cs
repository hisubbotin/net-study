using System;
using Xunit;

namespace AdventureTime.Tests
{
    public class TimeTests
    {
        [Theory]
        [InlineData(DateTimeKind.Local)]
        [InlineData(DateTimeKind.Utc)]
        [InlineData(DateTimeKind.Unspecified)]
        public void Test_RoundTrip(DateTimeKind kind)
        {
            DateTime dt = new DateTime(2018, 06, 01, 00, 00, 00, kind);
            Assert.True(dt.Equals(Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(dt))));
        }

        [Fact]
        public void Test_AddTenSeconds()
        {
            DateTime dt = new DateTime(2018, 06, 01, 00, 00, 00, DateTimeKind.Local);
            DateTime dtFinal = new DateTime(2018, 06, 01, 00, 00, 10, DateTimeKind.Local);
            Assert.True(dtFinal.Equals(Time.AddTenSeconds(dt)));
        }

        [Fact]
        public void Test_AddTenSecondsV2()
        {
            DateTime dt = new DateTime(2018, 06, 01, 00, 00, 00, DateTimeKind.Local);
            DateTime dtFinal = new DateTime(2018, 06, 01, 00, 00, 10, DateTimeKind.Local);
            Assert.True(dtFinal.Equals(Time.AddTenSecondsV2(dt)));
        }

        [Fact]
        public void Test_TimeDurationInMinutes()
        {
            int time1 = Time.GetAdventureTimeDurationInMinutes_ver2_FeelsLikeRocketScience();
            int time2 = Time.GetAdventureTimeDurationInMinutes_ver3_NodaTime();
            Assert.True(time1.Equals(time2));
        }

        [Fact]
        public void Test_AreEqualBirthdays_BothLocal()
        {
            DateTime dt1 = new DateTime(1997, 03, 31, 12, 45, 0, DateTimeKind.Local);
            DateTime dt2 = new DateTime(1957, 03, 31, 01, 37, 15, DateTimeKind.Local);
            Assert.True(Time.AreEqualBirthdays(dt1, dt2));
        }

        [Fact]
        public void Test_AreEqualBirthdays_UtcAndLocal()
        {
            DateTime dt1 = new DateTime(1997, 03, 31, 0, 15, 0, DateTimeKind.Utc);
            DateTime dt2 = new DateTime(1956, 03, 31, 01, 15, 15, DateTimeKind.Local);
            Assert.True(Time.AreEqualBirthdays(dt1, dt2));
        }

        [Fact]
        public void Test_AreEqualBirthdays_FalseResult()
        {
            DateTime dt1 = new DateTime(1997, 03, 30, 23, 15, 0, DateTimeKind.Local);
            DateTime dt2 = new DateTime(1956, 03, 31, 01, 15, 15, DateTimeKind.Local);
            Assert.False(Time.AreEqualBirthdays(dt1, dt2));
        }

        [Fact]
        public void Test_AreEqualBirthdays_FalseResultWithUtcAndLocal()
        {
            DateTime dt1 = new DateTime(1997, 03, 30, 23, 15, 0, DateTimeKind.Utc);
            DateTime dt2 = new DateTime(1956, 03, 31, 01, 15, 15, DateTimeKind.Local);
            Assert.False(Time.AreEqualBirthdays(dt1, dt2));
        }
    }
}
