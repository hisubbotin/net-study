using System;
using Xunit;

namespace AdventureTime.Tests
{
    public class FirstPartTests
    {
        [Fact]
        public void Test_RoundTripConvert()
        {
            var dtLocal = new DateTime(2018, 1, 1, 0, 0, 0, DateTimeKind.Local);
            var dtUnspecified = new DateTime(2018, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
            var dtUtc = new DateTime(2018, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            Assert.Equal(dtUnspecified, Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(dtUnspecified)));
            Assert.Equal(dtLocal, Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(dtLocal)));
            Assert.Equal(dtUtc, Time.ParseFromRoundTripFormat(Time.ToRoundTripFormatString(dtUtc)));
        }

        [Fact]
        public void Test_AddTenSeconds()
        {
            var dt = new DateTime(2018, 1, 1, 0, 0, 0);
            Assert.Equal(Time.AddTenSeconds(dt), Time.AddTenSecondsV2(dt));
        }

        [Fact]
        public void Test_GetHoursBetween()
        {
            var dt1 = new DateTime(2018, 1, 1, 5, 0, 0);
            var dt2 = new DateTime(2018, 1, 1, 0, 0, 0);
            Assert.Equal(5, Time.GetHoursBetween(dt2, dt1));

            var dtLocal = new DateTime(2018, 1, 1, 5, 0, 0, DateTimeKind.Local);
            var dtUtc = new DateTime(2018, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            Assert.Equal(5, Time.GetHoursBetween(dtUtc, dtLocal));
        }

        [Fact]
        public void Test_MinutesInThreeMonths()
        {
            Assert.Equal(Time.GetTotalMinutesInThreeMonths(), 90 * 24 * 60);
        }

        [Fact]
        public void Test_Birthday_Equals()
        {
            Assert.True(Time.AreEqualBirthdays(
                new DateTime(2018, 1, 1, 0, 0, 0),
                new DateTime(2018, 1, 1, 0, 0, 5)));

            Assert.True(Time.AreEqualBirthdays(
                new DateTime(2018, 1, 1, 4, 0, 0, DateTimeKind.Local),
                new DateTime(2018, 1, 1, 0, 0, 5, DateTimeKind.Utc)));
        }

        [Fact]
        public void Test_Birthday_NotEquals()
        {
            Assert.False(Time.AreEqualBirthdays(
                new DateTime(2018, 1, 1, 0, 0, 0),
                new DateTime(2018, 2, 1, 0, 0, 5)));

            Assert.False(Time.AreEqualBirthdays(
                new DateTime(2018, 1, 2, 3, 0, 0, DateTimeKind.Local),
                new DateTime(2018, 1, 1, 0, 0, 5, DateTimeKind.Utc)));
        }
    }

}
